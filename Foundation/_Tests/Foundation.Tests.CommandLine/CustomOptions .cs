//-----------------------------------------------------------------------
// <copyright file="CustomOptions .cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Logging.Console;

namespace Foundation.Tests.CommandLine
{
    public sealed class CustomOptions : ConsoleFormatterOptions
    {
        public string? CustomPrefix { get; set; }
    }
}
