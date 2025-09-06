//-----------------------------------------------------------------------
// <copyright file="MockDispatcherTimerWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Threading;

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks
{
    public class MockDispatcherTimerWrapper : IDispatcherTimerWrapper
    {
        public MockDispatcherTimerWrapper() { }

        private MockDispatcherTimerWrapper(TimeSpan interval, DispatcherPriority priority, EventHandler callback)
        {
        }

        public IDispatcherTimerWrapper NewTimer(TimeSpan interval, DispatcherPriority priority, EventHandler callback)
        {
            IDispatcherTimerWrapper retVal = new MockDispatcherTimerWrapper(interval, priority, callback);

            return retVal;
        }

        public void Start()
        {

        }
    }
}
