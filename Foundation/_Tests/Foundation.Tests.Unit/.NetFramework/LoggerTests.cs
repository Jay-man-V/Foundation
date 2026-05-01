//-----------------------------------------------------------------------
// <copyright file="LoggerTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Logging;

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// Simple .Net Framework tests
    /// </summary>
    [TestFixture]
    public class LoggerTests
    {
        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Logger()
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Program");
            logger.LogInformation("Hello World! Logging is {Description}.", "fun");
        }
    }
}