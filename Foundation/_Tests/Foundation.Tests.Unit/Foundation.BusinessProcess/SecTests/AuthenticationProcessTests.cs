//-----------------------------------------------------------------------
// <copyright file="AuthenticationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for AuthenticationProcessTests
    /// </summary>
    [TestFixture]
    public class AuthenticationProcessTests : UnitTestBase
    {
        private IAuthenticationRepository? TheRepository { get; set; }
        private IIdGeneratorService? IdService { get; set; }
        private IAuthenticationProcess? TheProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            IdService = Substitute.For<IIdGeneratorService>();

            TheRepository = Substitute.For<IAuthenticationRepository>();

            TheProcess = new AuthenticationProcess(CoreInstance, LoggingService, TheRepository!);
        }

        [TestCase]
        public void Test_AuthenticateUser_LoggedOnUser()
        {
            IdService!.NewUniqueIdentifier().Returns(Guid.NewGuid().ToString());
            EntityId authenticationTokenId = new EntityId(1);
            AppId applicationId = new AppId(1);
            EntityId userProfileId = new EntityId(2);
            DateTime acquired = DateTimeService.SystemDateTimeNow.AddHours(-1);
            String token = IdService.NewUniqueIdentifier();
            DateTime lastRefreshed = DateTimeService.SystemDateTimeNow.AddMinutes(-10);

            AuthenticationToken expectedAuthenticationToken = new AuthenticationToken(authenticationTokenId, applicationId, userProfileId, acquired, token, lastRefreshed);

            TheRepository!.AuthenticateUser(Arg.Any<AppId>(), Arg.Any<IUserProfile>()).Returns(expectedAuthenticationToken);

            AuthenticationToken authenticationToken = TheProcess!.AuthenticateUser(applicationId);

            Assert.That(authenticationToken, Is.Not.EqualTo(null));
            Assert.That(authenticationToken.Id, Is.EqualTo(authenticationTokenId));
            Assert.That(authenticationToken.ApplicationId, Is.EqualTo(applicationId));
            Assert.That(authenticationToken.UserProfileId, Is.EqualTo(userProfileId));
            Assert.That(authenticationToken.Acquired, Is.EqualTo(acquired));
            Assert.That(authenticationToken.LastRefreshed, Is.EqualTo(lastRefreshed));
            Assert.That(authenticationToken.Token, Is.EqualTo(token));
        }

        [TestCase]
        public void Test_AuthenticateUser_UserProfile()
        {
            IUserProfile userProfile = CoreInstance.CurrentLoggedOnUser.UserProfile;

            IdService!.NewUniqueIdentifier().Returns(Guid.NewGuid().ToString());
            EntityId authenticationTokenId = new EntityId(1);
            AppId applicationId = new AppId(1);
            EntityId userProfileId = new EntityId(2);
            DateTime acquired = DateTimeService.SystemDateTimeNow.AddHours(-1);
            String token = IdService.NewUniqueIdentifier();
            DateTime lastRefreshed = DateTimeService.SystemDateTimeNow.AddMinutes(-10);

            AuthenticationToken expectedAuthenticationToken = new AuthenticationToken(authenticationTokenId, applicationId, userProfileId, acquired, token, lastRefreshed);

            TheRepository!.AuthenticateUser(Arg.Any<AppId>(), Arg.Any<IUserProfile>()).Returns(expectedAuthenticationToken);

            AuthenticationToken authenticationToken = TheProcess!.AuthenticateUser(applicationId, userProfile);

            Assert.That(authenticationToken, Is.Not.EqualTo(null));
            Assert.That(authenticationToken.Id, Is.EqualTo(authenticationTokenId));
            Assert.That(authenticationToken.ApplicationId, Is.EqualTo(applicationId));
            Assert.That(authenticationToken.UserProfileId, Is.EqualTo(userProfileId));
            Assert.That(authenticationToken.Acquired, Is.EqualTo(acquired));
            Assert.That(authenticationToken.LastRefreshed, Is.EqualTo(lastRefreshed));
            Assert.That(authenticationToken.Token, Is.EqualTo(token));
        }

        [TestCase]
        public void Test_AuthenticateUser_UserProfile_Exception()
        {
        }

        [TestCase]
        public void Test_ValidateAuthenticationToken()
        {
            IUserProfile userProfile = CoreInstance.CurrentLoggedOnUser.UserProfile;

            IdService!.NewUniqueIdentifier().Returns(Guid.NewGuid().ToString());
            EntityId authenticationTokenId = new EntityId(1);
            AppId applicationId = new AppId(1);
            EntityId userProfileId = new EntityId(2);
            DateTime acquired = DateTimeService.SystemDateTimeNow.AddHours(-1);
            String token = IdService.NewUniqueIdentifier();
            DateTime lastRefreshed = DateTimeService.SystemDateTimeNow.AddMinutes(-10);

            AuthenticationToken expectedAuthenticationToken = new AuthenticationToken(authenticationTokenId, applicationId, userProfileId, acquired, token, lastRefreshed);
            TheRepository!.AuthenticateUser(Arg.Any<AppId>(), Arg.Any<IUserProfile>()).Returns(expectedAuthenticationToken);

            DateTime newLastRefreshed = DateTimeService.SystemDateTimeNow;
            AuthenticationToken newAuthenticationToken = new AuthenticationToken(expectedAuthenticationToken, newLastRefreshed);
            TheRepository!.ValidateAuthenticationToken(ref newAuthenticationToken);

            TheRepository.WhenForAnyArgs(x => x.ValidateAuthenticationToken(ref newAuthenticationToken))
                .Do(x =>
                {
                    x[0] = newAuthenticationToken;
                });


            AuthenticationToken authenticationToken = TheProcess!.AuthenticateUser(applicationId, userProfile);
            Assert.That(authenticationToken.Token, Is.EqualTo(token));

            TheProcess!.ValidateAuthenticationToken(ref authenticationToken);
            Assert.That(authenticationToken.Token, Is.EqualTo(token));
            Assert.That(authenticationToken.LastRefreshed, Is.EqualTo(newLastRefreshed));
        }

        [TestCase]
        public void Test_ValidateAuthenticationToken_Exception()
        {
        }

        [TestCase]
        public void Test_ExpireAuthenticationToken()
        {
            AppId appId = new AppId(1);
            IUserProfile userProfile = CoreInstance.CurrentLoggedOnUser.UserProfile;

            AuthenticationToken authenticationToken = TheProcess!.AuthenticateUser(appId, userProfile);

            Assert.That(authenticationToken, Is.Not.EqualTo(null));

            TheProcess!.ExpireAuthenticationToken(ref authenticationToken);

            Assert.That(authenticationToken, Is.Not.EqualTo(null));
            Assert.That(authenticationToken.Id.TheEntityId, Is.EqualTo(0));
            Assert.That(authenticationToken.ApplicationId.TheAppId, Is.EqualTo(0));
            Assert.That(authenticationToken.UserProfileId.TheEntityId, Is.EqualTo(0));
            Assert.That(authenticationToken.Acquired, Is.EqualTo(DateTime.MinValue));
            Assert.That(authenticationToken.LastRefreshed, Is.EqualTo(DateTime.MinValue));
            Assert.That(authenticationToken.Token, Is.EqualTo(null));
        }

        [TestCase]
        public void Test_ExpireAuthenticationToken_Exception()
        {
        }
    }
}
