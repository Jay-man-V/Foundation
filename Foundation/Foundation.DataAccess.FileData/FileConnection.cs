//-----------------------------------------------------------------------
// <copyright file="FileConnection.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileConnection : DbConnection
    {
        private ConnectionState _state;

        internal FileConnection()
        {
            _state = ConnectionState.Closed;
        }

        [AllowNull]
        public override String ConnectionString { get; set; } = String.Empty;

        public override String Database { get; } = String.Empty;

        public override ConnectionState State => _state;

        public override String DataSource { get; } = String.Empty;

        public override String ServerVersion { get; } = String.Empty;

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

        protected override DbCommand CreateDbCommand()
        {
            return new FileCommand();
        }
    }
}
