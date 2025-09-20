//-----------------------------------------------------------------------
// <copyright file="UserSecuritySupport.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

using Microsoft.Win32.SafeHandles;

// https://docs.microsoft.com/en-us/dotnet/api/system.security.principal.windowsidentity.runimpersonated?view=net-6.0&viewFallbackFrom=netcore-3.1

namespace Foundation.Tests.Unit.Support
{
    /// <summary>
    /// The user security support class
    /// </summary>
    internal class UserSecuritySupport
    {
        /// <summary>
        /// The unit test Logon Domain
        /// </summary>
        public const String UnitTestAccountDomain = ".";

        /// <summary>
        /// The unit test account username
        /// </summary>
        public const String UnitTestAccountUserName = "UnitTestUserName";

        /// <summary>
        /// The unit test account display name
        /// </summary>
        public const String UnitTestAccountDisplayName = "Unit Test User Name";

        /// <summary>
        /// The unit test account password
        /// </summary>
        public const String UnitTestAccountPassword = "Password12345!";

        /// <summary>
        /// Logs the user on.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="password">The password.</param>
        /// <param name="logonType">Type of the logon.</param>
        /// <param name="logonProvider">The logon provider.</param>
        /// <param name="token">The token.</param>
        /// <returns>A boolean value indicates the function succeeded or not.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Boolean LogonUser(
            String username,
            String domain,
            String password,
            Int32 logonType,
            Int32 logonProvider,
            out SafeAccessTokenHandle token);

        /// <summary>
        /// Impersonates the unit test user account.
        /// </summary>
        /// <exception cref="SecurityException">Logon user failed</exception>
        public static void RunFunctionUnderImpersonation(Action? action,
                                                         String domain = UnitTestAccountDomain,
                                                         String username = UnitTestAccountUserName,
                                                         String password = UnitTestAccountPassword)
        {
            Boolean success = LogonUser(
                username,
                domain,
                password,
                2, // (int) AdvApi32Utility.LogonType.LOGON32_LOGON_INTERACTIVE, //2
                0, // (int) AdvApi32Utility.LogonProvider.LOGON32_PROVIDER_DEFAULT, //0
                out SafeAccessTokenHandle safeAccessTokenHandle);

            if (!success)
            {
                String errorMessage = $@"Win32API::LogonUser failed for '{domain}\{username}'";
                throw new SecurityException(errorMessage);
            }

            if (action != null)
            {
                WindowsIdentity.RunImpersonated(safeAccessTokenHandle, action);
            }
        }

        /// <summary>
        /// Creates the testing user accounts.
        /// </summary>
        public static void CreateTestingUserAccounts()
        {
            DirectoryEntry? unitTestUserAccount = FindUserAccount(UnitTestAccountUserName);
            if (unitTestUserAccount == null)
            {
                //DirectoryEntry deComputer = new DirectoryEntry($"WinNT://{UnitTestAccountDomain},computer");
                //DirectoryEntry deUser = deComputer.Children.Add(UnitTestAccountUserName, "user");
                //deUser.Invoke("SetPassword", new Object[] { UnitTestAccountPassword });
                //deUser.Invoke("Put", new Object[] { "Description", "Test User from Foundation Automated Unit Tests" });
                //deUser.CommitChanges();

                //DirectoryEntry grp = deComputer.Children.Find("Users", "group");
                //grp.Invoke("Add", new { deUser.Path });

                using (PrincipalContext ctx = new PrincipalContext(ContextType.Machine))
                {
                    // Create new user
                    UserPrincipal newUser = new UserPrincipal(ctx)
                    {
                        // Set some properties
                        SamAccountName = UnitTestAccountUserName,
                        DisplayName = UnitTestAccountDisplayName,
                    };

                    // Define new user to be enabled and password never expires
                    newUser.SetPassword(UnitTestAccountPassword);
                    newUser.Description = "Test User from Foundation Automated Unit Tests";
                    newUser.Enabled = true;
                    newUser.PasswordNeverExpires = true;

                    // Save new user
                    newUser.Save();

                    String sAdministrators = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null).Translate(typeof(NTAccount)).Value;

                    GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, sAdministrators);
                    groupPrincipal.Members.Add(newUser);
                    groupPrincipal.Save();
                }
            }
        }

        /// <summary>
        /// Removes the unit test user on local computer.
        /// </summary>
        public static void RemoveUnitTestUserOnLocalComputer()
        {
            DirectoryEntry localDirectory = new DirectoryEntry($"WinNT://{UnitTestAccountDomain}");
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry? user = FindUserAccount(UnitTestAccountUserName);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        /// <summary>
        /// Finds the user account.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The <see cref="DirectoryEntry"/></returns>
        public static DirectoryEntry? FindUserAccount(String userName)
        {
            String directoryPath = $"WinNT://{UnitTestAccountDomain},computer";
            DirectoryEntry localComputer = new DirectoryEntry(directoryPath);

            DirectoryEntry? foundUser = null;
            try
            {
                foundUser = localComputer.Children.Find(userName);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 0)
                {
                    // Does nothing
                }
            }

            return foundUser;
        }
    }
}
