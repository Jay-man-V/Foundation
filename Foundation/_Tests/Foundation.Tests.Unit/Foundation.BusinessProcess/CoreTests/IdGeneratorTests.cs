//-----------------------------------------------------------------------
// <copyright file="IdGeneratorTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for DepartmentProcessTests
    /// </summary>
    [TestFixture]
    public class IdGeneratorTests : CommonBusinessProcessTests<IDepartment, IDepartmentProcess, IDepartmentRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Departments";
        protected override String ExpectedStatusBarText => "Number of Departments:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Department.Code;

        protected override IDepartmentRepository CreateRepository()
        {
            IDepartmentRepository dataAccess = Substitute.For<IDepartmentRepository>();

            return dataAccess;
        }

        protected override IDepartmentProcess CreateBusinessProcess()
        {
            IDepartmentProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IDepartmentProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IDepartmentProcess process = new DepartmentProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IDepartment CreateBlankEntity(IDepartmentProcess process, Int32 entityId)
        {
            IDepartment retVal = CoreInstance.IoC.Get<IDepartment>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDepartment CreateEntity(IDepartmentProcess process, Int32 entityId)
        {
            IDepartment retVal = CreateBlankEntity(process, entityId);

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
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000001,6b95ee3f-3ed2-4ee3-a096-6d79edb3df22,307dff65-9188-4aaa-9234-1ff617da8d23" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000002,3f22440b-ea1b-4e33-b60f-81c14f2abc91,cb4c6dd1-df14-4449-85d5-c085719c0a13" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000003,8b880c8a-0e2f-47e8-a939-d649c16755b7,2bc04e3d-970a-478a-9201-999ea8f8cbee" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000004,6323868f-b5fc-4e15-90ba-12fb249add18,e90a33d7-88e8-4127-afac-06448a560908" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000005,a8e46253-aaab-4856-b69d-f85acdfd8bb7,2a017403-7039-4917-9af5-57736f0161b2" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000006,cf10e84d-7662-4483-9db4-964c09e3316d,b7a38237-49a4-414e-85fd-53a04d99bdcc" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000007,fd8a093a-180b-47b0-81ea-de1b256f6c74,5a522877-53a0-408b-911e-cf8ac0dc2ef2" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000008,9ff5a161-38f0-4af8-893b-7bd2d10156a1,248bbe42-79f1-421c-94c6-ad82178b0d44" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000009,5058e6f4-1095-4bca-8a1f-0b5a49de3c59,20f0370d-ae60-46ec-83a8-8e047c807485" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000010,c96ad5a4-ae67-4395-bfac-800cd0a0ecb9,50a90531-c7f9-48f7-a951-26272ee996fb" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IDepartment entity)
        {
            entity.ShortName += "Updated";
            entity.Description += "Updated";
        }
    }
}
