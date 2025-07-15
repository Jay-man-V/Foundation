//-----------------------------------------------------------------------
// <copyright file="Event.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;

using Newtonsoft.Json;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// Defines the Bank Holiday Event
    /// </summary>
    public class BankHolidayEvent
    {
        /// <summary>
        /// The date format used in the government source data
        /// </summary>
        internal const String DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Initialises a new instance of the <see cref="BankHolidayEvent" /> class.
        /// </summary>
        public BankHolidayEvent()
        {
            Title = String.Empty;
            DateAsString = DateTime.MinValue.ToString(DateFormat);
            Notes = String.Empty;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the date as string.
        /// </summary>
        /// <value>
        /// The date as string.
        /// </value>
        [JsonProperty(PropertyName = "date")]
        public String DateAsString { get; set; }
        
        /// <summary>
        /// Gets the bank holiday date.
        /// </summary>
        /// <value>
        /// The bank holiday date.
        /// </value>
        public DateTime BankHolidayDate => DateTime.ParseExact(DateAsString, DateFormat, CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public String Notes { get; set; }
    
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BankHolidayEvent" /> is bunting.
        /// </summary>
        /// <value>
        ///   <c>true</c> if bunting; otherwise, <c>false</c>.
        /// </value>
        public Boolean Bunting { get; set; }
    }
}
