//-----------------------------------------------------------------------
// <copyright file="FileFactory.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;

namespace Foundation.FileData.Client
{
    public sealed class FileClientFactory : DbProviderFactory
    {
        /// <summary>Gets an instance of the <see cref="T:FileClientFactory" />. This can be used to retrieve strongly typed data objects.</summary>
        public static readonly FileClientFactory Instance = new FileClientFactory();

        private FileClientFactory() { }

        /// <summary>
        /// Returns a strongly typed <see cref="T:DbConnection" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:DbConnection" />.
        /// </returns>
        public override DbConnection CreateConnection()
        {
            return new FileConnection();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:DbCommand" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:DbCommand" />.
        /// </returns>
        public override DbCommand CreateCommand()
        {
            return new FileCommand();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:DbDataAdapter" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:DbDataAdapter" />.
        /// </returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new FileAdapter();
        }

        /// <summary>
        /// Returns a strongly typed <see cref="T:DbParameter" /> instance.
        /// </summary>
        /// <returns>
        /// A new strongly typed instance of <see cref="T:DbParameter" />.
        /// </returns>
        public override DbParameter CreateParameter()
        {
            return new FileParameter();
        }
    }
}
