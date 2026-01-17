//-----------------------------------------------------------------------
// <copyright file="TraceLogWriterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.LogWritersTests
{
    /// <summary>
    /// The Trace Log Writer Tests
    /// </summary>
    [TestFixture]
    public class TraceLogWriterTests : UnitTestBase
    {
        /// <summary>
        /// The requested log level
        /// </summary>
        private const TraceLevel RequestedLogLevel = TraceLevel.Info;

        /// <summary>
        /// The message prefix
        /// </summary>
        private const String MessagePrefix = "UnitTest Message";

        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            TraceLogWriter logWriter = new TraceLogWriter(RunTimeEnvironmentSettings, RequestedLogLevel, MessagePrefix);

            Assert.That(logWriter.RequestedLogLevel, Is.EqualTo(RequestedLogLevel));
            Assert.That(logWriter.MessagePrefix, Is.EqualTo(MessagePrefix));
        }

        /// <summary>
        /// Tests WriteMessage.
        /// </summary>
        [TestCase]
        public void Test_WriteMessage()
        {
            CustomTraceListener customTraceListener = new CustomTraceListener();
            Trace.Listeners.Add(customTraceListener);
            TraceLogWriter logWriter = new TraceLogWriter(RunTimeEnvironmentSettings, RequestedLogLevel, MessagePrefix);

            String outputMessage = Guid.NewGuid().ToString();
            String expectedMessage = outputMessage + Environment.NewLine;
            logWriter.WriteMessage(outputMessage);

            String actualMessage = customTraceListener.Message;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            Trace.Listeners.Remove(customTraceListener);
        }

        /// <summary>
        /// Tests WriteLine.
        /// </summary>
        [TestCase]
        public void Test_CustomTraceListener_WriteLine()
        {
            CustomTraceListener customTraceListener = new CustomTraceListener();
            Trace.Listeners.Add(customTraceListener);
            String outputMessage = Guid.NewGuid().ToString();
            String expectedMessage = outputMessage + Environment.NewLine;
            customTraceListener.WriteLine(outputMessage);

            String actualMessage = customTraceListener.Message;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            Trace.Listeners.Remove(customTraceListener);
        }

        /// <summary>
        /// Tests Write.
        /// </summary>
        [TestCase]
        public void Test_CustomTraceListener_Write()
        {
            CustomTraceListener customTraceListener = new CustomTraceListener();
            Trace.Listeners.Add(customTraceListener);
            String outputMessage = Guid.NewGuid().ToString();
            String expectedMessage = outputMessage;
            customTraceListener.Write(outputMessage);

            String actualMessage = customTraceListener.Message;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            Trace.Listeners.Remove(customTraceListener);
        }
    }
}
