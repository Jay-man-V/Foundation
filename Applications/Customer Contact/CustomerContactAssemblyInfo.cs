//-----------------------------------------------------------------------
// <copyright file="CustomerContactAssemblyInfo.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyCompany("JDV Software Ltd")]
[assembly: AssemblyCopyright("Copyright © JDV Software Ltd 2023")]
[assembly: AssemblyProduct("Customer Contact")]
[assembly: AssemblyTrademark("JDV Software Ltd")]
[assembly: AssemblyCulture("")]

[assembly: InternalsVisibleTo("CustomerContact.BusinessProcess")]
[assembly: InternalsVisibleTo("CustomerContact.DataAccess")]
[assembly: InternalsVisibleTo("CustomerContact.WPF.ViewModels")]

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]

[assembly: InternalsVisibleTo("CustomerContact.Tests.Unit")]
[assembly: InternalsVisibleTo("CustomerContact.Tests.Views")]

[assembly: AssemblyVersion("01.0.0.0")]
[assembly: AssemblyFileVersion("01.0.0.0")]
#else
[assembly: AssemblyConfiguration("Release")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif
