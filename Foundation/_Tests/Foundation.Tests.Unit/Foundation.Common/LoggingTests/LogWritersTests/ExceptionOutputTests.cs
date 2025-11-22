//-----------------------------------------------------------------------
// <copyright file="ExceptionOutputTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text;

using Foundation.Common;

using Foundation.Tests.Unit.Support;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.LogWritersTests
{
    /// <summary>
    /// The Context Information Tests
    /// </summary>
    [TestFixture]
    [DeploymentItem(@".ExpectedResults\Logging\LogWriter\TestToString_1.txt", @".ExpectedResults\Logging\LogWriter\")]
    [DeploymentItem(@".ExpectedResults\Logging\LogWriter\TestToString_2.txt", @".ExpectedResults\Logging\LogWriter\")]
    public class ExceptionOutputTests : UnitTestBase
    {
        private const String BaseFolder = @".ExpectedResults\Logging\LogWriter\";

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void TestToString_1()
        {
            String functionName = LocationUtils.GetFunctionName();

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            Debug.WriteLine(expectedValue);

            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = new ExceptionOutput(RunTimeEnvironmentSettings, DateTimeService)
            {
                ErrorDetail = "This is the error detail",
                ErrorMessage = "What else could be the error message?",
                ErrorSource = "Some namespace:class:function",
            };

            Debug.WriteLine(exceptionOutput.ToString());
            String actualValue = FixUpStringWithReplacements(exceptionOutput.ToString());

            String[] expected = expectedValue.Split([Environment.NewLine], StringSplitOptions.None);
            String[] actual = actualValue.Split([Environment.NewLine], StringSplitOptions.None);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));

            for (Int16 i = 0; i < expected.Length; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
