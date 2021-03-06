﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRegistrationManager.cs" company="Labo">
//   The MIT License (MIT)
//   
//   Copyright (c) 2013 Bora Akgun
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of
//   this software and associated documentation files (the "Software"), to deal in
//   the Software without restriction, including without limitation the rights to
//   use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//   the Software, and to permit persons to whom the Software is furnished to do so,
//   subject to the following conditions:
//   
//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//   FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Defines the ServiceRegistrationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Common.Ioc.Container
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Service registration manager class.
    /// </summary>
    internal sealed class ServiceRegistrationManager : IServiceRegistrationManager
    {
        /// <summary>
        /// The service factory builder
        /// </summary>
        private readonly IServiceFactoryBuilder m_ServiceFactoryBuilder;

        /// <summary>
        /// The service entries
        /// </summary>
        private readonly Dictionary<ServiceKey, ServiceRegistration> m_ServiceEntries;

        /// <summary>
        /// The service entries by service type
        /// </summary>
        private readonly Dictionary<Type, ServiceRegistration> m_ServiceEntriesByServiceType;

        private readonly Dictionary<Type, Func<object>> m_ServiceInvokerCache; 

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRegistrationManager"/> class.
        /// </summary>
        /// <param name="serviceFactoryBuilder">
        /// The service Factory Builder.
        /// </param>
        public ServiceRegistrationManager(IServiceFactoryBuilder serviceFactoryBuilder)
        {
            m_ServiceFactoryBuilder = serviceFactoryBuilder;
            m_ServiceEntries = new Dictionary<ServiceKey, ServiceRegistration>(256);
            m_ServiceEntriesByServiceType = new Dictionary<Type, ServiceRegistration>(128);
            m_ServiceInvokerCache = new Dictionary<Type, Func<object>>(128);
        }

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <param name="serviceType">
        /// Type of the service.
        /// </param>
        /// <param name="implementationType">
        /// Type of the implementation.
        /// </param>
        /// <param name="serviceLifetime">
        /// The service lifetime.
        /// </param>
        /// <param name="serviceName">
        /// Name of the service.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceRegistration"/>.
        /// </returns>
        public ServiceRegistration RegisterService(Type serviceType, Type implementationType, ServiceLifetime serviceLifetime, string serviceName = null)
        {
            // TODO: Make thread-safe
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException("implementationType");
            }

            ServiceRegistration serviceRegistration;

            if (serviceName == null)
            {
                if (m_ServiceEntriesByServiceType.TryGetValue(serviceType, out serviceRegistration))
                {
                    serviceRegistration.ServiceInstanceCreator.Invalidate();
                }

                serviceRegistration = m_ServiceEntriesByServiceType[serviceType] = new ServiceRegistration(serviceType, implementationType, serviceLifetime);
            }
            else
            {
                ServiceKey serviceKey = new ServiceKey(serviceName, serviceType);
                if (m_ServiceEntries.TryGetValue(serviceKey, out serviceRegistration))
                {
                    serviceRegistration.ServiceInstanceCreator.Invalidate();
                }

                serviceRegistration = m_ServiceEntries[serviceKey] = new ServiceRegistration(serviceType, implementationType, serviceLifetime, serviceName);
            }

            SetServiceInstanceCreator(serviceRegistration);

            return serviceRegistration;
        }

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="instanceCreator">
        /// The instance creator.
        /// </param>
        /// <param name="serviceLifetime">
        /// The service lifetime.
        /// </param>
        /// <param name="serviceName">
        /// Name of the service.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceRegistration"/>.
        /// </returns>
        public ServiceRegistration RegisterService(Type serviceType, Func<object> instanceCreator, ServiceLifetime serviceLifetime, string serviceName = null)
        {
            if (instanceCreator == null)
            {
                throw new ArgumentNullException("instanceCreator");
            }

            ServiceRegistration serviceRegistration;

            if (serviceName == null)
            {
                serviceRegistration = m_ServiceEntriesByServiceType[serviceType] = new ServiceRegistration(serviceType, instanceCreator, serviceLifetime);
            }
            else
            {
                serviceRegistration = m_ServiceEntries[new ServiceKey(serviceName, serviceType)] = new ServiceRegistration(serviceType, instanceCreator, serviceLifetime, serviceName);
            }

            SetServiceInstanceCreator(serviceRegistration);

            return serviceRegistration;
        }

        /// <summary>
        /// Gets the service registration.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Service registration class.</returns>
#if net45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public ServiceRegistration GetServiceRegistration(Type serviceType)
        {
            ServiceRegistration serviceRegistration;
            m_ServiceEntriesByServiceType.TryGetValue(serviceType, out serviceRegistration);
            return serviceRegistration;
        }

        /// <summary>
        /// Gets the service invoker.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Service Invoker</returns>
        public Func<object> GetServiceInvoker(Type serviceType)
        {
            Func<object> invoker;
            if (!m_ServiceInvokerCache.TryGetValue(serviceType, out invoker))
            {
                invoker = GetServiceRegistration(serviceType).ServiceInstanceCreator.GetServiceFactory().ServiceInvokerFunc;
                m_ServiceInvokerCache[serviceType] = invoker;
            }

            return invoker;
        }

        /// <summary>
        /// Gets the service registration.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>Service registration class.</returns>
        public ServiceRegistration GetServiceRegistration(Type serviceType, string serviceName)
        {
            ServiceRegistration serviceRegistration;
            m_ServiceEntries.TryGetValue(new ServiceKey(serviceName, serviceType), out serviceRegistration);
            return serviceRegistration;
        }

        /// <summary>
        /// Determines whether [is service registered] [the specified service type].
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>true if the service is registered otherwise false.</returns>
        public bool IsServiceRegistered(Type serviceType, string serviceName)
        {
            return m_ServiceEntries.ContainsKey(new ServiceKey(serviceName, serviceType));
        }

        /// <summary>
        /// Determines whether [is service registered] [the specified service type].
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>true if the service is registered otherwise false.</returns>
        public bool IsServiceRegistered(Type serviceType)
        {
            bool isServiceRegistered = m_ServiceEntriesByServiceType.ContainsKey(serviceType);
            if (!isServiceRegistered)
            {
                Dictionary<ServiceKey, ServiceRegistration>.Enumerator serviceEntriesEnumerator = m_ServiceEntries.GetEnumerator();
                while (serviceEntriesEnumerator.MoveNext())
                {
                    KeyValuePair<ServiceKey, ServiceRegistration> serviceRegistration = serviceEntriesEnumerator.Current;
                    if (serviceRegistration.Key.ServiceType == serviceType)
                    {
                        return true;
                    }
                }
            }

            return isServiceRegistered;
        }

        /// <summary>
        /// Gets all service creators.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>List of service instance creators.</returns>
        public IList<ServiceInstanceCreator> GetAllServiceCreators(Type serviceType)
        {
             if (serviceType == null)
             {
                 throw new ArgumentNullException("serviceType");
             }

             List<ServiceInstanceCreator> instances = new List<ServiceInstanceCreator>();
             Dictionary<ServiceKey, ServiceRegistration>.Enumerator serviceEntriesEnumerator = m_ServiceEntries.GetEnumerator();
             while (serviceEntriesEnumerator.MoveNext())
             {
                 KeyValuePair<ServiceKey, ServiceRegistration> entry = serviceEntriesEnumerator.Current;
                 if (entry.Key.ServiceType == serviceType)
                 {
                     instances.Add(entry.Value.ServiceInstanceCreator);
                 }
             }

             Dictionary<Type, ServiceRegistration>.Enumerator serviceEntriesByKeyEnumerator = m_ServiceEntriesByServiceType.GetEnumerator();
             while (serviceEntriesByKeyEnumerator.MoveNext())
             {
                 KeyValuePair<Type, ServiceRegistration> entry = serviceEntriesByKeyEnumerator.Current;
                 if (entry.Key == serviceType)
                 {
                     instances.Add(entry.Value.ServiceInstanceCreator);
                 }
             }

             return instances;
        }

        /// <summary>
        /// Gets the service creator.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>The service instance creator.</returns>
        public ServiceInstanceCreator GetServiceCreator(Type serviceType)
        {
            return GetServiceRegistration(serviceType).ServiceInstanceCreator;
        }

        /// <summary>
        /// Gets the service creator.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="name">The name.</param>
        /// <returns>The service instance creator.</returns>
        public ServiceInstanceCreator GetServiceCreator(Type serviceType, string name)
        {
            return GetServiceRegistration(serviceType, name).ServiceInstanceCreator;
        }

        /// <summary>
        /// Sets the service instance creator.
        /// </summary>
        /// <param name="serviceRegistration">The service registration.</param>
        private void SetServiceInstanceCreator(ServiceRegistration serviceRegistration)
        {
            serviceRegistration.SetServiceInstanceCreator(new ServiceInstanceCreator(this, m_ServiceFactoryBuilder, serviceRegistration, serviceType => m_ServiceInvokerCache.Remove(serviceType)));
        }
    }
}
