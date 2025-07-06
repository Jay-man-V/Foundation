//-----------------------------------------------------------------------
// <copyright file="PostCode.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Foundation.Interfaces
{
    /// <summary>
    /// A struct to hold a Postcode alongside validation routines
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public readonly struct PostCode
    {
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
        public String Value { get; }

        /// <summary>
        /// Indicates whether the <see cref="Value"/> has been parsed
        /// </summary>
        public Boolean Parsed { get; }

        /// <summary>
        /// String representation of the struct
        /// </summary>
        /// <returns></returns>

        public override String ToString()
        {
            if (String.IsNullOrWhiteSpace(Value))
            {
                return GetType().ToString();
            }
            else
            {
                return Value;
            }
        }
    }
}