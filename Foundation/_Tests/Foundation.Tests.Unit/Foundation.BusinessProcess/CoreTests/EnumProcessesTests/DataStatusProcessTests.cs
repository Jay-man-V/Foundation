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
        protected override int ColumnDefinitionsCount => 9;
        protected override string ExpectedScreenTitle => "Data Statuses";
        protected override string ExpectedStatusBarText => "Number of Data Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.DataStatus.Name;

        protected override IDataStatusRepository CreateRepository()
        {
            IDataStatusRepository retVal = Substitute.For<IDataStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IDataStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IDataStatusProcess process = new DataStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

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

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IDataStatus entity1, IDataStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,266b4d12-dd24-4c44-82b5-2,25784f1c-e3b5-4b8d-9813-42c79181443c" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,838e06dc-dc57-45e3-84a3-8,aa11fc81-ab6f-4ecc-a822-1fa7cb095405" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7a863e0b-dd13-4889-9034-6,ffe171b0-3ea8-49d9-9681-29408453c346" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,59deb293-a906-4b11-be51-7,5dc46e8b-4679-400c-927a-f875e2de1331" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7b153735-1c59-45e7-8a38-f,bf24f80a-89f5-4c75-93ab-3209e35634de" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,238de31f-c39b-4388-8a88-d,b982b1af-32e2-46a9-92ed-f0564e606bec" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e41e9854-b3fb-4b20-b7ae-1,9cdbf560-949c-4e36-ab0e-de1ad67fd9dd" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,270a2e10-43a2-493f-92b7-3,37d463c9-8687-4c1f-96a3-be1874732357" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,02fe0222-c3aa-4c61-abf8-3,4cc8d224-921e-4ede-9197-c1508856b0bf" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9bdb23eb-348e-4c62-ac2d-3,e45a2fbc-9e41-438e-8610-a53198c89a3f" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IDataStatus entity)
        {
            entity.Name = "Updated";
            entity.Description += "Updated";
        }
    }
}
