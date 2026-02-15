//-----------------------------------------------------------------------
// <copyright file="JDV.NationalLottery.AssemblyInfo.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

[assembly: AssemblyCompany("JDV Software Ltd")]
[assembly: AssemblyCopyright("Copyright © JDV Software Ltd 2026")]
[assembly: AssemblyProduct("National Lottery")]
[assembly: AssemblyTrademark("JDV Software Ltd™")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]

[assembly: AssemblyVersion("01.0.0.0")]
[assembly: AssemblyFileVersion("01.0.0.0")]
#else
[assembly: AssemblyConfiguration("Release")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif
