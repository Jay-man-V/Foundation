//-----------------------------------------------------------------------
// <copyright file="CommandFormatter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;

using Foundation.Common;
using Foundation.Resources;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Command Parser class
    /// </summary>
    public class CommandFormatter
    {
        /// <summary>
        /// Constructs a new <see cref="CommandFormatter"/> with the specified parameters
        /// </summary>
        /// <param name="commandName">Name of the command</param>
        public CommandFormatter
        (
            String commandName
        )
            : this
            (
                commandName,
                DateTime.MinValue,
                String.Empty
            )
        {
            LoggingHelpers.TraceCallEnter(commandName);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Constructs a new <see cref="CommandFormatter"/> with the specified parameters
        /// </summary>
        /// <param name="commandName">Name of the command</param>
        /// <param name="dateTime">Date/Time to execute the command</param>
        public CommandFormatter
        (
            String commandName,
            DateTime dateTime
        )
            : this
            (
                commandName,
                dateTime,
                String.Empty
            )
        {
            LoggingHelpers.TraceCallEnter(commandName, dateTime);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Constructs a new <see cref="CommandFormatter"/> with the specified parameters
        /// </summary>
        /// <param name="commandName">Name of the command</param>
        /// <param name="dateTime">Date/Time to execute the command</param>
        /// <param name="message">Message to be displayed to the user</param>
        public CommandFormatter
        (
            String commandName,
            DateTime dateTime,
            String message
        )
        {
            LoggingHelpers.TraceCallEnter(commandName, dateTime, message);

            commandName = commandName.ToUpper();
            Command = String.Empty;

            ValidateInput(commandName, dateTime, message);

            if (commandName == CommandNames.Abort)
            {
                Command = $"{commandName}=";
            }
            else if (commandName == CommandNames.Quit)
            {
                Command = $"{commandName}={dateTime.ToString(Formats.DotNet.Iso8601DateTime)}";
            }
            else if (commandName == CommandNames.Message)
            {
                Command = $"{commandName}={message}";
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public String Command { get; }

        /// <summary>
        /// Validates the supplied parameters
        /// </summary>
        /// <param name="commandName">The command name</param>
        /// <param name="dateTime">The date time to execute</param>
        /// <param name="message">The message to be displayed</param>
        /// <exception cref="ArgumentNullException">If a parameter is not supplied</exception>
        /// <exception cref="ArgumentException">If a parameter is not valid</exception>
        private void ValidateInput(String commandName, DateTime dateTime, String message)
        {
            LoggingHelpers.TraceCallEnter(commandName, dateTime, message);

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
                // Must have a Date/Time
                if (dateTime == DateTime.MinValue)
                {
                    String errorMessage = $"Invalid DateTime '{dateTime.ToString(Formats.DotNet.Iso8601DateTime)}' passed to {this.GetType()}";
                    throw new ArgumentException(errorMessage, nameof(dateTime));
                }

                if (String.IsNullOrEmpty(message))
                {
                    String errorMessage = $"Empty message '{message}' passed to {this.GetType()}";
                    throw new ArgumentException(errorMessage, nameof(message));
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            return Command;
        }
    }
}
