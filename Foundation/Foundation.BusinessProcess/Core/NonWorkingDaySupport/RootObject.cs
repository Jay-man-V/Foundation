//-----------------------------------------------------------------------
// <copyright file="RootObject.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// Defines the Root Object
    /// </summary>
    public class RootObject
    {
        /// <summary>
        /// Gets or sets the england and wales.
        /// </summary>
        /// <value>
        /// The england and wales.
        /// </value>
        [JsonProperty(PropertyName = "england-and-wales")]
        public UkNation? EnglandAndWales { get; set; }

        /// <summary>
        /// Gets or sets the scotland.
        /// </summary>
        /// <value>
        /// The scotland.
        /// </value>
        [JsonProperty(PropertyName = "scotland")]
        public UkNation? Scotland { get; set; }

        /// <summary>
        /// Gets or sets the northern ireland.
        /// </summary>
        /// <value>
        /// The northern ireland.
        /// </value>
        [JsonProperty(PropertyName = "northern-ireland")]
        public UkNation? NorthernIreland { get; set; }
    }
}
