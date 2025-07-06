//-----------------------------------------------------------------------
// <copyright file="IDatabaseParameters.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines a collection to hold <see cref="IDbDataParameter"/>
    /// </summary>
    public interface IDatabaseParameters : IList<IDbDataParameter>
    {
    }
}
