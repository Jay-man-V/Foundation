//-----------------------------------------------------------------------
// <copyright file="LoggerTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Logging;

using Foundation.Common;

namespace Foundation.Tests.CommandLine
{
    /// <summary>
     /// Simple .Net Framework tests
     /// </summary>
    public class LoggerTests
    {
        /// <summary>
        ///
        /// </summary>
        static void Main(String[] args)
        {
            //using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddCustomFormatter(options => options.CustomPrefix = " ~~~~~ "));
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddCustomFormatter(options => options.UseUtcTimestamp = true));
            ILogger<LoggerTests> logger = loggerFactory.CreateLogger<LoggerTests>();
            try
            {
                logger.LogInformation(nameof(LoggerTests));
                logger.LogInformation("Hello World! Logging is \"{Description}\".", args.Serialise());
                logger.LogWarning("Hello World! Logging is {Description}.", "fun");
                logger.LogError("Hello World! Logging is {Description}.", "fun");

                FunctionWithException();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in FunctionWithException.");
            }
        }

        private static void FunctionWithException()
        {
            throw new InvalidOperationException("This is a test exception.");
        }
    }
}
