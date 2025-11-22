//-----------------------------------------------------------------------
// <copyright file="ExceptionOutputTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.FormattingTests
{
    /// <summary>
    /// The Exception Output Tests
    /// </summary>
    [TestFixture]
    public class ExceptionOutputTests : UnitTestBase
    {
        private const String BaseFolder = @".ExpectedResults\Logging\Formatting\";

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_RethrowAsNew.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_RethrowAsNew()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(true);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService,actualException);
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_RethrowAsNewWithMessage.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_RethrowAsNewWithMessage()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(true);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, actualException, "Show this message to the users");
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_RethrowAsNewWithMessageFormat.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_RethrowAsNewWithMessageFormat()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(true);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, actualException, "Message: {0}. {1}", "A", 123);
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_ThrowOriginal.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_ThrowOriginal()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(true);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, actualException);
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_ThrowOriginalWithMessage.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_ThrowOriginalWithMessage()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(false);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, actualException, "Show this message to the users");
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Logging\Formatting\TestNestedException_ThrowOriginalWithMessageFormat.txt", @".ExpectedResults\Logging\Formatting\")]
        public void TestNestedException_ThrowOriginalWithMessageFormat()
        {
            String functionName = LocationUtils.GetFunctionName();
            Exception actualException = Assert.Throws<Exception>(() =>
            {
                Common.NestedExceptionFirstMethod(false);
            });

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, actualException, "Message: {0}. {1}", "A", 123);
            String actualValue = exceptionOutput.ToString();
            actualValue = FixUpStringWithReplacements(actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
