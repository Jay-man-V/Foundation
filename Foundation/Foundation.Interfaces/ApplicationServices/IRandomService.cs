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
        /// Returns the next (or first) random <see cref="Int32"/> value
        /// </summary>
        /// <returns></returns>
        Int32 RandomInt32();

        /// <summary>
        /// Returns the next (or first) random <see cref="Int32"/> value up to a maximum value set by <paramref name="maxValue"/>
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        Int32 RandomInt32(Int32 maxValue);

        /// <summary>
        /// Returns a random <see cref="Int32"/> between <paramref name="minValue"/> and <paramref name="maxValue"/>
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        Int32 RandomInt32(Int32 minValue, Int32 maxValue);

        /// <summary>
        /// Generates a simple random string. returned string will only use the characters defined by <paramref name="validCharacters"/>.
        /// <para>
        /// This method should not be used for passwords as it is not cryptographically secure. Use <see cref="IPasswordGeneratorService.RandomCharacterPassword"/>
        /// </para>
        /// </summary>
        /// <param name="length"></param>
        /// <param name="validCharacters"></param>
        /// <returns></returns>
        String SimpleRandomString(Int32 length, String validCharacters);
    }
}
