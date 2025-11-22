//-----------------------------------------------------------------------
// <copyright file="ProgressTrackerTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks.Wrappers;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.ProgressEventTrackingTests
{
    /// <summary>
    /// Summary description for UnitTestTemplate
    /// </summary>
    [TestFixture]
    public class ProgressTrackerTests : UnitTestBase
    {
        private const String BaseFolder = @".ExpectedResults\ProgressEventTracker\";
        private IClipBoardWrapper ClipBoardWrapper { get; } = new MockClipBoardWrapper();

        [TestCase]
        public void TestConstructor()
        {
            Object mockProgressTrackerObject = new MockProgressTracker();

            Assert.That(mockProgressTrackerObject, Is.Not.EqualTo(null));
            Assert.That(mockProgressTrackerObject, Is.InstanceOf<ProgressTracker>());
            Assert.That(mockProgressTrackerObject, Is.InstanceOf<IProgressEventTracker>());            
        }

        [TestCase]
        public void TestAddEvent()
        {
            IProgressEventTracker mockProgressTracker = new MockProgressTracker();

            Object mockProgressUpdaterObject = mockProgressTracker.AddEvent(DateTimeService, MessageType.NotSet, "Unit Test", "No status", "No message");

            Assert.That(mockProgressUpdaterObject, Is.Not.EqualTo(null));
            Assert.That(mockProgressUpdaterObject, Is.InstanceOf<IProgressUpdater>());
            Assert.That(mockProgressUpdaterObject, Is.InstanceOf<MockProgressUpdater>());
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\ProgressEventTracker\TestGenerateReport.txt", @".ExpectedResults\ProgressEventTracker\")]
        public void TestGenerateReport()
        {
            String functionName = LocationUtils.GetFunctionName();

            IProgressEventTracker mockProgressTracker = new MockProgressTracker();

            IProgressUpdater mockProgressUpdater = mockProgressTracker.AddEvent(DateTimeService, MessageType.NotSet, "Unit Test", "No status", "No message");

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            StringBuilder report = mockProgressTracker.GenerateReport();
            String actual = FixUpStringWithReplacements(report.ToString());

            Assert.That(actual, Is.EqualTo(expectedValue));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\ProgressEventTracker\TestCopyToClipboard.txt", @".ExpectedResults\ProgressEventTracker\")]
        public void TestCopyToClipboard()
        {
            String functionName = LocationUtils.GetFunctionName();

            IProgressEventTracker mockProgressTracker = new MockProgressTracker();
            mockProgressTracker.CopyToClipBoard -= MockProgressTrackerOnCopyToClipBoard;
            mockProgressTracker.CopyToClipBoard += MockProgressTrackerOnCopyToClipBoard;

            IProgressUpdater mockProgressUpdater = mockProgressTracker.AddEvent(DateTimeService, MessageType.NotSet, "Unit Test", "No status", "No message");

            mockProgressUpdater.StartEvent();

            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Information, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Warning, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update1 via UpdateEvent", "Message update1 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update2 via UpdateEvent", "Message update2 via UpdateEvent");
            mockProgressUpdater.UpdateEvent(MessageType.Error, "Status update3 via UpdateEvent", "Message update3 via UpdateEvent");

            String expectedValue = File.ReadAllText(BaseFolder + functionName + ".txt", Encoding.UTF8);
            expectedValue = FixUpStringWithReplacements(expectedValue);

            mockProgressTracker.GenerateReport();

            mockProgressTracker.CopyReportToClipboard();

            String reportFromClipboard = GetClipboardText();
            String actual = FixUpStringWithReplacements(reportFromClipboard);

            Assert.That(actual, Is.EqualTo(expectedValue));
        }

        private void MockProgressTrackerOnCopyToClipBoard(Object? sender, CopyToClipBoardEventArgs e)
        {
            Thread thread = new Thread(() => ClipBoardWrapper.SetText(e.Data));
            thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA
            thread.Start();
            thread.Join(); // Wait for the thread to end
        }

        private String GetClipboardText()
        {
            String retVal = String.Empty;
            Thread thread = new Thread(() => retVal = ClipBoardWrapper.GetText());
            thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA
            thread.Start();
            thread.Join(); // Wait for the thread to end

            return retVal;
        }
    }
}
