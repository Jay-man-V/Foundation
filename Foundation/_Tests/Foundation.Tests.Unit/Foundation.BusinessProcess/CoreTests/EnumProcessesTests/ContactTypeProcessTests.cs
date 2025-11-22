//-----------------------------------------------------------------------
// <copyright file="ContactTypeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ContactTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ContactTypeProcessTests : CommonBusinessProcessTests<IContactType, IContactTypeProcess, IContactTypeRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Contact Types";
        protected override String ExpectedStatusBarText => "Number of Contact Types:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ContactType.Name;

        protected override IContactTypeRepository CreateRepository()
        {
            IContactTypeRepository retVal = Substitute.For<IContactTypeRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IContactTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IContactTypeProcess process = new ContactTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IContactType CreateBlankEntity(Int32 entityId)
        {
            IContactType retVal = new FModels.ContactType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContactType CreateEntity(IContactTypeProcess process, Int32 entityId)
        {
            IContactType retVal = CreateBlankEntity(entityId);

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IContactType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IContactType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IContactType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IContactType entity1, IContactType entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name,Description" + Environment.NewLine;
            retVal += "1,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,95ea8aca-cf9b-4f64-9502-9e0bb8cb6472,bf881e81-22d3-4923-a4e5-5b0bd275e9f7" + Environment.NewLine;
            retVal += "2,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b3dcd0dc-cdc9-4698-babe-cc461f16c604,74e6270f-5dc3-42df-a836-034999a71ce5" + Environment.NewLine;
            retVal += "3,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ecc5209a-808b-423a-a88f-cccd88292e67,5a664387-c1fc-44f6-8d89-51b830ebb057" + Environment.NewLine;
            retVal += "4,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9570e9f0-bc30-495a-9868-10e039132562,fe427d9f-9bcd-4c3d-b767-932a98591e8d" + Environment.NewLine;
            retVal += "5,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1063ea3d-8063-43f4-98c2-ea1095f3d641,fbe5d1a3-f7a5-4d0a-bbc7-4451a448e232" + Environment.NewLine;
            retVal += "6,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,33e8f8a2-482c-42ff-a449-085af0ae23b3,340042ea-e461-416e-ab63-07e73c75db6d" + Environment.NewLine;
            retVal += "7,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,302433c2-d6fb-4f82-90ba-8e86b1cab9c9,84af9802-1a42-4bce-b0f2-ce8dbf0d41a6" + Environment.NewLine;
            retVal += "8,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,33395128-626a-4859-8d85-3f874721902e,0eebf432-de18-4c92-989e-213aeea7cc75" + Environment.NewLine;
            retVal += "9,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,824cd28c-5ae2-4e31-bb6d-4313a6fc8e61,001953ae-542c-44d2-acf9-f79a84ad5b11" + Environment.NewLine;
            retVal += "10,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c8ffcf70-55b1-405e-a95b-def9f998f7ac,baf7a1ff-46a4-4daa-a493-350260ca0017" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IContactType entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }
    }
}
