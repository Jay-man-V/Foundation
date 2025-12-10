//-----------------------------------------------------------------------
// <copyright file="FileParameter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileParameter : DbParameter
    {
        public override DbType DbType { get; set; }
        public override ParameterDirection Direction { get; set; }
        public override Boolean IsNullable { get; set; }

        [AllowNull]
        public override String ParameterName { get; set; }

        [AllowNull]
        public override String SourceColumn { get; set; }
        public override Object? Value { get; set; }
        public override Boolean SourceColumnNullMapping { get; set; }
        public override Int32 Size { get; set; }

        public override void ResetDbType()
        {
            DbType = DbType.Object;
        }
    }
}
