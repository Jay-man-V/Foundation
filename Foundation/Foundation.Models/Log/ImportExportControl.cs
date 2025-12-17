//-----------------------------------------------------------------------
// <copyright file="ImportExportControl.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models.Log
{
    /// <summary>
    /// Event Log Application class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IImportExportControl" />
    [DependencyInjectionTransient]
    public class ImportExportControl : FoundationModel, IImportExportControl, IEquatable<IImportExportControl>
    {
        private DateTime _processedOn;
        private String _name = String.Empty;
        private Boolean _inProgress = false;

        /// <inheritdoc cref="IImportExportControl.ProcessedOn"/>
        [Column(nameof(FDC.ImportExportControl.ProcessedOn))]
        [Required]
        public DateTime ProcessedOn
        {
            get => _processedOn;
            set => this.SetPropertyValue(ref _processedOn, value);
        }

        /// <inheritdoc cref="IImportExportControl.Name"/>
        [Column(nameof(FDC.ImportExportControl.Name)), MaxLength(FDC.ImportExportControl.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.ImportExportControl.Lengths.Name);
        }

        /// <inheritdoc cref="IImportExportControl.InProgress"/>
        [Column(nameof(FDC.ImportExportControl.InProgress))]
        public Boolean InProgress
        {
            get => this._inProgress;
            set => this.SetPropertyValue(ref _inProgress, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ProcessedOn): retVal = ProcessedOn; break;
                case nameof(Name): retVal = Name; break;
                case nameof(InProgress): retVal = InProgress; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ImportExportControl retVal = (ImportExportControl)base.Clone();
            retVal.Initialising = true;

            retVal._processedOn = this._processedOn;
            retVal._name = this._name;
            retVal._inProgress = this._inProgress;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IImportExportControl? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ImportExportControl importExportControl)
            {
                retVal = InternalEquals(importExportControl);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(ProcessedOn);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(InProgress);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IImportExportControl? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<DateTime>.Default.Equals(this.ProcessedOn, right.ProcessedOn);
                retVal &= EqualityComparer<String>.Default.Equals(this.Name, right.Name);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.InProgress, right.InProgress);
            }

            return retVal;
        }
    }
}
