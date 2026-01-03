//-----------------------------------------------------------------------
// <copyright file="LogWritingTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using NSubstitute;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.LogWritersTests
{
    /// <summary>
    /// The Log Writing Tests
    /// </summary>
    [TestFixture]
    public class LogWritingTests : UnitTestBase
    {
        /// <summary>
        /// The string message
        /// </summary>
        private const String StringMessage = "String message to be output: {0}, {1}, {2}, {3}, {4}";

        /// <summary>
        /// The string message only
        /// </summary>
        private const String StringMessageOnly = "Simple message. Nothing special here.";

        /// <summary>
        /// The _parameters
        /// </summary>
        private readonly Object[] _parameters = ["0", "1", "2", "3", "4"];

        private LoggingHelpers LoggingHelpers { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            LoggingHelpers = new LoggingHelpers(CoreInstance, RunTimeEnvironmentSettings, DateTimeService);
        }

        /// <summary>
        /// Tests the information logging.
        /// </summary>
        [TestCase("0", "Off")]
        [TestCase("1", "Error")]
        [TestCase("2", "Warning")]
        [TestCase("3", "Info")]
        [TestCase("4", "Verbose")]
        public void TestInformationLogging(String logLevel, String comment)
        {
            RunTimeEnvironmentSettings.TraceSwitch.Returns(new TraceSwitch("TraceLevelSwitch", comment, logLevel));

            LoggingHelpers.TraceCallEnter();
            InternalMethodString(String.Format(StringMessage, _parameters));
            InternalMethodFormatString(StringMessage, _parameters);
            InternalMethodParamArray(StringMessageOnly, _parameters);
            InternalMethodException("A", 1);
            InternalMethodException2();
            InternalMethodException3();
            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Internals the method string.
        /// </summary>
        /// <param name="message">The message.</param>
        private void InternalMethodString(String message)
        {
            LoggingHelpers.TraceCallEnter(message);
            LoggingHelpers.TraceMessage(message);
            LoggingHelpers.LogInformationMessage(message);
            LoggingHelpers.LogWarningMessage(message);
            LoggingHelpers.LogAuditMessage(message);
            LoggingHelpers.LogErrorMessage(message);
            LoggingHelpers.TraceCallReturn("Made up return Value");
        }

        /// <summary>
        /// Internals the method format string.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        private void InternalMethodFormatString(String message, params Object[] parameters)
        {
            LoggingHelpers.TraceCallEnter(message, parameters);
            LoggingHelpers.TraceMessage(message, parameters);
            LoggingHelpers.LogInformationMessage(message, parameters);
            LoggingHelpers.LogWarningMessage(message, parameters);
            LoggingHelpers.LogAuditMessage(message, parameters);
            LoggingHelpers.LogErrorMessage(message, parameters);
            LoggingHelpers.TraceCallReturn("Made up return Value");
        }

        /// <summary>
        /// Internals the method parameter array.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void InternalMethodParamArray(params Object[] parameters)
        {
            LoggingHelpers.TraceCallEnter(parameters);
            LoggingHelpers.TraceMessage(parameters);
            LoggingHelpers.LogInformationMessage(parameters);
            LoggingHelpers.LogWarningMessage(parameters);
            LoggingHelpers.LogAuditMessage(parameters);
            LoggingHelpers.LogErrorMessage(parameters);
            LoggingHelpers.TraceCallReturn("Made up return Value");
        }

        /// <summary>
        /// Internals the method exception.
        /// </summary>
        /// <param name="a">The a parameter.</param>
        /// <param name="b">The b parameter.</param>
        private void InternalMethodException(String a, Int32 b)
        {
            LoggingHelpers.TraceCallEnter(a, b);
            try
            {
                ApplicationException newEx = new ApplicationException("Test harness generated exception")
                {
                    HelpLink = "http://www.google.co.uk",
                };

                throw newEx;
            }
            catch (ApplicationException exception)
            {
                LoggingHelpers.TraceMessage(exception, 0, 1, 2, 3, 4);
                LoggingHelpers.LogInformationMessage(exception, 0, 1, 2, 3, 4);
                LoggingHelpers.LogWarningMessage(exception, 0, 1, 2, 3, 4);
                LoggingHelpers.LogAuditMessage(exception, 0, 1, 2, 3, 4);
                LoggingHelpers.LogErrorMessage(exception, 0, 1, 2, 3, 4);
            }

            LoggingHelpers.TraceCallReturn("Made up return Value");
        }

        /// <summary>
        /// Internals the method exception2.
        /// </summary>
        private void InternalMethodException2()
        {
            LoggingHelpers.TraceCallEnter();
            try
            {
                ApplicationException newEx = new ApplicationException("Test harness generated exception: {0}, {1}, {2}, {3}, {4}")
                {
                    HelpLink = "http://www.google.co.uk",
                };

                throw newEx;
            }
            catch (ApplicationException exception)
            {
                LoggingHelpers.TraceMessage(exception, exception.Message, 0, 1, 2, 3, 4);
                LoggingHelpers.LogInformationMessage(exception, exception.Message, 0, 1, 2, 3, 4);
                LoggingHelpers.LogWarningMessage(exception, exception.Message, 0, 1, 2, 3, 4);
                LoggingHelpers.LogAuditMessage(exception, exception.Message, 0, 1, 2, 3, 4);
                LoggingHelpers.LogErrorMessage(exception, exception.Message, 0, 1, 2, 3, 4);
            }

            LoggingHelpers.TraceCallReturn("Made up return Value");
        }

        /// <summary>
        /// Internals the method exception2.
        /// </summary>
        private void InternalMethodException3()
        {
            LoggingHelpers.TraceCallEnter();
            try
            {
                ApplicationException newEx = new ApplicationException("Test harness generated exception: {0}, {1}, {2}, {3}, {4}")
                {
                    HelpLink = "http://www.google.co.uk",
                };

                throw newEx;
            }
            catch (ApplicationException exception)
            {
                LoggingHelpers.TraceMessage(exception);
                LoggingHelpers.LogInformationMessage(exception);
                LoggingHelpers.LogWarningMessage(exception);
                LoggingHelpers.LogAuditMessage(exception);
                LoggingHelpers.LogErrorMessage(exception);
            }

            LoggingHelpers.TraceCallReturn("Made up return Value");
        }
    }
}
