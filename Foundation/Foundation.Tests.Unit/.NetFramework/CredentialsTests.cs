//-----------------------------------------------------------------------
// <copyright file="CredentialsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

using NUnit.Framework;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// Simple .Net Framework tests
    /// </summary>
    [TestFixture]
    public class CredentialsTests : UnitTestBase
    {
        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NetworkCredential()
        {
            String userName = Guid.NewGuid().ToString();
            String password = Guid.NewGuid().ToString();
            String domain = Guid.NewGuid().ToString();

            NetworkCredential networkCredential = new NetworkCredential(userName, password, domain);

            Assert.That(networkCredential.UserName, Is.EqualTo(userName));
            Assert.That(networkCredential.Password, Is.EqualTo(password));
            Assert.That(networkCredential.Domain, Is.EqualTo(domain));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetFileOwner()
        {
            FileInfo fi = new FileInfo(@"D:\Projects\Generic Entity Search.txt");
            FileSecurity fileSecurity = fi.GetAccessControl();
            IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));
            Debug.WriteLine(identityReference.Value);
        }
    }
}
