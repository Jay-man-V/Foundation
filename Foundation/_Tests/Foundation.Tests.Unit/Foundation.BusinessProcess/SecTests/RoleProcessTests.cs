//-----------------------------------------------------------------------
// <copyright file="RoleProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for RoleProcessTests
    /// </summary>
    [TestFixture]
    public class RoleProcessTests : CommonBusinessProcessTests<IRole, IRoleProcess, IRoleRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Roles";
        protected override String ExpectedStatusBarText => "Number of Roles:";

        protected override String ExpectedComboBoxDisplayMember => FDC.Role.Name;

        protected override IRoleRepository CreateRepository()
        {
            IRoleRepository dataAccess = Substitute.For<IRoleRepository>();

            return dataAccess;
        }

        protected override IRoleProcess CreateBusinessProcess()
        {
            IRoleProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IRoleProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IRoleProcess process = new RoleProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IRole CreateBlankEntity(IRoleProcess process, Int32 entityId)
        {
            IRole retVal = CoreInstance.IoC.Get<IRole>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IRole CreateEntity(IRoleProcess process, Int32 entityId)
        {
            IRole retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IRole entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IRole entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IRole entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IRole entity1, IRole entity2)
        {
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));

            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name,Description,System Support Only" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0b42d00b-c9a8-448b-b1e2-216d609fd888,550c9cca-c9e7-4771-963a-c01959681a75,False" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,168036ff-4499-4ecb-9b87-68a3be3df8ca,29c5f1e7-769a-4d27-9126-51a0027d8d64,False" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8a19a4f4-a206-4fe8-8b56-5222fc5be2e0,cd66498f-cf83-425b-aca3-64b6dbfd4d16,False" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4ecbdde9-4e27-41d3-aeeb-9d8e50117a9f,f4b41cc0-1cbd-4bde-a753-5d1966b2b1b2,False" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,71efbdbe-b5b9-4ed5-bf7e-1459252a62c7,7de23b0f-d663-4061-8f19-e3357b1c9275,False" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,75aa24e3-8f2b-46c2-9445-d13d53563ba7,adf4f397-5d1e-4338-a4e8-674f65139aa8,False" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9e681171-4493-4731-9460-220205aaf720,4a2c3826-9b28-41d1-9be3-0fc20425ce00,False" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7a71a610-c684-4847-b070-d52fef44a399,51edc428-9b0d-484e-ae9d-c71fcd73420a,False" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ccb86b8b-6c14-454d-953e-c95de2d0937c,f1aa8d7b-2d16-4eb9-aff9-3f18293f0a58,False" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,a6d599e1-4fce-4709-b8c5-aaf19a1f9159,c7e5dd46-07eb-4945-9bc0-b909deabd7b8,False" + Environment.NewLine;

            return retVal;
        }
        protected override void UpdateEntityProperties(IRole entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }
    }
}
