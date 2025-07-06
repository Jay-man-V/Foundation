//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionStrategyAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Strategy classes are registered as instance classes by the IoC container
    /// <para>
    /// Strategy classes are used for multiple resolutions - one interface implemented by many classes
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionStrategyAttribute : Attribute
    {
    }
}
