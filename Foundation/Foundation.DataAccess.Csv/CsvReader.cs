//-----------------------------------------------------------------------
// <copyright file="CsvReader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
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
    public class CsvReader<TCsvRecord> : IDisposable
        where TCsvRecord : CsvRecord
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CsvReader{TCsvRecord}"/> class
        /// </summary>
        /// <param name="sourceFile"></param>
        public CsvReader(String sourceFile)
        {
            InputStream = File.OpenText(sourceFile);
            RowCounter = 0;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CsvReader{TCsvRecord}"/> class
        /// </summary>
        /// <param name="sourceStream"></param>
        public CsvReader(StreamReader sourceStream)
        {
            InputStream = sourceStream;
            RowCounter = 0;
        }

        private StreamReader? InputStream { get; set; }
        private UInt64 RowCounter { get; set; }

        /// <summary>
        /// Gets the header row
        /// </summary>
        public TCsvRecord? HeaderRow { get; private set; }

        /// <summary>
        /// Gets the end of file
        /// </summary>
        public Boolean EndOfFile { get; private set; }

        /// <summary>
        /// Gets the size of the file
        /// </summary>
        public UInt64 Size
        {
            get
            {
                UInt64 retVal = (UInt64)InputStream.BaseStream.Length;

                return retVal;
            }
        }

        /// <summary>
        /// Reads the next record from the Csv file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TCsvRecord> Read()
        {
            EndOfFile = false;
            RowCounter = 0;
            InputStream.BaseStream.Seek(0, SeekOrigin.Begin);

            StringBuilder sb = new StringBuilder();

            Boolean recordEnd = false;
            Boolean inQuotes = false;
            Char prevChar = Char.MinValue;

            while (!InputStream.EndOfStream)
            {
                Char currentChar = (Char)InputStream.Read();
                Char nextChar = (Char)InputStream.Peek();

                // Figure out if the current field is contained within Quotes ("...")
                if (prevChar != CharacterCodes.DoubleQuote &&
                    currentChar == CharacterCodes.DoubleQuote &&
                    nextChar != CharacterCodes.DoubleQuote)
                {
                    inQuotes = !inQuotes;
                }

                // We expect records to be terminated by a Carriage Return or New Line,
                // if not within a set of Quotes ("...")
                if (!inQuotes &&
                    (currentChar == CharacterCodes.CarriageReturn ||
                     currentChar == CharacterCodes.NewLine))
                {
                    // Discard the New Line character if it's the next one
                    if (nextChar == CharacterCodes.NewLine) InputStream.Read();

                    recordEnd = true;
                }

                if (!recordEnd)
                {
                    sb.Append(currentChar);
                }

                if (recordEnd &&
                    sb.Length > 0)
                {
                    RowCounter++;
                    TCsvRecord retVal = (TCsvRecord)Activator.CreateInstance(typeof(TCsvRecord), RowCounter, HeaderRow, sb.ToString());

                    recordEnd = false;
                    inQuotes = false;

                    // RowCounter 1 = Header row
                    if (RowCounter == 1)
                    {
                        HeaderRow = retVal;
                    }
                    else
                    {
                        yield return retVal;
                    }

                    sb = new StringBuilder();
                }

                prevChar = currentChar;
            }

            EndOfFile = InputStream.EndOfStream;
        }

        /// <summary>
        /// Reads all the CsvRecords from the Csv file
        /// </summary>
        /// <returns></returns>
        public List<TCsvRecord> ReadAll()
        {
            List<TCsvRecord> retVal = new List<TCsvRecord>();

            foreach (TCsvRecord csvRecord in Read())
            {
                String val = csvRecord.ToString();
                Debug.WriteLine($"Record: {val} ");

                retVal.Add(csvRecord);
            }

            return retVal;
        }

        /// <inheritdoc cref="Dispose"/>
        public void Dispose()
        {
            if (InputStream != null)
            {
                InputStream.BaseStream.Dispose();
            }

            if (InputStream != null)
            {
                InputStream.Dispose();
            }

            InputStream = null;
        }
    }
}
