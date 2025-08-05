//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionTransientAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Transient classes are registered as instance classes by the IoC container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionTransientAttribute : Attribute
    {
    }
}
