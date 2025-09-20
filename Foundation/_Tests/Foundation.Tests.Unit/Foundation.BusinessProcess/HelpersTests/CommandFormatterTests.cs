//-----------------------------------------------------------------------
// <copyright file="CommandFormatterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Helpers;
using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.HelpersTests
{
    /// <summary>
    /// Summary description for the Command Formatter tests
    /// </summary>
    [TestFixture]
    public class CommandFormatterTests : UnitTestBase
    {
        [TestCase]
        public void TestCountCommands()
        {
            // This test is here to ensure each of the commands are tested, if a command is added or removed, this test will fail
            String[] knownCommands = { CommandNames.Abort, CommandNames.Message, CommandNames.Quit };

            Assert.That(CommandNames.AllCommands, Is.EquivalentTo(knownCommands));
            Assert.That(CommandNames.AllCommands.Length, Is.EqualTo(knownCommands.Length));
        }

        [TestCase]
        public void TestQuitCommand()
        {
            String commandName = CommandNames.Quit;
            DateTime parameterDateTime = new DateTime(2021, 1, 5, 21, 22, 5);
            String commandText = $"{commandName}={parameterDateTime.ToString(Formats.DotNet.Iso8601DateTime)}";

            CommandFormatter commandFormatter = new CommandFormatter(commandName, parameterDateTime);

            Assert.That(commandFormatter.ToString(), Is.EqualTo(commandText));
        }

        [TestCase]
        public void TestAbortCommand()
        {
            String commandName = CommandNames.Abort;
            String commandText = $"{commandName}=";

            CommandFormatter commandFormatter = new CommandFormatter(commandName);

            Assert.That(commandFormatter.ToString(), Is.EqualTo(commandText));
        }

        [TestCase]
        public void TestMessageCommand()
        {
            String commandName = CommandNames.Message;
            DateTime parameterDateTime = new DateTime(2021, 1, 5, 21, 22, 5);
            String parameterMessage = "Message to be shown to the user";
            String commandText = $"{commandName}={parameterMessage}";

            CommandFormatter commandFormatter = new CommandFormatter(commandName, parameterDateTime, parameterMessage);

            Assert.That(commandFormatter.ToString(), Is.EqualTo(commandText));
        }

        [TestCase]
        public void TestParser_Exception_NoCommand()
        {
            String commandName = String.Empty;
            String parameterBeingTested = "commandName";
            DateTime parameterDateTime = new DateTime(2021, 1, 5, 21, 22, 5);
            String errorMessage = $"Empty Command Name '' passed to {typeof(CommandFormatter)} (Parameter '{parameterBeingTested}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new CommandFormatter(commandName, parameterDateTime);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void TestParser_Exception_UnknownCommand()
        {
            String commandName = "MADE UP COMMAND";
            String parameterBeingTested = "commandName";
            DateTime parameterDateTime = new DateTime(2021, 1, 5, 21, 22, 5);
            String errorMessage = $"Unknown Command Name '{commandName}' passed to {typeof(CommandFormatter)} (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new CommandFormatter(commandName, parameterDateTime);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void TestParser_Exception_NoDateTime()
        {
            String commandName = CommandNames.Message;
            String parameterBeingTested = "dateTime";
            DateTime parameterDateTime = DateTime.MinValue;

            String errorMessage = $"Invalid DateTime '{parameterDateTime.ToString(Formats.DotNet.Iso8601DateTime)}' passed to {typeof(CommandFormatter)} (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new CommandFormatter(commandName, parameterDateTime);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void TestParser_Exception_EmptyMessage()
        {
            String commandName = CommandNames.Message;
            String parameterBeingTested = "message";
            DateTime parameterDateTime = new DateTime(2021, 1, 5, 21, 22, 5);
            String parameterMessage = String.Empty;

            String errorMessage = $"Empty message '{parameterMessage}' passed to {typeof(CommandFormatter)} (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new CommandFormatter(commandName, parameterDateTime);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }
    }
}
