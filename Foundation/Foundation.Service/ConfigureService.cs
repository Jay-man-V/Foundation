//-----------------------------------------------------------------------
// <copyright file="ConfigureService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Topshelf;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Service
{
    internal static class ConfigureService
    {
        private static ICore? Core { get; set; }

        internal static void Configure(ICore core)
        {
            LoggingHelpers.TraceCallEnter(core);

            Core = core;

            IMyService myService = core.IoC.Get<IMyService>();
            MyService theService = (MyService)myService;

            HostFactory.Run(configure =>
            {
                configure.Service<IMyService>(service =>
                {
                    service.ConstructUsing(s => theService);
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                // Setup Account that window service use to run.  
                configure.SetServiceName("Foundation-Service");
                configure.SetDisplayName("Foundation Service");
                configure.SetDescription("Application Service for JDV Software Foundation based software");

                configure.DependsOnEventLog().BeforeInstall(settings =>
                {
                    if (!EventLog.SourceExists(settings.ServiceName))
                    {
                        EventLog.CreateEventSource(settings.ServiceName, "Application");
                    }
                });
            });

            LoggingHelpers.TraceCallReturn();
        }
    }
}
