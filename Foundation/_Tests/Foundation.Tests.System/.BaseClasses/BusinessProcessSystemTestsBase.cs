//-----------------------------------------------------------------------
// <copyright file="BusinessProcessSystemTestsBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.System.BaseClasses
{
    /// <summary>
    /// The Business Process System Tests Base class
    /// </summary>
    [TestFixture]
    public abstract class BusinessProcessSystemTestsBase : SystemTestBase
    {
        public override void TestInitialise()
        {
            base.TestInitialise();

        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }
    }
}
