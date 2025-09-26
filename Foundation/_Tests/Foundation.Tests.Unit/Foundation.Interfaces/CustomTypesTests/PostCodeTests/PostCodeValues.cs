//-----------------------------------------------------------------------
// <copyright file="PostCodeValues.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.PostCodeTests
{
    /// <summary>
    /// Post Code values for testing
    /// </summary>
    internal static class PostCodeValues
    {
        public const String PostCode1 = "A1 1AA";
        public const String PostCode2 = "A11 1AA";
        public const String PostCode3 = "AA1 1AA";
        public const String PostCode4 = "AA11 1AA";
        public const String PostCode5 = "A1A 1AA";
        public const String PostCode6 = "AA1A 1AA";

        public const String Pattern1 = @"^\w\d\s?\d\w{2}$";
        public const String Pattern2 = @"^\w\d{2}\s?\d\w{2}";
        public const String Pattern3 = @"^\w{2}\d\s?\d\w{2}$";
        public const String Pattern4 = @"^\w{2}\d{2}\s?\d\w{2}$";
        public const String Pattern5 = @"^\w\d\w\s?\d\w{2}$";
        public const String Pattern6 = @"^\w{2}\d\w\s?\d\w{2}$";

        public static readonly String AllPatterns = $"({Pattern1})|({Pattern2})|({Pattern3})|({Pattern4})|({Pattern5})|({Pattern6})";
    }
}