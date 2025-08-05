//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Command Parser class
    /// </summary>
    [DependencyInjectionTransient]
    public class CommandParser : ICommandParser
    {
        /// <summary>
        /// Constructs a new Command Parser with the supplied parameters
        /// </summary>
        /// <param name="dateTimeService"></param>
        /// <param name="commandText">The whole command text</param>
        public CommandParser(IDateTimeService dateTimeService, String commandText)
        {
            LoggingHelpers.TraceCallEnter(dateTimeService, commandText);

            DateTimeService = dateTimeService;
            FullCommandText = commandText;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the full command text.
        /// </summary>
        /// <value>
        /// The full command text.
        /// </value>
        public String FullCommandText { get; private set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsValid { get; private set; }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public String CommandName { get; private set; } = String.Empty;

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public String Parameters { get; private set; } = String.Empty;

        /// <summary>
        /// Gets the execution date time.
        /// </summary>
        /// <value>
        /// The execution date time.
        /// </value>
        public DateTime ExecutionDateTime { get; private set; }

        /// <summary>
        /// Gets the date time service.
        /// </summary>
        /// <value>
        /// The date time service.
        /// </value>
        protected IDateTimeService DateTimeService { get; }

        public void ParseCommand(String commandText)
        {
            LoggingHelpers.TraceCallEnter(DateTimeService, commandText);

            FullCommandText = commandText;
            Int32 pos = FullCommandText.IndexOf("=", StringComparison.InvariantCulture);

            IsValid = (pos > 0);

            if (IsValid)
            {
                CommandName = FullCommandText.Substring(0, pos).ToUpper();

                Parameters = FullCommandText.Substring(pos + 1);
            }

            ValidateInput(CommandName, Parameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        private void ValidateInput(String commandName, String parameters)
        {
            LoggingHelpers.TraceCallEnter(commandName, parameters);

            // Must have a Command Name
            if (String.IsNullOrEmpty(commandName))
            {
                String errorMessage = $"Empty Command Name '{commandName}' passed to {this.GetType()}";
                throw new ArgumentNullException(nameof(commandName), errorMessage);
            }

            // Command Name must be known
            if (!CommandNames.AllCommands.Contains(commandName))
            {
                String errorMessage = $"Unknown Command Name '{commandName}' passed to {this.GetType()}";
                throw new ArgumentException(errorMessage, nameof(commandName));
            }

            // Command Specific validations
            if (commandName == CommandNames.Message)
            {
                if (String.IsNullOrEmpty(parameters))
                {
                    String errorMessage = $"Unknown Parameters '{parameters}' passed to {this.GetType()} with Command '{commandName}'";
                    throw new ArgumentException(errorMessage, nameof(parameters));
                }
            }
            else if (commandName == CommandNames.Abort)
            {
                // Nothing to do
            }
            else if (commandName == CommandNames.Quit)
            {
                if (String.IsNullOrEmpty(parameters))
                {
                    String errorMessage = $"Unknown Parameters '{parameters}' passed to {this.GetType()} with Command '{commandName}'";
                    throw new ArgumentException(errorMessage, nameof(parameters));
                }

                ExecutionDateTime = DateTime.ParseExact(parameters, Formats.DotNet.Iso8601DateTime, CultureInfo.InvariantCulture);

                // Must have a Date/Time in the future
                if (ExecutionDateTime < DateTimeService.SystemDateTimeNow)
                {
                    String errorMessage = $"Invalid DateTime '{ExecutionDateTime.ToString(Formats.DotNet.Iso8601DateTime)}' passed to {this.GetType()} with Command '{commandName}'";
                    throw new ArgumentException(errorMessage, nameof(ExecutionDateTime));
                }
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
