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
        internal FileConnection()
        {
            _state = ConnectionState.Closed;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return new FileTransaction(this);
        }

        public override void Close()
        {
            _state = ConnectionState.Closed;
        }

        public override void ChangeDatabase(String databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            _state = ConnectionState.Open;
        }

        public override String ConnectionString { get; set; }
        public override String Database { get; }

        private ConnectionState _state;
        public override ConnectionState State => _state;
        public override String DataSource { get; }
        public override String ServerVersion { get; }

        protected override DbCommand CreateDbCommand()
        {
            return (DbCommand)new FileCommand();
        }
    }
}
