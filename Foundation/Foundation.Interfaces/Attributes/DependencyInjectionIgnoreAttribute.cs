//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionIgnoreAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the Dependency Injection Ignore Attribute for dependency injection
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionIgnoreAttribute : Attribute
    {
    }
}
