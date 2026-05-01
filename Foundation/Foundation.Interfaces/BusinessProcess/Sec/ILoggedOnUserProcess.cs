//-----------------------------------------------------------------------
// <copyright file="ILoggedOnUserProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Logged On User process
    /// </summary>
    public interface ILoggedOnUserProcess : ICommonBusinessProcess<ILoggedOnUser>
    {
        /// <summary>
        /// A list of <see cref="IGridColumnDefinition"/> items that defines the columns for the display control
        /// </summary>
        /// <returns></returns>
        List<IGridColumnDefinition> GetColumnDefinitionsForDisplayControl();

        /// <summary>
        /// Sends a Quit command to the user
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="loggedOnUser">The logged on user to send the command to</param>
        void SendQuitCommand(AppId applicationId, ILoggedOnUser loggedOnUser);

        /// <summary>
        /// Sends an Abort command to the user
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="loggedOnUser">The logged on user to send the command to</param>
        void SendAbortCommand(AppId applicationId, ILoggedOnUser loggedOnUser);

        /// <summary>
        /// Sends a Message command to the user
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="loggedOnUser">The logged on user to send the command to</param>
        /// <param name="message">The message to be sent</param>
        void SendMessageCommand(AppId applicationId, ILoggedOnUser loggedOnUser, String message);

        /// <summary>
        /// Clears the command sent to the user
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="loggedOnUser">The logged on user to send the command to</param>
        void ClearCommand(AppId applicationId, ILoggedOnUser loggedOnUser);

        /// <summary>
        /// Marks the user as logged on for the Application Id
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="userProfile">The logged on user to send the command to</param>
        void LogOnUser(AppId applicationId, IUserProfile userProfile);

        /// <summary>
        /// Updates the logged on user
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="userProfile">The logged on user to send the command to</param>
        void UpdateLoggedOnUser(AppId applicationId, IUserProfile userProfile);

        /// <summary>
        /// Retrieves a list of all logged on users
        /// </summary>
        /// <param name="applicationId">The application id</param>
        List<ILoggedOnUser> GetLoggedOnUsers(AppId applicationId);
    }
}
