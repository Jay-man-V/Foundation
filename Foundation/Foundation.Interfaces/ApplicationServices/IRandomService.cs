//-----------------------------------------------------------------------
// <copyright file="IRandomService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behavior of the Random Service
    /// </summary>
    public interface IRandomService
    {
        /// <summary>
        /// List of English alphabetical upper case characters (A-Z)
        /// </summary>
        String AlphaUpperCaseOnly { get; }

        /// <summary>
        /// List of English alphabetical lower case characters (a-z)
        /// </summary>
        String AlphaLowerCaseOnly { get; }

        /// <summary>
        /// List of numbers (0-9)
        /// </summary>
        String NumericOnly { get; }

        /// <summary>
        /// List of all the non-alphabetic characters (!"£$%^&amp;*() _-+={}[]#:@;'&lt;&gt;?,./|\)
        /// </summary>
        String NonAlphaChars { get; }

        /// <summary>
        /// Combination of <see cref="AlphaUpperCaseOnly"/>, <see cref="AlphaLowerCaseOnly"/>, and <see cref="NumericOnly"/>
        /// </summary>
        String AlphaNumeric { get; }

        /// <summary>
        /// Combination of <see cref="AlphaUpperCaseOnly"/>, <see cref="AlphaLowerCaseOnly"/>, <see cref="NumericOnly"/>, and <see cref="NonAlphaChars"/>
        /// </summary>
        String AllChars { get; }

        /// <summary>
        /// Returns the next (or first) random <see cref="Int32"/> value
        /// </summary>
        /// <returns></returns>
        Int32 NextInt32();

        /// <summary>
        /// Returns the next (or first) random <see cref="Int32"/> value up to a maximum value set by <paramref name="maxValue"/>
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        Int32 NextInt32(Int32 maxValue);

        /// <summary>
        /// Returns a random <see cref="Int32"/> between <paramref name="minValue"/> and <paramref name="maxValue"/>
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        Int32 NextInt32(Int32 minValue, Int32 maxValue);

        /// <summary>
        /// Generates a simple random string. returned string will only use the characters defined by <paramref name="validCharacters"/>.
        /// <para>
        /// This method should not be used for passwords as it is not cryptographically secure. Use <see cref="RandomPassword"/>
        /// </para>
        /// </summary>
        /// <param name="length"></param>
        /// <param name="validCharacters"></param>
        /// <returns></returns>
        String SimpleRandomString(Int32 length, String validCharacters);

        /// <summary>
        /// Generates a random password using a cryptographically secure random number generator, returned password will only use the characters defined by <paramref name="validCharacters"/>
        /// </summary>
        /// <param name="length"></param>
        /// <param name="validCharacters"></param>
        /// <returns></returns>
        String RandomPassword(Int32 length, String validCharacters);
    }
}
