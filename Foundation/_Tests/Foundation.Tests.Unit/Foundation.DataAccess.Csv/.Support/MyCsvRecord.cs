//-----------------------------------------------------------------------
// <copyright file="MyCsvRecord.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.DataAccess.Csv;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Csv.Support
{
    public class MyCsvRecord : CsvRecord
    {
        public MyCsvRecord
        (
            UInt64 rowIndex,
            CsvRecord headerRow,
            String input
        ) :
            base
            (
                rowIndex,
                headerRow,
                input
            )
        {
        }

        public String Field1
        {
            get => Fields["H1"]; 
            set => Fields["H1"] = value;
        }

        public String Field2
        {
            get => Fields["H2"];
            set => Fields["H2"] = value;
        }

        public String Field3
        {
            get => Fields["H3"];
            set => Fields["H3"] = value;
        }

        public String Field4
        {
            get => Fields["H4"];
            set => Fields["H4"] = value;
        }

        public String Field5
        {
            get => Fields["H5"];
            set => Fields["H5"] = value;
        }

        public String Field6
        {
            get => Fields["H6"];
            set => Fields["H6"] = value;
        }
    }
}
