//-----------------------------------------------------------------------
// <copyright file="StatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for StatusProcessTests
    /// </summary>
    [TestFixture]
    public class StatusProcessTests : CommonBusinessProcessTests<IStatus, IStatusProcess, IStatusRepository>
    {
        protected override int ColumnDefinitionsCount => 10;
        protected override string ExpectedScreenTitle => "Statuses";
        protected override string ExpectedStatusBarText => "Number of Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Status.Code;

        protected override IStatusRepository CreateRepository()
        {
            IStatusRepository retVal = Substitute.For<IStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IStatusProcess process = new StatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IStatus CreateBlankEntity(Int32 entityId)
        {
            IStatus retVal = new FModels.Status();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IStatus CreateEntity(IStatusProcess process, Int32 entityId)
        {
            IStatus retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IStatus entity1, IStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6a2be7f9-b,61ce9018-ed22-4e33-af52-18d410ee2395,61ce9018-ed22-4e33-af52-18d410ee2395" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,82eadc44-9,1cec1d23-3746-426d-9f7c-29a75d17756c,1cec1d23-3746-426d-9f7c-29a75d17756c" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,13052b75-d,6cf66cf4-169f-4b47-a47d-afb3b42c746f,6cf66cf4-169f-4b47-a47d-afb3b42c746f" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,84bcbf32-f,1fa832b0-14f3-48de-81e6-bdf0a8b4da4a,1fa832b0-14f3-48de-81e6-bdf0a8b4da4a" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b32bf9a4-b,87144fbc-17b2-4bd3-b3ba-db859805637b,87144fbc-17b2-4bd3-b3ba-db859805637b" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8b67de6e-7,efb2cf01-542e-4547-8d2b-2d92fa633689,efb2cf01-542e-4547-8d2b-2d92fa633689" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5b88ad19-c,1728a73c-5265-4e40-9984-391c3c49d171,1728a73c-5265-4e40-9984-391c3c49d171" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6c30b150-f,2704521e-d8d6-4ff4-8bb0-8ba1289de2d4,2704521e-d8d6-4ff4-8bb0-8ba1289de2d4" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,cd7331fb-c,45c3cb39-618b-40a0-bfad-f37dc1ac3a34,45c3cb39-618b-40a0-bfad-f37dc1ac3a34" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,79f2f0d2-4,2565a5d6-ba80-4179-ba1b-f10f13438ab8,2565a5d6-ba80-4179-ba1b-f10f13438ab8" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IStatus entity)
        {
            entity.Code = "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
