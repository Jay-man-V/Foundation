//-----------------------------------------------------------------------
// <copyright file="DocGenNumberingFormat.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

using Foundation.Interfaces;

namespace Foundation.DocumentGenerator
{
    /// <summary>
    /// Custom Numbering DotNetFormat
    /// </summary>
    public class DocGenNumberingFormat : NumberingFormat
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridColumnDefinition"></param>
        public DocGenNumberingFormat(IGridColumnDefinition gridColumnDefinition)
        {
            GridColumnDefinition = gridColumnDefinition;

            FormatCode = StringValue.FromString(gridColumnDefinition.ExcelFormat);
        }

        /// <summary>
        /// 
        /// </summary>
        public IGridColumnDefinition GridColumnDefinition { get; }

        /// <summary>
        /// 
        /// </summary>
        public HorizontalAlignmentValues HorizontalAlignment
        {
            get
            {
                HorizontalAlignmentValues retVal = HorizontalAlignmentValues.General;

                switch (GridColumnDefinition.TextAlignment)
                {
                    case TextAlignment.Centre: retVal = HorizontalAlignmentValues.Center; break;
                    case TextAlignment.Left: retVal = HorizontalAlignmentValues.Left; break;
                    case TextAlignment.Right: retVal = HorizontalAlignmentValues.Right; break;
                }

            return retVal;
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            Int32 hashCode = 641921680;
            Int32 constant = -29624512;

            if (NumberFormatId != null && NumberFormatId.HasValue)
            {
                hashCode = hashCode * constant + EqualityComparer<UInt32Value>.Default.GetHashCode(NumberFormatId);
            }

            if (FormatCode != null && FormatCode.HasValue)
            {
                hashCode = hashCode * constant + EqualityComparer<StringValue>.Default.GetHashCode(FormatCode);
            }

            hashCode = hashCode * constant + EqualityComparer<HorizontalAlignmentValues>.Default.GetHashCode(HorizontalAlignment);

            return hashCode;
        }
    }
}