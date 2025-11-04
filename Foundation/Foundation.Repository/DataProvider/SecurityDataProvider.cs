//-----------------------------------------------------------------------
// <copyright file="SecurityDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Security Data Provider class
    /// </summary>
    /// <see cref="ISecurityDataProvider" />
    public class SecurityDataProvider : ISecurityDataProvider
    {
        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Security";
    }
}
