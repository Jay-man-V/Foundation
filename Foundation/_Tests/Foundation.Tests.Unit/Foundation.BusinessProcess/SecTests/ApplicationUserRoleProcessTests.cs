//-----------------------------------------------------------------------
// <copyright file="ApplicationUserRoleProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for ApplicationUserRoleProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationUserRoleProcessTests : CommonBusinessProcessTests<IApplicationUserRole, IApplicationUserRoleProcess, IApplicationUserRoleRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Application/User/Roles";
        protected override String ExpectedStatusBarText => "Number of Application/User/Roles:";

        protected override IApplicationUserRoleRepository CreateRepository()
        {
            IApplicationUserRoleRepository dataAccess = Substitute.For<IApplicationUserRoleRepository>();

            return dataAccess;
        }

        protected override IApplicationUserRoleProcess CreateBusinessProcess()
        {
            IApplicationUserRoleProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IApplicationUserRoleProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IRoleProcess roleProcess = Substitute.For<IRoleProcess>();
            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();

            IApplicationUserRoleProcess process = new ApplicationUserRoleProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess, roleProcess, userProfileProcess);

            return process;
        }

        protected override IApplicationUserRole CreateBlankEntity(IApplicationUserRoleProcess process, Int32 entityId)
        {
            IApplicationUserRole retVal = CoreInstance.IoC.Get<IApplicationUserRole>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationUserRole CreateEntity(IApplicationUserRoleProcess process, Int32 entityId)
        {
            IApplicationUserRole retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.UserProfileId = new EntityId(1);
            retVal.RoleId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationUserRole entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.UserProfileId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.RoleId, Is.EqualTo(new EntityId(0)));
        }

        protected override void CheckAllEntry(IApplicationUserRole entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        protected override void CheckNoneEntry(IApplicationUserRole entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        [TestCase]
        public override void Test_GetAllEntry()
        {
            String paramName = nameof(IApplicationUserRoleProcess.ComboBoxDisplayMember);
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
            String paramName = nameof(IApplicationUserRoleProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetNoneEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        protected override void CompareEntityProperties(IApplicationUserRole entity1, IApplicationUserRole entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.UserProfileId, Is.EqualTo(entity1.UserProfileId));
            Assert.That(entity2.RoleId, Is.EqualTo(entity1.RoleId));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application,Role,User Display Name,User Logon Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplicationUserRole entity)
        {
            entity.ApplicationId = new AppId(2);
            entity.UserProfileId = new EntityId(2);
            entity.RoleId = new EntityId(2);
        }
    }
}
