//-----------------------------------------------------------------------
// <copyright file="MailAttachment.cs" company="JDV Software Ltd">
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
    public class MailAttachment : IMailAttachment
    {
        /// <inheritdoc cref="IMailAttachment.Filename"/>
        public String Filename { get; set; } = String.Empty;

        /// <inheritdoc cref="IMailAttachment.Content"/>
        public Byte[]? Content { get; set; } = null;

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public Object Clone()
        {
            if (Activator.CreateInstance(this.GetType()) is not MailAttachment retVal)
            {
                String message = $"The Type '{this.GetType()}' cannot be cloned but is calling {LocationUtils.GetFullyQualifiedFunctionName()}";
                throw new InvalidOperationException(message);
            }

            retVal.Filename = this.Filename;

            if (Content != null)
            {
                retVal.Content = Content.ToArray();
            }

            return retVal;
        }
    }
}