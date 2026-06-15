//-----------------------------------------------------------------------
// <copyright file="SerialiseTest.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Support
{
    /// <summary>
    /// The user security support class
    /// </summary>
    public class SerialiseTest
    {
        public AppId AppId { get; set; }
        public LogId LogId { get; set; }
        public EntityId EntityId { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public PostCode PostCode { get; set; }
        public TelephoneNumber TelephoneNumber { get; set; }
        public Boolean BooleanValue { get; set; }
        public TimeSpan TimeSpanValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public Guid GuidValue { get; set; }
        public Char CharValue { get; set; }
        public String StringValue { get; set; } = String.Empty;
        public Int16 Int16Value { get; set; }
        public UInt16 UInt16Value { get; set; }
        public Int32 Int32Value { get; set; }
        public UInt32 UInt32Value { get; set; }
        public Int64 Int64Value { get; set; }
        public UInt64 UInt64Value { get; set; }
        public Decimal DecimalValue { get; set; }
        public Double DoubleValue { get; set; }
        public Single SingleValue { get; set; }
        public Byte ByteValue { get; set; }
        public SByte SByteValue { get; set; }
        public List<String> StringList { get; set; } = [];
        public List<Int32> Int32List { get; set; } = [];

        public void Initialise()
        {
            AppId  = new AppId(123);
            LogId  = new LogId(456);
            EntityId  = new EntityId(789);
            EmailAddress  = new EmailAddress("info@jdvsoftware.com");
            PostCode  = new PostCode("HP1 1aa");
            TelephoneNumber  = new TelephoneNumber("0123 4567 9876");
            BooleanValue  = true;
            TimeSpanValue  = new TimeSpan(01, 02, 03, 04);
            DateTimeValue  = new DateTime(2025, 04, 05, 18, 12, 14, 123);
            GuidValue  = Guid.Parse("{88701824-8375-4C0C-9D79-CEB5D3FC040D}");
            CharValue  = 'Z';
            StringValue  = "{88701824-8375-4C0C-9D79-CEB5D3FC040D}";
            Int16Value  = Int16.MaxValue;
            UInt16Value  = UInt16.MaxValue;
            Int32Value  = Int32.MaxValue;
            UInt32Value  = UInt32.MaxValue;
            Int64Value  = Int64.MaxValue;
            UInt64Value  = UInt64.MaxValue;
            DecimalValue  = Decimal.MaxValue;
            DoubleValue  = Double.MaxValue;
            SingleValue  = Single.MaxValue;
            ByteValue  = Byte.MaxValue;
            SByteValue  = SByte.MaxValue;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 hashCode = 746720419;
            Int32 constant = -1521134295;

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(AppId);
            hashCode = hashCode * constant + EqualityComparer<LogId>.Default.GetHashCode(LogId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(EntityId);
            hashCode = hashCode * constant + EqualityComparer<EmailAddress>.Default.GetHashCode(EmailAddress);

            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(BooleanValue);
            hashCode = hashCode * constant + EqualityComparer<TimeSpan>.Default.GetHashCode(TimeSpanValue);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(DateTimeValue);
            hashCode = hashCode * constant + EqualityComparer<Guid>.Default.GetHashCode(GuidValue);
            hashCode = hashCode * constant + EqualityComparer<Char>.Default.GetHashCode(CharValue);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(StringValue);
            hashCode = hashCode * constant + EqualityComparer<Int16>.Default.GetHashCode(Int16Value);
            hashCode = hashCode * constant + EqualityComparer<UInt16>.Default.GetHashCode(UInt16Value);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(Int32Value);
            hashCode = hashCode * constant + EqualityComparer<UInt32>.Default.GetHashCode(UInt32Value);
            hashCode = hashCode * constant + EqualityComparer<Int64>.Default.GetHashCode(Int64Value);
            hashCode = hashCode * constant + EqualityComparer<UInt64>.Default.GetHashCode(UInt64Value);
            hashCode = hashCode * constant + EqualityComparer<Decimal>.Default.GetHashCode(DecimalValue);
            hashCode = hashCode * constant + EqualityComparer<Double>.Default.GetHashCode(DoubleValue);
            hashCode = hashCode * constant + EqualityComparer<Single>.Default.GetHashCode(SingleValue);
            hashCode = hashCode * constant + EqualityComparer<Byte>.Default.GetHashCode(ByteValue);
            hashCode = hashCode * constant + EqualityComparer<SByte>.Default.GetHashCode(SByteValue);
            hashCode = hashCode * constant + EqualityComparer<List<String>>.Default.GetHashCode(StringList);
            hashCode = hashCode * constant + EqualityComparer<List<Int32>>.Default.GetHashCode(Int32List);

            return hashCode;
        }

        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj != null &&
                obj is SerialiseTest serialiseTest)
            {
                retVal = InternalEquals(this, serialiseTest);
            }

            return retVal;
        }

        public Boolean Equals(SerialiseTest? other)
        {
            Boolean retVal = false;

            if (other != null)
            {
                retVal = InternalEquals(this, other);
            }

            return retVal;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(SerialiseTest left, SerialiseTest right)
        {
            Boolean retVal = true;

            retVal &= left.BooleanValue == right.BooleanValue;
            retVal &= left.TimeSpanValue == right.TimeSpanValue;
            retVal &= left.DateTimeValue == right.DateTimeValue;
            retVal &= left.GuidValue == right.GuidValue;
            retVal &= left.CharValue == right.CharValue;
            retVal &= left.StringValue == right.StringValue;
            retVal &= left.Int16Value == right.Int16Value;
            retVal &= left.UInt16Value == right.UInt16Value;
            retVal &= left.Int32Value == right.Int32Value;
            retVal &= left.UInt32Value == right.UInt32Value;
            retVal &= left.Int64Value == right.Int64Value;
            retVal &= left.UInt64Value == right.UInt64Value;
            retVal &= left.DecimalValue == right.DecimalValue;
            retVal &= left.DoubleValue == right.DoubleValue;
            retVal &= left.SingleValue == right.SingleValue;
            retVal &= left.ByteValue == right.ByteValue;
            retVal &= left.SByteValue == right.SByteValue;

            retVal &= left.StringList.SequenceEqual(right.StringList);
            retVal &= left.Int32List.SequenceEqual(right.Int32List);

            return retVal;
        }
    }
}
