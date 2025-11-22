//-----------------------------------------------------------------------
// <copyright file="ProgressUpdaterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ProgressEventTrackingTests
{
    /// <summary>
    /// Summary description for UnitTestTemplate
    /// </summary>
    [TestFixture]
    public class ProgressUpdaterTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            ProgressItem progressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            Object progressUpdaterObject = new MockProgressUpdater(progressItem);

            Assert.That(progressUpdaterObject, Is.Not.EqualTo(null));
            Assert.That(progressUpdaterObject, Is.InstanceOf<MockProgressUpdater>());
        }

        [TestCase]
        public void Test_Properties()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdaterObject = new MockProgressUpdater(initialProgressItem);

            Assert.That(progressUpdaterObject.EventType, Is.EqualTo(MessageType.Information));
            Assert.That(progressUpdaterObject.Action, Is.EqualTo("Initial Action"));
            Assert.That(progressUpdaterObject.Status, Is.EqualTo("Initial Status"));
            Assert.That(progressUpdaterObject.Message, Is.EqualTo("Initial Message"));
            Assert.That(progressUpdaterObject.Minimum, Is.EqualTo(0));
            Assert.That(progressUpdaterObject.Maximum, Is.EqualTo(0));
            Assert.That(progressUpdaterObject.StepAmount, Is.EqualTo(0));
            Assert.That(progressUpdaterObject.Progress, Is.EqualTo(0));

            progressUpdaterObject.Minimum = 5;
            progressUpdaterObject.Maximum = 120;
            progressUpdaterObject.StepAmount = 7;

            Assert.That(progressUpdaterObject.Minimum, Is.EqualTo(5));
            Assert.That(progressUpdaterObject.Maximum, Is.EqualTo(120));
            Assert.That(progressUpdaterObject.StepAmount, Is.EqualTo(7));
            Assert.That(progressUpdaterObject.Progress, Is.EqualTo(0));


            progressUpdaterObject.EventType = MessageType.Success;
            progressUpdaterObject.Status = "New and updated status";
            progressUpdaterObject.Message = "New and updated message";

            Assert.That(progressUpdaterObject.EventType, Is.EqualTo(MessageType.Success));
            Assert.That(progressUpdaterObject.Status, Is.EqualTo("New and updated status"));
            Assert.That(progressUpdaterObject.Message, Is.EqualTo("New and updated message"));
        }

        [TestCase]
        public void Test_StartEvent()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);

            progressUpdater.StartEvent();
        }

        [TestCase]
        public void Test_FormatProgressItem()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);
            MockProgressUpdater mockProgressUpdater = (MockProgressUpdater)progressUpdater;

            ProgressItem targetProgressItem = new ProgressItem(DateTimeService, MessageType.Warning, "Second Action", "Second Status", "Second Message");

            String expectedFormattedProgressItem = $"{DateTimeService.SystemUtcDateTimeNow.ToString(Formats.DotNet.DateTimeMilliseconds)} Second Action Second Status Second Message{Environment.NewLine}";
            String expected = ReplaceDateTimeWithConstant(expectedFormattedProgressItem);

            StringBuilder formattedProgressItem = mockProgressUpdater.FormatProgressItem(targetProgressItem);
            String actual = ReplaceDateTimeWithConstant(formattedProgressItem.ToString());

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_UpdateEvent()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);
            MockProgressUpdater mockProgressUpdater = (MockProgressUpdater)progressUpdater;

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
        }

        [TestCase]
        public void Test_UpdateEventType()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);
            MockProgressUpdater mockProgressUpdater = (MockProgressUpdater)progressUpdater;

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.MockUpdateEventType(MessageType.Error);
        }

        [TestCase]
        public void Test_UpdateEventStatus()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);
            MockProgressUpdater mockProgressUpdater = (MockProgressUpdater)progressUpdater;

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.MockUpdateEventStatus("Updated Event Status");
        }

        [TestCase]
        public void Test_UpdateEventMessage()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);
            MockProgressUpdater mockProgressUpdater = (MockProgressUpdater)progressUpdater;

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.MockUpdateEventMessage("Updated Event Message");
        }

        [TestCase]
        public void Test_IncrementAndProgress()
        {
            ProgressItem initialProgressItem = new ProgressItem(DateTimeService, MessageType.Information, "Initial Action", "Initial Status", "Initial Message");
            IProgressUpdater progressUpdater = new MockProgressUpdater(initialProgressItem);

            Assert.That(progressUpdater.Progress, Is.EqualTo(0));
            Assert.That(progressUpdater.StepAmount, Is.EqualTo(0));
            progressUpdater.StepAmount = 5;

            progressUpdater.Increment();
            Assert.That(progressUpdater.Progress, Is.EqualTo(5));

            progressUpdater.Increment();
            Assert.That(progressUpdater.Progress, Is.EqualTo(10));

            progressUpdater.Increment();
            Assert.That(progressUpdater.Progress, Is.EqualTo(15));

            progressUpdater.Increment(10);
            Assert.That(progressUpdater.Progress, Is.EqualTo(25));

            progressUpdater.Increment(10);
            Assert.That(progressUpdater.Progress, Is.EqualTo(35));
        }
    }
}
