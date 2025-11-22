//-----------------------------------------------------------------------
// <copyright file="ProgressItemTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ProgressEventTrackingTests
{
    /// <summary>
    /// Summary description for UnitTestTemplate
    /// </summary>
    [TestFixture]
    public class ProgressItemTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ProgressItem"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(ProgressItem));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.Index)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.TimeOfEntry)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.History)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.Action)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.EventType)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.Status)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ProgressItem.Message)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        [TestCase]
        public void Test_Constructor()
        {
            MessageType eventType = MessageType.NotSet;
            String action = String.Empty;
            String status = String.Empty;
            String message = String.Empty;
            ProgressItem progressItem = new ProgressItem(DateTimeService, eventType, action, status, message);

            Int32 index = 0;

            Assert.That(progressItem.Index, Is.EqualTo(index));
            Assert.That(progressItem.EventType, Is.EqualTo(eventType));
            Assert.That(progressItem.Action, Is.EqualTo(action));
            Assert.That(progressItem.Status, Is.EqualTo(status));
            Assert.That(progressItem.Message, Is.EqualTo(message));
        }

        [TestCase]
        public void Test_AllProperties()
        {
            MessageType eventType = MessageType.NotSet;
            String action = String.Empty;
            String status = String.Empty;
            String message = String.Empty;
            ProgressItem progressItem = new ProgressItem(DateTimeService, eventType, action, status, message);

            const Int32 expectedIndex = 123;
            DateTime expectedTimeOfEntry = DateTimeService.SystemUtcDateTimeNow;
            const String expectedAction = "Expected Action message";
            const MessageType expectedMessageType = MessageType.Information;
            const String expectedStatus = "Expected Status message";
            const String expectedMessage = "Expected Message message";

            progressItem.Index = expectedIndex;
            progressItem.TimeOfEntry = expectedTimeOfEntry;
            progressItem.Action = expectedAction;
            progressItem.EventType = expectedMessageType;
            progressItem.Status = expectedStatus;
            progressItem.Message = expectedMessage;

            Int32 actualIndex = progressItem.Index;
            DateTime actualTimeOfEntry = progressItem.TimeOfEntry;
            String actualAction = progressItem.Action;
            MessageType actualMessageType = progressItem.EventType;
            String actualStatus = progressItem.Status;
            String actualMessage = progressItem.Message;

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
            Assert.That(actualTimeOfEntry, Is.EqualTo(expectedTimeOfEntry));
            Assert.That(actualAction, Is.EqualTo(expectedAction));
            Assert.That(actualMessageType, Is.EqualTo(expectedMessageType));
            Assert.That(actualStatus, Is.EqualTo(expectedStatus));
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [TestCase]
        public void Test_AddHistory()
        {
            MessageType eventType = MessageType.NotSet;
            String initialAction = String.Empty;
            String initialStatus = String.Empty;
            String initialMessage = String.Empty;
            ProgressItem progressItem = new ProgressItem(DateTimeService, eventType, initialAction, initialStatus, initialMessage);

            const MessageType expectedFirstMessageType = MessageType.Information;
            const String expectedFirstAction = "History Item added";
            const String expectedFirstStatus = "Work in progress";
            const String expectedFirstMessage = "message";

            ProgressItem historyItem = new ProgressItem(DateTimeService, expectedFirstMessageType, expectedFirstAction, expectedFirstStatus, expectedFirstMessage);
            progressItem.AddHistory(historyItem);

            const MessageType expectedSecondMessageType = MessageType.Success;
            const String expectedSecondStatus = "Second History Item added";
            const String expectedSecondMessage = "Second message";

            progressItem.AddHistory(expectedSecondMessageType, expectedSecondStatus, expectedSecondMessage);

            ProgressItem firstProgressItem = progressItem.History[0];
            Assert.That(firstProgressItem.EventType, Is.EqualTo(expectedFirstMessageType));
            Assert.That(firstProgressItem.Action, Is.EqualTo(expectedFirstAction));
            Assert.That(firstProgressItem.Status, Is.EqualTo(expectedFirstStatus));
            Assert.That(firstProgressItem.Message, Is.EqualTo(expectedFirstMessage));

            ProgressItem secondProgressItem = progressItem.History[1];
            Assert.That(secondProgressItem.EventType, Is.EqualTo(expectedSecondMessageType));
            Assert.That(secondProgressItem.Status, Is.EqualTo(expectedSecondStatus));
            Assert.That(secondProgressItem.Message, Is.EqualTo(expectedSecondMessage));
        }
    }
}
