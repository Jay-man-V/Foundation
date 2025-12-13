//-----------------------------------------------------------------------
// <copyright file="FileTransaction.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileTransaction : DbTransaction
    {
        internal FileTransaction(FileConnection dbConnection)
        {
            DbConnection = dbConnection;
        }
        protected override DbConnection DbConnection { get; }
        public override IsolationLevel IsolationLevel { get; }

        public override void Commit()
        {
            throw new NotImplementedException();
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
