//-----------------------------------------------------------------------
// <copyright file="AuthorisationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for AuthorisationProcessTests
    /// </summary>
    [TestFixture]
    public class AuthorisationProcessTests : BusinessProcessUnitTestBase
    {
        private IPermissionMatrixProcess? PermissionMatrixProcess { get; set; }
        private IAuthorisationProcess? TheProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            PermissionMatrixProcess = Substitute.For<IPermissionMatrixProcess>();
            IAuthenticationProcess authenticationProcess = Substitute.For<IAuthenticationProcess>();

            TheProcess = new AuthorisationProcess(CoreInstance, LoggingService, PermissionMatrixProcess, authenticationProcess);
        }

        private AuthenticationToken GetAuthenticationToken()
        {
            IUserProfile userProfile = CoreInstance.CurrentLoggedOnUser.UserProfile;

            EntityId tokenId = new EntityId(1);
            AppId appId = new AppId(1);
            Guid tokenReference = Guid.NewGuid();

            AuthenticationToken authenticationToken = new AuthenticationToken(tokenId, appId, userProfile.Id, CreatedOnDateTime, tokenReference.ToString(), LastUpdatedOnDateTime);

            return authenticationToken;
        }

        [TestCase]
        public void Test_IsUserAuthorised_Success()
        {
            AuthenticationToken authenticationToken = GetAuthenticationToken();

            PermissionMatrixProcess!.CanUserPerformFunction(ref authenticationToken, Arg.Any<String>()).Returns(true);

            TheProcess!.IsUserAuthorised(ref authenticationToken, LocationUtils.GetFunctionName());
        }

        [TestCase]
        public void Test_IsUserAuthorised_Fail()
        {
            AuthenticationToken authenticationToken = GetAuthenticationToken();
            AppId applicationId = CoreInstance.ApplicationId;
            String userFullLogonName = RunTimeEnvironmentSettings.UserFullLogonName;
            String roles = String.Join(", ", CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.Select(r => r.ApplicationRole));
            String functionKey = LocationUtils.GetFunctionName();

            String errorMessage = $"Application Id: '{applicationId}'. User: '{userFullLogonName}' does not have the required permissions. Assigned Roles are: '{roles}'. Function Key is: '{functionKey}'.";

            ApplicationPermissionsException actualException = Assert.Throws<ApplicationPermissionsException>(() =>
            {
                TheProcess!.IsUserAuthorised(ref authenticationToken, functionKey);
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
