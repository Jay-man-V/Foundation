//-----------------------------------------------------------------------
// <copyright file="ConsoleLoggerExtensions.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Logging;

namespace Foundation.Tests.CommandLine
{
    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddCustomFormatter(this ILoggingBuilder builder, Action<CustomOptions> configure)
        {
            ILoggingBuilder loggingBuilder = builder.AddConsole(options => options.FormatterName = CustomFormatter.CustomFormatterName);
            loggingBuilder = loggingBuilder.AddConsoleFormatter<CustomFormatter, CustomOptions>(configure);

            return loggingBuilder;
        }
    }
}
