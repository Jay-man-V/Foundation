//-----------------------------------------------------------------------
// <copyright file="AuthenticationTokenTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Authentication Token type
    /// </summary>
    [TestFixture]
    public class AuthenticationTokenTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_NoPublicConstructorsAllowed()
        {
            Type thisType = typeof(AuthenticationToken);
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
            ConstructorInfo[] constructorInfos = thisType.GetConstructors(bindingFlags);
            Assert.That(constructorInfos.Length, Is.EqualTo(0));
        }

        [TestCase]
        public void Test_Constructor_1()
        {
            // Default constructor is not listed as accessible even though it is usable
            AuthenticationToken token = new AuthenticationToken();
            Assert.That(token.Token, Is.EqualTo(null));
        }

        [TestCase]
        public void Test_Constructor_2()
        {
            AppId appId = new AppId(1);
            EntityId entityId = new EntityId(1);
            EntityId userProfileId = new EntityId(1);
            DateTime expectedAcquired = new DateTime(2023, 05, 08, 08, 39, 15);
            String expectedToken = Guid.NewGuid().ToString();
            DateTime expectedLastRefreshed = new DateTime(2023, 05, 08, 10, 05, 17);

            AuthenticationToken token = new AuthenticationToken(entityId, appId, userProfileId, expectedAcquired, expectedToken, expectedLastRefreshed);
            AuthenticationToken token2 = new AuthenticationToken(token, token.LastRefreshed.AddDays(1));

            Assert.That(token2.Id, Is.EqualTo(entityId));
            Assert.That(token2.ApplicationId, Is.EqualTo(appId));
            Assert.That(token2.UserProfileId, Is.EqualTo(userProfileId));
            Assert.That(token2.Acquired, Is.EqualTo(expectedAcquired));
            Assert.That(token2.Token, Is.EqualTo(expectedToken));
            Assert.That(token2.LastRefreshed, Is.EqualTo(expectedLastRefreshed.AddDays(1)));
        }

        [TestCase]
        public void Test_Constructor_3()
        {
            AppId appId = new AppId(1);
            EntityId entityId = new EntityId(1);
            EntityId userProfileId = new EntityId(1);
            DateTime expectedAcquired = new DateTime(2023, 05, 08, 08, 39, 15);
            String expectedToken = Guid.NewGuid().ToString();
            DateTime expectedLastRefreshed = new DateTime(2023, 05, 08, 10, 05, 17);

            AuthenticationToken token = new AuthenticationToken(entityId, appId, userProfileId, expectedAcquired, expectedToken, expectedLastRefreshed);
            
            Assert.That(token.Id, Is.EqualTo(entityId));
            Assert.That(token.ApplicationId, Is.EqualTo(appId));
            Assert.That(token.UserProfileId, Is.EqualTo(userProfileId));
            Assert.That(token.Acquired, Is.EqualTo(expectedAcquired));
            Assert.That(token.Token, Is.EqualTo(expectedToken));
            Assert.That(token.LastRefreshed, Is.EqualTo(expectedLastRefreshed));
        }

        [TestCase]
        public void Test_ToString()
        {
            EntityId entityId = new EntityId(1);
            AppId appId = new AppId(1);
            EntityId userProfileId = new EntityId(1);
            DateTime expectedAcquired = new DateTime(2023, 05, 08, 08, 39, 15, 123);
            DateTime expectedLastRefreshed = new DateTime(2023, 05, 08, 10, 05, 17, 456);
            String expectedToken = Guid.NewGuid().ToString();

            String expected = $"Token Id:'{entityId}'. " +
                              $"Application Id:'{appId}'. " +
                              $"User Profile Id:'{userProfileId}'. " +
                              $"Acquired:'{expectedAcquired:yyyy-mmm-dd HH:mm:ss.fff}'. " +
                              $"Last Refreshed:'{expectedLastRefreshed:yyyy-mmm-dd HH:mm:ss.fff}'. " +
                              $"Token:'{expectedToken}'.";

            AuthenticationToken token = new AuthenticationToken(entityId, appId, userProfileId, expectedAcquired, expectedToken, expectedLastRefreshed);

            String actual = token.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
