//-----------------------------------------------------------------------
// <copyright file="CommandNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Command Names class
    /// </summary>
    public static class CommandNames
    {
        /// <summary>
        /// Quit command forces the application to close.
        /// </summary>
        /// <value>
        /// QUIT.
        /// </value>
        public static String Quit => "QUIT";

        /// <summary>
        /// Abort command aborts the last sent command
        /// </summary>
        /// <value>
        /// ABORT.
        /// </value>
        public static String Abort => "ABORT";

        /// <summary>
        /// Displays a message to logged on users
        /// </summary>
        /// <value>
        /// MESSAGE.
        /// </value>
        public static String Message => "MESSAGE";

        /// <summary>
        /// Gets all commands.
        /// </summary>
        /// <value>
        /// ABORT, MESSAGE, QUIT.
        /// </value>
        public static String[] AllCommands => new[] { Abort, Message, Quit };
    }
}
