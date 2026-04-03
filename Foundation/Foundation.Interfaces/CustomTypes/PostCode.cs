//-----------------------------------------------------------------------
// <copyright file="PostCode.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        public PostCode(String? postCode)
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
        public String? Value { get; init; }

        /// <summary>
        /// Indicates whether the <see cref="Value"/> has been parsed
        /// </summary>
        public Boolean IsParsed() { return Parsed; }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
        /// </returns>
        public override Boolean Equals([NotNullWhen(true)] Object? obj)
        {
            Boolean retVal = false;
            if (!String.IsNullOrEmpty(Value) &&
                obj != null)
            {
                Type objectType = obj.GetType();

                if (objectType == typeof(PostCode))
                {
                    PostCode input = (PostCode)obj;
                    retVal = Value.Equals(input.Value);
                }
                else if (objectType == typeof(String))
                {
                    String input = (String)obj;
                    retVal = Value.Equals(input);
                }
            }

            return retVal;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override Int32 GetHashCode()
        {
            //Int32 constant = -1521134295;
            //Int32 hashCode = 746720419;

            //hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TheEmailAddress?? String.Empty);
            Int32 hashCode = EqualityComparer<String>.Default.GetHashCode(Value ?? String.Empty);

            return hashCode;
        }
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