//-----------------------------------------------------------------------
// <copyright file="BulkDataLoadSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Defines the BulkDataLoadSettings class
    /// </summary>
    [DependencyInjectionTransient]
    public class BulkDataLoadSettings : ICloneable, IBulkDataLoadSettings
    {
        public String SourceFilePath { get; set; } = String.Empty;
        public String DestinationTable { get; set; } = String.Empty;
        public String ProcedureName { get; set; } = String.Empty;
        public String ProcedureParameterName { get; set; } = String.Empty;
        public String ProcedureCustomTypeName { get; set; } = String.Empty;
        public List<IDbDataParameter> DataLoadParameters { get; private set; } = [];

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public Object Clone()
        {
            BulkDataLoadSettings retVal = (BulkDataLoadSettings)Activator.CreateInstance(this.GetType())!;

            retVal.SourceFilePath = this.SourceFilePath;
            retVal.DestinationTable = this.DestinationTable;
            retVal.ProcedureName = this.ProcedureName;
            retVal.ProcedureParameterName = this.ProcedureParameterName;
            retVal.ProcedureCustomTypeName = this.ProcedureCustomTypeName;
            retVal.DataLoadParameters = new List<IDbDataParameter>(this.DataLoadParameters);

            return retVal;
        }
    }
}
