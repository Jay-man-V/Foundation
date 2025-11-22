//-----------------------------------------------------------------------
// <copyright file="TaskStatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for TaskStatusProcessTests
    /// </summary>
    [TestFixture]
    public class TaskStatusProcessTests : CommonBusinessProcessTests<ITaskStatus, ITaskStatusProcess, ITaskStatusRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Task Statuses";
        protected override String ExpectedStatusBarText => "Number of Task Statuses:";

        protected override String ExpectedComboBoxDisplayMember => FDC.TaskStatus.Name;

        protected override ITaskStatusRepository CreateRepository()
        {
            ITaskStatusRepository retVal = Substitute.For<ITaskStatusRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override ITaskStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ITaskStatusProcess process = new TaskStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override ITaskStatus CreateBlankEntity(Int32 entityId)
        {
            ITaskStatus retVal = new FModels.TaskStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ITaskStatus CreateEntity(ITaskStatusProcess process, Int32 entityId)
        {
            ITaskStatus retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(ITaskStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ITaskStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ITaskStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ITaskStatus entity1, ITaskStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,31251ca2-3c2a-444a-be3c-4,f3d7598f-26fc-4035-9912-a9b303a61e2e" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,3283d4c9-77d0-44dd-bfb6-d,689dc938-ff11-4bd9-a068-2ff3b6b1bbf6" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,eafff06b-96e4-4174-b8c5-3,f649e324-0b47-402a-aad2-76e51a76b4fc" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7de329a2-3109-4a1c-8e61-8,1d50187c-1731-4c24-9212-03cf239f9afd" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e42fbb15-7444-4a9b-8811-1,d1e90e5e-1232-4224-a79b-34bd6ffc96e9" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,dce0ebad-7816-4cf5-b17c-1,cd1b6fb0-02f1-450a-9f6f-c94ac8509f08" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7a965337-1cd7-434b-9f40-6,904e1146-8382-4c50-8dcc-4b213ffa3913" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0216b894-80e9-4f22-9f06-0,a6e8474b-d071-4070-93e4-80317928fa9c" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e82a97ac-8f84-484c-bfb7-1,66ffbc1d-e928-46a3-b375-6629f3fdc9f3" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4dbaa945-12d3-4d4f-9058-6,7ade9cc3-9255-4a99-83b6-48817b4fe757" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ITaskStatus entity)
        {
            entity.Name = "Updated";
            entity.Description += "Updated";
        }
    }
}
