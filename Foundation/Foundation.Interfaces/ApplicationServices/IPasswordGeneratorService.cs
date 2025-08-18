//-----------------------------------------------------------------------
// <copyright file="IPasswordGeneratorService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Id Service
    /// </summary>
    public interface IPasswordGeneratorService
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

        /// <summary>
        /// Generates a random password using a cryptographically secure random number generator, returned password will only use the characters defined by <paramref name="validCharacters"/>
        /// </summary>
        /// <param name="length"></param>
        /// <param name="validCharacters"></param>
        /// <returns></returns>
        String RandomCharacterPassword(Int32 length, String validCharacters);
    }
}
