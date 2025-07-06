//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionSingletonAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Singleton classes are registered as instance classes by the IoC container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionSingletonAttribute : Attribute
    {
    }
}
