//-----------------------------------------------------------------------
// <copyright file="EventLogApplication.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Event Log Application class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IEventLogApplication" />
    [DependencyInjectionTransient]
    public class EventLogApplication : FoundationModel, IEventLogApplication, IEquatable<IEventLogApplication>
    {
        private AppId _applicationId;
        private String _shortName = String.Empty;
        private String _processName = String.Empty;

        /// <inheritdoc cref="IEventLogApplication.ApplicationId"/>
        [Column(nameof(FDC.EventLogApplication.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => _applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IEventLogApplication.ShortName"/>
        [Column(nameof(FDC.EventLogApplication.ShortName)), MaxLength(FDC.EventLogApplication.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.EventLogApplication.Lengths.ShortName);
        }

        /// <inheritdoc cref="IEventLogApplication.ProcessName"/>
        [Column(nameof(FDC.EventLogApplication.ProcessName)), MaxLength(FDC.EventLogApplication.Lengths.ProcessName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Process Name must be provided")]
        public String ProcessName
        {
            get => this._processName;
            set => this.SetPropertyValue(ref _processName, value, FDC.EventLogApplication.Lengths.ProcessName);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(ProcessName): retVal = ProcessName; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            EventLogApplication retVal = (EventLogApplication)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._shortName = this._shortName;
            retVal._processName = this._processName;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IEventLogApplication? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is EventLogApplication eventLogApplication)
            {
                retVal = InternalEquals(this, eventLogApplication);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ShortName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ProcessName);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IEventLogApplication? left, IEventLogApplication? right)
        {
            Boolean retVal;

            if (left == null && right == null)
            {
                retVal = true;
            }
            else if (left == null || right == null)
            {
                retVal = false;
            }
            else
            {
                retVal = FoundationModel.InternalEquals(left, right);

                retVal &= EqualityComparer<AppId>.Default.Equals(left.ApplicationId, right.ApplicationId);
                retVal &= EqualityComparer<String>.Default.Equals(left.ShortName, right.ShortName);
                retVal &= EqualityComparer<String>.Default.Equals(left.ProcessName, right.ProcessName);
            }

            return retVal;
        }
    }
}
