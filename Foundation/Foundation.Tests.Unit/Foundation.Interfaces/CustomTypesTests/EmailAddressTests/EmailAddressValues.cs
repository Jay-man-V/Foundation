//-----------------------------------------------------------------------
// <copyright file="_EmailAddressValues.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Email Address Values used within the EmailAddress tests
    /// </summary>
    internal static class EmailAddressValues
    {
        static EmailAddressValues()
        {
            InvalidEmailAddresses =
            [
                "a@b.c", // Invalid
                "Firstname.Surname@domainlocal" // Invalid
            ];

            InvalidPotentialTypoEmailAddresses =
            [
                "Firstname#Surname@domainlocal", // Invalid - Potential typo
                @"Firstname""Surname@domainlocal" // Invalid - Potential typo
            ];

            ValidEmailAddresses =
            [
                "a@b.co", // Valid
                "Firstname.Surname@domain.one.co.uk", // Valid
                "Firstname.Surname@domain.two.co.uk", // Valid
                "FirstnameSurname@domain.com", // Valid
                "Firstname.Surname@domain.local", // Valid
                "FirstnameSurname@domain.local", // Valid
                "FirstnameSurname123@domain.local", // Valid
                "Firstname.Surname123@domain.local", // Valid
            ];

            ValidPotentialTypoEmailAddresses =
            [
                "Firstname#Surname@domain.local", // Valid - Potential typo
                @"Firstname""Surname@domain.local" // Valid - Potential typo
            ];

            AllEmailAddresses = [];
            AllEmailAddresses.AddRange(InvalidEmailAddresses);
            AllEmailAddresses.AddRange(InvalidPotentialTypoEmailAddresses);
            AllEmailAddresses.AddRange(ValidEmailAddresses);
            AllEmailAddresses.AddRange(ValidPotentialTypoEmailAddresses);
        }

        /// <summary>
        /// The _invalid email addresses
        /// </summary>
        public static readonly List<String> InvalidEmailAddresses;

        /// <summary>
        /// The _invalid potential typo email addresses
        /// </summary>
        public static readonly List<String> InvalidPotentialTypoEmailAddresses;

        /// <summary>
        /// The _valid email addresses
        /// </summary>
        public static readonly List<String> ValidEmailAddresses;

        /// <summary>
        /// The _valid potential typo email addresses
        /// </summary>
        public static readonly List<String> ValidPotentialTypoEmailAddresses;

        /// <summary>
        /// The _all email addresses
        /// </summary>
        public static readonly List<String> AllEmailAddresses;
    }
}
