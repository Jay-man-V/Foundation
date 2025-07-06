//-----------------------------------------------------------------------
// <copyright file="IDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IDatabaseProvider behaviours.
    /// Defines requirements
    /// </summary>
    public interface IDatabaseProvider
    {
        /// <summary>
        /// The name of the connection to be used
        /// </summary>
        String ConnectionName { get; }
    }
}
