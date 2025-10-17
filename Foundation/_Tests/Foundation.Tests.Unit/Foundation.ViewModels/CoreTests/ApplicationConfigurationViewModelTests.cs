//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationConfigurationViewModelTests : GenericDataGridViewModelTests<IApplicationConfiguration, IApplicationConfigurationViewModel, IApplicationConfigurationProcess>
    {
        protected override Boolean ExpectedAction1Enabled => true;

        private IConfigurationScopeProcess? ConfigurationScopeProcess { get; set; }
        private IApplicationProcess? ApplicationProcess { get; set; }

        protected override IApplicationConfigurationProcess CreateBusinessProcess()
        {
            ConfigurationScopeProcess = Substitute.For<IConfigurationScopeProcess>();
            ApplicationProcess = Substitute.For<IApplicationProcess>();

            IApplicationConfigurationProcess process = Substitute.For<IApplicationConfigurationProcess>();

            return process;
        }

        protected override IApplicationConfiguration CreateBlankModel(Int32 entityId)
        {
            IApplicationConfiguration retVal = new ApplicationConfiguration();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationConfiguration CreateModel(Int32 entityId)
        {
            IApplicationConfiguration retVal = base.CreateModel(entityId);

            retVal.ConfigurationScopeId = new EntityId(0);
            retVal.Key = Guid.NewGuid().ToString();
            retVal.Value = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IApplicationConfigurationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationConfigurationViewModel viewModel = new ApplicationConfigurationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ConfigurationScopeProcess!, ApplicationProcess!);

            return viewModel;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IConfigurationScope> configurationScopes =
            [
                Substitute.For<IConfigurationScope>(),
                Substitute.For<IConfigurationScope>(),
            ];
            ConfigurationScopeProcess!.GetAll().Returns(configurationScopes);

            List<IApplication> applications =
            [
                Substitute.For<IApplication>(),
                Substitute.For<IApplication>(),
            ];
            ApplicationProcess!.GetAll().Returns(applications);

            List<IApplicationConfiguration> filteredData = [];
            BusinessProcess.ApplyFilter(Arg.Any<List<IApplicationConfiguration>>(), Arg.Any<IConfigurationScope>(), Arg.Any<IApplication>(), Arg.Any<IUserProfile>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            return Substitute.For<IConfigurationScope>();
        }

        protected override Object CreateModelForDropDown2()
        {
            return Substitute.For<IApplication>();
        }

        protected override Object CreateModelForDropDown3()
        {
            return Substitute.For<IUserProfile>();
        }
    }
}
