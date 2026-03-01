//-----------------------------------------------------------------------
// <copyright file="DataStatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for DataStatusProcessTests
    /// </summary>
    [TestFixture]
    public class DataStatusProcessTests : CommonBusinessProcessTests<IDataStatus, IDataStatusProcess, IDataStatusRepository>
    {
        protected override int ColumnDefinitionsCount => 10;
        protected override string ExpectedScreenTitle => "Data Statuses";
        protected override string ExpectedStatusBarText => "Number of Data Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.DataStatus.Code;

        protected override IDataStatusRepository CreateRepository()
        {
            IDataStatusRepository retVal = Substitute.For<IDataStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IDataStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IDataStatusProcess process = new DataStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IDataStatus CreateBlankEntity(Int32 entityId)
        {
            IDataStatus retVal = new FModels.DataStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDataStatus CreateEntity(IDataStatusProcess process, Int32 entityId)
        {
            IDataStatus retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IDataStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IDataStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IDataStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IDataStatus entity1, IDataStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,266b4d12-d,25784f1c-e3b5-4b8d-9813-42c79181443c,25784f1c-e3b5-4b8d-9813-42c79181443c" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,838e06dc-d,aa11fc81-ab6f-4ecc-a822-1fa7cb095405,aa11fc81-ab6f-4ecc-a822-1fa7cb095405" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7a863e0b-d,ffe171b0-3ea8-49d9-9681-29408453c346,ffe171b0-3ea8-49d9-9681-29408453c346" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,59deb293-a,5dc46e8b-4679-400c-927a-f875e2de1331,5dc46e8b-4679-400c-927a-f875e2de1331" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7b153735-1,bf24f80a-89f5-4c75-93ab-3209e35634de,bf24f80a-89f5-4c75-93ab-3209e35634de" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,238de31f-c,b982b1af-32e2-46a9-92ed-f0564e606bec,b982b1af-32e2-46a9-92ed-f0564e606bec" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e41e9854-b,9cdbf560-949c-4e36-ab0e-de1ad67fd9dd,9cdbf560-949c-4e36-ab0e-de1ad67fd9dd" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,270a2e10-4,37d463c9-8687-4c1f-96a3-be1874732357,37d463c9-8687-4c1f-96a3-be1874732357" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,02fe0222-c,4cc8d224-921e-4ede-9197-c1508856b0bf,4cc8d224-921e-4ede-9197-c1508856b0bf" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9bdb23eb-3,e45a2fbc-9e41-438e-8610-a53198c89a3f,e45a2fbc-9e41-438e-8610-a53198c89a3f" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IDataStatus entity)
        {
            entity.Code = "Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
