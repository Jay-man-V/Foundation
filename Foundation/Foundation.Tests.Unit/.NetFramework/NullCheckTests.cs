//-----------------------------------------------------------------------
// <copyright file="NullCheckTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// Simple .Net Framework tests
    /// </summary>
    [TestFixture]
    public class NullCheckTests : UnitTestBase
    {
        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_CheckForNull()
        {
            const Object? valueA = null;
            Object valueB = DBNull.Value;

            Assert.That(valueA, Is.Null);
            Assert.That(valueB, Is.Not.Null);
        }
    }
}
