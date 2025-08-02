//-----------------------------------------------------------------------
// <copyright file="DialogService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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
            //CurrentDispatcher.Invoke(DispatcherPriority.Normal, new Action(
            //    () =>
            //    {
                    NotificationWindow notificationWindow = new NotificationWindow(messageType, messageHeader, message);
                    notificationWindow.Show();
                //}));
        }

        /// <ineritdoc cref="IDialogService.ShowMessageBox(Object, IMessageBoxSettings)"/>
        public DialogResult ShowMessageBox(Object parent, IMessageBoxSettings messageBoxSettings)
        {
            throw new NotImplementedException();
        }

        /// <ineritdoc cref="IDialogService.ShowSaveFileDialog(Object, ISaveFileDialogSettings)"/>
        public DialogResult ShowSaveFileDialog(Object parent, ISaveFileDialogSettings saveDialogSettings)
        {
            throw new NotImplementedException();
        }

        /// <ineritdoc cref="IDialogService.ShowOpenFileDialog(Object, IOpenFileDialogSettings)"/>
        public DialogResult ShowOpenFileDialog(Object parent, IOpenFileDialogSettings openDialogSettings)
        {
            throw new NotImplementedException();
        }

        /// <ineritdoc cref="IDialogService.ShowOpenFolderDialog(Object, IOpenFolderDialogSettings)"/>
        public DialogResult ShowOpenFolderDialog(Object parent, IOpenFolderDialogSettings openDialogSettings)
        {
            DialogResult dialogResult = DialogResult.Cancel;

            FolderPicker folderPicker = new FolderPicker();
            Boolean? result = folderPicker.ShowDialog();
            if (result.HasValue)
            {
                openDialogSettings.FolderName = folderPicker.ResultName;
                dialogResult = DialogResult.Ok;
            }

            return dialogResult;
        }
    }
}
