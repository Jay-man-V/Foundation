//-----------------------------------------------------------------------
// <copyright file="ICrossSiteScriptingIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Cross Site Scripting Identifier
    /// </summary>
    public interface ICrossSiteScriptingIdentifier
    {
        /// <summary>
        /// Checks the input for Cross Site Scripting patterns
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Boolean CheckInput(String input);
    }
}
