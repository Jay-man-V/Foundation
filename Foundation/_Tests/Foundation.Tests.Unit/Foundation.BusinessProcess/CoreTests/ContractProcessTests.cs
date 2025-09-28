//-----------------------------------------------------------------------
// <copyright file="ContractProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for ContractProcessTests
    /// </summary>
    [TestFixture]
    public class ContractProcessTests : CommonBusinessProcessTests<IContract, IContractProcess, IContractRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 13;
        protected override String ExpectedScreenTitle => "Contracts";
        protected override String ExpectedStatusBarText => "Number of Contracts:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Contract Type:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ContractType.Description;

        protected override string ExpectedComboBoxDisplayMember => FDC.Contract.ShortName;

        private readonly DateTime _contractStartDate = new DateTime(2022, 01, 01, 0, 0, 0);
        private readonly DateTime _contractEndDate = new DateTime(2022, 12, 31, 23, 59, 59);

        protected override IContractRepository CreateRepository()
        {
            IContractRepository dataAccess = Substitute.For<IContractRepository>();

            return dataAccess;
        }

        protected override IContractProcess CreateBusinessProcess()
        {
            IContractProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IContractProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IContractTypeProcess contractTypeProcess = Substitute.For<IContractTypeProcess>();

            CopyProperties(contractTypeProcess, CoreInstance.IoC.Get<IContractTypeProcess>());

            IContractProcess process = new ContractProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, contractTypeProcess);

            return process;
        }

        protected override IContract CreateBlankEntity(IContractProcess process, Int32 entityId)
        {
            IContract retVal = new FModels.Contract();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContract CreateEntity(IContractProcess process, Int32 entityId)
        {
            IContract retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ContractTypeId = new EntityId(1);
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = retVal.ShortName.Substring(0, 24);
            retVal.ContractReference = retVal.ShortName;
            retVal.StartDate = _contractStartDate;
            retVal.EndDate = _contractEndDate;

            return retVal;
        }

        protected override void CheckBlankEntry(IContract entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IContract entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IContract entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IContract entity1, IContract entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ContractTypeId, Is.EqualTo(entity1.ContractTypeId));
            Assert.That(entity2.StartDate, Is.EqualTo(entity1.StartDate));
            Assert.That(entity2.EndDate, Is.EqualTo(entity1.EndDate));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.FullName, Is.EqualTo(entity1.FullName));
            Assert.That(entity2.ContractReference, Is.EqualTo(entity1.ContractReference));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Type,Reference,Start Date,End Date,Short Name,Full Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,bf657023-0f37-4620-a2eb-c2d054017f67,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,bf657023-0f37-4620-a2eb-c2d054017f67,bf657023-0f37-4620-a2eb-" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,7b50896e-0a33-465d-9f48-396d23e3f6ba,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,7b50896e-0a33-465d-9f48-396d23e3f6ba,7b50896e-0a33-465d-9f48-" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,25c6f6dc-5d24-4f4f-b691-beb0eeaa0c8c,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,25c6f6dc-5d24-4f4f-b691-beb0eeaa0c8c,25c6f6dc-5d24-4f4f-b691-" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,e55eb15c-2dfc-4e23-b1b0-2095451cbbb0,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,e55eb15c-2dfc-4e23-b1b0-2095451cbbb0,e55eb15c-2dfc-4e23-b1b0-" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,4cf47814-cc27-41f1-82af-39722ec6968f,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,4cf47814-cc27-41f1-82af-39722ec6968f,4cf47814-cc27-41f1-82af-" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,a82a5e1a-2671-42b4-bd16-7269407a937a,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,a82a5e1a-2671-42b4-bd16-7269407a937a,a82a5e1a-2671-42b4-bd16-" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,b5a8c562-096a-4fc9-ad85-e1e8ed8c8836,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,b5a8c562-096a-4fc9-ad85-e1e8ed8c8836,b5a8c562-096a-4fc9-ad85-" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,8850a4b2-c58e-4388-b5a0-59576416e7d3,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,8850a4b2-c58e-4388-b5a0-59576416e7d3,8850a4b2-c58e-4388-b5a0-" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,4ed06295-301c-4a55-a6d8-556ee98f9b43,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,4ed06295-301c-4a55-a6d8-556ee98f9b43,4ed06295-301c-4a55-a6d8-" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2996392d-1cfb-4555-965f-74553e00a28d,2022-01-01T00:00:00.000,2022-12-31T23:59:59.000,2996392d-1cfb-4555-965f-74553e00a28d,2996392d-1cfb-4555-965f-" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IContract entity)
        {
            entity.ShortName += "Updated";
            entity.ContractReference += "Updated";
        }

        [TestCase]
        public void Test_ApplyFilter_ContractType()
        {
            List<IContract> contracts = new List<IContract>();

            IContractType contractType1 = CoreInstance.IoC.Get<IContractType>();
            contractType1.Id = new EntityId(1);

            IContractType contractType2 = CoreInstance.IoC.Get<IContractType>();
            contractType2.Id = new EntityId(2);

            contracts.Add(CreateEntity(TheProcess!, 1));
            contracts.Add(CreateEntity(TheProcess!, 2));
            contracts.Add(CreateEntity(TheProcess!, 3));
            contracts.Add(CreateEntity(TheProcess!, 4));
            contracts.Add(CreateEntity(TheProcess!, 5));

            contracts[0].Id = new EntityId(0);
            contracts[0].ContractTypeId = new EntityId(1);

            contracts[1].Id = new EntityId(1);
            contracts[1].ContractTypeId = new EntityId(2);

            contracts[2].Id = new EntityId(2);
            contracts[2].ContractTypeId = new EntityId(1);

            contracts[3].Id = new EntityId(3);
            contracts[3].ContractTypeId = new EntityId(2);

            contracts[4].Id = new EntityId(4);
            contracts[4].ContractTypeId = new EntityId(1);

            List<IContract> filteredContacts1 = TheProcess!.ApplyFilter(contracts, contractType1);
            Assert.That(filteredContacts1.Count, Is.EqualTo(3));

            List<IContract> filteredContacts2 = TheProcess!.ApplyFilter(contracts, contractType2);
            Assert.That(filteredContacts2.Count, Is.EqualTo(2));
        }
    }
}
