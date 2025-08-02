//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionClasses.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Support
{
    [DependencyInjectionScoped]
    public class StandardClass : IStandardClass
    {
        private Int32 Count { get; set; }

        public String OperationGuid => $"{GetType()}{Guid.NewGuid()}";
        public String OperationName => $"{GetType()}";

        public Int32 CountAndGet()
        {
            Count++;

            return Count;
        }
    }

    public abstract class DefaultOperation : IDefaultOperation
    {
        protected Int32 Count { get; set; }

        public String OperationGuid => $"{GetType()}{Guid.NewGuid()}";
        public String OperationName => $"{GetType()}";

        public Int32 CountAndGet()
        {
            Count++;

            return Count;
        }
    }

    [DependencyInjectionTransient]
    public class TransientOperation : DefaultOperation, ITransientOperation
    {
    }

    [DependencyInjectionTransient]
    public class TypeWithGenerics<TValue> : ITypeWithGenerics<TValue>
    {
        public TValue Value { get; set; }
    }

    [DependencyInjectionTransient]
    public class MultipleInstance1 : IMultipleInstances
    {
        public String GetOperationType() { return GetType().ToString(); }
    }

    [DependencyInjectionTransient]
    public class MultipleInstance2 : IMultipleInstances
    {
        public String GetOperationType() { return GetType().ToString(); }
    }

    //[DependencyInjectionTransient]
    //public class TransientOperationWithParameters : DefaultOperation, ITransientOperationWithParameters
    //{
    //    public TransientOperationWithParameters(Int32 initialCount)
    //    {
    //        Count = initialCount;
    //    }
    //}
}