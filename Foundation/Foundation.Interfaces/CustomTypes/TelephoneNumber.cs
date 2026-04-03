//-----------------------------------------------------------------------
// <copyright file="TelephoneNumber.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.Interfaces
{
    /// <summary>
    /// A struct to hold a Telephone number alongside validation routines
    /// </summary>
    [DebuggerDisplay("{TheTelephoneNumber}")]
    public struct TelephoneNumber
    {
        //public static class Constants
        //{
        //    public static class RegularExpressions
        //    {
        //        public static class Groups
        //        {
        //            public const String LocalNumber = "LocalNumber";
        //            public const String AreaCode = "AreaCode";
        //            public const String InternationalCode = "InternationalCode";
        //        }

        //        public static readonly String LocalNumber = $@"(?<{Groups.LocalNumber}>[\d ]*)";
        //        public static readonly String AreaCode = $@"(?<{Groups.AreaCode}>\d*)";
        //        public static readonly String InternationalCode = $@"(?<{Groups.InternationalCode}>\+\d*)";
        //    }
        //}

        private String? _telephoneNumber { get; set; }
        private String _localNumber { get; set; }
        private String _areaCode { get; set; }
        private String _internationalCode { get; set; }
        private Boolean Parsed { get; set; }

        //public TelephoneNumber() : this(String.Empty) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="telephoneNumber"></param>
        public TelephoneNumber(String? telephoneNumber)
        {
            Parsed = false;
            TheTelephoneNumber = telephoneNumber;
            _internationalCode = String.Empty;
            _areaCode = String.Empty;
            _localNumber = String.Empty;

            //LocalNumber = String.Empty;
            //AreaCode = String.Empty;
            //InternationalCode = String.Empty;
            //Value = telephoneNumber;
            //String[] expressions =
            //{
            //    Constants.RegularExpressions.LocalNumber,
            //    Constants.RegularExpressions.AreaCode,
            //    Constants.RegularExpressions.InternationalCode
            //};

            //foreach (String expression in expressions)
            //{
            //    Match matches = Regex.Match(Value, expression, RegexOptions.CultureInvariant);
            //    Parsed = matches.Success;
            //    if (Parsed)
            //    {
            //        LocalNumber = matches.Groups[Constants.RegularExpressions.Groups.LocalNumber].Value;
            //        AreaCode = matches.Groups[Constants.RegularExpressions.Groups.AreaCode].Value;
            //        InternationalCode = matches.Groups[Constants.RegularExpressions.Groups.InternationalCode].Value;
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// The encapsulated value
        /// </summary>
        public String? TheTelephoneNumber
        {
            get => _telephoneNumber;
            init => _telephoneNumber = value;
        }

        /// <summary>
        /// Indicates whether the <seeref name="Value"/> has been parsed
        /// </summary>
        public Boolean IsParsed() { return Parsed; }

        /// <summary>
        /// Local number part of the telephone number
        /// </summary>
        public String LocalNumber() { return _localNumber; }

        /// <summary>
        /// Area code part of the telephone number
        /// </summary>
        public String AreaCode() { return _areaCode; }

        /// <summary>
        /// International code part of the telephone number
        /// </summary>
        public String InternationalCode() { return _internationalCode; }

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
            if (!String.IsNullOrEmpty(TheTelephoneNumber) &&
                obj != null)
            {
                Type objectType = obj.GetType();

                if (objectType == typeof(TelephoneNumber))
                {
                    TelephoneNumber input = (TelephoneNumber)obj;
                    retVal = TheTelephoneNumber.Equals(input.TheTelephoneNumber);
                }
                else if (objectType == typeof(String))
                {
                    String input = (String)obj;
                    retVal = TheTelephoneNumber.Equals(input);
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

            Int32 hashCode = EqualityComparer<String>.Default.GetHashCode(TheTelephoneNumber);

            return hashCode;
        }

        /// <summary>
        /// String representation of the struct
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return TheTelephoneNumber;
        }
    }
}
