//-----------------------------------------------------------------------
// <copyright file="EmailAddressTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Unit Tests for the Email Address type
    /// </summary>
    [TestFixture]
    public partial class EmailAddressTests : UnitTestBase
    {
        ///// <summary>
        ///// Tests the implicit cast from string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastFromString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = originalEmailAddressString;

        //        Assert.That(emailAddress, Is.Not.EqualTo(null));
        //        String emailAddressString = emailAddress;
        //        Assert.That(emailAddressString, Is.EqualTo(originalEmailAddressString), $"Email Address '{originalEmailAddressString}' did not work");
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast from null string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastFromNullString()
        //{
        //    const String nullEmailAddressString = null;
        //    EmailAddress emailAddress = nullEmailAddressString;

        //    Assert.That(emailAddress, Is.Not.EqualTo(null));
        //    String emailAddressString = emailAddress;
        //    Assert.That(emailAddressString, Is.EqualTo(null), "Email Address from null String did not work");
        //}

        ///// <summary>
        ///// Tests the implicit cast email address equals.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressEquals()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = new EmailAddress(originalEmailAddressString);
        //        Object objEmailAddress = new EmailAddress(originalEmailAddressString);

        //        Boolean result1 = emailAddress1 == emailAddress2;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress2 == emailAddress1;
        //        Assert.That(result2, Is.EqualTo(true));

        //        Boolean result3 = emailAddress1 == objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(true));

        //        Boolean result4 = objEmailAddress == emailAddress1;
        //        Assert.That(result4, Is.EqualTo(true));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address equals2.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressEquals2()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = new EmailAddress(String.Concat(originalEmailAddressString, "ExtraString"));
        //        Object objEmailAddress = new EmailAddress(String.Concat(originalEmailAddressString, "ExtraString"));

        //        Boolean result1 = emailAddress1 == emailAddress2;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress2 == emailAddress1;
        //        Assert.That(result2, Is.EqualTo(false));

        //        Boolean result3 = emailAddress1 == objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(false));

        //        Boolean result4 = objEmailAddress == emailAddress1;
        //        Assert.That(result4, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address equals3.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressEquals3()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = null;
        //        const Object objEmailAddress = null;

        //        Boolean result1 = emailAddress1 == emailAddress2;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress2 == emailAddress1;
        //        Assert.That(result2, Is.EqualTo(false));

        //        Boolean result3 = emailAddress1 == objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(false));

        //        Boolean result4 = objEmailAddress == emailAddress1;
        //        Assert.That(result4, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address equals3.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressEquals4()
        //{
        //    EmailAddress emailAddress1 = null;
        //    EmailAddress emailAddress2 = null;
        //    const Object objEmailAddress = null;

        //    Boolean result1 = emailAddress1 == emailAddress2;
        //    Assert.That(result1, Is.EqualTo(false));

        //    Boolean result2 = emailAddress2 == emailAddress1;
        //    Assert.That(result2, Is.EqualTo(false));

        //    Boolean result3 = emailAddress1 == objEmailAddress;
        //    Assert.That(result3, Is.EqualTo(false));

        //    Boolean result4 = objEmailAddress == emailAddress1;
        //    Assert.That(result4, Is.EqualTo(false));
        //}

        ///// <summary>
        ///// Tests the implicit cast email address not equals.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressNotEquals()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = new EmailAddress(originalEmailAddressString);
        //        Object objEmailAddress = new EmailAddress(originalEmailAddressString);

        //        Boolean result1 = emailAddress1 != emailAddress2;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress2 != emailAddress1;
        //        Assert.That(result2, Is.EqualTo(false));

        //        Boolean result3 = emailAddress1 != objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(false));

        //        Boolean result4 = objEmailAddress != emailAddress1;
        //        Assert.That(result4, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address not equals2.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressNotEquals2()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = new EmailAddress(String.Concat(originalEmailAddressString, "ExtraString"));
        //        Object objEmailAddress = new EmailAddress(String.Concat(originalEmailAddressString, "ExtraString"));

        //        Boolean result1 = emailAddress1 != emailAddress2;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress2 != emailAddress1;
        //        Assert.That(result2, Is.EqualTo(true));

        //        Boolean result3 = emailAddress1 != objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(true));

        //        Boolean result4 = objEmailAddress != emailAddress1;
        //        Assert.That(result4, Is.EqualTo(true));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address not equals3.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressNotEquals3()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress1 = new EmailAddress(originalEmailAddressString);
        //        EmailAddress emailAddress2 = null;
        //        const Object objEmailAddress = null;

        //        Boolean result1 = emailAddress1 != emailAddress2;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress2 != emailAddress1;
        //        Assert.That(result2, Is.EqualTo(true));

        //        Boolean result3 = emailAddress1 != objEmailAddress;
        //        Assert.That(result3, Is.EqualTo(true));

        //        Boolean result4 = objEmailAddress != emailAddress1;
        //        Assert.That(result4, Is.EqualTo(true));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast email address not equals3.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEmailAddressNotEquals4()
        //{
        //    EmailAddress emailAddress1 = null;
        //    EmailAddress emailAddress2 = null;
        //    const Object objEmailAddress = null;

        //    Boolean result1 = emailAddress1 != emailAddress2;
        //    Assert.That(result1, Is.EqualTo(true));

        //    Boolean result2 = emailAddress2 != emailAddress1;
        //    Assert.That(result2, Is.EqualTo(true));

        //    Boolean result3 = emailAddress1 != objEmailAddress;
        //    Assert.That(result3, Is.EqualTo(true));

        //    Boolean result4 = objEmailAddress != emailAddress1;
        //    Assert.That(result4, Is.EqualTo(true));
        //}

        ///// <summary>
        ///// Tests the implicit cast to string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastToString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
        //        String emailAddressString = emailAddress;
        //        Assert.That(emailAddressString, Is.EqualTo(originalEmailAddressString), $"EmailAddress '{originalEmailAddressString}' to StringBuilder did not work");
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast equals string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEqualsString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
        //        String emailAddressString2 = String.Concat(originalEmailAddressString, "ExtraString");

        //        Boolean result1 = originalEmailAddressString == emailAddress;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress == originalEmailAddressString;
        //        Assert.That(result2, Is.EqualTo(true));

        //        Boolean result3 = emailAddressString2 == emailAddress;
        //        Assert.That(result3, Is.EqualTo(false));

        //        Boolean result4 = emailAddress == emailAddressString2;
        //        Assert.That(result4, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast equals null string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEqualsNullString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
        //        const String emailAddressString2 = null;

        //        Boolean result1 = emailAddressString2 == emailAddress;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress == emailAddressString2;
        //        Assert.That(result2, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast equals string null email address.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastEqualsStringNullEmailAddress()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = null;

        //        Boolean result1 = originalEmailAddressString == emailAddress;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress == originalEmailAddressString;
        //        Assert.That(result2, Is.EqualTo(false));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast not equals string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastNotEqualsString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
        //        String emailAddressString2 = String.Concat(originalEmailAddressString, "ExtraString");

        //        Boolean result1 = originalEmailAddressString != emailAddress;
        //        Assert.That(result1, Is.EqualTo(false));

        //        Boolean result2 = emailAddress != originalEmailAddressString;
        //        Assert.That(result2, Is.EqualTo(false));

        //        Boolean result3 = emailAddressString2 != emailAddress;
        //        Assert.That(result3, Is.EqualTo(true));

        //        Boolean result4 = emailAddress != emailAddressString2;
        //        Assert.That(result4, Is.EqualTo(true));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast not equals null string.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastNotEqualsNullString()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
        //        const String emailAddressString2 = null;

        //        Boolean result1 = emailAddressString2 != emailAddress;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress != emailAddressString2;
        //        Assert.That(result2, Is.EqualTo(true));
        //    }
        //}

        ///// <summary>
        ///// Tests the implicit cast not equals string null email address.
        ///// </summary>
        //[TestCase]
        //public void Test_ImplicitCastNotEqualsStringNullEmailAddress()
        //{
        //    foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
        //    {
        //        EmailAddress emailAddress = null;

        //        Boolean result1 = originalEmailAddressString != emailAddress;
        //        Assert.That(result1, Is.EqualTo(true));

        //        Boolean result2 = emailAddress != originalEmailAddressString;
        //        Assert.That(result2, Is.EqualTo(true));
        //    }
        //}
    }
}
