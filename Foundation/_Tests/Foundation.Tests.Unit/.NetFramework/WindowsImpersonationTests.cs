//-----------------------------------------------------------------------
// <copyright file="WindowsImpersonationTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

using Microsoft.Win32.SafeHandles;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// The unit test template class
    /// </summary>
    [TestFixture]
    public class WindowsImpersonationTests
    {
        const Int32 Logon32ProviderDefault = 0;
        //This parameter causes LogonUser to create a primary token. 
        const Int32 Logon32LogonInteractive = 2;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern Boolean LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, Int32 dwLogonType, Int32 dwLogonProvider, out SafeAccessTokenHandle phToken);

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_RunImpersonated_Success()
        {
            String actionResult = $@"During impersonation: {Environment.MachineName}\{UserSecuritySupport.UnitTestAccountUserName}";

            String actualActionResult = String.Empty;
            void TestAction()
            {
                actualActionResult = $"During impersonation: {WindowsIdentity.GetCurrent().Name}";
            }

            RunImpersonated(TestAction, UserSecuritySupport.UnitTestAccountDomain, UserSecuritySupport.UnitTestAccountUserName, UserSecuritySupport.UnitTestAccountPassword);

            Assert.That(actualActionResult, Is.EqualTo(actionResult));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_RunImpersonated_Fail()
        {
            String logonDomain = "MadeUp";
            String username = "Fake";
            String password = "EncryptedPassword";

            String actionResult = String.Empty;

            String actualActionResult = String.Empty;

            Int32 errorCode = -2147467259;
            Int32 nativeErrorCode = 1326;
            String message = "The user name or password is incorrect.";

            const Action? emptyAction = null;


            Win32Exception actualException = Assert.Throws<Win32Exception>(() =>
            {
                RunImpersonated(emptyAction, logonDomain, username, password);
            });

            Assert.That(actualException, Is.Not.Null);

            Assert.That(actualException.ErrorCode, Is.EqualTo(errorCode));
            Assert.That(actualException.NativeErrorCode, Is.EqualTo(nativeErrorCode));
            Assert.That(actualException.Message, Is.EqualTo(message));

            Assert.That(actualActionResult, Is.EqualTo(actionResult));
        }

        [TestCase]
        public void Test_FoundationImpersonation()
        {
            UserSecuritySupport.RemoveUnitTestUserOnLocalComputer();

            DirectoryEntry? testAccountDirectoryEntry = UserSecuritySupport.FindUserAccount(UserSecuritySupport.UnitTestAccountUserName);
            Assert.That(testAccountDirectoryEntry, Is.Null);

            UserSecuritySupport.CreateTestingUserAccounts();

            String currentLoggedOnUser = Environment.UserName;
            UserSecuritySupport.RunFunctionUnderImpersonation(() =>
            {
                String impersonatedUser = Environment.UserName;
                Assert.That(impersonatedUser, Is.Not.EqualTo(currentLoggedOnUser));
            });
        }

        [TestCase]
        public void Test_FoundationImpersonation_Exception()
        {
            String domain = ".";
            String username = "Made up account";
            String password = "no password";

            String errorMessage = $@"Win32API::LogonUser failed for '{domain}\{username}'";
            SecurityException actualException = Assert.Throws<SecurityException>(() =>
            {
                UserSecuritySupport.RunFunctionUnderImpersonation(null, domain, username, password);
            });

            Assert.That(actualException, Is.Not.Null);
            String actualExceptionMessage = actualException.Message;

            Assert.That(actualExceptionMessage, Is.EqualTo(errorMessage));
        }

        /// <summary>
        ///
        /// </summary>
        private void RunImpersonated(Action? action, String logonDomain, String username, String password)
        {
            // Call LogonUser to obtain a handle to an access token. 
            Boolean returnValue = LogonUser
            (
                username,
                logonDomain,
                password,
                Logon32LogonInteractive,
                Logon32ProviderDefault,
                out SafeAccessTokenHandle safeAccessTokenHandle
            );

            if (!returnValue)
            {
                Int32 ret = Marshal.GetLastWin32Error();
                Debug.WriteLine($"LogonUser failed with error code : {ret}");
                throw new Win32Exception(ret);
            }

            Debug.WriteLine("LogonUser Succeed");
            // Check the identity.
            Debug.WriteLine("Before impersonation: " + WindowsIdentity.GetCurrent().Name);

            // Note: if you want to run as un-impersonated, pass 'SafeAccessTokenHandle.InvalidHandle' instead of variable 'safeAccessTokenHandle'
            if (action != null)
            {
                WindowsIdentity.RunImpersonated(safeAccessTokenHandle, action);
            }

            // Check the identity again.
            Debug.WriteLine("After impersonation: " + WindowsIdentity.GetCurrent().Name);
        }
    }
}
