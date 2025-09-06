//-----------------------------------------------------------------------
// <copyright file="EmailAddress.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Refer to RFC 2822
    /// </summary>
    [DebuggerDisplay("{TheEmailAddress}")]
    public struct EmailAddress
    {
        /// <summary>
        /// Constants for the Email Address class
        /// </summary>
        private static class Constants
        {
            /// <summary>
            /// Constants regarding lengths
            /// </summary>
            public static class Lengths
            {
                /// <summary>
                /// The maximum local part
                /// </summary>
                public const Int32 MaxLocalPart = 64;

                /// <summary>
                /// The maximum domain name
                /// </summary>
                public const Int32 MaxDomainName = 255;

                public const Int32 MaxLength = MaxLocalPart + MaxDomainName;
            }

            /// <summary>
            /// Constants regarding Regular Expressions
            /// </summary>
            public static class RegularExpressions
            {
                // @"^[a-zA-Z0-9_\+-]+(\.[a-zA-Z0-9_\+-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.([a-zA-Z]{2,5})$";
                // @"^[a-z0-9,!#\$%&'\*\+/=\?\^_`\{\|}~-]+(\.[a-z0-9,!#\$%&'\*\+/=\?\^_`\{\|}~-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,})$"

                /// <summary>
                /// The normal address
                /// </summary>
                public const String NormalAddress = @"^[\w\W\d_\+-]+(\.[\w\W\d_\+-]+)*@[\w\W\d-]+(\.[\w\W\d-]+)*\.([\w\W]{2,5})$";

                /// <summary>
                /// The valid but rare
                /// </summary>
                public const String ValidButRare = @"[,!#\$%&'\""\*\+/=\?\^_`\{\|}~-]+";
            }
        }

        ///// <summary>
        ///// Initialises a new instance of the <see cref="EmailAddress"/> class.
        ///// </summary>
        //public EmailAddress()
        //    : this(String.Empty)
        //{
        //    // Does nothing
        //}

        /// <summary>
        /// Initialises a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public EmailAddress(String? emailAddress)
        {
            IsValid = false;
            HasPotentialTypo = false;
            LocalPart = String.Empty;
            DomainName = String.Empty;

            TheEmailAddress = emailAddress;
            SplitInToParts();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public EmailAddress(EmailAddress emailAddress)
        {
            IsValid = false;
            HasPotentialTypo = false;
            LocalPart = String.Empty;
            DomainName = String.Empty;

            TheEmailAddress = String.Empty;

            if (!String.IsNullOrWhiteSpace(emailAddress.TheEmailAddress))
            {
                TheEmailAddress = emailAddress.ToString();
                SplitInToParts();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsValid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has potential typo.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has potential typo; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasPotentialTypo { get; private set; }

        /// <summary>
        /// Gets the local part.
        /// </summary>
        /// <value>
        /// The local part.
        /// </value>
        public String LocalPart { get; private set; }

        /// <summary>
        /// Gets the name of the domain.
        /// </summary>
        /// <value>
        /// The name of the domain.
        /// </value>
        public String DomainName { get; private set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        private String TheEmailAddress { get; }

        /// <summary>
        /// == (equals) operator for EmailAddress Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(EmailAddress x, EmailAddress y)
        {
            Boolean retVal = false;

            if (!String.IsNullOrEmpty(x) && !String.IsNullOrEmpty(y))
            {
                retVal = (x.TheEmailAddress == y.TheEmailAddress);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EmailAddress Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(EmailAddress x, EmailAddress y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// Implicit cast from a String to EmailAddress Object
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// New instance of <see cref="EmailAddress" />
        /// </returns>
        public static implicit operator EmailAddress(String? x)
        {
            return new EmailAddress(x);
        }

        /// <summary>
        /// Implicit cast from EmailAddress Object to String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator String(EmailAddress x)
        {
            String retVal = x.TheEmailAddress;

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(EmailAddress x, String y)
        {
            Boolean retVal = false;

            if (!String.IsNullOrWhiteSpace(y))
            {
                retVal = (x.TheEmailAddress == y);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(EmailAddress x, String y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(String x, EmailAddress y)
        {
            Boolean retVal = (y == x);

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(String x, EmailAddress y)
        {
            Boolean retVal = !(y == x);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(EmailAddress x, Object y)
        {
            Boolean retVal = false;

            if (y is EmailAddress emailAddressY)
            {
                retVal = (x.TheEmailAddress == emailAddressY.TheEmailAddress);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(EmailAddress x, Object y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(Object x, EmailAddress y)
        {
            Boolean retVal = (y == x);

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EmailAddress Object with a String
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(Object x, EmailAddress y)
        {
            Boolean retVal = !(y == x);

            return retVal;
        }

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
            if (!String.IsNullOrEmpty(TheEmailAddress) &&
                obj != null)
            {
                Type objectType = obj.GetType();

                if (objectType == typeof(String))
                {
                    String input = (String)obj;
                    retVal = TheEmailAddress.Equals(input);
                }
                else if (objectType == typeof(EmailAddress))
                {
                    EmailAddress input = (EmailAddress)obj;
                    retVal = TheEmailAddress.Equals(input.TheEmailAddress);
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
            Int32 retVal = TheEmailAddress.GetHashCode();

            return retVal;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override String ToString()
        {
            return TheEmailAddress;
        }

        /// <summary>
        /// Splits the in to parts.
        /// </summary>
        private void SplitInToParts()
        {
            IsValid = CheckIsValid(TheEmailAddress);
            HasPotentialTypo = CheckForTypos(TheEmailAddress);

            if (IsValid)
            {
                String[] splitChar = ["@"];
                String[] parts = TheEmailAddress.Split(splitChar, StringSplitOptions.None);

                if (2 == parts.Length)
                {
                    LocalPart = parts[0];
                    DomainName = parts[1];

                    if (LocalPart.Length > Constants.Lengths.MaxLocalPart)
                    {
                        IsValid = false;
                    }

                    if (DomainName.Length > Constants.Lengths.MaxDomainName)
                    {
                        IsValid = false;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the is valid.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>[True] or [False]</returns>
        private Boolean CheckIsValid(String emailAddress)
        {
            Boolean retVal = false;

            if (!String.IsNullOrWhiteSpace(emailAddress))
            {
                if (emailAddress.Length > 0)
                {
                    Regex regex = new(Constants.RegularExpressions.NormalAddress);
                    Match match = regex.Match(emailAddress);

                    retVal = match.Success;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Checks for typos.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>[True] or [False]</returns>
        private Boolean CheckForTypos(String emailAddress)
        {
            Boolean retVal = false;

            if (!String.IsNullOrWhiteSpace(emailAddress))
            {
                if (emailAddress.Length > 0)
                {
                    Regex regex = new(Constants.RegularExpressions.ValidButRare);
                    Match match = regex.Match(emailAddress);

                    retVal = match.Success;
                }
            }

            return retVal;
        }
    }
}
