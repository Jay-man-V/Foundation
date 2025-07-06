//-----------------------------------------------------------------------
// <copyright file="GridColumnDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Common
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
#if DEBUG
        internal void SetDataMemberName(String newDataMemberName)
        {
            DataMemberName = newDataMemberName;
        }
#endif

        /// <summary>
        /// Width
        /// </summary>
        public Int32 Width { get; set; }

        /// <summary>
        /// Data member name
        /// </summary>
        public String DataMemberName { get; private set; }

        /// <summary>
        /// Column header name
        /// </summary>
        public String ColumnHeaderName { get; private set; }

        /// <summary>
        /// Data type
        /// </summary>
        public Type DataType { get; private set; }

        /// <summary>
        /// Text alignment
        /// </summary>
        public TextAlignment TextAlignment { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the input.
        /// </summary>
        /// <value>
        /// The maximum length of the input.
        /// </value>
        public Int32 MaxInputLength { get; set; }

        /// <summary>
        /// Dot Net DotNetFormat
        /// </summary>
        public String DotNetFormat { get; set; }

        /// <summary>
        /// Excel format
        /// </summary>
        public String ExcelFormat { get; set; }

        /// <summary>
        /// Minimum value
        /// </summary>
        public Object MinimumValue { get; set; }

        /// <summary>
        /// Maximum value
        /// </summary>
        public Object MaximumValue { get; set; }

        /// <summary>
        /// Value to show if the mapped value is True
        /// </summary>
        public String TrueValue { get; set; }

        /// <summary>
        /// Value to show if the mapped value is False
        /// </summary>
        public String FalseValue { get; set; }

        /// <summary>
        /// Data Source
        /// </summary>
        public Object DataSource { get; set; }

        /// <summary>
        /// Value Member
        /// </summary>
        public String ValueMember { get; set; }

        /// <summary>
        /// Display Member
        /// </summary>
        public String DisplayMember { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public Boolean Visible { get; set; }

        /// <summary>
        /// Read Only
        /// </summary>
        public Boolean ReadOnly { get; set; }

        /// <summary>
        /// Template Name
        /// </summary>
        public String TemplateName
        {
            get
            {
                String retVal;
                if (DataType == typeof(String) &&
                    DataSource.IsNotNull())
                {
                    retVal = GridColumnTemplateNames.DropDownBoxColumnTemplate;
                }
                else if (DataType == typeof(Image) &&
                         DataSource.IsNotNull())
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

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public Object Clone()
        {
            GridColumnDefinition retVal = Activator.CreateInstance(this.GetType()) as GridColumnDefinition;

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


        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is GridColumnDefinition gridColumnDefinition)
            {
                retVal = InternalEquals(this, gridColumnDefinition);
            }

            return retVal;
        }

        /// <summary>
        /// Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public Boolean Equals(GridColumnDefinition other)
        {
            Boolean retVal = false;

            if (other.IsNotNull())
            {
                retVal = InternalEquals(this, other);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 hashCode = 746720419;
            Int32 constant = -1521134295;

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
            hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(MaximumValue);
            hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(MinimumValue);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TrueValue);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FalseValue);
            hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(DataSource);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ValueMember);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DisplayMember);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Visible);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(ReadOnly);

            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(GridColumnDefinition left, GridColumnDefinition right)
        {
            Boolean retVal = false;

            if (left.IsNotNull() &&
                right.IsNotNull())
            {
                retVal = InternalEquals(left, right);
            }

            return retVal;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(GridColumnDefinition left, GridColumnDefinition right)
        {
            Boolean retVal = false;

            if (left.IsNotNull() &&
                right.IsNotNull())
            {
                retVal = !InternalEquals(left, right);
            }

            return retVal;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(GridColumnDefinition left, GridColumnDefinition right)
        {
            Boolean retVal = true;

            // Constructor parameters
            retVal &= left.Width == right.Width;
            retVal &= left.DataMemberName == right.DataMemberName;
            retVal &= left.ColumnHeaderName == right.ColumnHeaderName;
            retVal &= left.DataType == right.DataType;

            // Other properties
            retVal &= left.TextAlignment == right.TextAlignment;
            retVal &= left.MaxInputLength == right.MaxInputLength;
            retVal &= left.DotNetFormat == right.DotNetFormat;
            retVal &= left.ExcelFormat == right.ExcelFormat;
            retVal &= left.MaximumValue == right.MaximumValue;
            retVal &= left.MinimumValue == right.MinimumValue;
            retVal &= left.TrueValue == right.TrueValue;
            retVal &= left.FalseValue == right.FalseValue;
            retVal &= left.DataSource == right.DataSource;
            retVal &= left.ValueMember == right.ValueMember;
            retVal &= left.DisplayMember == right.DisplayMember;
            retVal &= left.Visible == right.Visible;
            retVal &= left.ReadOnly == right.ReadOnly;

            return retVal;
        }
    }
}
