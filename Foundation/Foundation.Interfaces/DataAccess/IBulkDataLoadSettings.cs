//-----------------------------------------------------------------------
// <copyright file="IBulkDataLoadSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IBulkDataLoadSettings behaviours
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IBulkDataLoadSettings
    {
        Stream SourceStream { get; }
        String SourceFilePath { get; }
        String DestinationTable { get; }
        String ProcedureName { get; }
    }
}
