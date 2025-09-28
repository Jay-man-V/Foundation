//-----------------------------------------------------------------------
// <copyright file="ContractTypeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ContractTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ContractTypeProcessTests : CommonBusinessProcessTests<IContractType, IContractTypeProcess, IContractTypeRepository>
    {
        protected override int ColumnDefinitionsCount => 9;
        protected override string ExpectedScreenTitle => "Contract Types";
        protected override string ExpectedStatusBarText => "Number of Contract Types:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ContractType.Description;

        protected override IContractTypeRepository CreateRepository()
        {
            IContractTypeRepository dataAccess = Substitute.For<IContractTypeRepository>();

            return dataAccess;
        }

        protected override IContractTypeProcess CreateBusinessProcess()
        {
            IContractTypeProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IContractTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IContractTypeProcess process = new ContractTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IContractType CreateBlankEntity(IContractTypeProcess process, Int32 entityId)
        {
            IContractType retVal = new FModels.ContractType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContractType CreateEntity(IContractTypeProcess process, Int32 entityId)
        {
            IContractType retVal = CreateBlankEntity(process, entityId);

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Convert.ToChar(entityId + 64).ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IContractType entity)
        {
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IContractType entity)
        {
            Assert.That(entity.Description, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IContractType entity)
        {
            Assert.That(entity.Description, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IContractType entity1, IContractType entity2)
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
            retVal += "1,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,A,a119a703-757e-46a9-a49b-bf9b934f187c" + Environment.NewLine;
            retVal += "2,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,B,61552fac-e69d-4336-957a-6bd76bae70f1" + Environment.NewLine;
            retVal += "3,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,C,e597643b-6a2b-4cdb-8011-b2ba5ab49bf4" + Environment.NewLine;
            retVal += "4,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,D,60a3d8f5-9aac-4cb6-89e9-f434724207d7" + Environment.NewLine;
            retVal += "5,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,E,51def955-83b5-490b-ad85-649f1de1cfa7" + Environment.NewLine;
            retVal += "6,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,F,2853b1e9-2fe3-4049-99fe-e8aea34defe4" + Environment.NewLine;
            retVal += "7,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,G,8b6a4726-3ece-451a-bb5b-f50a445b8bac" + Environment.NewLine;
            retVal += "8,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,H,ee38f9b2-577b-40a6-bef0-91b4a5548fa5" + Environment.NewLine;
            retVal += "9,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,I,e2a2a148-3875-41c2-8620-b419d53ca92a" + Environment.NewLine;
            retVal += "10,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,J,a652ff76-ea65-4103-9e6d-d0d0550208ce" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IContractType entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }
    }
}
