//-----------------------------------------------------------------------
// <copyright file="MockProgressTracker.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ProgressEventTrackingTests
{
    internal class MockProgressTracker : ProgressTracker
    {
        protected override IProgressUpdater AddEvent(ProgressItem item)
        {
            IProgressUpdater retVal = new MockProgressUpdater(item);
            return retVal;
        }
    }
}
