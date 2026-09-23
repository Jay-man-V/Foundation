//-----------------------------------------------------------------------
// <copyright file="IBulkDataLoadSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IBulkDataLoadSettings behaviours
    /// </summary>
    public interface IBulkDataLoadSettings
    {
        String SourceFilePath { get; set; }
        List<IDbDataParameter> DataLoadParameters { get; }

        String ProcedureName { get; set; }
        String ProcedureParameterName { get; set; }
        String ProcedureCustomTypeName { get; set; }
    }
}
