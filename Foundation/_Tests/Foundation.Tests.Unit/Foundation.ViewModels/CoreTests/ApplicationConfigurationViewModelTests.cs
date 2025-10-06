//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;
using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationConfigurationViewModelTests : GenericDataGridViewModelTestBaseClass<IApplicationConfiguration, IApplicationConfigurationViewModel, IApplicationConfigurationProcess>
    {
        protected override String ExpectedScreenTitle => "Application Configurations";
        protected override String ExpectedStatusBarText => "Number of Application Configurations:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Configuration Scope:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ConfigurationScope.Name;

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override Boolean ExpectedAction1Enabled => true;
        protected override String ExpectedAction1Name => "Load group...";

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Application Name:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.Application.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter3 => true;
        protected override String ExpectedFilter3Name => "User:";
        protected override string ExpectedFilter3DisplayMemberPath => FDC.UserProfile.DisplayName;

        private IConfigurationScopeProcess ConfigurationScopeProcess { get; set; }
        private IApplicationProcess ApplicationProcess { get; set; }


        protected override IApplicationConfigurationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationConfigurationViewModel viewModel = new ApplicationConfigurationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ConfigurationScopeProcess, ApplicationProcess);

            return viewModel;
        }

        protected override IApplicationConfigurationProcess CreateBusinessProcess()
        {
            ConfigurationScopeProcess = Substitute.For<IConfigurationScopeProcess>();
            ApplicationProcess = Substitute.For<IApplicationProcess>();
            UserProfileProcess = Substitute.For<IUserProfileProcess>();

            IApplicationConfigurationProcess process = Substitute.For<IApplicationConfigurationProcess>();

            List<IUserProfile> userProfiles = new List<IUserProfile>
            {
                CoreInstance.IoC.Get<IUserProfile>(),
                CoreInstance.IoC.Get<IUserProfile>(),
            };
            UserProfileProcess.GetAll().Returns(userProfiles);
            UserProfileProcess.GetAll(Arg.Any<Boolean>()).Returns(userProfiles);

            return process;
        }

        protected override IApplicationConfiguration CreateModel()
        {
            IApplicationConfiguration retVal = base.CreateModel();

            retVal.ConfigurationScopeId = new EntityId(0);
            retVal.Key= Guid.NewGuid().ToString();
            retVal.Value = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IConfigurationScope> configurationScopes = new List<IConfigurationScope>
            {
                CoreInstance.IoC.Get<IConfigurationScope>(),
                CoreInstance.IoC.Get<IConfigurationScope>(),
            };
            ConfigurationScopeProcess.GetAll().Returns(configurationScopes);

            List<IApplication> applications = new List<IApplication>
            {
                CoreInstance.IoC.Get<IApplication>(),
                CoreInstance.IoC.Get<IApplication>(),
            };
            ApplicationProcess.GetAll().Returns(applications);

            List<IUserProfile> userProfiles = new List<IUserProfile>
            {
                CoreInstance.IoC.Get<IUserProfile>(),
                CoreInstance.IoC.Get<IUserProfile>(),
            };
            ViewModelBase.UserProfileProcess.GetAll().Returns(userProfiles);
            ViewModelBase.UserProfileProcess.GetAll(Arg.Any<Boolean>()).Returns(userProfiles);

            List<IApplicationConfiguration> filteredData = new List<IApplicationConfiguration>();
            BusinessProcess.ApplyFilter(Arg.Any<List<IApplicationConfiguration>>(), Arg.Any<IConfigurationScope>(), Arg.Any<IApplication>(), Arg.Any<IUserProfile>()).Returns(filteredData);
        }
    }
}
