//-----------------------------------------------------------------------
// <copyright file="FileCommand.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileCommand : DbCommand
    {
        public FileCommand()
        {
            CommandText = String.Empty;
            DbParameterCollection = new FileParameterCollection();
        }

        public FileCommand(String commandText) : this()
        {
            CommandText = commandText;
        }

        public FileCommand(String commandText, FileConnection connection) : this()
        {
            CommandText = commandText;
            DbConnection = connection;
        }

        public FileCommand(String commandText, FileConnection connection, FileTransaction transaction) : this()
        {
            CommandText = commandText;
            DbConnection = connection;
            Transaction = transaction;
        }

        [AllowNull]
        public override String CommandText { get; set; }
        public override Int32 CommandTimeout { get; set; }
        public override CommandType CommandType { get; set; }
        public override UpdateRowSource UpdatedRowSource { get; set; }
        protected override DbConnection? DbConnection { get; set; }
        protected override DbParameterCollection DbParameterCollection { get; }
        protected override DbTransaction? DbTransaction { get; set; }
        public override Boolean DesignTimeVisible { get; set; }

        public override void Prepare()
        {
            throw new NotImplementedException();
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        protected override DbParameter CreateDbParameter()
        {
            return new FileParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            throw new NotImplementedException();
        }

        public override int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar()
        {
            throw new NotImplementedException();
        }
    }
}
