//-----------------------------------------------------------------------
// <copyright file="IInjectionIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Injection Identifier
    /// </summary>
    public interface IInjectionIdentifier
    {
        /// <summary>
        /// Checks the input for any Injection problem patterns
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Boolean CheckInput(String input);
    }
}
