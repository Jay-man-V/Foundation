//-----------------------------------------------------------------------
// <copyright file="FoundationFileDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;

using Foundation.DataAccess.FileData;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// The Oracle Database Data Logic Provider
    /// </summary>
    [DependencyInjectionTransient]
    internal class FoundationFileDataProvider : IDataLogicProvider
    {
        public FoundationFileDataProvider()
        {
            foreach (String factoryName in DataProviders.FoundationFileClient)
            {
                Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
                if (!alreadyExists)
                {
                    DbProviderFactories.RegisterFactory(factoryName, FileClientFactory.Instance);
                }
            }
        }

        /// <inheritdoc cref="IDataLogicProvider.ValidToDateString" />
        public String ValidToDateString => ApplicationDefaultValues.DefaultValidToDateTime.ToString(Formats.DotNet.DateTimeMilliseconds);

        /// <inheritdoc cref="IDataLogicProvider.DatabaseProviderName" />
        public String DatabaseProviderName => DataProviders.FoundationFileClient[0];

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public String DatabaseParameterPrefix => ":";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public String IdentityOfLastInsertFunction => throw new NotImplementedException();

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public String IdentityOfNewRowSql => throw new NotImplementedException();

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public String TimestampOfUpdatedRowSql => throw new NotImplementedException();

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public String CurrentDateTimeFunction => throw new NotImplementedException();

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public String UniqueIdFunction => throw new NotImplementedException();

        /// <inheritdoc cref="IDataLogicProvider.MapDbTypeToDotNetType" />
        public Type MapDbTypeToDotNetType(String dbType)
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
        public Object GetRowVersionValue()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IDataLogicProvider.GetDateComparisonSql(String, String, String)" />
        public String GetDateComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IDataLogicProvider.GetMinuteComparisonSql(String, String, String)" />
        public String GetMinuteComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            throw new NotImplementedException();
        }
    }
}
