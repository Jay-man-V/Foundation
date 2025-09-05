//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Service
{
    internal class Program
    {
        static void Main(String[] args)
        {
            // For catching Global uncaught exception
            ApplicationControl.ApplicationStart(null);

            Core.Core.Initialise(typeNamespacePrefix: "Foundation", searchPattern: "Foundation.*.exe");
            ICore core = Core.Core.TheInstance;

            ConfigureService.Configure(core);
        }
    }
}
