//-----------------------------------------------------------------------
// <copyright file="DataLogicProvider.cs" company="JDV Software Ltd">
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
    /// The Database Data Logic Provider base class
    /// </summary>
    internal abstract class DataLogicProvider : IDataLogicProvider
    {
        internal DataLogicProvider
        (
            ICore core,
            String[] databaseProviders
        )
        {
            Core = core;
            DatabaseProviders = databaseProviders;
            DatabaseProviderName = databaseProviders[0];
        }

        internal DataLogicProvider
        (
            ICore core,
            String[] databaseProviders,
            String assemblyName,
            String typeName
        ) :
            this
            (
                core,
                databaseProviders
            )
        {
            foreach (String factoryName in DatabaseProviders)
            {
                Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
                if (!alreadyExists)
                {
                    SetupFactory(factoryName, assemblyName, typeName);
                }
            }
        }

        protected ICore Core { get; }
        protected String[] DatabaseProviders { get; }

        protected void SetupFactory(String factoryName, String assemblyName, String typeName)
        {
            Type factoryClass = (Type)Core.IoC.Get(assemblyName, typeName, true);

            FieldInfo[] fieldInfos = factoryClass.GetFields(BindingFlags.Static | BindingFlags.Public);
            FieldInfo? fi = fieldInfos.FirstOrDefault(f => f.Name == "Instance");
            if (fi != null &&
                fi.GetValue(factoryClass) is DbProviderFactory factoryInstance)
            {
                DbProviderFactories.RegisterFactory(factoryName, factoryInstance);
            }
        }

        /// <inheritdoc cref="IDataLogicProvider.DatabaseProviderName" />
        public String DatabaseProviderName { get; set; }

        /// <inheritdoc cref="IDataLogicProvider.ValidToDateString" />
        public String ValidToDateString => ApplicationDefaultValues.DefaultValidToDateTime.ToString(Formats.DotNet.DateTimeMilliseconds);

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public abstract String DatabaseParameterPrefix { get; }

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public abstract String IdentityOfLastInsertFunction { get; }

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public abstract String IdentityOfNewRowSql { get; }

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public abstract String TimestampOfUpdatedRowSql { get; }

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public abstract String CurrentDateTimeFunction { get; }

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public abstract String UniqueIdFunction { get; }

        /// <inheritdoc cref="IDataLogicProvider.MapDbTypeToDotNetType" />
        public abstract Type MapDbTypeToDotNetType(String dbType);

        /// <inheritdoc cref="IDataLogicProvider.GetRowVersionValue" />
        public abstract Object GetRowVersionValue();

        /// <inheritdoc cref="IDataLogicProvider.GetDateComparisonSql(String, String, String)" />
        public abstract String GetDateComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult);

        /// <inheritdoc cref="IDataLogicProvider.GetMinuteComparisonSql(String, String, String)" />
        public abstract String GetMinuteComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult);
    }
}
