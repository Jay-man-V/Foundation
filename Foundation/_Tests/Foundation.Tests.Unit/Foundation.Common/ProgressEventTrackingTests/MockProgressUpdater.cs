//-----------------------------------------------------------------------
// <copyright file="MockProgressUpdater.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Common.ProgressEventTrackingTests
{
    internal class MockProgressUpdater : ProgressUpdater
    {
        public MockProgressUpdater(ProgressItem item) : base(item)
        {
        }

        protected override void UpdateEvent(ProgressItem item)
        {
            // Does nothing
        }

        public override void StartEvent()
        {
            // Does nothing
        }

        public void MockUpdateEventType(MessageType eventType)
        {
            UpdateEventType(eventType);
        }

        public void MockUpdateEventStatus(String status)
        {
            UpdateEventStatus(status);
        }

        public void MockUpdateEventMessage(String message)
        {
            UpdateEventMessage(message);
        }
    }
}
