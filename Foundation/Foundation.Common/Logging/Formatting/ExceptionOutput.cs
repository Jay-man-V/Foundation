//-----------------------------------------------------------------------
// <copyright file="ExceptionOutput.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the Exception Output
    /// </summary>
    public class ExceptionOutput
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExceptionOutput"/> class.
        /// </summary>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        public ExceptionOutput(IRunTimeEnvironmentSettings runTimeEnvironmentSettings, IDateTimeService dateTimeService)
        {
            ErrorDetail = String.Empty;
            ErrorMessage = String.Empty;
            ErrorSource = String.Empty;
            UserLogon = $@"{runTimeEnvironmentSettings.UserDomainName}\{runTimeEnvironmentSettings.UserName}";
            ErrorDateTime = dateTimeService.SystemDateTimeNow;
            ComputerName = runTimeEnvironmentSettings.MachineName;
            CultureInfo = CultureInfo.CurrentCulture;
            UiCultureInfo = CultureInfo.CurrentUICulture;
            ThreadCultureInfo = Thread.CurrentThread.CurrentCulture;
            ThreadUiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        }

        /// <summary>
        /// Gets the user logon.
        /// </summary>
        /// <value>
        /// The user logon.
        /// </value>
        public String UserLogon { get; }

        /// <summary>
        /// Gets the error date time.
        /// </summary>
        /// <value>
        /// The error date time.
        /// </value>
        public DateTime ErrorDateTime { get; }

        /// <summary>
        /// Gets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public String ComputerName { get; }

        /// <summary>
        /// Gets the culture information.
        /// </summary>
        /// <value>
        /// The culture information.
        /// </value>
        public CultureInfo CultureInfo { get; }

        /// <summary>
        /// Gets the UI culture information.
        /// </summary>
        /// <value>
        /// The UI culture information.
        /// </value>
        public CultureInfo UiCultureInfo { get; }

        /// <summary>
        /// Gets the thread culture information.
        /// </summary>
        /// <value>
        /// The thread culture information.
        /// </value>
        public CultureInfo ThreadCultureInfo { get; }

        /// <summary>
        /// Gets the thread UI culture information.
        /// </summary>
        /// <value>
        /// The thread UI culture information.
        /// </value>
        public CultureInfo ThreadUiCultureInfo { get; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public String ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error source.
        /// </summary>
        /// <value>
        /// The error source.
        /// </value>
        public String ErrorSource { get; set; }

        /// <summary>
        /// Gets or sets the error detail.
        /// </summary>
        /// <value>
        /// The error detail.
        /// </value>
        public String ErrorDetail { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User logon: {UserLogon}");
            sb.AppendLine($"Error occurred on: {ErrorDateTime.ToString(Formats.DotNet.DateTimeSeconds)}");
            sb.AppendLine($"Culture/UI Culture: {CultureInfo}/{UiCultureInfo}");
            sb.AppendLine($"Current Thread - Culture/UI Culture: {ThreadCultureInfo}/{ThreadUiCultureInfo}");

            Assembly callingAssembly = Assembly.GetCallingAssembly();
            if (callingAssembly != null)
            {
                sb.AppendLine($"Calling assembly: {callingAssembly.FullName}");
                sb.AppendLine($"Assembly location: {callingAssembly.Location}");
            }

            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                sb.AppendLine($"Entry assembly: {entryAssembly.FullName}");
                sb.AppendLine($"Assembly location: {entryAssembly.Location}");
            }

            Assembly executingAssembly = Assembly.GetExecutingAssembly(); 
            if (Assembly.GetExecutingAssembly() != null)
            {
                sb.AppendLine($"Executing assembly: {executingAssembly.FullName}");
                sb.AppendLine($"Assembly location: {executingAssembly.Location}");
            }

            sb.AppendLine($"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
            sb.AppendLine($"Directory.GetCurrentDirectory: {Directory.GetCurrentDirectory()}");

            sb.AppendLine();
            sb.AppendLine($"Error message: {ErrorMessage}");
            sb.AppendLine($"Error source: {ErrorSource}");
            sb.AppendLine($"Server name: {ComputerName}");
            sb.AppendLine("Error Detail:");
            sb.AppendLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            sb.Append(ErrorDetail);

            return sb.ToString();
        }
    }
}
