//-----------------------------------------------------------------------
// <copyright file="UnitTestingDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Support
{
    public interface IUnitTestingDataProvider : IDataProvider
    {

    }

    [DependencyInjectionTransient]
    public class UnitTestingDataProvider : IUnitTestingDataProvider
    {
        public String ConnectionName => "UnitTesting";
    }
}
