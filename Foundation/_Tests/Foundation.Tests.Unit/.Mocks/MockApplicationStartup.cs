//-----------------------------------------------------------------------
// <copyright file="MockApplicationStartup.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks
{
    public interface IMockApplicationStartup : IApplicationStartup
    {
        Boolean ApplicationStartupCalled { get; set; }
    }

    [DependencyInjectionSingleton]
    public class MockApplicationStartup : IMockApplicationStartup
    {
        public static EventHandler? ApplicationStartingCalled { get; set; }

        public Boolean ApplicationStartupCalled { get; set; }

        public void ApplicationStarting()
        {
            ApplicationStartupCalled = true;
            ApplicationStartingCalled?.Invoke(this, EventArgs.Empty);
        }
    }
}
