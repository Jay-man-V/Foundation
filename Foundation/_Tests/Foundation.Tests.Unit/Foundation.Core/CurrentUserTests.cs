//-----------------------------------------------------------------------
// <copyright file="CurrentUserTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Core;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The Current Logged On User Tests
    /// </summary>
    public class CurrentUserTests // Do not inherit from UnitTestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void Test_AllProperties()
        {
            EntityId id = new EntityId(123);
            String username = Guid.NewGuid().ToString();
            String displayName = Guid.NewGuid().ToString();
            const Boolean isSystemSupport = true;

            IUserProfile userProfile = Substitute.For<IUserProfile>();
            userProfile.Id.Returns(id);
            userProfile.Username.Returns(username);
            userProfile.DisplayName.Returns(displayName);
            userProfile.IsSystemSupport.Returns(isSystemSupport);

            ICurrentUser currentUser = new CurrentUser(userProfile);

            Assert.That(currentUser.UserProfile, Is.EqualTo(userProfile));
            Assert.That(currentUser.Id, Is.EqualTo(id));
            Assert.That(currentUser.Username, Is.EqualTo(username));
            Assert.That(currentUser.DisplayName, Is.EqualTo(displayName));
            Assert.That(currentUser.IsSystemSupport, Is.EqualTo(isSystemSupport));
        }
    }
}