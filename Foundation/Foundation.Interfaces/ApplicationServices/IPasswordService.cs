//-----------------------------------------------------------------------
// <copyright file="IPasswordService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Id Service
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Generates a password based on system rules
        /// </summary>
        /// <returns></returns>
        String GeneratePassword();

        /// <summary>
        /// Generates multiple passwords based on system rules
        /// </summary>
        /// <returns></returns>
        String[] GenerateMultiplePasswords();
    }
}
