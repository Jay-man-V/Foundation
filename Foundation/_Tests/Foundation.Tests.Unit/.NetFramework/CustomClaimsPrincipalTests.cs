//-----------------------------------------------------------------------
// <copyright file="CustomClaimsPrincipalTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Principal;

using Foundation.Interfaces;

// https://docs.microsoft.com/en-us/dotnet/api/system.security.principal.iprincipal.isinrole?view=net-6.0
// https://stackoverflow.com/questions/7411650/authorisation-attribute
// https://blog.magnusmontin.net/2013/03/24/custom-authorization-in-wpf/

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// The Custom Claims Principal Tests class
    /// </summary>
    [TestFixture]
    public class CustomClaimsPrincipalTests
    {
    }

    [DependencyInjectionIgnore]
    public class FoundationIdentity : IIdentity
    {
        public FoundationIdentity()
        {
            AuthenticationType = String.Empty;
            IsAuthenticated = false;
            Name = String.Empty;
        }

        public String AuthenticationType { get; }
        public Boolean IsAuthenticated { get; }
        public String Name { get; }
    }

    // https://docs.microsoft.com/en-us/dotnet/framework/wcf/extending/how-to-create-a-custom-principal-identity
    [DependencyInjectionIgnore]
    public class FoundationPrincipal : IPrincipal
    {
        public FoundationPrincipal(IIdentity identity)
        {
            this.Identity = identity;
        }

        public IIdentity Identity { get; }

        public Boolean IsInRole(String role)
        {
            throw new NotImplementedException();
        }
    }
}
