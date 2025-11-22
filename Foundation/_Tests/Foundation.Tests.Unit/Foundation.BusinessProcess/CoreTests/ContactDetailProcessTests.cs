//-----------------------------------------------------------------------
// <copyright file="ContactDetailProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for ContactDetailProcessTests
    /// </summary>
    [TestFixture]
    public class ContactDetailProcessTests : CommonBusinessProcessTests<IContactDetail, IContactDetailProcess, IContactDetailRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 24;
        protected override String ExpectedScreenTitle => "Contacts";
        protected override String ExpectedStatusBarText => "Number of Contacts:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Contact Type:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ContactType.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Parent Contact:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.ContactDetail.DisplayName;

        protected override String ExpectedComboBoxDisplayMember => FDC.ContactDetail.DisplayName;

        protected override IContactDetailRepository CreateRepository()
        {
            IContactDetailRepository retVal = Substitute.For<IContactDetailRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IContactDetailProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IContractProcess contractProcess = Substitute.For<IContractProcess>();
            IContactTypeProcess contactTypeProcess = Substitute.For<IContactTypeProcess>();
            INationalRegionProcess nationalRegionProcess = Substitute.For<INationalRegionProcess>();
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();

            SetComboBoxProperties(contractProcess);
            SetComboBoxProperties(contactTypeProcess);
            SetComboBoxProperties(nationalRegionProcess);
            SetComboBoxProperties(countryProcess);

            IContactDetailProcess process = new ContactDetailProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, contractProcess, contactTypeProcess, nationalRegionProcess, countryProcess);

            return process;
        }

        protected override IContactDetail CreateBlankEntity(Int32 entityId)
        {
            IContactDetail retVal = new FModels.ContactDetail();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContactDetail CreateEntity(IContactDetailProcess process, Int32 entityId)
        {
            IContactDetail retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ParentContactId = new EntityId(10);
            retVal.ContractId = new EntityId(2);
            retVal.ContactTypeId = new EntityId(3);
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.DisplayName = Guid.NewGuid().ToString();
            retVal.LegalName = Guid.NewGuid().ToString();
            retVal.BuildingName = Guid.NewGuid().ToString();
            retVal.Street1 = Guid.NewGuid().ToString();
            retVal.Street2 = Guid.NewGuid().ToString();
            retVal.Town = Guid.NewGuid().ToString();
            retVal.County = Guid.NewGuid().ToString();
            retVal.PostCode = Guid.NewGuid().ToString();
            retVal.NationalRegionId = new EntityId(4);
            retVal.CountryId = new EntityId(5);
            retVal.Telephone1 = Guid.NewGuid().ToString();
            retVal.Telephone2 = Guid.NewGuid().ToString();
            retVal.EmailAddress = new EmailAddress("a@b.co");

            return retVal;
        }

        protected override void CheckBlankEntry(IContactDetail entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IContactDetail entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IContactDetail entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IContactDetail entity1, IContactDetail entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.DisplayName, Is.EqualTo(entity1.DisplayName));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Parent Contact,Contract,Contact Type,Short Name,Display Name,Legal Name,Telephone 1,Telephone 2,Email Address,Building Name,Street 1,Street 2,Town,County,Post Code,National Region,Country" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,23c9b2ee-1423-487e-ba7b-ef8f0f9a63ad,00dd0a6f-4ae1-4203-a2c6-5af58fa0d73e,83bc6a63-602f-4735-bcfd-a208fa7a6cc8,c5b5494a-c172-47c7-b058-7bbb2bb173d5,9e109872-0fa5-4ae9-800b-dc7ca3b5ee2c,a@b.co,5a3912bf-f414-4a5a-aa60-2b15e6611612,4ecf22f5-ac9e-48e3-9548-8bf6d79c4468,d4f58636-ae24-48aa-8c37-f3a2a8393e99,2cba954c-90d8-43c5-887b-685075b12ecc,79b22a6c-4d0c-4f46-919c-24a52dae7384,10601f12-d85f-49e5-a796-8,4,5" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,0f7cf118-ef12-4f23-bae3-1496f62203eb,474b7d86-1c00-424f-acbe-775691a9391f,32829299-7eb5-493b-8ec7-46a40eec6c16,620eccf2-1623-450d-a315-a7a4a6a75974,ca578ad3-8f10-4614-97a6-75153ef28f04,a@b.co,93f5948d-3492-4b84-a8d7-ba97ca2684ad,ac5d100c-f927-4a5a-9cd5-6784b499d3b2,60345b1d-c107-45fc-97b7-2e822c11081b,a9374e22-55bb-4b50-9060-60c0cdde7b29,e9c24621-8159-4d8f-8ade-e8e8a6f2bd0d,1eacf708-3fd0-452d-9a04-2,4,5" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,76363ab7-5051-4057-bda8-e6431143e0d7,3f062dcf-0385-4ba5-8a45-fa5a06fa8807,3983a551-b2a4-4d1b-83c2-0be1148f6df1,3cb3f4b4-1920-43dd-8a5f-8fdcb9070ffd,a3847302-b4d2-4205-9c22-1be12622bc15,a@b.co,7caa2c7d-5826-4d4c-b8f1-92afa39f2d4e,f2e231f4-8fa0-48fc-9bb5-8793b80c98e4,5269f8d1-fa79-4177-9654-bc1773f853b2,9f2b9710-b7b2-4f70-8c5f-f16487d1be33,565ea488-48a2-4e6d-be1b-a909c2cfd66a,e7d00dc9-7e2a-4c8c-b97a-8,4,5" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,fcb9268b-2711-4226-a282-f15216cf5dfc,04f4a9b4-ab08-4512-886d-a35ba9a676b1,89c59d1d-6f7d-4d29-8e15-ac1954cd3315,acf22df3-9230-4225-a9bc-15ba736320b3,af08a605-707a-45df-80ce-0fc8122118a4,a@b.co,bdf7659f-505f-45e7-a412-1ce6ad239e80,45f7fdef-6964-444d-9564-8f022e8e8fcd,ba22f5ae-b415-496b-9f65-2856935e3bd9,2161d175-2509-4d75-9d65-37634adbbbbc,16f138a9-515c-43ac-a240-fc4748945256,5cadc86f-cf81-448c-a138-3,4,5" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,67b5f18d-667e-402d-ae2b-e4dfeaebf755,21246974-78f5-4bcc-8695-6ef2684d4be6,6160dbff-8983-4ed5-a3d2-3493020a764a,8ec70744-7401-4037-b3a7-069f9704e6e2,83282c45-eedc-43b4-942a-a945ff52aee0,a@b.co,4b256aa5-7a0b-4bb2-87c0-c3f534be7451,5672a02e-c651-4dd5-b26b-41fa7c13f6fc,f3285510-42aa-4ec9-baa7-22334d23f734,260a461b-9eeb-4c24-bfd8-cd336929a50a,202576fa-87a8-4e3f-8a81-0d74a7cd6765,e6b875cd-bdfe-40a2-aa8d-9,4,5" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,0dba18fa-ee67-42da-bccf-4bf20ad0f439,6b367df1-83f7-4512-86a6-d674ee3a49d1,b971e7cb-7ac6-46e3-9400-0084451ea18d,9d9f30c5-bba6-4eba-a276-30cad8675bdd,8c1ca700-5ae4-4991-8951-56a8165a619b,a@b.co,2da629b1-de2c-4b7f-aafb-d711aa829047,fa1f9525-c945-45f2-bafb-f35d20048137,b51a475c-2af3-4416-8fc2-11736e69c9a2,aeacc682-cfa6-4f5a-ac1b-99a9d0372fc1,c0f344a0-e02c-4952-b32e-ae5c24935445,a54f0e3a-8792-44a7-9e2e-2,4,5" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,9edb1234-4065-408f-941f-3e5c2e9f6a5f,a5821913-49ca-4be2-b6ed-c873c875c17f,d0f9d13a-f623-4494-b833-0ca25d1c70c0,9d18e718-fca1-480c-a3ff-2475bb793a68,01fc59e2-423d-47a9-a22b-d513406c8c9e,a@b.co,bb4e9759-d778-4c61-9a58-c0e7f9bd621a,566d39a8-b88d-4e0f-8644-f12d45122eec,3f16f46a-a5dd-460b-9b20-e5a7e90e53b7,034a5e7e-6f36-4f23-8c5f-3563cb3dad2d,9cb94ecb-9997-4280-aac4-772b96e8c2b5,511ffd33-d166-4592-b7c7-1,4,5" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,5bb75a31-758e-4b0a-869a-250c0f5f27a7,48724cbe-d853-4f95-9c58-48fd88ede36e,87ddd3f8-2013-4831-acae-39cf3df60778,cf8042ce-5146-4ef8-9bd9-61436811f088,720b782a-0e6b-4950-b846-0d00974649e4,a@b.co,bac79ab9-a669-440c-9309-49eec9bb6d38,b922f4a3-5135-438d-a633-a12556818281,2ee3c92a-25be-4d2a-83c4-e1a2b36659a5,1efb966a-891b-4269-ae04-e2d1addd9144,e3998edd-24e5-41a8-ba20-7ba40f2e581f,b76041a3-a96e-4f91-a39d-4,4,5" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,7df1b26e-78d5-463a-8fa7-6403b8622a66,6bb133ea-762d-458a-a22f-5c6db0b3edbe,7a07c1fd-d0ae-4b46-9f16-fd469416175a,e3fc901a-6b46-4ac7-9279-4708e3fa001f,cf0d8db4-aff8-4a88-b9b5-8be168cfd6c3,a@b.co,db909d9e-1286-4f8a-adc4-df6f0dd5c011,910136a6-8bcc-43d3-84a9-043dd3e28615,f475fbe3-e68b-412b-964e-3afa482c5c6b,8624daa0-a161-412e-8dc3-37da4498ac53,90cd1438-802f-4eb4-8ed7-9eb44b84956d,c6536f41-d96f-48c2-9bd5-4,4,5" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,2,3,93a63120-3685-4939-a59d-d337c0b89b8d,ef536440-64b5-4ab0-94f1-8f01e533fafe,4e6f147a-f9e9-4f2c-83a1-603804081162,f2622db3-c56f-4387-ba87-d01c324d219f,a5407a50-d324-4d28-8ea1-f53a882d4a7c,a@b.co,9c1d1914-b092-4ccb-994f-713b49728ff4,8b8b1f24-6e71-4155-b533-a8700f74dbd5,77749ca3-8084-44d8-8767-36c4ff775c94,06a3d41a-a2a3-48c7-9a37-ed8b01187c78,1de84f50-1302-480a-a8b2-229295d4a00b,6f89a3f0-7012-47ef-96dd-0,4,5" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IContactDetail entity)
        {
            entity.DisplayName += "Updated";
            entity.ShortName += "Updated";
        }

        [TestCase]
        public void Test_ValidateEntity()
        {
            IContactDetail contactDetail = CreateEntity(TheProcess!, 1);
            contactDetail.EmailAddress = new EmailAddress(new String('A', 150) + '@' + new String('B', 250));

            String aggregateErrorMessage = "One or more errors occurred. (The field EmailAddress must be a string or array type with a maximum length of '320'.)";
            String validationErrorMessage = "The field EmailAddress must be a string or array type with a maximum length of '320'.";

            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                TheProcess!.ValidateEntity(contactDetail);
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(aggregateErrorMessage));

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException, Is.TypeOf<AggregateException>());

            ValidationException validationException = (ValidationException)actualException.InnerExceptions[0];
            Assert.That(validationException.Message, Is.EqualTo(validationErrorMessage));
        }

        [TestCase]
        public void Test_MakeListOfParentContacts()
        {
            List<IContactDetail> contacts =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            contacts[0].ParentContactId = new EntityId(0);
            contacts[1].ParentContactId = new EntityId(0);
            contacts[2].ParentContactId = new EntityId(0);
            contacts[3].ParentContactId = new EntityId(0);
            contacts[4].ParentContactId = new EntityId(0);

            List<IContactDetail> parentContactDetails = TheProcess!.MakeListOfParentContacts(contacts);
            Assert.That(parentContactDetails.Count, Is.EqualTo(0));

            Int32 counter = 1;
            foreach (IContactDetail contact in contacts)
            {
                contact.Id = new EntityId(counter);

                counter++;
                contact.ParentContactId = new EntityId(counter);
            }

            parentContactDetails = TheProcess!.MakeListOfParentContacts(contacts);
            Assert.That(parentContactDetails.Count, Is.EqualTo(4));

            contacts[1].ParentContactId = new EntityId(1);
            contacts[2].ParentContactId = new EntityId(2);
            contacts[3].ParentContactId = new EntityId(3);
            contacts[4].ParentContactId = new EntityId(1);

            parentContactDetails = TheProcess!.MakeListOfParentContacts(contacts);
            Assert.That(parentContactDetails.Count, Is.EqualTo(3));
        }

        [TestCase]
        public void Test_ApplyFilter_ContactType()
        {
            IContactType contactType1 = Substitute.For<IContactType>();
            contactType1.Id = new EntityId(1);

            IContactType contactType2 = Substitute.For<IContactType>();
            contactType2.Id = new EntityId(2);

            const IContactDetail? parentContactDetail = null;

            List<IContactDetail> contacts =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            contacts[0].ParentContactId = new EntityId(0);
            contacts[1].ParentContactId = new EntityId(0);
            contacts[2].ParentContactId = new EntityId(0);
            contacts[3].ParentContactId = new EntityId(0);
            contacts[4].ParentContactId = new EntityId(0);

            contacts[0].Id = new EntityId(0);
            contacts[0].ContactTypeId = contactType1.Id;
            contacts[0].ParentContactId = new EntityId(1);

            contacts[1].Id = new EntityId(1);
            contacts[1].ContactTypeId = contactType2.Id;
            contacts[1].ParentContactId = new EntityId(2);

            contacts[2].Id = new EntityId(2);
            contacts[2].ContactTypeId = contactType1.Id;
            contacts[2].ParentContactId = new EntityId(3);

            contacts[3].Id = new EntityId(3);
            contacts[3].ContactTypeId = contactType2.Id;
            contacts[3].ParentContactId = new EntityId(4);

            contacts[4].Id = new EntityId(4);
            contacts[4].ContactTypeId = contactType1.Id;
            contacts[4].ParentContactId = new EntityId(5);

            List<IContactDetail> filteredContacts1 = TheProcess!.ApplyFilter(contacts, contactType1, parentContactDetail);
            Assert.That(filteredContacts1.Count, Is.EqualTo(3));

            List<IContactDetail> filteredContacts2 = TheProcess!.ApplyFilter(contacts, contactType2, parentContactDetail);
            Assert.That(filteredContacts2.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void Test_ApplyFilter_ParentContact()
        {
            const IContactType? contactType1 = null;

            IContactDetail parentContactDetail1 = CreateEntity(TheProcess!, 1);
            parentContactDetail1.Id = new EntityId(1);

            IContactDetail parentContactDetail2 = CreateEntity(TheProcess!, 2);
            parentContactDetail2.Id = new EntityId(2);

            List<IContactDetail> contacts =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            contacts[0].ParentContactId = new EntityId(0);
            contacts[1].ParentContactId = new EntityId(0);
            contacts[2].ParentContactId = new EntityId(0);
            contacts[3].ParentContactId = new EntityId(0);
            contacts[4].ParentContactId = new EntityId(0);

            contacts[0].Id = new EntityId(0);
            contacts[0].ContactTypeId = new EntityId(1);
            contacts[0].ParentContactId = parentContactDetail1.Id;

            contacts[1].Id = new EntityId(1);
            contacts[1].ContactTypeId = new EntityId(2);
            contacts[1].ParentContactId = parentContactDetail2.Id;

            contacts[2].Id = new EntityId(2);
            contacts[2].ContactTypeId = new EntityId(1);
            contacts[2].ParentContactId = parentContactDetail1.Id;

            contacts[3].Id = new EntityId(3);
            contacts[3].ContactTypeId = new EntityId(2);
            contacts[3].ParentContactId = parentContactDetail2.Id;

            contacts[4].Id = new EntityId(4);
            contacts[4].ContactTypeId = new EntityId(1);
            contacts[4].ParentContactId = parentContactDetail1.Id;

            List<IContactDetail> filteredContacts1 = TheProcess!.ApplyFilter(contacts, contactType1, parentContactDetail1);
            Assert.That(filteredContacts1.Count, Is.EqualTo(3));

            List<IContactDetail> filteredContacts2 = TheProcess!.ApplyFilter(contacts, contactType1, parentContactDetail2);
            Assert.That(filteredContacts2.Count, Is.EqualTo(2));
        }
    }
}
