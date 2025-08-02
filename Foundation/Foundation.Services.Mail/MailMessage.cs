//-----------------------------------------------------------------------
// <copyright file="MailMessage.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Mail
{
    /// <summary>
    /// The Mail Message class
    /// </summary>
    [DependencyInjectionTransient]
    public class MailMessage : IMailMessage
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MailMessage"/> class.
        /// </summary>
        public MailMessage()
        {
            Attachments = new List<IMailAttachment>();
            ToAddress = new List<String>();

            FromAddress = String.Empty;
            FromAddressDisplayName = String.Empty;
            Body = String.Empty;
            Subject = String.Empty;
        }

        /// <inheritdoc cref="IMailMessage.FromAddress"/>
        public String FromAddress { get; set; }

        /// <inheritdoc cref="IMailMessage.FromAddressDisplayName"/>
        public String FromAddressDisplayName { get; set; }

        /// <inheritdoc cref="IMailMessage.ToAddress"/>
        public List<String> ToAddress { get; set; }

        /// <inheritdoc cref="IMailMessage.Body"/>
        public String Body { get; set; }

        /// <inheritdoc cref="IMailMessage.IsBodyHtml"/>
        public Boolean IsBodyHtml { get; set; }

        /// <inheritdoc cref="IMailMessage.Subject"/>
        public String Subject { get; set; }

        /// <inheritdoc cref="IMailMessage.Attachments"/>
        public List<IMailAttachment> Attachments { get; set; }

        /// <inheritdoc cref="ICloneable.Clone"/>
        public Object Clone()
        {
            IMailMessage retVal = (IMailMessage)Activator.CreateInstance(this.GetType());

            retVal.Body = this.Body;
            retVal.IsBodyHtml = this.IsBodyHtml;
            retVal.FromAddress = this.FromAddress;
            retVal.FromAddressDisplayName = this.FromAddressDisplayName;
            retVal.Subject = this.Subject;

            retVal.ToAddress = this.ToAddress.Clone();
            retVal.Attachments = this.Attachments.Clone();

            return retVal;
        }
    }
}
