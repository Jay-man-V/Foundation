//-----------------------------------------------------------------------
// <copyright file="PermissionMatrixProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FModels = Foundation.Models.Sec;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for PermissionMatrixProcessTests
    /// </summary>
    [TestFixture]
    public class PermissionMatrixProcessTests : CommonBusinessProcessTests<IPermissionMatrix, IPermissionMatrixProcess, IPermissionMatrixRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 12;
        protected override String ExpectedScreenTitle => "Permissions Matrix";
        protected override String ExpectedStatusBarText => "Number of Permission Matrices:";

        protected override IPermissionMatrixRepository CreateRepository()
        {
            IPermissionMatrixRepository dataAccess = Substitute.For<IPermissionMatrixRepository>();

            return dataAccess;
        }

        protected override IPermissionMatrixProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IRoleProcess roleProcess = Substitute.For<IRoleProcess>();
            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();

            IPermissionMatrixProcess process = new PermissionMatrixProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess, roleProcess, userProfileProcess);

            return process;
        }

        protected override IPermissionMatrix CreateBlankEntity(IPermissionMatrixProcess process, Int32 entityId)
        {
            IPermissionMatrix retVal = new FModels.PermissionMatrix();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IPermissionMatrix CreateEntity(IPermissionMatrixProcess process, Int32 entityId)
        {
            IPermissionMatrix retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(1);
            retVal.UserProfileId = new EntityId(1);
            retVal.FunctionKey = Guid.NewGuid().ToString();
            retVal.Permission = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IPermissionMatrix entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.RoleId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.UserProfileId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.FunctionKey, Is.EqualTo(String.Empty));
            Assert.That(entity.Permission, Is.EqualTo(String.Empty));
        }

        [TestCase]
        public override void Test_GetAllEntry()
        {
            String paramName = nameof(IPermissionMatrixProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetAllEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        protected override void CheckAllEntry(IPermissionMatrix entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        [TestCase]
        public override void Test_GetNoneEntry()
        {
            String paramName = nameof(IPermissionMatrixProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetNoneEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        protected override void CheckNoneEntry(IPermissionMatrix entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        protected override void CompareEntityProperties(IPermissionMatrix entity1, IPermissionMatrix entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.RoleId, Is.EqualTo(entity1.RoleId));
            Assert.That(entity2.UserProfileId, Is.EqualTo(entity1.UserProfileId));
            Assert.That(entity2.FunctionKey, Is.EqualTo(entity1.FunctionKey));
            Assert.That(entity2.Permission, Is.EqualTo(entity1.Permission));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application Name,Role,Display Name,Function Key,Permission" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,57328d0a-e9e0-44a1-94fe-91f09d2c8b5c,946b6ed9-0f43-4350-bcfa-45fc5153b8b6" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,bff2cd6e-4688-41db-8b8c-a8a243790a76,2a4144ad-3693-4345-82c9-6a7e91da823d" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,5951f3a7-33c2-4179-9f81-55f0adebeeb0,4c988bd7-c2b8-4b86-9a19-2140250536e1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,5f6c1096-b822-4e04-a85f-0ffd708b7341,e62ae3dc-7798-4c37-862b-c2ffd4192781" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,e40609e6-a189-4de3-9b1e-c5b13e7ed1a4,213854b6-bae4-4080-992a-4fa21f9a1fcc" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,f60e74a4-3956-4dde-a351-3787a509aeb9,095d059e-2812-4b18-889b-ff8e3dd5f19d" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,7de97015-94f9-47c9-8634-566c55f33a43,b8402ceb-ad0d-4035-ba7c-e609b4bea012" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,8eea58f3-d417-49bd-9a81-e932b28bd564,c703b559-09a4-4e33-9e59-0bcd46483da0" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,3ddcc381-ef16-4ac5-aa75-a682fb57e604,e19b2879-a35f-4fb5-91e7-4f86c7ff84f7" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,1,f5d7b519-9cd5-4d3b-ac62-20f6077c5ec2,80b964e0-a278-408d-9551-9df515ce6483" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IPermissionMatrix entity)
        {
            entity.FunctionKey += "Updated";
            entity.Permission += "Updated";
        }

        [TestCase]
        public void Test_CanUserPerformFunction()
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();
            String functionKey = LocationUtils.GetFullyQualifiedFunctionName();

            TheRepository!.CanUserPerformFunction(ref Arg.Any<AuthenticationToken>(), Arg.Any<String>()).Returns(true);

            Boolean actual = TheProcess!.CanUserPerformFunction(ref authenticationToken, functionKey);

            Assert.That(actual, Is.EqualTo(true));
        }
    }
}
