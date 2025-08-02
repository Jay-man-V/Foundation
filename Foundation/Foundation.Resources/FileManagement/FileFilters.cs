//-----------------------------------------------------------------------
// <copyright file="FileFilters.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Defines File Filters used in File Open/Save dialogs
    /// </summary>
    public static class FileFilters
    {
        /// <summary>
        /// All files:
        /// All Files (*.*)|*.*
        /// </summary>
        public static String AllFiles => "All Files (*.*)|*.*";

        /// <summary>
        /// The text files:
        /// Text Files (*.txt)|*.txt
        /// </summary>
        public static String TextFiles => AllFiles + "|Text Files (*.txt)|*.txt";

        /// <summary>
        /// The csv text files:
        /// Text Files (*.txt)|*.txt
        /// </summary>
        public static String CsvFiles => AllFiles + "|Comma Separated Values Files (Csv) (*.csv)|*.csv";

        /// <summary>
        /// The Excel files:
        ///  Excel Files (*.xls)|*.xls
        /// |Excel Files (*.xlsx)|*.xlsx
        /// |Excel Files (*.xlsm)|*.xlsm
        /// </summary>
        public static String ExcelFiles => AllFiles + "|Excel Files (*.xls)|*.xls" +
                                                      "|Excel Files (*.xlsx)|*.xlsx" +
                                                      "|Excel Files (*.xlsm)|*.xlsm";

        /// <summary>
        /// The Word files
        ///  Word Files (*.doc)|*.doc
        /// |Word Files (*.docx)|*.docx
        /// |Word Files (*.docm)|*.docm
        /// </summary>
        public static String WordFiles => AllFiles + "|Word Files (*.doc)|*.doc" +
                                                     "|Word Files (*.docx)|*.docx" +
                                                     "|Word Files (*.docm)|*.docm";
    }
}
