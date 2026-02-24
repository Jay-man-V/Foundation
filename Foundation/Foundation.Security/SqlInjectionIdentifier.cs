//-----------------------------------------------------------------------
// <copyright file="LdapInjectionIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Security
{
    /// <summary>
    /// Implementation of the Ldap Injection Identifier
    /// </summary>
    [DependencyInjectionTransient]
    public class LdapInjectionIdentifier : ILdapInjectionIdentifier
    {
        /// <inheritdoc cref="ILdapInjectionIdentifier.CheckInput(String)"/>
        public Boolean CheckInput(String input)
        {
            Boolean retVal = true;

            return retVal;
        }
    }
}
