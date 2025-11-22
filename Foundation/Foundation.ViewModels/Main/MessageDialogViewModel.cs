//-----------------------------------------------------------------------
// <copyright file="MessageDialogViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;

using Foundation.Common;
using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.ViewModels.Main
{
    /// <summary>
    /// The User Interface interaction logic for Message Dialogs
    /// </summary>
    public class MessageDialogViewModel : ViewModel
    {
        /// <summary>
        /// Local constants
        /// </summary>
        private static class Constants
        {
            public const String Yes = "YES";
            public const String No = "NO";
            public const String Cancel = "CANCEL";
            public const String Okay = "OKAY";
            public const String Close = "CLOSE";
        }

        /// <summary>Initialises a new instance of the <see cref="MessageDialogViewModel" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        /// <param name="formTitle">The form title.</param>
        public MessageDialogViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IWindow targetWindow,
            IViewModel parentViewModel,
            String formTitle = "Information"
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                formTitle
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, targetWindow, parentViewModel, formTitle);

            Exception = null;
            ExceptionOutput = null;

            ExpanderCaption = "More Information";

            MessageBoxImage = FEnums.MessageBoxImage.None;

            Message = "<Message>";
            Source = "<Source>";
            Detail = "<Detail>";

            ComputerName = "<Computer Name>";
            MessageDateTime = DateTimeService.SystemDateTimeNowWithoutMilliseconds;
            UserLogon = "<User logon>";

            // All buttons are collapsed by default except Close
            YesVisibility = Visibility.Collapsed;
            NoVisibility = Visibility.Collapsed;
            OkayVisibility = Visibility.Collapsed;
            CancelVisibility = Visibility.Collapsed;
            CloseVisibility = Visibility.Visible;
            ContinueVisibility = Visibility.Collapsed;
            ExitApplicationVisibility = Visibility.Collapsed;

            MessageBoxResult = MessageBoxResult.None;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Initialises a new instance of the <see cref="MessageDialogViewModel" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        /// <param name="messageBoxImage">The message box image.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="formTitle">The form title.</param>
        public MessageDialogViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IWindow targetWindow,
            IViewModel parentViewModel,
            FEnums.MessageBoxImage messageBoxImage,
            Exception exception,
            String formTitle
        ) :
        this
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                targetWindow,
                parentViewModel,
                formTitle
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, targetWindow, parentViewModel, messageBoxImage, exception, formTitle);

            Exception = exception;
            ExceptionOutput = MessageFormatter.FormatMessage(runTimeEnvironmentSettings, dateTimeService, Exception);

            MessageBoxImage = messageBoxImage;

            Message = ExceptionOutput.ErrorMessage;
            Detail = ExceptionOutput.ErrorDetail;
            Source = ExceptionOutput.ErrorSource;
            MessageDateTime = ExceptionOutput.ErrorUtcDateTime;
            ComputerName = ExceptionOutput.ComputerName;
            UserLogon = ExceptionOutput.UserLogon;

            // All buttons as per main constructor except Close, Continue, and ExitApplication
            CloseVisibility = Visibility.Collapsed;
            ContinueVisibility = Visibility.Visible;
            ExitApplicationVisibility = Visibility.Visible;

            MessageBoxResult = MessageBoxResult.None;

            ScreenInstructions = exception.Message;

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            // Nothing to do

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Gets the exception.</summary>
        /// <value>The exception.</value>
        protected Exception? Exception { get; }

        /// <summary>Gets the exception output.</summary>
        /// <value>The exception output.</value>
        protected ExceptionOutput? ExceptionOutput { get; }

        /// <summary>Gets or sets a value indicating whether this <see cref="MessageDialogViewModel" /> is expanded.</summary>
        /// <value>
        ///   <c>true</c> if expanded; otherwise, <c>false</c>.</value>
        protected Boolean Expanded { get; set; }

        /// <summary>Gets the message box result.</summary>
        /// <value>The message box result.</value>
        public MessageBoxResult MessageBoxResult { get; private set; }

        /// <summary>Gets the message.</summary>
        /// <value>The message.</value>
        public String Message { get; }
        
        /// <summary>Gets the detail.</summary>
        /// <value>The detail.</value>
        public String Detail { get; }
        
        /// <summary>Gets the source.</summary>
        /// <value>The source.</value>
        public String Source { get; }
        
        /// <summary>Gets the message date time.</summary>
        /// <value>The message date time.</value>
        public DateTime MessageDateTime { get; }
        
        /// <summary>Gets the name of the computer.</summary>
        /// <value>The name of the computer.</value>
        public String ComputerName { get; }
        
        /// <summary>Gets the user logon.</summary>
        /// <value>The user logon.</value>
        public String UserLogon { get; }
        
        /// <summary>Gets the yes visibility.</summary>
        /// <value>The yes visibility.</value>
        public Visibility YesVisibility { get; }
        
        /// <summary>Gets the no visibility.</summary>
        /// <value>The no visibility.</value>
        public Visibility NoVisibility { get; }
        
        /// <summary>Gets the okay visibility.</summary>
        /// <value>The okay visibility.</value>
        public Visibility OkayVisibility { get; }
        
        /// <summary>Gets the cancel visibility.</summary>
        /// <value>The cancel visibility.</value>
        public Visibility CancelVisibility { get; }
        
        /// <summary>Gets the close visibility.</summary>
        /// <value>The close visibility.</value>
        public Visibility CloseVisibility { get; }
        
        /// <summary>Gets or sets the continue visibility.</summary>
        /// <value>The continue visibility.</value>
        public Visibility ContinueVisibility { get; set; }
        
        /// <summary>Gets the exit application visibility.</summary>
        /// <value>The exit application visibility.</value>
        public Visibility ExitApplicationVisibility { get; }
        
        /// <summary>Gets the expander caption.</summary>
        /// <value>The expander caption.</value>
        public String ExpanderCaption { get; private set; }
        
        /// <summary>Gets the yes button command.</summary>
        /// <value>The yes button command.</value>
        public ICommand YesButtonCommand => RelayCommandFactory.New<IWindow>(OnYesButtonCommand_Execute);

        /// <summary>Gets the no button command.</summary>
        /// <value>The no button command.</value>
        public ICommand NoButtonCommand => RelayCommandFactory.New<IWindow>(OnNoButtonCommand_Execute);

        /// <summary>Gets the okay button command.</summary>
        /// <value>The okay button command.</value>
        public ICommand OkayButtonCommand => RelayCommandFactory.New<IWindow>(OnOkayButtonCommand_Execute);

        /// <summary>Gets the cancel button command.</summary>
        /// <value>The cancel button command.</value>
        public ICommand CancelButtonCommand => RelayCommandFactory.New<IWindow>(OnCancelButtonCommand_Execute);

        /// <summary>Gets the close button command.</summary>
        /// <value>The close button command.</value>
        public ICommand CloseButtonCommand => RelayCommandFactory.New<IWindow>(OnCloseButtonCommand_Execute);

        /// <summary>Gets the copy to clipboard command.</summary>
        /// <value>The copy to clipboard command.</value>
        public ICommand CopyToClipboardCommand => RelayCommandFactory.New<object>(OnCopyToClipboardCommand_Execute);

        /// <summary>Gets the expanded collapsed event command.</summary>
        /// <value>The expanded collapsed event command.</value>
        public ICommand ExpandedCollapsedEventCommand => RelayCommandFactory.New<object>(OnExpandedCollapsedEventCommand_Execute);

        /// <summary>Called when [expanded collapsed event command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnExpandedCollapsedEventCommand_Execute(object? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            using (MouseCursor)
            {
                Expanded = !Expanded;
                ExpanderCaption = Expanded ? "Less Information" : "More Information";

                NotifyPropertyChanged(nameof(ExpanderCaption));
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [copy to clipboard command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnCopyToClipboardCommand_Execute(object? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            using (MouseCursor)
            {
                ClipBoardWrapper.SetText(Detail);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [button command execute].</summary>
        /// <param name="window">The window.</param>
        /// <param name="buttonText">The button text.</param>
        /// <exception cref="ArgumentException"></exception>
        private void OnButtonCommand_Execute(IWindow? window, String buttonText)
        {
            LoggingHelpers.TraceCallEnter(window);

            using (MouseCursor)
            {
                switch (buttonText.ToUpper())
                {
                    case Constants.Yes: MessageBoxResult = MessageBoxResult.Yes; break;
                    case Constants.No: MessageBoxResult = MessageBoxResult.No; break;
                    case Constants.Cancel: MessageBoxResult = MessageBoxResult.Cancel; break;
                    case Constants.Okay: MessageBoxResult = MessageBoxResult.OK; break;
                    case Constants.Close: MessageBoxResult = MessageBoxResult.OK; break;
                    default:
                        String message = $"{this}.{window} Command Button '{buttonText}' is unknown. Cannot process Message Box Result";
                        throw new ArgumentException(message);
                }
            }

            base.OnCloseWindowCommand_Execute(window);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [yes button command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnYesButtonCommand_Execute(IWindow? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            OnButtonCommand_Execute(o, Constants.Yes);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [no button command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnNoButtonCommand_Execute(IWindow? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            OnButtonCommand_Execute(o, Constants.No);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [okay button command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnOkayButtonCommand_Execute(IWindow? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            OnButtonCommand_Execute(o, Constants.Okay);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [cancel button command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnCancelButtonCommand_Execute(IWindow? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            OnButtonCommand_Execute(o, Constants.Cancel);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Called when [close button command execute].</summary>
        /// <param name="o">The o.</param>
        private void OnCloseButtonCommand_Execute(IWindow? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            OnButtonCommand_Execute(o, Constants.Close);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
