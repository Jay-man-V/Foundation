//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationConfigurationProcessTests : CommonBusinessProcessTests<IApplicationConfiguration, IApplicationConfigurationProcess, IApplicationConfigurationRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 12;
        protected override String ExpectedScreenTitle => "Application Configurations";
        protected override String ExpectedStatusBarText => "Number of Application Configurations:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Configuration Scope:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ConfigurationScope.Name;

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override String ExpectedAction1Name => "Load group...";

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Application Name:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.ConfigurationScope.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter3 => true;
        protected override String ExpectedFilter3Name => "User:";
        protected override string ExpectedFilter3DisplayMemberPath => FDC.UserProfile.DisplayName;

        protected override String ExpectedComboBoxDisplayMember => FDC.ApplicationConfiguration.Key;

        protected override IApplicationConfigurationRepository CreateRepository()
        {
            IApplicationConfigurationRepository retVal = Substitute.For<IApplicationConfigurationRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IApplicationConfigurationProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IConfigurationScopeProcess configurationScopeProcess = Substitute.For<IConfigurationScopeProcess>();
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();

            SetComboBoxProperties(configurationScopeProcess);
            SetComboBoxProperties(applicationProcess);
            SetComboBoxProperties(userProfileProcess);
            userProfileProcess.ComboBoxDisplayMember.Returns(FDC.UserProfile.DisplayName);

            IApplicationConfigurationProcess process = new ApplicationConfigurationProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, configurationScopeProcess, applicationProcess, userProfileProcess);

            return process;
        }

        protected override IApplicationConfiguration CreateBlankEntity(Int32 entityId)
        {
            IApplicationConfiguration retVal = new FModels.ApplicationConfiguration();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationConfiguration CreateEntity(IApplicationConfigurationProcess process, Int32 entityId)
        {
            IApplicationConfiguration retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ConfigurationScopeId = new EntityId(ConfigurationScope.System.Id());
            retVal.Key = Guid.NewGuid().ToString();
            retVal.Value = $"{Guid.NewGuid()},{Guid.NewGuid()}";
            retVal.IsEncrypted = true;

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationConfiguration entity)
        {
            Assert.That(entity.Key, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IApplicationConfiguration entity)
        {
            Assert.That(entity.Key, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IApplicationConfiguration entity)
        {
            Assert.That(entity.Key, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IApplicationConfiguration entity1, IApplicationConfiguration entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ConfigurationScopeId, Is.EqualTo(entity1.ConfigurationScopeId));
            Assert.That(entity2.Key, Is.EqualTo(entity1.Key));
            Assert.That(entity2.Value, Is.EqualTo(entity1.Value));
            Assert.That(entity2.IsEncrypted, Is.EqualTo(entity1.IsEncrypted));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application,Scope,Key,Value,Is encrypted?" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,26ccd9dd-40bd-4980-a847-11b6c3a25271,\"9455708b-12e2-4b2e-b750-14f1fbcf213d,d4e34845-c802-46f2-aba2-f520839658b4\",True" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,c80f2360-5ee1-436a-a5fe-f14830c2189c,\"29189d31-3f7b-47de-869c-cb1e8dbf73de,9cbc86cc-e3df-4f47-96fb-eebded3c4c42\",True" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,d1bb257a-3b45-407a-8106-1431b65f3560,\"a3b61ee2-2423-48e9-8633-1ba97586c66c,8e64e9b9-61ad-4822-b372-f358b63f2624\",True" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,dc89e098-b11d-4dc4-ba17-6e7ad658e68c,\"6578c7a3-f36d-42e9-9707-d4de5f4fce48,4fa18b7c-c8e1-4017-8e11-58d7f13c0c2a\",True" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,4645b0e7-84ec-4ae7-9598-0be53b489c8a,\"52f18ff6-9f4e-4a6f-b15f-e80fdcc5e66a,6b91b734-e9f4-46c3-b8d6-53c5f7ec0db7\",True" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,949a3829-9f52-48d3-8ecd-42b3446769cd,\"4bdd1b4b-ecca-46af-a440-3ddfef58dfc5,cdbdd3cb-fb42-4fe3-9e33-23b0646e0cc3\",True" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,e8c41a11-d91e-490a-97ad-565f05661d14,\"7e9a06b0-a97b-4ac5-8424-0937d24df188,6278d4ef-39fe-44c0-9c6f-ba74c17c8f2e\",True" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,54358ad5-8c7b-4116-a99a-2708180d89c4,\"851a5afa-1ed7-4bf6-8b7f-d36fe8b8cd1a,3904864b-dd1b-4f09-bef8-465a60e54e32\",True" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,940ada3d-ea9e-473e-90aa-8775e71a5ea3,\"4e1b40be-3950-4fae-94e0-7ceca4144a59,24dc9a05-38df-4247-9132-53b4ab102003\",True" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,0001-01-01T00:00:00.000,9999-12-31T23:59:59.999,1,1,eb0f7ac5-62eb-42ad-8752-dcdacf34c181,\"8bcb3662-2508-4dbf-bc60-e3bc8ad2e12d,21a9034a-b295-4875-8d2c-a9424693d889\",True" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplicationConfiguration entity)
        {
            entity.Key += "Updated";
            entity.Value += "Updated";
        }

        [TestCase]
        public void Test_ApplyFilter_ConfigurationScope()
        {
            IConfigurationScope configurationScope1 = Substitute.For<IConfigurationScope>();
            configurationScope1.Id = new EntityId(1);

            IConfigurationScope configurationScope2 = Substitute.For<IConfigurationScope>();
            configurationScope2.Id = new EntityId(2);

            IApplication application1 = Substitute.For<IApplication>();
            application1.Id = new AppId(0);

            IUserProfile userProfile1 = Substitute.For<IUserProfile>();
            userProfile1.Id = new EntityId(1);

            List<IApplicationConfiguration> applicationConfigurations =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            applicationConfigurations[0].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[1].ConfigurationScopeId = configurationScope2.Id;
            applicationConfigurations[2].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[3].ConfigurationScopeId = configurationScope2.Id;
            applicationConfigurations[4].ConfigurationScopeId = configurationScope1.Id;

            applicationConfigurations[0].Id = new EntityId(0);
            applicationConfigurations[0].ApplicationId = application1.Id;
            applicationConfigurations[0].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[1].Id = new EntityId(1);
            applicationConfigurations[1].ApplicationId = application1.Id;
            applicationConfigurations[1].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[2].Id = new EntityId(2);
            applicationConfigurations[2].ApplicationId = application1.Id;
            applicationConfigurations[2].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[3].Id = new EntityId(3);
            applicationConfigurations[3].ApplicationId = application1.Id;
            applicationConfigurations[3].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[4].Id = new EntityId(4);
            applicationConfigurations[4].ApplicationId = application1.Id;
            applicationConfigurations[4].CreatedByUserProfileId = userProfile1.Id;

            List<IApplicationConfiguration> filteredApplicationConfigurations1 = TheProcess!.ApplyFilter(applicationConfigurations, configurationScope1, application1, userProfile1);
            Assert.That(filteredApplicationConfigurations1.Count, Is.EqualTo(3));

            List<IApplicationConfiguration> filteredApplicationConfigurations2 = TheProcess!.ApplyFilter(applicationConfigurations, configurationScope2, application1, userProfile1);
            Assert.That(filteredApplicationConfigurations2.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void Test_ApplyFilter_Application()
        {
            IConfigurationScope configurationScope1 = Substitute.For<IConfigurationScope>();
            configurationScope1.Id = new EntityId(1);

            IApplication application1 = Substitute.For<IApplication>();
            application1.Id = new AppId(1);

            IApplication application2 = Substitute.For<IApplication>();
            application2.Id = new AppId(2);

            IUserProfile userProfile1 = Substitute.For<IUserProfile>();
            userProfile1.Id = new EntityId(1);

            List<IApplicationConfiguration> applicationConfigurations =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            applicationConfigurations[0].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[1].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[2].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[3].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[4].ConfigurationScopeId = configurationScope1.Id;

            applicationConfigurations[0].Id = new EntityId(0);
            applicationConfigurations[0].ApplicationId = application1.Id;
            applicationConfigurations[0].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[1].Id = new EntityId(1);
            applicationConfigurations[1].ApplicationId = application2.Id;
            applicationConfigurations[1].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[2].Id = new EntityId(2);
            applicationConfigurations[2].ApplicationId = application1.Id;
            applicationConfigurations[2].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[3].Id = new EntityId(3);
            applicationConfigurations[3].ApplicationId = application2.Id;
            applicationConfigurations[3].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[4].Id = new EntityId(4);
            applicationConfigurations[4].ApplicationId = application1.Id;
            applicationConfigurations[4].CreatedByUserProfileId = userProfile1.Id;

            List<IApplicationConfiguration> filteredApplicationConfigurations1 = TheProcess!.ApplyFilter(applicationConfigurations, configurationScope1, application1, userProfile1);
            Assert.That(filteredApplicationConfigurations1.Count, Is.EqualTo(3));

            List<IApplicationConfiguration> filteredApplicationConfigurations2 = TheProcess!.ApplyFilter(applicationConfigurations, configurationScope1, application2, userProfile1);
            Assert.That(filteredApplicationConfigurations2.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void Test_ApplyFilter_UserProfile()
        {
            IApplicationConfigurationProcess process = CreateBusinessProcess();

            IConfigurationScope configurationScope1 = Substitute.For<IConfigurationScope > ();
            configurationScope1.Id = new EntityId(1);

            IApplication application1 = Substitute.For<IApplication>();
            application1.Id = new AppId(1);

            IUserProfile userProfile1 = Substitute.For<IUserProfile>();
            userProfile1.Id = new EntityId(1);

            IUserProfile userProfile2 = Substitute.For<IUserProfile>();
            userProfile2.Id = new EntityId(2);

            List<IApplicationConfiguration> applicationConfigurations =
            [
                CreateEntity(process, 1),
                CreateEntity(process, 2),
                CreateEntity(process, 3),
                CreateEntity(process, 4),
                CreateEntity(process, 5),
            ];

            applicationConfigurations[0].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[1].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[2].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[3].ConfigurationScopeId = configurationScope1.Id;
            applicationConfigurations[4].ConfigurationScopeId = configurationScope1.Id;

            applicationConfigurations[0].Id = new EntityId(0);
            applicationConfigurations[0].ApplicationId = application1.Id;
            applicationConfigurations[0].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[1].Id = new EntityId(1);
            applicationConfigurations[1].ApplicationId = application1.Id;
            applicationConfigurations[1].CreatedByUserProfileId = userProfile2.Id;

            applicationConfigurations[2].Id = new EntityId(2);
            applicationConfigurations[2].ApplicationId = application1.Id;
            applicationConfigurations[2].CreatedByUserProfileId = userProfile1.Id;

            applicationConfigurations[3].Id = new EntityId(3);
            applicationConfigurations[3].ApplicationId = application1.Id;
            applicationConfigurations[3].CreatedByUserProfileId = userProfile2.Id;

            applicationConfigurations[4].Id = new EntityId(4);
            applicationConfigurations[4].ApplicationId = application1.Id;
            applicationConfigurations[4].CreatedByUserProfileId = userProfile1.Id;

            List<IApplicationConfiguration> filteredApplicationConfigurations1 = process.ApplyFilter(applicationConfigurations, configurationScope1, application1, userProfile1);
            Assert.That(filteredApplicationConfigurations1.Count, Is.EqualTo(3));

            List<IApplicationConfiguration> filteredApplicationConfigurations2 = process.ApplyFilter(applicationConfigurations, configurationScope1, application1, userProfile2);
            Assert.That(filteredApplicationConfigurations2.Count, Is.EqualTo(2));
        }
    }
}
