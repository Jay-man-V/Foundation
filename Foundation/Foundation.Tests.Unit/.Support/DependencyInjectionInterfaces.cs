//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionInterfaces.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Support
{
    public interface IStandardClass
    {
        String OperationGuid { get; }
        String OperationName { get; }
        Int32 CountAndGet();
    }

    public interface IDefaultOperation
    {
        String OperationGuid { get; }
        String OperationName { get; }
        Int32 CountAndGet();
    }

    public interface ITransientOperation : IDefaultOperation
    {
    }

    public interface ITypeWithGenerics<TValue>
    {
        TValue Value { get; set; }
    }

    public interface IMultipleInstances
    {
        String GetOperationType();
    }

    //public interface ITransientOperationWithParameters : IDefaultOperation
    //{
    //}
}
