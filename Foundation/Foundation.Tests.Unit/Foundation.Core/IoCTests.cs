//-----------------------------------------------------------------------
// <copyright file="IoCTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Hosting;

using Foundation.Core;
using Foundation.Interfaces;
using Foundation.Tests.Unit.NetFramework;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The Current Logged On User Tests
    /// </summary>
    public class IoCTests // Do not inherit from UnitTestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown()
        {
        }

        [TestCase]
        public void Test_Initialise()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new();
            ioc.Initialise(hostApplicationBuilder.Services);
        }

        [TestCase]
        public void Test_Reset()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new();
            ioc.Initialise(hostApplicationBuilder.Services);

            ioc.Reset();
        }

        [TestCase]
        public void Test_Get()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new();
            ioc.Initialise(hostApplicationBuilder.Services);
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            IUserProfile userProfile = ioc.Get<IUserProfile>();

            Assert.That(userProfile, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_Get_Exception_ServiceProviderNotInitialised()
        {
            String parameterName = "ServiceProvider";
            String errorMessage = $"IoC Service Provider has not been initialised. (Parameter '{parameterName}')";
            ArgumentNullException? actualException = null;

            try
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new();
                ioc.Initialise(hostApplicationBuilder.Services);

                _ = ioc.Get<IUserProfile>();
            }
            catch (ArgumentNullException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase]
        public void Test_Get_Exception_UnableToGetInstance()
        {
            String typeName = $"{typeof(ITypeNotImplemented)}";
            String errorMessage = $"Unable to get instance of {typeName}";
            InvalidOperationException? actualException = null;

            try
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new();
                ioc.Initialise(hostApplicationBuilder.Services);
                IHost host = hostApplicationBuilder.Build();
                ioc.ServiceProvider = host.Services;

                _ = ioc.Get<ITypeNotImplemented>();
            }
            catch (InvalidOperationException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_TheInstance_Null()
        {
            InvalidOperationException? actualException = null;
            String expectedErrorMessage = "Foundation.Core has not been initialised";

            try
            {
                _ = global::Foundation.Core.Core.TheInstance;
            }
            catch (InvalidOperationException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
        }
    }
}