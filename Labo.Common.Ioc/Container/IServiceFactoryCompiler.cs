// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceFactoryCompiler.cs" company="Labo">
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
//   Defines the IServiceFactoryCompiler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Common.Ioc.Container
{
    using System.Collections.Generic;
    using System.Reflection.Emit;

    /// <summary>
    /// Service factory compiler interface.
    /// </summary>
    internal interface IServiceFactoryCompiler
    {
        /// <summary>
        /// Creates the service factory invoker.
        /// </summary>
        /// <returns>The service factory invoker.</returns>
        IServiceFactoryInvoker CreateServiceFactoryInvoker();

        /// <summary>
        /// Emits the service factory creator method.
        /// </summary>
        /// <param name="generator">The utility generator.</param>
        void EmitServiceFactoryCreatorMethod(ILGenerator generator);

        /// <summary>
        /// Compiles the service factory.
        /// </summary>
        void CompileServiceFactory();

        /// <summary>
        /// Gets the parent service factories.
        /// </summary>
        /// <value>
        /// The parents.
        /// </value>
        IList<IServiceFactory> ParentFactories { get; }

        /// <summary>
        /// Invalidates the service factory compiler.
        /// </summary>
        void Invalidate();
    }
}