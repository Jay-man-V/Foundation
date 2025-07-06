//-----------------------------------------------------------------------
// <copyright file="ColourScheme.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the Colour Scheme for all parts of the application
    /// </summary>
    public class ColourScheme
    {
        /// <summary>Gets the default background colour.</summary>
        /// <value>The default background colour.</value>
        public static Color DefaultBackgroundColour => Color.PaleGreen;

        /// <summary>Gets the default foreground colour.</summary>
        /// <value>The default foreground colour.</value>
        public static Color DefaultForegroundColour => Color.Yellow;

        /// <summary>Gets the data grid main background colour.</summary>
        /// <value>The data grid main background colour.</value>
        public static Color DataGridMainBackgroundColour => Color.PaleGreen;

        /// <summary>Gets the data grid alternate background colour.</summary>
        /// <value>The data grid alternate background colour.</value>
        public static Color DataGridAlternateBackgroundColour => Color.LightBlue;

        /// <summary>Gets the data grid row selected background.</summary>
        /// <value>The data grid row selected background.</value>
        public static Color DataGridRowSelectedBackground => SystemColors.Highlight;

        /// <summary>Gets the data grid row selected foreground.</summary>
        /// <value>The data grid row selected foreground.</value>
        public static Color DataGridRowSelectedForeground => SystemColors.HighlightText;

        /// <summary>Gets the system administrator background colour.</summary>
        /// <value>The system administrator background colour.</value>
        public static Color SystemAdministratorBackgroundColour => Color.Black;

        /// <summary>Gets the system administrator foreground colour.</summary>
        /// <value>The system administrator foreground colour.</value>
        public static Color SystemAdministratorForegroundColour => Color.White;

        /// <summary>Gets the system supervisor background colour.</summary>
        /// <value>The system supervisor background colour.</value>
        public static Color SystemSupervisorBackgroundColour => Color.Black;

        /// <summary>Gets the system supervisor foreground colour.</summary>
        /// <value>The system supervisor foreground colour.</value>
        public static Color SystemSupervisorForegroundColour => Color.Yellow;

        /// <summary>Gets the default window title brush colour1.</summary>
        /// <value>The default window title brush colour1.</value>
        public static Color DefaultWindowTitleBrushColour1 => Color.CornflowerBlue;

        /// <summary>Gets the default window title brush colour2.</summary>
        /// <value>The default window title brush colour2.</value>
        public static Color DefaultWindowTitleBrushColour2 => Color.LightCyan;

        /// <summary>Gets the error window title brush colour1.</summary>
        /// <value>The error window title brush colour1.</value>
        public static Color ErrorWindowTitleBrushColour1 => Color.PaleVioletRed;

        /// <summary>Gets the error window title brush colour2.</summary>
        /// <value>The error window title brush colour2.</value>
        public static Color ErrorWindowTitleBrushColour2 => Color.LightPink;

        /// <summary>Gets the question window title brush colour1.</summary>
        /// <value>The question window title brush colour1.</value>
        public static Color QuestionWindowTitleBrushColour1 => Color.LimeGreen;

        /// <summary>Gets the question window title brush colour2.</summary>
        /// <value>The question window title brush colour2.</value>
        public static Color QuestionWindowTitleBrushColour2 => Color.LightGreen;

        /// <summary>Gets the warning window title brush colour1.</summary>
        /// <value>The warning window title brush colour1.</value>
        public static Color WarningWindowTitleBrushColour1 => Color.GreenYellow;

        /// <summary>Gets the warning window title brush colour2.</summary>
        /// <value>The warning window title brush colour2.</value>
        public static Color WarningWindowTitleBrushColour2 => Color.Yellow;

        /// <summary>Gets the notification not set background colour1.</summary>
        /// <value>The notification not set background colour1.</value>
        public static Color NotificationNotSetBackgroundColour1 => SystemColors.Window;

        /// <summary>Gets the notification not set background colour2.</summary>
        /// <value>The notification not set background colour2.</value>
        public static Color NotificationNotSetBackgroundColour2 => SystemColors.WindowText;

        /// <summary>Gets the notification information background colour1.</summary>
        /// <value>The notification information background colour1.</value>
        public static Color NotificationInformationBackgroundColour1 => Color.Azure;

        /// <summary>Gets the notification information background colour2.</summary>
        /// <value>The notification information background colour2.</value>
        public static Color NotificationInformationBackgroundColour2 => Color.LightBlue;

        /// <summary>Gets the notification success background colour1.</summary>
        /// <value>The notification success background colour1.</value>
        public static Color NotificationSuccessBackgroundColour1 => Color.PaleGreen;

        /// <summary>Gets the notification success background colour2.</summary>
        /// <value>The notification success background colour2.</value>
        public static Color NotificationSuccessBackgroundColour2 => Color.Green;

        /// <summary>Gets the notification warning background colour1.</summary>
        /// <value>The notification warning background colour1.</value>
        public static Color NotificationWarningBackgroundColour1 => Color.LightYellow;

        /// <summary>Gets the notification warning background colour2.</summary>
        /// <value>The notification warning background colour2.</value>
        public static Color NotificationWarningBackgroundColour2 => Color.Yellow;

        /// <summary>Gets the notification serious warning background colour1.</summary>
        /// <value>The notification serious warning background colour1.</value>
        public static Color NotificationSeriousWarningBackgroundColour1 => Color.Yellow;

        /// <summary>Gets the notification serious warning background colour2.</summary>
        /// <value>The notification serious warning background colour2.</value>
        public static Color NotificationSeriousWarningBackgroundColour2 => Color.Yellow;

        /// <summary>Gets the notification error background colour1.</summary>
        /// <value>The notification error background colour1.</value>
        public static Color NotificationErrorBackgroundColour1 => Color.IndianRed;

        /// <summary>Gets the notification error background colour2.</summary>
        /// <value>The notification error background colour2.</value>
        public static Color NotificationErrorBackgroundColour2 => Color.Red;

        /// <summary>Gets the notification fatal error background colour1.</summary>
        /// <value>The notification fatal error background colour1.</value>
        public static Color NotificationFatalErrorBackgroundColour1 => Color.Red;

        /// <summary>Gets the notification fatal error background colour2.</summary>
        /// <value>The notification fatal error background colour2.</value>
        public static Color NotificationFatalErrorBackgroundColour2 => Color.DarkRed;

        /// <summary>Gets the notification common foreground colour.</summary>
        /// <value>The notification common foreground colour.</value>
        public static Color NotificationCommonForegroundColour => Color.Black;

        /// <summary>Gets the data grid main foreground colour.</summary>
        /// <value>The data grid main foreground colour.</value>
        public static Color DataGridMainForegroundColour => Color.Black;
    }
}
