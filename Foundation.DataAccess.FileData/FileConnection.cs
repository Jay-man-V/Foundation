//-----------------------------------------------------------------------
// <copyright file="FileConnection.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileConnection : DbConnection
    {
        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return (DbTransaction)new FileTransaction(this);
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public override string ConnectionString { get; set; }
        public override string Database { get; }
        public override ConnectionState State { get; }
        public override string DataSource { get; }
        public override string ServerVersion { get; }

        protected override DbCommand CreateDbCommand()
        {
            return (DbCommand)new FileCommand();
        }
    }
}
