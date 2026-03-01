//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApprovalStatusProcessTests
    /// </summary>
    [TestFixture]
    public class ApprovalStatusProcessTests : CommonBusinessProcessTests<IApprovalStatus, IApprovalStatusProcess, IApprovalStatusRepository>
    {
        protected override int ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Approval Statuses";
        protected override String ExpectedStatusBarText => "Number of Approval Statuses:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ApprovalStatus.Code;

        protected override IApprovalStatusRepository CreateRepository()
        {
            IApprovalStatusRepository retVal = Substitute.For<IApprovalStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IApprovalStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApprovalStatusProcess process = new ApprovalStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IApprovalStatus CreateBlankEntity(Int32 entityId)
        {
            IApprovalStatus retVal = new FModels.ApprovalStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApprovalStatus CreateEntity(IApprovalStatusProcess process, Int32 entityId)
        {
            IApprovalStatus retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IApprovalStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IApprovalStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IApprovalStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IApprovalStatus entity1, IApprovalStatus entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortDescription, Is.EqualTo(entity1.ShortDescription));
            Assert.That(entity2.LongDescription, Is.EqualTo(entity1.LongDescription));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short Description,Long Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2ca2eabe-7,d7ad27d0-6e2d-43ad-9727-5b15ccb13d79,d7ad27d0-6e2d-43ad-9727-5b15ccb13d79" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,dc0459cd-5,25911a5e-5d53-4982-a0dc-2487b2f7ef50,25911a5e-5d53-4982-a0dc-2487b2f7ef50" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,17c594ea-1,d361c249-8b5d-40c3-aaa8-1d0122f413b6,d361c249-8b5d-40c3-aaa8-1d0122f413b6" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1e7bdb85-d,0bb6ee37-4ea3-472a-8055-b1adcae2517f,0bb6ee37-4ea3-472a-8055-b1adcae2517f" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4bf13630-e,f4d095b0-a7d6-447d-850e-ecf1cfaaf9be,f4d095b0-a7d6-447d-850e-ecf1cfaaf9be" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,16e8e1dd-5,a4ea4654-c511-4499-afe7-886f5f1ec23b,a4ea4654-c511-4499-afe7-886f5f1ec23b" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b765c9f2-1,e4a3d5db-9885-42cd-94c7-2742fd73744c,e4a3d5db-9885-42cd-94c7-2742fd73744c" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ba05c6cf-0,3dda0470-f0e3-41f5-9899-d30c8a4ecbb6,3dda0470-f0e3-41f5-9899-d30c8a4ecbb6" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e068690c-7,da8ef4c8-1b2e-4a26-9fd0-0a7850b84f0f,da8ef4c8-1b2e-4a26-9fd0-0a7850b84f0f" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,730f712c-e,cad29840-fb2d-4cc6-838d-b9481c323b88,cad29840-fb2d-4cc6-838d-b9481c323b88" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApprovalStatus entity)
        {
            entity.Code += "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
