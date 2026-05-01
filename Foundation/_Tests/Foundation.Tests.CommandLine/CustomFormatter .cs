//-----------------------------------------------------------------------
// <copyright file="CustomOptions .cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Foundation.Tests.CommandLine
{
    public sealed class CustomFormatter : ConsoleFormatter, IDisposable
    {
        public static String CustomFormatterName => "FoundationLogCustomFormatter";
        private readonly IDisposable? _optionsReloadToken;
        private CustomOptions _formatterOptions;

        public CustomFormatter(IOptionsMonitor<CustomOptions> options)
            : base(CustomFormatterName) =>
            (_optionsReloadToken, _formatterOptions) =
            (options.OnChange(ReloadLoggerOptions), options.CurrentValue);

        private void ReloadLoggerOptions(CustomOptions options) => _formatterOptions = options;

        public override void Write<TState>
        (
            in LogEntry<TState> logEntry,
            IExternalScopeProvider? scopeProvider,
            TextWriter textWriter
        )
        {
            String? message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);

            if (message is not null)
            {
                CustomLogicGoesHere(textWriter);
                textWriter.WriteLine($"[{logEntry.LogLevel}] {message}");
            }
        }

        private void CustomLogicGoesHere(TextWriter textWriter)
        {
            textWriter.Write(_formatterOptions.CustomPrefix);
        }

        public void Dispose() => _optionsReloadToken?.Dispose();
    }
}
