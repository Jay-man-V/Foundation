//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionInterfaces.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
#if(DEBUG)
    public interface IMockApplicationStartup : IApplicationStartup
    {
        Boolean ApplicationStartupCalled { get; set; }
    }
#endif
}
