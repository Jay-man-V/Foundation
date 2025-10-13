﻿//-----------------------------------------------------------------------
// <copyright file="ConfigurationScopeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ConfigurationScopeViewModelTests
    /// </summary>
    [TestFixture]
    public class ConfigurationScopeViewModelTests : GenericDataGridViewModelTests<IConfigurationScope, IConfigurationScopeViewModel, IConfigurationScopeProcess>
    {
        protected override IConfigurationScopeProcess CreateBusinessProcess()
        {
            IConfigurationScopeProcess process = Substitute.For<IConfigurationScopeProcess>();

            return process;
        }

        protected override IConfigurationScope CreateBlankModel(Int32 entityId)
        {
            IConfigurationScope retVal = Substitute.For<IConfigurationScope>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IConfigurationScope CreateModel(Int32 entityId)
        {
            IConfigurationScope retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IConfigurationScopeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IConfigurationScopeViewModel viewModel = new ConfigurationScopeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
