//-----------------------------------------------------------------------
// <copyright file="IoCTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Sec;
using Foundation.Core;
using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.NetFramework;
using Foundation.Tests.Unit.Support;

using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

using System.Reflection;

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
        public void Test_Initialise_1()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
        }

        [TestCase]
        public void Test_Initialise_2()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise("Foundation.Tests.Unit.Support", "Foundation.Tests.Unit.dll");
        }

        [TestCase]
        public void Test_Reset()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();

            ioc.Reset();
        }

        [TestCase]
        public void Test_Get_Type()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            ITransientOperation transientOperation = ioc.Get<ITransientOperation>();

            Assert.That(transientOperation, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_Get_String()
        {
            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            ITransientOperation transientOperation = ioc.Get<ITransientOperation>(typeof(TransientOperation).AssemblyQualifiedName!);

            Assert.That(transientOperation, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_GetAll_Type()
        {
            List<String> expectedList = [typeof(MultipleInstance1).FullName!, typeof(MultipleInstance2).FullName!];

            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            List<IMultipleInstances> multipleInstances = ioc.GetAll<IMultipleInstances>().ToList();

            Assert.That(multipleInstances, Is.Not.EqualTo(null));
            Assert.That(multipleInstances.Count, Is.EqualTo(2));
            Assert.That(expectedList.Contains(multipleInstances[0].GetOperationType()), Is.EqualTo(true));
            Assert.That(expectedList.Contains(multipleInstances[1].GetOperationType()), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Get_String_Assembly_Type()
        {
            String assemblyName = "Foundation.Tests.Unit";
            String typeName = "Foundation.Tests.Unit.Support.TransientOperation";

            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            ITransientOperation transientOperation = ioc.Get<ITransientOperation>(assemblyName, typeName);

            Assert.That(transientOperation, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_Get_Type_Exception_ServiceProviderNotInitialised()
        {
            String parameterName = "ServiceProvider";
            String errorMessage = $"IoC Service Provider has not been initialised. (Parameter '{parameterName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new(hostApplicationBuilder.Services);
                ioc.Initialise();

                _ = ioc.Get<ITransientOperation>();
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase]
        public void Test_Get_String_Exception_ServiceProviderNotInitialised()
        {
            String parameterName = "ServiceProvider";
            String errorMessage = $"IoC Service Provider has not been initialised. (Parameter '{parameterName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new(hostApplicationBuilder.Services);
                ioc.Initialise();

                _ = ioc.Get<ITransientOperation>(typeof(ITransientOperation).AssemblyQualifiedName!);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase]
        public void Test_GetAll_Type_Exception_ServiceProviderNotInitialised()
        {
            String parameterName = "ServiceProvider";
            String errorMessage = $"IoC Service Provider has not been initialised. (Parameter '{parameterName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new(hostApplicationBuilder.Services);
                ioc.Initialise();

                _ = ioc.GetAll<ITransientOperation>();
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase]
        public void Test_Get_Type_Exception_UnableToGetInstance()
        {
            String typeName = $"{typeof(ITypeNotImplemented)}";
            String errorMessage = $"Unable to get instance of {typeName}";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new(hostApplicationBuilder.Services);
                ioc.Initialise();
                IHost host = hostApplicationBuilder.Build();
                ioc.ServiceProvider = host.Services;

                _ = ioc.Get<ITypeNotImplemented>();
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Get_String_Exception_UnableToGetInstance()
        {
            String typeName = "Foundation.Tests.Unit.Support.TypeNotImplemented, Foundation.Tests.Unit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            String errorMessage = $"Unable to get instance of '{typeName}'";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                HostApplicationBuilderSettings settings = new();

                HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                IoC ioc = new(hostApplicationBuilder.Services);
                ioc.Initialise();
                IHost host = hostApplicationBuilder.Build();
                ioc.ServiceProvider = host.Services;

                _ = ioc.Get<ITypeNotImplemented>(typeName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Get_String_Assembly_Exception_Type()
        {
            String assemblyName = "Foundation.Tests.Unit.made.up.assembly.name";
            String assemblyType = "Foundation.Tests.Unit.Support.TransientOperation";

            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            String paramName = nameof(assemblyName);
            String errorMessage = $"Cannot locate the Assembly: '{assemblyName}' (Parameter '{paramName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = ioc.Get<ITransientOperation>(assemblyName, assemblyType);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_Get_String_Assembly_Type_Exception()
        {
            String assemblyName = "Foundation.Tests.Unit";
            String assemblyNameInMessage = "Foundation.Tests.Unit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            String assemblyType = "Foundation.Tests.Unit.Support.TransientOperation.made.up.type.name";

            HostApplicationBuilderSettings settings = new();

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            IoC ioc = new(hostApplicationBuilder.Services);
            ioc.Initialise();
            IHost host = hostApplicationBuilder.Build();
            ioc.ServiceProvider = host.Services;

            String paramName = nameof(assemblyType);
            String errorMessage = $"Cannot load assembly type: '{assemblyType}' from the Assembly: '{assemblyNameInMessage}' (Parameter '{paramName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = ioc.Get<ITransientOperation>(assemblyName, assemblyType);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_TheInstance_Null()
        {
            String errorMessage = "Foundation.Core has not been initialised";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                _ = global::Foundation.Core.Core.TheInstance;
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}