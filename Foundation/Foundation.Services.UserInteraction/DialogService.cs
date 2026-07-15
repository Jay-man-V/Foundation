//-----------------------------------------------------------------------
// <copyright file="DialogService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Views;

namespace Foundation.Services.UserInteraction
{
    /// <ineritdoc cref="IDialogService" />
    [DependencyInjectionTransient]
    public class DialogService : IDialogService
    {
        /// <ineritdoc cref="IDialogService.ShowNotificationMessage(MessageType, String, String)"/>
        public void ShowNotificationMessage(MessageType messageType, String messageHeader, String message)
        {
            LoggingHelpers.TraceCallEnter(messageType, messageHeader, message);

            //CurrentDispatcher.Invoke(DispatcherPriority.Normal, new Action(
            //    () =>
            //    {
                    NotificationWindow notificationWindow = new NotificationWindow(messageType, messageHeader, message);
                    notificationWindow.Show();
                //}));

            LoggingHelpers.TraceCallReturn();
        }

        /// <ineritdoc cref="IDialogService.ShowMessageBox(Object, IMessageBoxSettings)"/>
        public DialogResult ShowMessageBox(Object parent, IMessageBoxSettings messageBoxSettings)
        {
            LoggingHelpers.TraceCallEnter(parent, messageBoxSettings);

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }

        /// <ineritdoc cref="IDialogService.ShowSaveFileDialog(Object, ISaveFileDialogSettings)"/>
        public DialogResult ShowSaveFileDialog(Object parent, ISaveFileDialogSettings saveDialogSettings)
        {
            LoggingHelpers.TraceCallEnter(parent, saveDialogSettings);

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }

        /// <ineritdoc cref="IDialogService.ShowOpenFileDialog(Object, IOpenFileDialogSettings)"/>
        public DialogResult ShowOpenFileDialog(Object parent, IOpenFileDialogSettings openDialogSettings)
        {
            LoggingHelpers.TraceCallEnter(parent, openDialogSettings);

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }

        /// <ineritdoc cref="IDialogService.ShowOpenFolderDialog(Object, IOpenFolderDialogSettings)"/>
        public DialogResult ShowOpenFolderDialog(Object parent, IOpenFolderDialogSettings openDialogSettings)
        {
            LoggingHelpers.TraceCallEnter(parent, openDialogSettings);

            DialogResult dialogResult = DialogResult.Cancel;

            FolderPicker folderPicker = new FolderPicker();
            Boolean? result = folderPicker.ShowDialog();
            if (result.HasValue)
            {
                openDialogSettings.FolderName = folderPicker.ResultName;
                dialogResult = DialogResult.Ok;
            }

            LoggingHelpers.TraceCallReturn();

            return dialogResult;
        }
    }
}
