//-----------------------------------------------------------------------
// <copyright file="OracleDataLogProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;
using System.Reflection;
using System.Windows.Media;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// The Oracle Database Data Logic Provider
    /// </summary>
    [DependencyInjectionTransient]
    internal class OracleDataLogicProvider : DataLogicProvider, IDataLogicProvider
    {
        public OracleDataLogicProvider
        (
            ICore core
        ) :
            base
            (
                core,
                DataProviders.OracleClient,
                "Oracle.ManagedDataAccess, Version=23.1.0.0, Culture=neutral, PublicKeyToken=89b483f429c47342",
                "Oracle.ManagedDataAccess.Client.OracleClientFactory"
            )
        {
            //foreach (String factoryName in DataProviders.OracleClient)
            //{
            //    Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
            //    if (!alreadyExists)
            //    {
            //        String assemblyName = "Oracle.ManagedDataAccess, Version=23.1.0.0, Culture=neutral, PublicKeyToken=89b483f429c47342";
            //        String typeName = "Oracle.ManagedDataAccess.Client.OracleClientFactory";

            //        SetupFactory(factoryName, assemblyName, typeName);
            //}
        }

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public override String DatabaseParameterPrefix => ":";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public override String IdentityOfLastInsertFunction => "(SELECT {0}_SEQ.CURRVAL FROM DUAL)";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public override String IdentityOfNewRowSql => "SELECT Timestamp, (SELECT {0}_SEQ.CURRVAL FROM DUAL) FROM {0} WHERE Id = " + IdentityOfLastInsertFunction;

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public override String TimestampOfUpdatedRowSql => "SELECT Timestamp FROM {0} WHERE Id = @id";

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public override String CurrentDateTimeFunction => "SYSDATE";

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public override String UniqueIdFunction => "SYS_GUID()";

        /// <inheritdoc cref="IDataLogicProvider.MapDbTypeToDotNetType" />
        public override Type MapDbTypeToDotNetType(String dbType)
        {
            Type retVal;

            switch (dbType.ToLower())
            {
                case "bit": retVal = typeof(Boolean); break;
                case "datetime": retVal = typeof(DateTime); break;
                case "int": retVal = typeof(Int32); break;
                case "decimal": retVal = typeof(Decimal); break;
                case "nchar": retVal = typeof(String); break;
                case "nvarchar": retVal = typeof(String); break;
                case "time": retVal = typeof(TimeSpan); break;
                case "timestamp": retVal = typeof(Byte[]); break;
                case "tinyint": retVal = typeof(Int32); break;
                case "varbinary": retVal = typeof(Byte[]); break;
                default:
                    String errorMessage = $"Oracle database type of '{dbType}' has not been mapped to a .Net type";
                    throw new ArgumentException(errorMessage);
            }

            return retVal;
        }

        /// <inheritdoc cref="IDataLogicProvider.GetRowVersionValue" />
        public override Object GetRowVersionValue()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IDataLogicProvider.GetDateComparisonSql(String, String, String)" />
        public override String GetDateComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"({columnOrParameter1} - {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }

        /// <inheritdoc cref="IDataLogicProvider.GetMinuteComparisonSql(String, String, String)" />
        public override String GetMinuteComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"({columnOrParameter1} - {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }
    }
}
