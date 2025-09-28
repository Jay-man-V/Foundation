//-----------------------------------------------------------------------
// <copyright file="ImportExportControlProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Log;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Log;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.LogTests
{
    /// <summary>
    /// Summary description for ImportExportControlProcessTests
    /// </summary>
    [TestFixture]
    public class ImportExportControlProcessTests : CommonBusinessProcessTests<IImportExportControl, IImportExportControlProcess, IImportExportControlRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 7;
        protected override String ExpectedScreenTitle => "Import/Export Control";
        protected override String ExpectedStatusBarText => "Number of Import/Export Controls:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ImportExportControl.Name;

        protected override IImportExportControlRepository CreateRepository()
        {
            IImportExportControlRepository dataAccess = Substitute.For<IImportExportControlRepository>();

            return dataAccess;
        }

        protected override IImportExportControlProcess CreateBusinessProcess()
        {
            IImportExportControlProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IImportExportControlProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IImportExportControlProcess process = new ImportExportControlProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IImportExportControl CreateBlankEntity(IImportExportControlProcess process, Int32 entityId)
        {
            IImportExportControl retVal = new FModels.ImportExportControl();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IImportExportControl CreateEntity(IImportExportControlProcess process, Int32 entityId)
        {
            IImportExportControl retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ProcessedOn = new DateTime(2025, 01, 25, 23, 03, 15);
            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IImportExportControl entity)
        {
            Assert.That(entity.ProcessedOn, Is.EqualTo(DateTime.MinValue));
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IImportExportControl entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IImportExportControl entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IImportExportControl entity1, IImportExportControl entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ProcessedOn, Is.EqualTo(entity1.ProcessedOn));
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Processed On,Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,711fd70c-15ed-4628-92cb-f52c2a71cb9b" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,f5fc851b-cc62-4477-9431-c3ed857b9db6" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,83d049f5-af04-4460-b88a-479c767d9a30" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,33f6255d-d7ac-4d04-8445-a53574361706" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,15552c7f-a4b4-4c94-ac4e-dc09bedc66b9" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,b9cba3d0-ebb9-441b-8a21-2ee76e721f1b" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,a97a8cd3-d768-461f-b1b5-50d7334b43de" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,54566cd1-698f-4f32-807f-080fb3aed805" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,bca061ce-791b-4d0e-aed8-34a612e26cea" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2025-01-25T23:03:15.000,4a929347-a012-425c-b14c-97b5becd178f" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IImportExportControl entity)
        {
            entity.ProcessedOn = entity.ProcessedOn.AddDays(1);
            entity.Name += "Updated";
        }
    }
}
