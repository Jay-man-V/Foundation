//-----------------------------------------------------------------------
// <copyright file="UnitTestingDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Support
{
    public interface IUnitTestingDatabaseProvider : IDatabaseProvider
    {

    }

    [DependencyInjectionTransient]
    public class UnitTestingDatabaseProvider : IUnitTestingDatabaseProvider
    {
        public String ConnectionName => "UnitTesting";
    }
}
