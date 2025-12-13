//-----------------------------------------------------------------------
// <copyright file="FileDataReader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Data;
using System.Data.Common;

namespace Foundation.DataAccess.FileData
{
    public sealed class FileDataReader : DbDataReader, IDataReader, IDisposable, IDataRecord
    {
        public override Int32 FieldCount { get; } = 0;
        public override Boolean HasRows { get; } = false;
        public override Boolean IsClosed { get; } = true;
        public override Int32 RecordsAffected { get; } = 0;
        public override Int32 Depth { get; } = 0;

        public override String GetName(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int32 GetValues(Object[] values)
        {
            throw new NotImplementedException();
        }

        public override Boolean IsDBNull(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Object this[Int32 ordinal] => throw new NotImplementedException();

        public override Object this[string name] => throw new NotImplementedException();

        public override Boolean NextResult()
        {
            throw new NotImplementedException();
        }

        public override Boolean Read()
        {
            throw new NotImplementedException();
        }

        public override Int32 GetOrdinal(String name)
        {
            throw new NotImplementedException();
        }

        public override Boolean GetBoolean(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Byte GetByte(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int64 GetBytes(Int32 ordinal, Int64 dataOffset, Byte[] buffer, Int32 bufferOffset, Int32 length)
        {
            throw new NotImplementedException();
        }

        public override Char GetChar(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int64 GetChars(Int32 ordinal, Int64 dataOffset, Char[] buffer, Int32 bufferOffset, Int32 length)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int16 GetInt16(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int32 GetInt32(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Int64 GetInt64(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override String GetString(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Decimal GetDecimal(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Double GetDouble(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Single GetFloat(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override String GetDataTypeName(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Type GetFieldType(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override Object GetValue(Int32 ordinal)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
