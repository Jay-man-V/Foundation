//-----------------------------------------------------------------------
// <copyright file="DepartmentProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for DepartmentProcessTests
    /// </summary>
    [TestFixture]
    public class DepartmentProcessTests : CommonBusinessProcessTests<IDepartment, IDepartmentProcess, IDepartmentRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Departments";
        protected override String ExpectedStatusBarText => "Number of Departments:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Department.Code;

        protected override IDepartmentRepository CreateRepository()
        {
            IDepartmentRepository retVal = Substitute.For<IDepartmentRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IDepartmentProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IDepartmentProcess process = new DepartmentProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IDepartment CreateBlankEntity(Int32 entityId)
        {
            IDepartment retVal = new FModels.Department();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDepartment CreateEntity(IDepartmentProcess process, Int32 entityId)
        {
            IDepartment retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = $"Code{entityId:D6}";
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IDepartment entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IDepartment entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IDepartment entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IDepartment entity1, IDepartment entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short name,Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000001,4363f761-7db7-4609-97e6-2e9a344c23c3,d4cf3521-ea20-42d3-8ac9-d45e1c6330ad" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000002,4f2d5d41-75ee-47e7-afae-94b532d10b17,a7fcbd1b-9490-48eb-b08b-c64e54d89cf2" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000003,656f13ba-5130-458e-8497-2e814ffb3651,fd55cf56-62b1-4e99-9d6e-86b3955a66b3" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000004,fcbafa61-e734-4289-be4f-dbb1b1aa0511,e5151656-4d52-4c89-a9f2-3573c8956c63" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000005,c4859248-95ff-4713-92e4-b18c7fd045af,ce929b62-2da6-4442-944a-46b879a5c41b" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000006,d474be7d-def8-4749-8d1e-cdcb08923719,474c3bc4-4482-4f7a-b85e-dfba7b7606cf" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000007,3e86bd72-c4ec-481f-a083-3838656791fb,ba29384d-9e19-43b6-bb7f-a4b378923d56" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000008,c1a16d96-5c54-4adb-b255-974c4e06b33f,fab2815f-eb88-4d5e-92a9-a3712ad3b29a" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000009,3f7b9175-11cf-4c1f-9e84-12bae496db37,5a8400f4-f1f2-4867-9a97-28ac4713c70c" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000010,97da9a1a-cff0-4094-ae61-4740c15a07a4,5399486b-f3ad-40c9-a45d-9f20afbd10df" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IDepartment entity)
        {
            entity.ShortName += "Updated";
            entity.Description += "Updated";
        }
    }
}
