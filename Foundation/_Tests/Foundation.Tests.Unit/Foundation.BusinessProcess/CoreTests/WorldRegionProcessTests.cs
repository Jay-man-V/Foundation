//-----------------------------------------------------------------------
// <copyright file="WorldRegionProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for WorldRegionProcessTests
    /// </summary>
    [TestFixture]
    public class WorldRegionProcessTests : CommonBusinessProcessTests<IWorldRegion, IWorldRegionProcess, IWorldRegionRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 8;
        protected override String ExpectedScreenTitle => "World Regions";
        protected override String ExpectedStatusBarText => "Number of World Regions:";

        protected override String ExpectedComboBoxDisplayMember => FDC.WorldRegion.Name;

        protected override IWorldRegionRepository CreateRepository()
        {
            IWorldRegionRepository retVal = Substitute.For<IWorldRegionRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IWorldRegionProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IWorldRegionProcess process = new WorldRegionProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IWorldRegion CreateBlankEntity(Int32 entityId)
        {
            IWorldRegion retVal = new FModels.WorldRegion();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IWorldRegion CreateEntity(IWorldRegionProcess process, Int32 entityId)
        {
            IWorldRegion retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IWorldRegion entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IWorldRegion entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IWorldRegion entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IWorldRegion entity1, IWorldRegion entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,da0b2f38-a9c8-47fd-8b71-74e73cea6964" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8e664f0e-a71c-4ba6-84f6-c5d0fd1dd04b" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d87b6d25-9de0-4627-b31f-9175bc86da39" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d4914577-6f50-4a49-92e6-172e57d2ee7d" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8150f8fe-893b-425f-99b6-0f56b2b786be" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8896d43c-dcba-4bce-a4a9-c96d6b97220d" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6dc43d53-2be6-4230-9c36-a8be6bae6818" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e17b2fef-b546-473e-bd00-cd4f65a75e00" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,abde186f-818b-4519-af1b-1fb2ff76d91b" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,498acaee-c9bb-46ee-9b09-f3cec14171b8" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IWorldRegion entity)
        {
            entity.Name += "Updated";
        }
    }
}
