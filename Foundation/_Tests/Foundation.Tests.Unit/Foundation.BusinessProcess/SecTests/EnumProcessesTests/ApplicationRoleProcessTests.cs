//-----------------------------------------------------------------------
// <copyright file="ApplicationRoleProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec.EnumProcesses;
using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ApplicationRoleProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationRoleProcessTests : CommonBusinessProcessTests<IApplicationRole, IApplicationRoleProcess, IApplicationRoleRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Application Roles";
        protected override String ExpectedStatusBarText => "Number of Application Roles:";

        protected override IApplicationRoleRepository CreateRepository()
        {
            IApplicationRoleRepository dataAccess = Substitute.For<IApplicationRoleRepository>();

            return dataAccess;
        }

        protected override IApplicationRoleProcess CreateBusinessProcess()
        {
            IApplicationRoleProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IApplicationRoleProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IRoleProcess roleProcess = Substitute.For<IRoleProcess>();

            IApplicationRoleProcess process = new ApplicationRoleProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess, roleProcess);

            return process;
        }

        protected override IApplicationRole CreateBlankEntity(IApplicationRoleProcess process, Int32 entityId)
        {
            IApplicationRole retVal = CoreInstance.IoC.Get<IApplicationRole>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationRole CreateEntity(IApplicationRoleProcess process, Int32 entityId)
        {
            IApplicationRole retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationRole entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.RoleId, Is.EqualTo(new EntityId(0)));
        }

        protected override void CheckAllEntry(IApplicationRole entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        protected override void CheckNoneEntry(IApplicationRole entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        [TestCase]
        public override void Test_GetAllEntry()
        {
            String paramName = nameof(IApplicationRoleProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetAllEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public override void Test_GetNoneEntry()
        {
            String paramName = nameof(IApplicationRoleProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetNoneEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        protected override void CompareEntityProperties(IApplicationRole entity1, IApplicationRole entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.RoleId, Is.EqualTo(entity1.RoleId));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application,Role" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplicationRole entity)
        {
            entity.ApplicationId = new AppId(2);
            entity.RoleId = new EntityId(2);
        }
    }
}
