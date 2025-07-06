//-----------------------------------------------------------------------
// <copyright file="ITimeZone.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Time Zone model interface
    /// </summary>
    public interface ITimeZone : IFoundationModel
    {
        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        String Code { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }

        /// <summary>Gets or sets the offset.</summary>
        /// <value>The offset.</value>
        Int32 Offset { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance has daylight savings.</summary>
        /// <value>
        ///   <c>true</c> if this instance has daylight savings; otherwise, <c>false</c>.</value>
        Boolean HasDaylightSavings { get; set; }
    }
}
