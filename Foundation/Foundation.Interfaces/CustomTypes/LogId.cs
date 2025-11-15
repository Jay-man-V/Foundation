//-----------------------------------------------------------------------
// <copyright file="LogId.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.Interfaces
{
    /// <summary>
    /// A struct to hold a Log Id alongside validation routines
    /// </summary>
    [DebuggerDisplay("{TheLogId}")]
    public readonly struct LogId : IEquatable<LogId>, IComparable<LogId>
    {
        /// <summary>
        /// The underlying type of the Log Id
        /// </summary>
        public static readonly Type LogIdType = typeof(Int64);

        /// <summary>
        /// Database type of the underlying type
        /// </summary>
        public static readonly DbType DbType = DbType.Int64;

        /// <summary>
        /// The minimum value
        /// </summary>
        public static Int64 MinValue => 1;

        /// <summary>
        /// The maximum value
        /// </summary>
        public static Int64 MaxValue => Int64.MaxValue;

        /// <summary>
        /// Initialises a new instance of the <see cref="LogId"/> class.
        /// </summary>
        /// <param name="logId">The <see cref="Int64"/> version of the log Id.</param>
        public LogId(Int64 logId)
        {
            TheLogId = logId;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="LogId"/> class.
        /// </summary>
        /// <param name="logId">The log id.</param>
        public LogId(LogId logId)
        {
            TheLogId = logId.TheLogId;
        }

        /// <summary>
        /// Gets or sets the Log Id.
        /// </summary>
        /// <value>
        /// The Log Id.
        /// </value>
        public Int64 TheLogId { get; }

        /// <summary>
        /// Attempts to cast from generic base <see cref="Object"/> to an <see cref="LogId"/>
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// New instance of <see cref="LogId" />
        /// </returns>
        public static LogId FromObject(Object? x)
        {
            LogId retVal = new LogId(0L);

            if (x != null)
            {
                Type objectType = x.GetType();

                if (objectType == LogIdType)
                {
                    Int64 input = Convert.ToInt64(x);
                    retVal = new LogId(input);
                }
                else if (objectType == typeof(LogId))
                {
                    LogId input = (LogId)x;
                    retVal = new LogId(input);
                }
            }

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(LogId x, LogId y)
        {
            Boolean retVal = (x.TheLogId == y.TheLogId);

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(LogId x, LogId y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(LogId x, Object y)
        {
            Boolean retVal = false;

            if (y is LogId logIdY)
            {
                retVal = (x.TheLogId == logIdY.TheLogId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(LogId x, Object y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(Object x, LogId y)
        {
            Boolean retVal = false;

            if (x is LogId logIdX)
            {
                retVal = (logIdX.TheLogId == y.TheLogId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for LogId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(Object x, LogId y)
        {
            Boolean retVal = !(y == x);

            return retVal;
        }

        ///// <summary>
        ///// Implicit cast from an Int64 to LogId Object
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator LogId(Int64 x)
        //{
        //    LogId retVal = new LogId(x);

        //    return retVal;
        //}

        ///// <summary>
        ///// Implicit cast from LogId Object to Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator Int64(LogId x)
        //{
        //    Int64 retVal = x.TheLogId;

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for LogId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(LogId x, Int64 y)
        //{
        //    Boolean retVal = (x.TheLogId == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for LogId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(Int64 x, LogId y)
        //{
        //    Boolean retVal = (y == x);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for LogId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(LogId x, Int64 y)
        //{
        //    Boolean retVal = !(x == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for LogId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(Int64 x, LogId y)
        //{
        //    Boolean retVal = !(x == y);

        //    return retVal;
        //}

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
        /// </returns>
        public override Boolean Equals([NotNullWhen(true)] Object? obj)
        {
            Boolean retVal = false;

            if (obj != null)
            {
                Type objectType = obj.GetType();

                if (objectType == typeof(LogId))
                {
                    LogId input = (LogId)obj;
                    retVal = TheLogId.Equals(input.TheLogId);
                }
            }

            return retVal;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override Int32 GetHashCode()
        {
            Int32 retVal = TheLogId.GetHashCode();

            return retVal;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override String ToString()
        {
            return TheLogId.ToString();
        }

        /// <summary>
        /// Compares the supplied <see cref="LogId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Boolean IEquatable<LogId>.Equals(LogId other)
        {
            Boolean retVal = Equals(other);

            return retVal;
        }

        /// <summary>
        /// Compares the supplied <see cref="LogId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Int32 IComparable<LogId>.CompareTo(LogId other)
        {
            Int32 retVal = TheLogId.CompareTo(other.TheLogId);

            return retVal;
        }

        /// <summary>
        /// Implements an Ascending Sort functionality for LogIds
        /// </summary>
        public class SortAscending : IComparer<LogId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied LogIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(LogId x, LogId y)
            {
                Int32 retVal = x.TheLogId.CompareTo(y.TheLogId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied LogIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, [NotNullWhen(true)] Object? y)
            {
                Int32 retVal = 0;
                if (x is LogId logIdX && y is LogId logIdY)
                {
                    retVal = Compare(logIdX, logIdY);
                }

                return retVal;
            }
        }

        /// <summary>
        /// Implements a Descending Sort functionality for LogIds
        /// </summary>
        public class SortDescending : IComparer<LogId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied LogIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(LogId x, LogId y)
            {
                Int32 retVal = y.TheLogId.CompareTo(x.TheLogId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied LogIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, Object? y)
            {
                Int32 retVal = 0;
                if (x is LogId logIdX && y is LogId logIdY)
                {
                    retVal = Compare(logIdX, logIdY);
                }

                return retVal;
            }
        }
    }
}
