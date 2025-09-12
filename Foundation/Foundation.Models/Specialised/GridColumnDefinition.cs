//-----------------------------------------------------------------------
// <copyright file="GridColumnDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Drawing;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Models.Specialised
{
    /// <summary>
    /// The Grid Column Definition class definition
    /// </summary>
    [DebuggerDisplay("{ColumnHeaderName}::{DataMemberName}::{DataType}")]
    [DependencyInjectionTransient]
    public class GridColumnDefinition : IGridColumnDefinition
    {
        private const String DefaultValueMember = "ValueMember";
        private const String DefaultDisplayMember = "DisplayMember";

        /// <summary>
        /// Initialises a new instance of the <see cref="GridColumnDefinition"/> class.
        /// </summary>
        public GridColumnDefinition()
        {
            DataMemberName = String.Empty;
            ColumnHeaderName = String.Empty;
            DataType = typeof(String);

            ValueMember = DefaultValueMember;
            DisplayMember = DefaultDisplayMember;
            Width = 0;
            Visible = (Width > 0); // If the Width is 0, we can assume it is to be hidden
            TextAlignment = TextAlignment.NotSet;

            DotNetFormat = String.Empty;
            ExcelFormat = String.Empty;
            TrueValue = String.Empty;
            FalseValue = String.Empty;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="GridColumnDefinition"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="dataMemberName">Name of the data member.</param>
        /// <param name="columnHeaderName">Name of the column header.</param>
        /// <param name="dataType">Type of the data.</param>
        public GridColumnDefinition(Int32 width, String dataMemberName, String columnHeaderName, Type dataType)
        {
            ValueMember = DefaultValueMember;
            DisplayMember = DefaultDisplayMember;
            Width = width;
            DataMemberName = dataMemberName;
            ColumnHeaderName = columnHeaderName;
            DataType = dataType;
            Visible = (width > 0); // If the Width is 0, we can assume it is to be hidden

            DotNetFormat = String.Empty;
            ExcelFormat = String.Empty;
            MinimumValue = null;
            MaximumValue = null;
            TrueValue = String.Empty;
            FalseValue = String.Empty;
            DataSource = null;

            // Only treat the Types listed below in a special way
            // All other types are to be handled as a String in consuming processes

            if (dataType == typeof(AppId))
            {
                TextAlignment = TextAlignment.Centre;
                DotNetFormat = "0";
                ExcelFormat = "###0";
                MinimumValue = AppId.MinValue;
                MaximumValue = AppId.MaxValue;
            }
            else if (dataType == typeof(EntityId))
            {
                TextAlignment = TextAlignment.Centre;
                DotNetFormat = "0";
                ExcelFormat = "###0";
                MinimumValue = 0;
                MaximumValue = EntityId.MaxValue;
            }
            else if (dataType == typeof(LogId))
            {
                TextAlignment = TextAlignment.Centre;
                DotNetFormat = "0";
                ExcelFormat = "###0";
                MinimumValue = 0;
                MaximumValue = LogId.MaxValue;
            }
            else if (dataType == typeof(Int16))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.Integer;
                ExcelFormat = Formats.Excel.Integer;
                MinimumValue = Int16.MinValue;
                MaximumValue = Int16.MaxValue;
            }
            else if (dataType == typeof(Int32))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.Integer;
                ExcelFormat = Formats.Excel.Integer;
                MinimumValue = Int32.MinValue;
                MaximumValue = Int32.MaxValue;
            }
            else if (dataType == typeof(Int64))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.Integer;
                ExcelFormat = Formats.Excel.Integer;
                MinimumValue = Int64.MinValue;
                MaximumValue = Int64.MaxValue;
            }
            else if (dataType == typeof(Decimal))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.Decimal2dp;
                ExcelFormat = Formats.Excel.Decimal2dp;
                MinimumValue = Decimal.MinValue;
                MaximumValue = Decimal.MaxValue;
            }
            else if (dataType == typeof(Double))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.Decimal2dp;
                ExcelFormat = Formats.Excel.Decimal2dp;
                MinimumValue = Double.MinValue;
                MaximumValue = Double.MaxValue;
            }
            else if (dataType == typeof(TimeSpan))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.TimeOnly;
                ExcelFormat = Formats.Excel.TimeOnly;
                MinimumValue = TimeSpan.MinValue;
                MaximumValue = TimeSpan.MaxValue;
            }
            else if (dataType == typeof(DateTime))
            {
                TextAlignment = TextAlignment.Right;
                DotNetFormat = Formats.DotNet.DateTime;
                ExcelFormat = Formats.Excel.DateTime;
                MinimumValue = DateTime.MinValue;
                MaximumValue = DateTime.MaxValue;
            }
            else if (dataType == typeof(Boolean))
            {
                TextAlignment = TextAlignment.Centre;
                TrueValue = "Y";
                FalseValue = "N";
            }
        }

        /// <inheritdoc cref="IGridColumnDefinition.Width"/>
        public Int32 Width { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.DataMemberName"/>
        public String DataMemberName { get; private set; }

        /// <inheritdoc cref="IGridColumnDefinition.ColumnHeaderName"/>
        public String ColumnHeaderName { get; private set; }

        /// <inheritdoc cref="IGridColumnDefinition.DataType"/>
        public Type DataType { get; private set; }

        /// <inheritdoc cref="IGridColumnDefinition.TextAlignment"/>
        public TextAlignment TextAlignment { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.MaxInputLength"/>
        public Int32 MaxInputLength { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.DotNetFormat"/>
        public String DotNetFormat { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.ExcelFormat"/>
        public String ExcelFormat { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.MinimumValue"/>
        public Object? MinimumValue { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.MaximumValue"/>
        public Object? MaximumValue { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.TrueValue"/>
        public String TrueValue { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.FalseValue"/>
        public String FalseValue { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.DataSource"/>
        public Object? DataSource { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.ValueMember"/>
        public String ValueMember { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.DisplayMember"/>
        public String DisplayMember { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.Visible"/>
        public Boolean Visible { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.ReadOnly"/>
        public Boolean ReadOnly { get; set; }

        /// <inheritdoc cref="IGridColumnDefinition.TemplateName"/>
        public String TemplateName
        {
            get
            {
                String retVal;
                if (DataType == typeof(String) &&
                    DataSource != null)
                {
                    retVal = GridColumnTemplateNames.DropDownBoxColumnTemplate;
                }
                else if (DataType == typeof(Image) &&
                         DataSource != null)
                {
                    retVal = GridColumnTemplateNames.ImageDropDownBoxColumnTemplate;
                }
                else if (DataType.IsNumericType())
                {
                    retVal = GridColumnTemplateNames.NumericColumnTemplate;
                }
                else if (DataType == typeof(TimeSpan))
                {
                    retVal = GridColumnTemplateNames.DateTimeColumnTemplate;
                }
                else if (DataType == typeof(DateTime))
                {
                    retVal = GridColumnTemplateNames.DateTimeColumnTemplate;
                }
                else if (DataType == typeof(Image) || DataType == typeof(Bitmap))
                {
                    retVal = GridColumnTemplateNames.ImageColumnTemplate;
                }
                else if (DataType == typeof(Boolean))
                {
                    retVal = GridColumnTemplateNames.YesNoColumnTemplate;
                }
                else
                {
                    retVal = GridColumnTemplateNames.DefaultColumnTemplate;
                }

                return retVal;
            }
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public Object Clone()
        {
            if (Activator.CreateInstance(this.GetType()) is not GridColumnDefinition retVal)
            {
                String message = $"The Type '{this.GetType()}' cannot be cloned but is calling {LocationUtils.GetFullyQualifiedFunctionName()}";
                throw new InvalidOperationException(message);
            }

            // Constructor parameters
            retVal.Width = this.Width;
            retVal.DataMemberName = this.DataMemberName;
            retVal.ColumnHeaderName = this.ColumnHeaderName;
            retVal.DataType = this.DataType;

            // Other properties
            retVal.TextAlignment = this.TextAlignment;
            retVal.MaxInputLength = this.MaxInputLength;
            retVal.DotNetFormat = this.DotNetFormat;
            retVal.ExcelFormat = this.ExcelFormat;
            retVal.MaximumValue = this.MaximumValue;
            retVal.MinimumValue = this.MinimumValue;
            retVal.TrueValue = this.TrueValue;
            retVal.FalseValue = this.FalseValue;
            retVal.DataSource = this.DataSource;
            retVal.ValueMember = this.ValueMember;
            retVal.DisplayMember = this.DisplayMember;
            retVal.Visible = this.Visible;
            retVal.ReadOnly = this.ReadOnly;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IGridColumnDefinition? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is IGridColumnDefinition gridColumnDefinition)
            {
                retVal = InternalEquals(gridColumnDefinition);
            }
            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = 746720419;

            // Constructor parameters
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(Width);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DataMemberName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ColumnHeaderName);
            hashCode = hashCode * constant + EqualityComparer<Type>.Default.GetHashCode(DataType);

            // Other properties
            hashCode = hashCode * constant + EqualityComparer<TextAlignment>.Default.GetHashCode(TextAlignment);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(MaxInputLength);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DotNetFormat);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ExcelFormat);

            if (MaximumValue != null)
            {
                hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(MaximumValue);
            }

            if (MinimumValue != null)
            {
                hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(MinimumValue);
            }

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TrueValue);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FalseValue);

            if (DataSource != null)
            {
                hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(DataSource);
            }

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ValueMember);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DisplayMember);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Visible);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(ReadOnly);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IGridColumnDefinition? right)
        {
            Boolean retVal = true;

            if (right == null)
            {
                retVal = false;
            }
            else
            {
                // Constructor parameters
                retVal &= this.Width == right.Width;
                retVal &= this.DataMemberName == right.DataMemberName;
                retVal &= this.ColumnHeaderName == right.ColumnHeaderName;
                retVal &= this.DataType == right.DataType;

                // Other properties
                retVal &= this.TextAlignment == right.TextAlignment;
                retVal &= this.MaxInputLength == right.MaxInputLength;
                retVal &= this.DotNetFormat == right.DotNetFormat;
                retVal &= this.ExcelFormat == right.ExcelFormat;
                retVal &= this.MaximumValue == right.MaximumValue;
                retVal &= this.MinimumValue == right.MinimumValue;
                retVal &= this.TrueValue == right.TrueValue;
                retVal &= this.FalseValue == right.FalseValue;
                retVal &= this.DataSource == right.DataSource;
                retVal &= this.ValueMember == right.ValueMember;
                retVal &= this.DisplayMember == right.DisplayMember;
                retVal &= this.Visible == right.Visible;
                retVal &= this.ReadOnly == right.ReadOnly;
            }

            return retVal;
        }
    }
}
