//-----------------------------------------------------------------------
// <copyright file="ApplicationRoleProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec.EnumProcesses;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Sec.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ApplicationRoleProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationRoleProcessTests : CommonBusinessProcessTests<IApplicationRole, IApplicationRoleProcess, IApplicationRoleDataAccess>
    {
        protected override Int32 ColumnDefinitionsCount => 12;
        protected override String ExpectedScreenTitle => "Application Roles";
        protected override String ExpectedStatusBarText => "Number of Application Roles:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ApplicationUserRole.Code;

        protected override IApplicationRoleDataAccess CreateRepository()
        {
            IApplicationRoleDataAccess retVal = Substitute.For<IApplicationRoleDataAccess>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IApplicationRoleProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IRoleProcess roleProcess = Substitute.For<IRoleProcess>();

            SetProperties(applicationProcess);
            SetProperties(roleProcess);

            IApplicationRoleProcess process = new ApplicationRoleProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, applicationProcess, roleProcess);

            return process;
        }

        protected override IApplicationRole CreateBlankEntity(Int32 entityId)
        {
            IApplicationRole retVal = new FModels.ApplicationRole();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationRole CreateEntity(IApplicationRoleProcess process, Int32 entityId)
        {
            IApplicationRole retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(1);
            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationRole entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.RoleId, Is.EqualTo(new EntityId(0)));
        }

        protected override void CheckAllEntry(IApplicationRole entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IApplicationRole entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        //[TestCase]
        //public override void Test_GetAllEntry()
        //{
        //    String paramName = nameof(IApplicationRoleProcess.ComboBoxDisplayMember);
        //    String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
        //    ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        _ = TheProcess!.GetAllEntry();
        //    });

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        //    Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        //}

        //[TestCase]
        //public override void Test_GetNoneEntry()
        //{
        //    String paramName = nameof(IApplicationRoleProcess.ComboBoxDisplayMember);
        //    String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
        //    ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        _ = TheProcess!.GetNoneEntry();
        //    });

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        //    Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        //}

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
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short Description,Long Description,Application,Role" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b586a655-d,cb493257-2bda-4976-86d2-1afa144d233b,1b2130ca-325f-48ec-92ae-133d6fcfdd72,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,bcddcfab-8,c4c1fcf2-ba47-4676-9b16-6e2ef979adf4,57d8f64e-08f0-4e9d-92d6-40071e61800d,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,feff6125-d,bda1b097-c01d-4b52-9f65-0ca1a0308382,e9d03164-ba9f-409f-9749-3093914f6d5c,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9000564b-0,ba438e69-bc89-476a-b9be-9c95715eb585,41326ac8-e0d6-47ec-bb85-e02c7b4fc399,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4a8a83fa-3,23a2da52-91b4-4953-b4a1-a0b07141ca3b,eb76845d-e100-4377-8a5b-02106077adf1,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,bd9d7dd4-d,bfc9b258-49b3-48dd-810e-1e4a50b83282,6d189b66-cba2-4a9d-9271-74ed4dbf141a,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,dcd28a1e-1,162bed6b-9f0f-49ad-80df-39aa38806c49,8b687937-8361-4a0c-abd5-ce6eda42941d,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,988d419a-a,c497ac0f-3837-4fb7-972a-9ebfe9827d4d,2cdc7d0d-683a-4105-bc39-1455d58b9031,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,16d3c1c8-8,b129bda0-0be8-4301-87c1-f383119a650e,81a31584-cdda-409b-8bc7-eb80917c796c,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,595c54be-8,0ef5f7cd-3d7a-4a81-a9c9-a7adbce04f42,cb023be0-f73f-4b3b-8074-c75704855569,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplicationRole entity)
        {
            entity.ApplicationId = new AppId(2);
            entity.RoleId = new EntityId(2);
        }
    }
}
