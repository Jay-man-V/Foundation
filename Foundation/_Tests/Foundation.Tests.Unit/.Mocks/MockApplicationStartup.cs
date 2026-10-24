//-----------------------------------------------------------------------
// <copyright file="MockApplicationStartup.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks
{
    [DependencyInjectionSingleton]
    public class MockApplicationStartup : IMockApplicationStartup
    {
        public static EventHandler? ApplicationStartingCalled { get; set; }

        public MockApplicationStartup()
        {
            InstanceCounter++;
        }

        public Int32 InstanceCounter { get; }

        public Boolean ApplicationStartupCalled { get; set; }

        public void ApplicationStarting()
        {
            ApplicationStartupCalled = true;
            ApplicationStartingCalled?.Invoke(this, EventArgs.Empty);
        }
    }
}
