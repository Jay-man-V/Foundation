//-----------------------------------------------------------------------
// <copyright file="UKNation.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// Defines the Uk Nation behaviours
    /// </summary>
    public class UkNation
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="UkNation" /> class.
        /// </summary>
        public UkNation()
        {
            Division = String.Empty;
            Events = new List<BankHolidayEvent>();
        }

        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>
        /// The division.
        /// </value>
        [JsonProperty(PropertyName = "division")]
        public String Division { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public List<BankHolidayEvent> Events { get; set; }
    }
}
