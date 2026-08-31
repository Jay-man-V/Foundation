//-----------------------------------------------------------------------
// <copyright file="Utils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

namespace Foundation.DataAccess.MSSql
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utils
    {
        public static SqlDbType MapFromDbType(DbType dbType)
        {
            return dbType switch
            {
                DbType.AnsiString => SqlDbType.VarChar,
                DbType.AnsiStringFixedLength => SqlDbType.VarChar,
                DbType.Binary => SqlDbType.VarBinary,
                DbType.Boolean => SqlDbType.Bit,
                DbType.Byte => SqlDbType.TinyInt,
                DbType.Currency => SqlDbType.Money,
                DbType.Date => SqlDbType.Date,
                DbType.DateTime => SqlDbType.DateTime,
                DbType.DateTime2 => SqlDbType.DateTime2,
                DbType.Int32 => SqlDbType.Int,
                DbType.String => SqlDbType.NVarChar,
                _ => throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null)
            };
        }
    }
}
