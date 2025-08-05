//-----------------------------------------------------------------------
// <copyright file="IHashingService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Cryptography;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Hashing Service
    /// </summary>
    public interface IHashingService
    {
        /// <summary>
        /// Uses the <see cref="RandomNumberGenerator"/> to create a Cryptographically secure random salt
        /// </summary>
        /// <param name="saltSize">Size of the salt to generate</param>
        /// <returns></returns>
        Byte[] GenerateSalt(Int32 saltSize = 1024);

        /// <summary>
        /// Generates a hash of the supplied <paramref name="input"/>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        String GenerateHash(String input, Byte[] salt);

        /// <summary>
        /// Generates a hash of the supplied <paramref name="input"/>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        Byte[] GenerateHash(Byte[] input, Byte[] salt);
    }
}
