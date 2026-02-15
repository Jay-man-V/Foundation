//-----------------------------------------------------------------------
// <copyright file="FileParameterCollection.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Data.Common;

namespace Foundation.FileData.Client
{
    public sealed class FileParameterCollection : DbParameterCollection
    {
        public override Int32 Count { get; }
        public override Object SyncRoot { get; }

        public override Int32 Add(Object value)
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override Boolean Contains(Object value)
        {
            throw new NotImplementedException();
        }

        public override Int32 IndexOf(Object value)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Int32 index, Object value)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Object value)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAt(Int32 index)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAt(String parameterName)
        {
            throw new NotImplementedException();
        }

        protected override void SetParameter(Int32 index, DbParameter value)
        {
            throw new NotImplementedException();
        }

        protected override void SetParameter(String parameterName, DbParameter value)
        {
            throw new NotImplementedException();
        }

        public override Int32 IndexOf(String parameterName)
        {
            throw new NotImplementedException();
        }

        public override Boolean Contains(String value)
        {
            throw new NotImplementedException();
        }

        public override void CopyTo(Array array, Int32 index)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        protected override DbParameter GetParameter(Int32 index)
        {
            throw new NotImplementedException();
        }

        protected override DbParameter GetParameter(String parameterName)
        {
            throw new NotImplementedException();
        }

        public override void AddRange(Array values)
        {
            throw new NotImplementedException();
        }
    }
}
