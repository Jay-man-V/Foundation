//-----------------------------------------------------------------------
// <copyright file="ISqlInjectionIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Sql Injection Identifier
    /// </summary>
    public interface ISqlInjectionIdentifier
    {
        /// <summary>
        /// Checks the input for SQL Injection patterns
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Boolean CheckInput(String input);
    }
}
