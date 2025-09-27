//-----------------------------------------------------------------------
// <copyright file="CommandParserTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.BusinessProcess.Helpers;
using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.HelpersTests
{
    /// <summary>
    /// Summary description for the Command Parser tests
    /// </summary>
    [TestFixture]
    public class CommandParserTests : UnitTestBase
    {
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(CommandNames);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CommandNames.Quit)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CommandNames.Abort)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CommandNames.Message)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CommandNames.AllCommands)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        [TestCase]
        public void Test_QuitCommand()
        {
            String commandName = CommandNames.Quit;
            // The DateTime is constructed like this to remove Milliseconds from the value
            DateTime parameter = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).AddDays(1);
            String commandText = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";

            CommandParser commandParser = new CommandParser(DateTimeService);

            commandParser.ParseCommand(commandText);
            DateTime parsedDateTime = commandParser.ExecutionDateTime;

            Assert.That(commandParser.IsValid, Is.EqualTo(true));
            Assert.That(commandParser.CommandName, Is.EqualTo(commandName));
            Assert.That(parsedDateTime, Is.EqualTo(parameter));
        }

        [TestCase]
        public void Test_AbortCommand()
        {
            String commandName = CommandNames.Abort;
            String commandText = $"{commandName}=";

            CommandParser commandParser = new CommandParser(DateTimeService);

            commandParser.ParseCommand(commandText);
            DateTime parsedDateTime = commandParser.ExecutionDateTime;

            Assert.That(commandParser.IsValid, Is.EqualTo(true));
            Assert.That(commandParser.CommandName, Is.EqualTo(commandName));
            Assert.That(DateTime.MinValue, Is.EqualTo(parsedDateTime));
        }

        [TestCase]
        public void Test_MessageCommand()
        {
            String commandName = CommandNames.Message;
            String parameter = "Message to be shown to the user";
            String commandText = $"{commandName}={parameter}";

            CommandParser commandParser = new CommandParser(DateTimeService);

            commandParser.ParseCommand(commandText);

            Assert.That(commandParser.IsValid, Is.EqualTo(true));
            Assert.That(commandParser.CommandName, Is.EqualTo(commandName));
            Assert.That(commandParser.Parameters, Is.EqualTo(parameter));
        }

        [TestCase]
        public void Test_Parser_Exception_NoCommand()
        {
            String commandName = String.Empty;
            DateTime parameter = new DateTime(2021, 1, 5, 21, 22, 5);
            String parameterBeingTested = "commandName";
            String commandText = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";

            String errorMessage = $"Empty Command Name '' passed to {typeof(CommandParser)} (Parameter '{parameterBeingTested}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                CommandParser commandParser = new CommandParser(DateTimeService);

                commandParser.ParseCommand(commandText);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void Test_Parser_Exception_UnknownCommand()
        {
            String commandName = "UNKNOWN COMMAND";
            DateTime parameter = new DateTime(2021, 1, 5, 21, 22, 5);
            String parameterBeingTested = "commandName";
            String commandText = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";

            String errorMessage = $"Unknown Command Name '{commandName}' passed to {typeof(CommandParser)} (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                CommandParser commandParser = new CommandParser(DateTimeService);

                commandParser.ParseCommand(commandText);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void Test_Parser_Exception_Quit_NoDateParameter()
        {
            String commandName = CommandNames.Quit;
            String parameterBeingTested = "parameters";
            String commandText = $"{commandName}=";

            String errorMessage = $"Unknown Parameters '' passed to {typeof(CommandParser)} with Command '{commandName}' (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                CommandParser commandParser = new CommandParser(DateTimeService);

                commandParser.ParseCommand(commandText);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void Test_Parser_Exception_Quit_InThePast()
        {
            String commandName = CommandNames.Quit;
            DateTime parameter = new DateTime(2022, 01, 01, 10, 00, 00);
            String parameterBeingTested = "ExecutionDateTime";
            String commandText = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";

            String errorMessage = $"Invalid DateTime '{parameter.ToString(Formats.DotNet.Iso8601DateTime)}' passed to {typeof(CommandParser)} with Command '{commandName}' (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                CommandParser commandParser = new CommandParser(DateTimeService);

                commandParser.ParseCommand(commandText);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }

        [TestCase]
        public void Test_Parser_Exception_Message_NoParameter()
        {
            String commandName = CommandNames.Message;
            String parameterBeingTested = "parameters";
            String commandText = $"{commandName}=";

            String errorMessage = $"Unknown Parameters '' passed to {typeof(CommandParser)} with Command '{commandName}' (Parameter '{parameterBeingTested}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                CommandParser commandParser = new CommandParser(DateTimeService);

                commandParser.ParseCommand(commandText);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterBeingTested));
        }
    }
}
