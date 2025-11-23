//-----------------------------------------------------------------------
// <copyright file="EventLogWriterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Security;

using Foundation.Common;
using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.LogWritersTests
{
    /// <summary>
    /// Defines Unit Tests for EventLogWriter class
    /// </summary>
    [TestFixture]
    public class EventLogWriterTests : UnitTestBase
    {
        /// <summary>
        /// The target event log
        /// </summary>
        private const String TargetEventLog = "UnitTests";

        /// <summary>
        /// The requested log level
        /// </summary>
        private const TraceLevel RequestedLogLevel = TraceLevel.Info;

        /// <summary>
        /// The message prefix
        /// </summary>
        private const String MessagePrefix = "UnitTest Message";

        /// <summary>
        /// The event source
        /// </summary>
        private const String EventSource = "Automated UnitTest";

        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestCase(TraceLevel.Off)]
        [TestCase(TraceLevel.Error)]
        [TestCase(TraceLevel.Warning)]
        [TestCase(TraceLevel.Info)]
        [TestCase(TraceLevel.Verbose)]
        public void Test_Constructor(TraceLevel logLevel)
        {
            ClearEventSource();

            EventLogWriter logWriter = new EventLogWriter(RunTimeEnvironmentSettings, DateTimeService,TargetEventLog, logLevel, MessagePrefix, EventSource);

            Assert.That(logWriter.RequestedLogLevel, Is.EqualTo(logLevel));
            Assert.That(logWriter.MessagePrefix, Is.EqualTo(MessagePrefix));
            Assert.That(logWriter.EventSource, Is.EqualTo(EventSource));
        }

        /// <summary>
        /// Tests the constructor failed to create event source.
        /// </summary>
        [TestCase]
        public void Test_ConstructorFailedToCreateEventSource()
        {
            ClearEventSource();
            UserSecuritySupport.RunFunctionUnderImpersonation(() =>
            {
                String targetEventLog = Guid.NewGuid().ToString();
                String eventSource = Guid.NewGuid().ToString();

                String tempMachineName = Environment.MachineName;
                String machineName = $"{tempMachineName.Substring(0, 1).ToUpper()}{tempMachineName.Substring(1)}";
                String expectedMessage = $"Error Creating Event Source '{eventSource}({eventSource.Substring(0, 8)})'. Check Permissions of execution account. Current Executing Account is: '{machineName}\\{Environment.UserName}'";

                SecurityException actualException = Assert.Throws<SecurityException>(() =>
                {
                    _ = new EventLogWriter(RunTimeEnvironmentSettings, DateTimeService, targetEventLog, RequestedLogLevel, MessagePrefix, eventSource);
                });

                String actualMessage = actualException.Message;
                Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            },
                ".", "UnitTest2", "UnitTest2");
        }

        /// <summary>
        /// Tests WriteMessage.
        /// </summary>
        [TestCase]
        public void Test_WriteMessage_1()
        {
            EventLogWriter logWriter = new EventLogWriter(RunTimeEnvironmentSettings, DateTimeService, TargetEventLog, RequestedLogLevel, MessagePrefix, EventSource);

            String outputMessage = Guid.NewGuid().ToString();
            EventLogEntryType expectedEventLogEntryType = EventLogEntryType.Information;
            String expectedMessage = outputMessage;

            logWriter.WriteMessage(outputMessage);

            EventLogEntry? eventLogEntry = FindEventLogEntry(outputMessage);

            Assert.That(eventLogEntry, Is.Not.EqualTo(null));
            Assert.That(eventLogEntry.EntryType, Is.EqualTo(expectedEventLogEntryType));
            Assert.That(eventLogEntry.Message.Contains(expectedMessage));
        }

        /// <summary>
        /// Tests WriteMessage.
        /// </summary>
        [TestCase]
        public void Test_WriteMessage_2()
        {
            EventLogWriter logWriter = new EventLogWriter(RunTimeEnvironmentSettings, DateTimeService, TargetEventLog, RequestedLogLevel, MessagePrefix, EventSource);

            String outputMessage = Guid.NewGuid().ToString();
            EventLogEntryType expectedEventLogEntryType = EventLogEntryType.Warning;
            String expectedMessage = outputMessage;

            logWriter.WriteMessage(EventLogEntryType.Warning, outputMessage);

            EventLogEntry? eventLogEntry = FindEventLogEntry(outputMessage);

            Assert.That(eventLogEntry, Is.Not.EqualTo(null));
            Assert.That(eventLogEntry.EntryType, Is.EqualTo(expectedEventLogEntryType));
            Assert.That(eventLogEntry.Message.Contains(expectedMessage));
        }

        public EventLogEntry? FindEventLogEntry(string outputMessage)
        {
            EventLog log = new EventLog(TargetEventLog);

            IEnumerable<EventLogEntry> entries = log.Entries.Cast<EventLogEntry>();
            EventLogEntry? retVal = entries.LastOrDefault(x => x.Message.Contains(outputMessage));

            return retVal;
        }

        /// <summary>
        /// Clears the event source.
        /// </summary>
        private void ClearEventSource()
        {
            try
            {
                Boolean eventSourceExists = EventLog.SourceExists(EventSource, EventLogWriter.LocalMachineName);

                if (eventSourceExists)
                {
                    EventLog.DeleteEventSource(EventSource);
                }
            }
            catch(SecurityException)
            {
                // Ignore this exception
            }
        }
    }
}
