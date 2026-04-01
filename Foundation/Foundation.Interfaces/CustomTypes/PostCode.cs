//-----------------------------------------------------------------------
// <copyright file="PostCode.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Foundation.Interfaces
{
    /// <summary>
    /// A struct to hold a Postcode alongside validation routines
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public struct PostCode
    {
        private Boolean Parsed { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postCode"></param>
        public PostCode(String postCode)
        {
            Value = postCode;
            Parsed = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postCode"></param>
        /// <param name="validatingRegEx"></param>
        public PostCode(String postCode, String validatingRegEx)
            : this(postCode)
        {
            Match matches = Regex.Match(Value, validatingRegEx, RegexOptions.CultureInvariant);
            Parsed = matches.Success;
        }

        /// <summary>
        /// The encapsulated value
        /// </summary>
        public String Value { get; init; }

        /// <summary>
        /// Indicates whether the <see cref="Value"/> has been parsed
        /// </summary>
        public Boolean IsParsed() { return Parsed; }

        /// <summary>
        /// String representation of the struct
        /// </summary>
        /// <returns></returns>

        public override String ToString()
        {
            return Value;
        }
    }
}