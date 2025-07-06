//-----------------------------------------------------------------------
// <copyright file="IApplicationStartup.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The IApplicationStartup interface is for special cases only.
    /// Classes that implement it will be created first.
    /// The implementation should be reserved for Singleton classes that need to be initialised as soon as possible when the application starts
    /// </summary>
    public interface IApplicationStartup
    {
    }
}
