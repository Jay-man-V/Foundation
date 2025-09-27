//-----------------------------------------------------------------------
// <copyright file="StringBuilderExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The StringBuilder Extension tests
    /// </summary>
    [TestFixture]
    public class StringBuilderExtensionMethodsTests : UnitTestBase
    {
        [TestCase]
        public void TestAppendFormatLine()
        {
            StringBuilder expectedValue = new StringBuilder();
            expectedValue.AppendFormat("AB{0}CD{1}EF", "12", "34");
            expectedValue.AppendLine();

            StringBuilder actualValue = new StringBuilder();
            actualValue.AppendFormatLine("AB{0}CD{1}EF", "12", "34");

            Assert.That(actualValue.ToString(), Is.EqualTo(expectedValue.ToString()));
        }
    }
}
