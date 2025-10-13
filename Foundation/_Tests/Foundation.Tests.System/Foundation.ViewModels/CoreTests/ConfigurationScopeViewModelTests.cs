//-----------------------------------------------------------------------
// <copyright file="ConfigurationScopeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ConfigurationScopeViewModelTests
    /// </summary>
    [TestFixture]
    public class ConfigurationScopeViewModelTests : GenericDataGridViewModelTestBaseClass<IConfigurationScope, IConfigurationScopeViewModel, IConfigurationScopeProcess>
    {
        protected override String ExpectedScreenTitle => "Configuration Scopes";
        protected override String ExpectedStatusBarText => "Number of Configuration Scopes:";

        protected override IConfigurationScopeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IConfigurationScopeViewModel viewModel = new ConfigurationScopeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IConfigurationScopeProcess CreateBusinessProcess()
        {
            IConfigurationScopeProcess process = Substitute.For<IConfigurationScopeProcess>();

            return process;
        }

        protected override IConfigurationScope CreateModel()
        {
            IConfigurationScope retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
