//-----------------------------------------------------------------------
// <copyright file="ActiveDirectoryUserProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Stg;
using Foundation.Interfaces;

using NSubstitute;

using System.ComponentModel.DataAnnotations;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.StgTests
{
    /// <summary>
    /// Summary FullName for ActiveDirectoryUserProcessTests
    /// </summary>
    [TestFixture]
    public class ActiveDirectoryUserProcessTests : CommonBusinessProcessTests<IActiveDirectoryUser, IActiveDirectoryUserProcess, IActiveDirectoryUserRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 3;
        protected override String ExpectedScreenTitle => "Active Directory Users";
        protected override String ExpectedStatusBarText => "Number of Active Directory Users:";

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override String ExpectedAction1Name => "Save to Staging";
        protected override Boolean ExpectedHasOptionalAction2 => true;
        protected override String ExpectedAction2Name => "Sync User Profiles";
        protected override String ExpectedComboBoxDisplayMember => FDC.ActiveDirectoryUser.FullName;

        protected override IActiveDirectoryUserRepository CreateRepository()
        {
            IActiveDirectoryUserRepository dataAccess = Substitute.For<IActiveDirectoryUserRepository>();

            return dataAccess;
        }

        protected override IActiveDirectoryUserProcess CreateBusinessProcess()
        {
            IActiveDirectoryUserProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IActiveDirectoryUserProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IActiveDirectoryUserProcess process = new ActiveDirectoryUserProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IActiveDirectoryUser CreateBlankEntity(IActiveDirectoryUserProcess process, Int32 entityId)
        {
            IActiveDirectoryUser retVal = CoreInstance.IoC.Get<IActiveDirectoryUser>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IActiveDirectoryUser CreateEntity(IActiveDirectoryUserProcess process, Int32 entityId)
        {
            IActiveDirectoryUser retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ObjectSId = Guid.NewGuid().ToString();
            retVal.Name = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IActiveDirectoryUser entity)
        {
            Assert.That(entity.FullName, Is.EqualTo(ExpectedNullText));
        }

        protected override void CheckAllEntry(IActiveDirectoryUser entity)
        {
            Assert.That(entity.FullName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IActiveDirectoryUser entity)
        {
            Assert.That(entity.FullName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IActiveDirectoryUser entity1, IActiveDirectoryUser entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ObjectSId, Is.EqualTo(entity1.ObjectSId));
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.FullName, Is.EqualTo(entity1.FullName));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Object SId,User name,Full name" + Environment.NewLine;
            retVal += "417d8cc7-7956-499d-9189-96c5ade1be50,890edecb-826f-4cdc-91c6-f3adcad33e12,4dffca2e-d668-4474-ab2c-61e453f71695" + Environment.NewLine;
            retVal += "05c5c236-0629-4100-8942-0258c619aa9d,807b7f4f-c5f2-43d5-ba45-d3d494214840,952a1d04-0516-4afd-8f0c-74bd05e241a5" + Environment.NewLine;
            retVal += "4d5deb31-98db-4b42-86c7-6b0122d7fa51,1fbd7540-9475-4d53-9300-814aa6db9a20,edc18dcf-95ea-41cd-842c-d55ad00ca3ea" + Environment.NewLine;
            retVal += "5a8df82f-b07b-45e6-8bd1-3cbe59a4019f,d2c433cb-59fc-4644-b886-abed7052388c,38ac3006-6e2d-4c58-9226-0f082a4e2108" + Environment.NewLine;
            retVal += "d64f4378-a13a-4be4-b1ed-54638d012c75,57b9b9f8-53b9-4615-bf1d-83701a7e01af,70572818-3be3-40ff-88f4-21c59a4e3f7f" + Environment.NewLine;
            retVal += "6dd9b086-fd68-45b2-aee8-e2adcb7e65b9,ab078690-315a-4830-bad8-cd3a58642448,94895910-ecf0-48f0-b5d9-d22a8d2a0f26" + Environment.NewLine;
            retVal += "dbebbacd-36ff-4e51-a786-629f81cf8bfb,d021263c-bcda-400e-ac1e-5a67c59ae5e3,fd5d4ddc-6120-44c3-ba32-fc65fca7f89b" + Environment.NewLine;
            retVal += "c2d6fad2-35ba-4061-b3fe-649a3c273828,5efb59a2-057c-4d8e-a627-0c41e6a06e3b,e6bd6aa5-7f4d-457b-8bbc-8f47a678f148" + Environment.NewLine;
            retVal += "c34070a7-58dd-4d3b-a4a2-33d818c2c6bb,0ae75204-b479-4468-9f8e-8a2b50ff5df9,d88e536d-b5b6-4a82-a486-390dede254ea" + Environment.NewLine;
            retVal += "de64ee88-4a80-4290-91fe-9aa8de724e2c,7dee7b94-1411-46a1-8ef2-298a6ee96deb,f3f13199-50fb-4ea0-ab4e-32f61ed5adda" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IActiveDirectoryUser entity)
        {
            throw new NotImplementedException("This method should not be called during the test");
        }

        [TestCase]
        public override void Test_Update_Entity()
        {
            // Does nothing
            // This Test is not valid for ActiveDirectoryUser
        }
    }
}
