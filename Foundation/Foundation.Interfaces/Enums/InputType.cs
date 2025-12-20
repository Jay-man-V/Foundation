//-----------------------------------------------------------------------
// <copyright file="InputType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Input Type specifies allowable inputs
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the input type")]
    public enum InputType
    {
        /// <summary>
        /// All characters
        /// </summary>
        [Id(0),
         Display(Order = 0, Name = "All characters"),
         Description("Allows All characters in the ASCII set"),
         DisplayFormat(DataFormatString = "")]
        AllCharacters = 0,

        /// <summary>
        /// Alphanumeric characters
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Alpha numeric"),
         Description("Allows Alphabetic and Numeric characters only"),
         DisplayFormat(DataFormatString = "")]
        AlphaNumeric = 1,

        /// <summary>
        /// Integers only
        /// </summary>
        [Id(2),
         Display(Order = 2, Name = "Integer"),
         Description("Allows Integers only"),
         DisplayFormat(DataFormatString = "n0")]
        Integer = 2,

        /// <summary>
        /// Alphabetic characters only
        /// </summary>
        [Id(3),
         Display(Order = 3, Name = "Alpha only"),
         Description("Allows Alphabetic characters only"),
         DisplayFormat(DataFormatString = "")]
        AlphaOnly = 3,

        /// <summary>
        /// Decimal value
        /// </summary>
        [Id(4),
         Display(Order = 4, Name = "Decimal 2dp"),
         Description("Allows any Decimal value"),
         DisplayFormat(DataFormatString = "n2")]
        Decimal2dp = 4,

        /// <summary>
        /// Monetary value
        /// </summary>
        [Id(5),
         Display(Order = 5, Name = "Money"),
         Description("Allows any Monetary value, shows 2 decimal places and using natural rounding"),
         DisplayFormat(DataFormatString = "c")]
        Money = 5,

        /// <summary>
        /// Financial Monetary value
        /// </summary>
        [Id(6),
         Display(Order = 6, Name = "Financial"),
         Description("Allows any Monetary value with additional decimal places, shows 8 decimal places and using natural rounding"),
         DisplayFormat(DataFormatString = "#,##0.00000000")]
        Financial = 5,

        /// <summary>
        /// The local date/time
        /// </summary>
        [Id(101),
         Display(Order = 101, Name = "Date/time"),
         Description("Allows input of a date/time"),
         DisplayFormat(DataFormatString = "g")]
        DateTime = 101,

        /// <summary>
        /// The local date
        /// </summary>
        [Id(102),
         Display(Order = 102, Name = "Date"),
         Description("Allows input of a date only"),
         DisplayFormat(DataFormatString = "d")]
        Date = 102,

        /// <summary>
        /// The local time
        /// </summary>
        [Id(102),
         Display(Order = 103, Name = "Time"),
         Description("Allows input of a time only"),
         DisplayFormat(DataFormatString = "T")]
        Time = 103,
    }
}
