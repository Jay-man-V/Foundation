//-----------------------------------------------------------------------
// <copyright file="CrossSiteScriptingIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Security
{
    /// <summary>
    /// Implementation of the Sql Injection Identifier
    /// </summary>
    public class CrossSiteScriptingIdentifier : ICrossSiteScriptingIdentifier
    {
        /// <inheritdoc cref="ICrossSiteScriptingIdentifier.CheckInput(String)"/>
        public Boolean CheckInput(String input)
        {
            throw new NotImplementedException();
        }
    }
}
