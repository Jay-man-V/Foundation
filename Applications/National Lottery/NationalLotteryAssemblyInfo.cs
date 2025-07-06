//-----------------------------------------------------------------------
// <copyright file="NationalLotteryAssemblyInfo.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyCompany("JDV Software Ltd")]
[assembly: AssemblyCopyright("Copyright © JDV Software Ltd 2023")]
[assembly: AssemblyProduct("National Lottery")]
[assembly: AssemblyTrademark("JDV Software Ltd")]
[assembly: AssemblyCulture("")]

[assembly: InternalsVisibleTo("NationalLottery.BusinessProcess")]
[assembly: InternalsVisibleTo("NationalLottery.Repository")]
[assembly: InternalsVisibleTo("NationalLottery.WPF.ViewModels")]

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]

[assembly: InternalsVisibleTo("NationalLottery.Tests.Unit")]
[assembly: InternalsVisibleTo("NationalLottery.Tests.System")]
[assembly: InternalsVisibleTo("NationalLottery.Tests.Views")]

[assembly: AssemblyVersion("01.0.0.0")]
[assembly: AssemblyFileVersion("01.0.0.0")]
#else
[assembly: AssemblyConfiguration("Release")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif
