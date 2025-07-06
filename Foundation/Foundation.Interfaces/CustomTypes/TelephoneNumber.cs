//-----------------------------------------------------------------------
// <copyright file="TelephoneNumber.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace Foundation.Interfaces
{
    /// <summary>
    /// A struct to hold a Telephone number alongside validation routines
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public readonly struct TelephoneNumber
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

        //public TelephoneNumber() : this(String.Empty) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="telephoneNumber"></param>
        public TelephoneNumber(String telephoneNumber)
        {
            Parsed = false;
            Value = telephoneNumber;
            InternationalCode = String.Empty;
            AreaCode = String.Empty;
            LocalNumber = String.Empty;

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
            //    Match matches = Regex.Match(Value, exceptionpression, RegexOptions.CultureInvariant);
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
        public String Value { get; }

        /// <summary>
        /// Indicates whether the <seeref name="Value"/> has been parsed
        /// </summary>
        public Boolean Parsed { get; }

        /// <summary>
        /// Local number part of the telephone number
        /// </summary>
        public String LocalNumber { get; }

        /// <summary>
        /// Area code part of the telephone number
        /// </summary>
        public String AreaCode { get; }

        /// <summary>
        /// International code part of the telephone number
        /// </summary>
        public String InternationalCode { get; }

        /// <summary>
        /// String representation of the struct
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"{Value}";
            //return $"{InternationalCode} ({AreaCode}) {LocalNumber}";
        }
    }
}
