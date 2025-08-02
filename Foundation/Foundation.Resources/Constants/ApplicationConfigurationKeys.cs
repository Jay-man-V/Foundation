//-----------------------------------------------------------------------
// <copyright file="FileApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationConfigurationKeys
    {
        /// <summary>
        /// UserDataPath
        /// </summary>
        public static String UserDataPath => "UserDataPath";

        /// <summary>
        /// SystemDataPath
        /// </summary>
        public static String SystemDataPath => "SystemDataPath";

        /// <summary>
        /// email.from.address
        /// </summary>
        public static String EmailFromAddress => "email.from.address";

        /// <summary>
        /// email.from.address
        /// </summary>
        public static String EmailFromDisplayName => "email.from.display.name";

        /// <summary>
        /// email.smtp.host.address
        /// </summary>
        public static String EmailSmtpHostAddress => "email.smtp.host.address";

        /// <summary>
        /// email.smtp.host.port
        /// </summary>
        public static String EmailSmtpHostPort => "email.smtp.host.port";

        /// <summary>
        /// email.smtp.host.enable.ssl
        /// </summary>
        public static String EmailSmtpHostEnableSsl => "email.smtp.host.enable.ssl";

        /// <summary>
        /// email.smtp.host.username
        /// </summary>
        public static String EmailSmtpHostUsername => "email.smtp.host.username";

        /// <summary>
        /// email.smtp.host.password
        /// </summary>
        public static String EmailSmtpHostPassword => "email.smtp.host.password";

        /// <summary>
        /// service.holidays.national.uk.url
        /// </summary>
        public static String ServiceHolidaysNationalUkUrl => "service.holidays.national.uk.url";

        /// <summary>
        /// service.generator.password.random.url
        /// </summary>
        public static String ServiceGeneratorPasswordRandomUrl => "service.generator.password.random.url";

        /// <summary>
        /// service.generator.password.memorable.url
        /// </summary>
        public static String ServiceGeneratorPasswordMemorableUrl => "service.generator.password.memorable.url";

        /// <summary>
        /// service.generator.password.rule.length
        /// </summary>
        public static String ServiceGeneratorPasswordRuleLength => "service.generator.password.rule.length";

        /// <summary>
        /// service.generator.password.rule.count
        /// </summary>
        public static String ServiceGeneratorPasswordRuleCount => "service.generator.password.rule.count";
    }
}
