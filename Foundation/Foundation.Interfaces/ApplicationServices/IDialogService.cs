//-----------------------------------------------------------------------
// <copyright file="IDialogService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Dialog Service
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Shows a notification message to the user
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="messageHeader"></param>
        /// <param name="message"></param>
        void ShowNotificationMessage(MessageType messageType, String messageHeader, String message);

        /// <summary>
        /// Shows a message box to the user based on the <paramref name="messageBoxSettings"/>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="messageBoxSettings"></param>
        /// <returns></returns>
        DialogResult ShowMessageBox(Object parent, IMessageBoxSettings messageBoxSettings);

        /// <summary>
        /// Shows a Save file dialog to the user based on the <paramref name="saveDialogSettings"/>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="saveDialogSettings"></param>
        /// <returns></returns>
        DialogResult ShowSaveFileDialog(Object parent, ISaveFileDialogSettings saveDialogSettings);

        /// <summary>
        /// Shows a Open file dialog to the user based on the <paramref name="openDialogSettings"/>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="openDialogSettings"></param>
        /// <returns></returns>
        DialogResult ShowOpenFileDialog(Object parent, IOpenFileDialogSettings openDialogSettings);

        /// <summary>
        /// Shows a Open folder dialog to the user based on the <paramref name="openDialogSettings"/>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="openDialogSettings"></param>
        /// <returns></returns>
        DialogResult ShowOpenFolderDialog(Object parent, IOpenFolderDialogSettings openDialogSettings);
    }
}
