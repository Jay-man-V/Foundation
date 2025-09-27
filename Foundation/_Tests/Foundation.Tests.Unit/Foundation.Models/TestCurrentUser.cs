﻿//-----------------------------------------------------------------------
// <copyright file="TestCurrentUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Models
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class TestCurrentUser : BusinessProcessUnitTestBase
    {
        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_AllProperties()
        {
            EntityId entityId = new EntityId(1);

            Assert.That(CoreInstance.CurrentLoggedOnUser.UserProfile, Is.Not.EqualTo(null));
            Assert.That(CoreInstance.CurrentLoggedOnUser.Id.ToInteger(), Is.EqualTo(entityId.ToInteger()));
            Assert.That(CoreInstance.CurrentLoggedOnUser.IsSystemSupport, Is.EqualTo(true));

            Assert.That(CoreInstance.CurrentLoggedOnUser.DisplayName, Is.EqualTo(UserSecuritySupport.UnitTestAccountDisplayName));
            Assert.That(CoreInstance.CurrentLoggedOnUser.Username, Is.EqualTo($@"{UserSecuritySupport.UnitTestAccountDomain}\{UserSecuritySupport.UnitTestAccountUserName}"));
        }
    }
}
