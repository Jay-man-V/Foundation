//-----------------------------------------------------------------------
// <copyright file="FileFactory.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileClientFactory : DbProviderFactory
    {
        /// <summary>Gets an instance of the <see cref="T:learning.UnitTestDataFactory" />. This can be used to retrieve strongly typed data objects.</summary>
        public static readonly FileClientFactory Instance = new FileClientFactory();

        private FileClientFactory() { }

        /// <summary>
        /// Returns a strongly typed <see cref="T:System.Data.Common.DbConnection" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:System.Data.Common.DbConnection" />.
        /// </returns>
        public override DbConnection CreateConnection()
        {
            return new FileConnection();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:System.Data.Common.DbCommand" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:System.Data.Common.DbCommand" />.
        /// </returns>
        public override DbCommand CreateCommand()
        {
            return new FileCommand();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:System.Data.Common.DbDataAdapter" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:System.Data.Common.DbDataAdapter" />.
        /// </returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new FileAdapter();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:System.Data.Common.DbParameter" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:System.Data.Common.DbParameter" />.
        /// </returns>
        public override DbParameter CreateParameter()
        {
            return new FileParameter();
        }

    }
}
