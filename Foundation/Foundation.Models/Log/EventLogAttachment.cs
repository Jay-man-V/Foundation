//-----------------------------------------------------------------------
// <copyright file="EventLogAttachment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models.Log
{
    /// <summary>
    /// Event Log Attachment class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IEventLogAttachment" />
    [DependencyInjectionTransient]
    public class EventLogAttachment : FoundationModel, IEventLogAttachment, IEquatable<IEventLogAttachment>
    {
        private LogId _eventLogId;
        private String _attachmentFileName = String.Empty;
        private Byte[]? _attachment;

        /// <inheritdoc cref="IEventLogAttachment.EventLogId"/>
        [Column(nameof(FDC.EventLogAttachment.EventLogId))]
        [RequiredLogId]
        public LogId EventLogId
        {
            get => _eventLogId;
            set => this.SetPropertyValue(ref _eventLogId, value);
        }

        /// <inheritdoc cref="IEventLogAttachment.AttachmentFileName"/>
        [Column(nameof(FDC.EventLogAttachment.AttachmentFileName)), MaxLength(FDC.EventLogAttachment.Lengths.AttachmentFileName)]
        [Required(AllowEmptyStrings = true)]
        public String AttachmentFileName
        {
            get => this._attachmentFileName;
            set => this.SetPropertyValue(ref _attachmentFileName, value, FDC.EventLogAttachment.Lengths.AttachmentFileName);
        }

        /// <inheritdoc cref="IEventLogAttachment.Attachment"/>
        [Column(nameof(FDC.EventLogAttachment.Attachment)), MaxLength(FDC.EventLogAttachment.Lengths.Attachment)]
        public Byte[]? Attachment
        {
            get => this._attachment;
            set => this.SetPropertyValue(ref _attachment, value, FDC.EventLogAttachment.Lengths.Attachment);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(EventLogId): retVal = EventLogId; break;
                case nameof(AttachmentFileName): retVal = AttachmentFileName; break;
                case nameof(Attachment): retVal = Attachment; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            EventLogAttachment retVal = (EventLogAttachment)base.Clone();
            retVal.Initialising = true;

            retVal._eventLogId = this._eventLogId;
            retVal._attachmentFileName = this._attachmentFileName;

            if (this._attachment != null)
            {
                retVal._attachment = this._attachment.ToList().Clone().ToArray();
            }

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IEventLogAttachment? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is EventLogAttachment eventLogAttachment)
            {
                retVal = InternalEquals(eventLogAttachment);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<LogId>.Default.GetHashCode(EventLogId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(AttachmentFileName);
            if (this.Attachment != null)
            {
                hashCode = hashCode * constant + StructuralComparisons.StructuralEqualityComparer.GetHashCode(Attachment);
            }

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IEventLogAttachment? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<LogId>.Default.Equals(this.EventLogId, right.EventLogId);
                retVal &= EqualityComparer<String>.Default.Equals(this.AttachmentFileName, right.AttachmentFileName);
                retVal &= StructuralComparisons.StructuralEqualityComparer.Equals(this.Attachment, right.Attachment);
            }

            return retVal;
        }
    }
}
