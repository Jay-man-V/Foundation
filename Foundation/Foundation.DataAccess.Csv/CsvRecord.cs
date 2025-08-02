//-----------------------------------------------------------------------
// <copyright file="CsvRecord.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Text;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.DataAccess.Csv
{
    /// <summary>
    /// Defines the CsvRecord class
    /// </summary>
    [DependencyInjectionTransient]
    public class CsvRecord
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CsvRecord"/> class
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="headerRow"></param>
        /// <param name="input"></param>
        public CsvRecord(UInt64 rowIndex, CsvRecord headerRow, String input)
        {
            HeaderFields = new List<String>();
            FieldCount = 0;
            Fields = new Dictionary<String, String>();

            RawData = input;
            RowIndex = rowIndex;

            Boolean inQuotes = false;
            Boolean inField = true;
            Boolean fieldEnd = false;
            StringBuilder fieldValue = new StringBuilder();

            Char prevChar = Char.MinValue;

            Byte[] byteArray = Encoding.ASCII.GetBytes(input);

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    while (!sr.EndOfStream)
                    {
                        Char currentChar = (Char)sr.Read();
                        Char nextChar = (Char)sr.Peek();

                        if (prevChar != CharacterCodes.DoubleQuote &&
                            currentChar == CharacterCodes.DoubleQuote &&
                            nextChar != CharacterCodes.DoubleQuote)
                        {
                            inQuotes = !inQuotes;
                        }

                        if (!inQuotes &&
                            currentChar == CharacterCodes.FieldDelimiter)
                        {
                            inField = false;
                            fieldEnd = true;
                        }

                        if (sr.EndOfStream) fieldEnd = true;

                        if (inField)
                        {
                            if (currentChar != CharacterCodes.DoubleQuote)
                            {
                                fieldValue.Append(currentChar);
                            }
                            else if (currentChar == CharacterCodes.DoubleQuote &&
                                     nextChar == CharacterCodes.DoubleQuote)
                            {
                                fieldValue.Append(currentChar);
                            }
                        }

                        if (fieldEnd)
                        {
                            fieldEnd = false;
                            inField = true;

                            String columnName = fieldValue.ToString();

                            if (headerRow != null)
                            {
                                columnName = headerRow.HeaderFields[FieldCount];
                            }

                            if (rowIndex == 1) HeaderFields.Add(columnName);

                            Fields.Add(columnName, fieldValue.ToString());
                            FieldCount++;

                            fieldValue = new StringBuilder();
                        }

                        prevChar = currentChar;
                    }
                }
            }

            //IsComplete = (!inQuotes || !inField || fieldEnd);
            IsComplete = (!inQuotes || !inField || fieldEnd);
        }

        private List<String> HeaderFields { get; }
        private Int32 FieldCount { get; }

        /// <summary>
        /// Gets the fields
        /// </summary>
        public Dictionary<String, String> Fields { get; }

        /// <summary>
        /// Gets the raw data
        /// </summary>
        public String RawData { get; }

        /// <summary>
        /// Gets the row index
        /// </summary>
        public UInt64 RowIndex { get; }

        /// <summary>
        /// Gets the is complete
        /// </summary>
        public Boolean IsComplete { get; }

        /// <inheritdoc cref="ToString"/>
        public override String ToString()
        {
            StringBuilder retVal = new StringBuilder();

            retVal.AppendFormat($"{IsComplete} = {RowIndex} ");
            retVal.Append(String.Join("|", Fields));

            return retVal.ToString();
        }
    }
}
