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
        protected override int ColumnDefinitionsCount => 10;
        protected override string ExpectedScreenTitle => "Task Statuses";
        protected override string ExpectedStatusBarText => "Number of Task Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.TaskStatus.Code;

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

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(ITaskStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ITaskStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ITaskStatus entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ITaskStatus entity1, ITaskStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,fd33a161-1,4ee502cc-b103-43ef-b8de-9ca9408009b7,ce801d17-3087-4c32-9c5e-f8861556581c" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1e369c1c-0,2a5d5ef5-99c7-41f4-a597-35a5c4cc4ba6,6567da84-32bc-4a63-bb6b-1c7ade37080d" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e3a9f0d0-1,53da5073-3dac-4831-9b00-87e5beaa686b,3534fe39-22b1-4439-b31e-8730e5f39ebe" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,a02001ba-0,4b2c5e49-e80a-498a-b5f4-fa9ea3ef061d,f3e69dd3-632a-4801-ac02-75f0c3c6da47" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ea2ce6b5-6,42072727-951b-4f64-98be-82ec4ce8e6ec,6726b29e-6d85-4ff6-91b9-6e803d998872" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c9e78952-e,83110ef3-44d1-429d-a256-1edc0b0c26fd,ee520645-a95f-43bc-806f-85e230e879c9" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,35420fc7-a,c4c20de5-6400-43d8-9761-d6e8f8f91abd,9d93bf30-8530-4353-8aa6-094c24ec79f8" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,22b7e213-4,212c34ec-1fb0-4c1e-9f81-0b15d832c48a,375d2e0c-445f-4bbc-92db-6191439da8cb" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,cbcfdc07-8,77ddc09b-2b18-479a-904b-a1e90fce8a70,00db4e8a-f5d9-43fd-a05b-164996d67288" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,590940d0-5,5fa41f06-0e6d-4514-b36c-60a050deaa08,45a553f4-b77c-453d-b6b1-a87c0077b175" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ITaskStatus entity)
        {
            entity.Code = "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
