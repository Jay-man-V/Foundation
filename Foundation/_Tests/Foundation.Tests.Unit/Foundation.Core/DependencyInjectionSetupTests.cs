//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionSetupTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Core;
using Foundation.Interfaces;

using Foundation.Models.App;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The DependencyInjectionSetupTests
    /// </summary>
    public class DependencyInjectionSetupTests // Do not inherit from UnitTestBase
    {
        [TestCase]
        public void Test_Direct()
        {
            HostApplicationBuilderSettings settings = new HostApplicationBuilderSettings();
            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            hostApplicationBuilder.Services.AddTransient(typeof(IMenuItem), typeof(MenuItem));

            hostApplicationBuilder.Services.AddTransient(typeof(IMultipleInstances), typeof(MultipleInstance1));
            hostApplicationBuilder.Services.AddTransient(typeof(IInstance1), typeof(MultipleInstance1));

            hostApplicationBuilder.Services.AddTransient(typeof(IMultipleInstances), typeof(MultipleInstance2));
            hostApplicationBuilder.Services.AddTransient(typeof(IInstance2), typeof(MultipleInstance2));

            hostApplicationBuilder.Services.AddTransient(typeof(ITransientOperation), typeof(TransientOperation));

            IHost theHost = hostApplicationBuilder.Build();

            IMenuItem menuItem = theHost.Services.GetService<IMenuItem>()!;
            Assert.That(menuItem, Is.Not.Null);

            List<IMultipleInstances>? multipleInstances = theHost.Services.GetServices<IMultipleInstances>().ToList();
            Assert.That(multipleInstances, Is.Not.Null);
            Assert.That(multipleInstances.Count(), Is.EqualTo(2));

            IInstance1 instance1 = theHost.Services.GetService<IInstance1>()!;
            Assert.That(instance1, Is.Not.Null);

            IInstance2 instance2 = theHost.Services.GetService<IInstance2>()!;
            Assert.That(instance2, Is.Not.Null);

            ITransientOperation transientOperation = theHost.Services.GetService<ITransientOperation>()!;
            Assert.That(transientOperation, Is.Not.Null);
        }

        [TestCase]
        public void Test_Foundation()
        {
            HostApplicationBuilderSettings settings = new HostApplicationBuilderSettings();
            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            DependencyInjectionSetup.ResetDependencyInjection();
            
            DependencyInjectionSetup.SetupDependencyInjection(hostApplicationBuilder.Services, "*", "*.dll");

            IHost theHost = hostApplicationBuilder.Build();

            IMenuItem? menuItem = theHost.Services.GetService<IMenuItem>();
            Assert.That(menuItem, Is.Not.Null);

            IInstance1? instance1 = theHost.Services.GetService<IInstance1>();
            Assert.That(instance1, Is.Not.Null);

            IInstance2? instance2 = theHost.Services.GetService<IInstance2>();
            Assert.That(instance2, Is.Not.Null);

            List<IMultipleInstances>? multipleInstances = theHost.Services.GetServices<IMultipleInstances>().ToList();
            Assert.That(multipleInstances, Is.Not.Null);
            Assert.That(multipleInstances.Count(), Is.EqualTo(2));
        }
    }
}
