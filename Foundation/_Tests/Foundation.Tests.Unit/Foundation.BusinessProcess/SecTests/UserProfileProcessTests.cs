//-----------------------------------------------------------------------
// <copyright file="UserProfileProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for UserProfileProcessTests
    /// </summary>
    [TestFixture]
    public class UserProfileProcessTests : CommonBusinessProcessTests<IUserProfile, IUserProfileProcess, IUserProfileRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 12;
        protected override String ExpectedScreenTitle => "User Profiles";
        protected override String ExpectedStatusBarText => "Number of User Profiles:";

        protected override String ExpectedComboBoxDisplayMember => FDC.UserProfile.DisplayName;

        protected override IUserProfileRepository CreateRepository()
        {
            IUserProfileRepository dataAccess = Substitute.For<IUserProfileRepository>();

            return dataAccess;
        }

        protected override IUserProfileProcess CreateBusinessProcess()
        {
            IUserProfileProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IUserProfileProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IUserProfileProcess process = new UserProfileProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!);

            return process;
        }

        protected override IUserProfile CreateBlankEntity(IUserProfileProcess process, Int32 entityId)
        {
            IUserProfile retVal = CoreInstance.IoC.Get<IUserProfile>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IUserProfile CreateEntity(IUserProfileProcess process, Int32 entityId)
        {
            IUserProfile retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.DisplayName = Guid.NewGuid().ToString();
            retVal.DomainName = Guid.NewGuid().ToString();
            retVal.Username = Guid.NewGuid().ToString();
            retVal.ExternalKeyId = Guid.NewGuid().ToString();
            retVal.ContactDetailId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IUserProfile entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedNullText));
            Assert.That(entity.Username, Is.EqualTo(ExpectedNullText));
        }

        protected override void CheckAllEntry(IUserProfile entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IUserProfile entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IUserProfile entity1, IUserProfile entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.DisplayName, Is.EqualTo(entity1.DisplayName));
            Assert.That(entity2.Username, Is.EqualTo(entity1.Username));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Domain name,User name,Display name,Is\r\nSystem\r\nSupport,External Key Id" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6fdfea1c-2b5d-46e7-8e09-979c6450eee0,e032b18d-d80a-4405-9f45-3e808e9d7a6b,290e6cea-cfe8-4264-8582-7034fadca593,False,869d10c8-489c-4e65-bf71-955611c61a6f" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1e655109-57e0-40dd-848e-5ef9912878de,92f79319-7d23-49f9-8612-0a70f10124a1,514ab98d-7c83-4a35-b489-c5b1463d5942,False,e8f48276-5b8a-4282-b039-a64923724ae2" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,cdf77e95-b79a-4d7a-b119-b23d495503df,03b66d91-20c9-4d78-afa1-3dc14611348a,1a4c4781-763c-4670-91fc-e7d031ee0a19,False,f1d56cc2-4db3-4303-bf1d-21de9f9171ba" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,adad66fd-f260-4790-b2d3-6c6249432521,08817825-8993-401e-a228-096a3b4d29c8,afc08d78-f02e-4e2a-8615-5a6f8d79900d,False,0ad58dee-3d53-488c-b3fd-f1ea5d9eb1c3" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c1890108-ae56-4b67-84f2-b0554631d741,fcbf9f11-cea9-4831-af1d-9788f528f8a0,fc6e1768-2748-43ca-99e9-47839245f7ec,False,3ad30ed4-9b7e-4980-82cd-d99005562f88" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,cacb3e97-d345-4110-b365-884ac47a9b07,e2d1f088-0268-4182-8114-54cc7769db6e,0cec3389-a3fa-4394-9793-a1011ec640c6,False,17226a27-4cbe-404f-a7e1-0e715baab315" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2e4030e0-5ae7-44c8-928e-11eaf10186d7,5039f7ed-f19c-4127-9050-f291c40ef546,76422c6d-2202-4606-bd8c-a72a2a43a5c3,False,a62b1605-816d-4c67-ba3d-d45b85fd877d" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b05c36c5-548d-428d-a41b-82d5c9678117,1eb0e49c-7fe3-419d-b73e-9ad2ee9b20d6,b9d048b5-4fc2-4dc7-802b-d79b9dc966ea,False,00b1a120-3da9-4949-8d2f-421b1d53cd06" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c88e37ce-0c9a-4a41-a29a-c7a52bb74d28,482ed9e3-e8f2-4836-8a7a-73f75881ca72,e0a5eee9-91bf-48f3-ae4f-4c2e6698d975,False,36cc4ac7-ea3d-4fc4-b938-5709760001fd" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,11c18e36-5da3-46bf-97d2-f6b653fa8f4a,4a4b4d3e-0208-43b1-91e6-84e98a41efca,1d96765d-2099-4c28-9050-343b4a5c023c,False,6197dd6c-bf1c-455b-bc31-48ef47745f79" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IUserProfile entity)
        {
            entity.DisplayName += "Updated";
            entity.Username += "Updated";
        }

        [TestCase]
        public void Test_GetLoggedOnUserProfile()
        {
            AppId appId = new AppId(1);

            IUserProfile expectedUserProfile = CoreInstance.IoC.Get<IUserProfile>();
            expectedUserProfile.Id = new EntityId(1);
            expectedUserProfile.DisplayName = "Unit Testing user name";
            expectedUserProfile.ExternalKeyId = Guid.NewGuid().ToString();
            expectedUserProfile.IsSystemSupport = false;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<String>(), Arg.Any<String>()).Returns(expectedUserProfile);

            IUserProfile actualUserProfile = TheProcess!.GetLoggedOnUserProfile(appId);

            Assert.That(actualUserProfile.Id, Is.EqualTo(expectedUserProfile.Id));
            Assert.That(actualUserProfile.DisplayName, Is.EqualTo(expectedUserProfile.DisplayName));
            Assert.That(actualUserProfile.ExternalKeyId, Is.EqualTo(expectedUserProfile.ExternalKeyId));
            Assert.That(actualUserProfile.IsSystemSupport, Is.EqualTo(expectedUserProfile.IsSystemSupport));
        }

        [TestCase]
        public void Test_GetUserProfile_UserProfileId()
        {
            AppId appId = new AppId(1);
            EntityId userProfileId = new EntityId(1);

            IUserProfile expectedUserProfile = CoreInstance.IoC.Get<IUserProfile>();
            expectedUserProfile.Id = new EntityId(1);
            expectedUserProfile.DisplayName = "Unit Testing user name";
            expectedUserProfile.ExternalKeyId = Guid.NewGuid().ToString();
            expectedUserProfile.IsSystemSupport = false;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<EntityId>()).Returns(expectedUserProfile);

            IUserProfile? actualUserProfile = TheProcess!.GetUserProfile(appId, userProfileId);

            Assert.That(actualUserProfile!.Id, Is.EqualTo(expectedUserProfile.Id));
            Assert.That(actualUserProfile.DisplayName, Is.EqualTo(expectedUserProfile.DisplayName));
            Assert.That(actualUserProfile.ExternalKeyId, Is.EqualTo(expectedUserProfile.ExternalKeyId));
            Assert.That(actualUserProfile.IsSystemSupport, Is.EqualTo(expectedUserProfile.IsSystemSupport));
        }

        [TestCase]
        public void Test_GetUserProfile_Username()
        {
            AppId appId = new AppId(1);
            String domainName = $"{UserSecuritySupport.UnitTestAccountDomain}";
            String username = $"{UserSecuritySupport.UnitTestAccountUserName}";

            IUserProfile expectedUserProfile = CoreInstance.IoC.Get<IUserProfile>();
            expectedUserProfile.Id = new EntityId(1);
            expectedUserProfile.DisplayName = "Unit Testing user name";
            expectedUserProfile.ExternalKeyId = Guid.NewGuid().ToString();
            expectedUserProfile.IsSystemSupport = false;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<String>(), Arg.Any<String>()).Returns(expectedUserProfile);

            IUserProfile? actualUserProfile = TheProcess!.GetUserProfile(appId, domainName, username);

            Assert.That(actualUserProfile!.Id, Is.EqualTo(expectedUserProfile.Id));
            Assert.That(actualUserProfile.DisplayName, Is.EqualTo(expectedUserProfile.DisplayName));
            Assert.That(actualUserProfile.ExternalKeyId, Is.EqualTo(expectedUserProfile.ExternalKeyId));
            Assert.That(actualUserProfile.IsSystemSupport, Is.EqualTo(expectedUserProfile.IsSystemSupport));
        }

        [TestCase]
        public void Test_GetUserProfile_Exception()
        {
            AppId appId = new AppId(1);
            String domainName = $"{UserSecuritySupport.UnitTestAccountDomain}";
            String username = $"{UserSecuritySupport.UnitTestAccountUserName}";

            IUserProfile? expectedUserProfile = null;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<String>(), Arg.Any<String>()).Returns(expectedUserProfile);

            String errorMessage = $"Unable to locate the User Profile with details: Application Id: '{appId.TheAppId}'. Logon Domain: '{domainName}'. User name: '{username}'.";

            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TheProcess!.GetLoggedOnUserProfile(appId);
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_SyncActiveDirectoryUserDataFromStaging()
        {
            TheRepository!.SyncActiveDirectoryUserDataFromStaging(Arg.Any<IUserProfile>());

            TheProcess!.SyncActiveDirectoryUserDataFromStaging();
        }
    }
}
