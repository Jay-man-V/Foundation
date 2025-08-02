//-----------------------------------------------------------------------
// <copyright file="DatabaseParameters.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Defines the DatabaseParameters collection class
    /// </summary>
    /// <see cref="IDbDataParameter" />
    [DependencyInjectionTransient]
    public class DatabaseParameters : List<IDbDataParameter>, IDatabaseParameters
    {
    }
}
