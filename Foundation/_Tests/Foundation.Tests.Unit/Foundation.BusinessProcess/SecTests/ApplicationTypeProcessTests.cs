//-----------------------------------------------------------------------
// <copyright file="ApplicationTypeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Sec;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for ApplicationTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationTypeProcessTests : CommonBusinessProcessTests<IApplicationType, IApplicationTypeProcess, IApplicationTypeRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Application Types";
        protected override String ExpectedStatusBarText => "Number of Application Types:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ApplicationType.Name;


        protected override IApplicationTypeRepository CreateRepository()
        {
            IApplicationTypeRepository dataAccess = Substitute.For<IApplicationTypeRepository>();

            return dataAccess;
        }

        protected override IApplicationTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationTypeProcess process = new ApplicationTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IApplicationType CreateBlankEntity(IApplicationTypeProcess process, Int32 entityId)
        {
            IApplicationType retVal = new FModels.ApplicationType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationType CreateEntity(IApplicationTypeProcess process, Int32 entityId)
        {
            IApplicationType retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IApplicationType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IApplicationType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IApplicationType entity1, IApplicationType entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0b7c419c-0adc-47aa-884c-597030e1e569,ead531c2-e317-488c-98cc-62efa160ded7" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,935c2e55-c165-45f2-b087-7e01e75f5ee1,334417de-5fb5-4a82-9918-6927cba85171" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,99c1cad3-b0cd-4cc3-80c3-6b4e0f02c123,5284616a-6429-4cd0-b45f-390156af2918" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4fefbbc0-5077-4547-9e70-84326c9ec64b,b10da2b8-ee16-48b9-966c-259280dbf075" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0410394c-5fc7-4ac9-b1b8-163f0e2147f7,d7d790d0-446f-47a4-9fad-8a2ddff85089" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f7e3ce3b-6d66-4c8b-ae87-7c4b0f783b85,c31db92d-30a4-42c1-9871-9d7a1266864f" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,13c4f8e9-fd51-49f4-8612-0fd960ef0d4d,6a58902b-3542-40d5-af6e-8531b54df274" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,55170afd-3e9a-4f42-adc0-250a86ba30c1,9b4d3588-60c3-4add-b6c8-834efa5d4adf" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,bc1f7534-94a0-4191-bf2c-81e8808dcdcf,2000757b-b817-4a47-b363-c44112920d24" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b0e76be1-fe07-44f7-bac8-8833c4211d5f,c9c5617c-a219-4720-a88a-638f8a9ba49a" + Environment.NewLine;

            return retVal;
        }
        protected override void UpdateEntityProperties(IApplicationType entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }
    }
}
