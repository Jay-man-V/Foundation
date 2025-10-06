//-----------------------------------------------------------------------
// <copyright file="ICommandParser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Parses the given command text
        /// </summary>
        /// <param name="commandText"></param>
        ICommandParser ParseCommand(String commandText);

        /// <summary>
        /// Gets the full command text.
        /// </summary>
        /// <value>
        /// The full command text.
        /// </value>
        String FullCommandText { get; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        Boolean IsValid { get; }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        String CommandName { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        String Parameters { get; }

        /// <summary>
        /// Gets the execution date time.
        /// </summary>
        /// <value>
        /// The execution date time.
        /// </value>
        DateTime ExecutionDateTime { get; }
    }
}
