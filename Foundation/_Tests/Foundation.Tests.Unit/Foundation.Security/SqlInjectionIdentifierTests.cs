//-----------------------------------------------------------------------
// <copyright file="SqlInjectionIdentifierTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Security;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Security
{
    /// <summary>
    /// Summary description for Sql Injection Identifier Tests
    /// </summary>
    [TestFixture]
    public class SqlInjectionIdentifierTests : UnitTestBase
    {
        private ISqlInjectionIdentifier? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new SqlInjectionIdentifier();
        }

        [TestCase(true, "String.Empty", "String.Empty")]
        public void Test_CheckIsWorkingDayOrGetNextWorkingDay(Boolean expected, String inputString, String comment)
        {
            Boolean actual = TheService!.CheckInput(inputString);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }
    }
}
