//-----------------------------------------------------------------------
// <copyright file="FoundationAssemblyInfo.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyCompany("JDV Software Ltd")]
[assembly: AssemblyCopyright("Copyright © JDV Software Ltd 2023")]
[assembly: AssemblyProduct("Foundation")]
[assembly: AssemblyTrademark("JDV Software Ltd")]
[assembly: AssemblyCulture("")]

//[assembly: AssemblyKeyFile(@"..\..\..\Foundation.snk")] /* PublicKey=623f5633252e817b */

[assembly: InternalsVisibleTo("Foundation.ApplicationServices")]
[assembly: InternalsVisibleTo("Foundation.BusinessProcess")]
[assembly: InternalsVisibleTo("Foundation.Repository")]
[assembly: InternalsVisibleTo("Foundation.ViewModels")]

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]

[assembly: InternalsVisibleTo("Foundation.Tests.System")]
[assembly: InternalsVisibleTo("Foundation.Tests.Unit")]
[assembly: InternalsVisibleTo("Foundation.Tests.Views")]

[assembly: AssemblyVersion("01.0.0.0")]
[assembly: AssemblyFileVersion("01.0.0.0")]
#else
[assembly: AssemblyConfiguration("Release")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif
