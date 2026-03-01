//-----------------------------------------------------------------------
// <copyright file="EntityStatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EntityStatusProcessTests
    /// </summary>
    [TestFixture]
    public class EntityStatusProcessTests : CommonBusinessProcessTests<IEntityStatus, IEntityStatusProcess, IEntityStatusRepository>
    {
        protected override int ColumnDefinitionsCount => 10;
        protected override string ExpectedScreenTitle => "Entity Statuses";
        protected override string ExpectedStatusBarText => "Number of Entity Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.EntityStatus.Code;

        protected override IEntityStatusRepository CreateRepository()
        {
            IEntityStatusRepository retVal = Substitute.For<IEntityStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IEntityStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IEntityStatusProcess process = new EntityStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IEntityStatus CreateBlankEntity(Int32 entityId)
        {
            IEntityStatus retVal = new FModels.EntityStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEntityStatus CreateEntity(IEntityStatusProcess process, Int32 entityId)
        {
            IEntityStatus retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IEntityStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IEntityStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IEntityStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IEntityStatus entity1, IEntityStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,030cc063-2,0e3f7178-d857-4be8-bf4a-fd4f2b9ca1cc,0e3f7178-d857-4be8-bf4a-fd4f2b9ca1cc" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ab2a7da6-6,7010f407-7c40-4bb5-a666-306252d980d8,7010f407-7c40-4bb5-a666-306252d980d8" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,64adce54-1,1605a079-4fe0-4c58-804f-8c0848542b8c,1605a079-4fe0-4c58-804f-8c0848542b8c" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0aac1d4b-f,f8302a46-cb16-4ec6-a705-513ccfbeab05,f8302a46-cb16-4ec6-a705-513ccfbeab05" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,238494e5-b,9f60d20a-cf5f-4262-b342-9a6f091e0ac8,9f60d20a-cf5f-4262-b342-9a6f091e0ac8" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ef5e537d-b,5edf466a-88d2-4f5f-8de1-a24ccfbf3c13,5edf466a-88d2-4f5f-8de1-a24ccfbf3c13" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6bd57b8b-6,2c9576ec-9fd8-409c-a577-963aae3ed91b,2c9576ec-9fd8-409c-a577-963aae3ed91b" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f58cf823-3,0803dee5-6417-42ab-81e4-6c39e5da92ed,0803dee5-6417-42ab-81e4-6c39e5da92ed" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4675dc55-4,21dbdfca-1f02-4e97-a4b0-50941de0ec27,21dbdfca-1f02-4e97-a4b0-50941de0ec27" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,eefafcce-b,baa1441e-00d4-43ad-9276-f515b5a6d3cb,baa1441e-00d4-43ad-9276-f515b5a6d3cb" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IEntityStatus entity)
        {
            entity.Code = "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
