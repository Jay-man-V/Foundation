//-----------------------------------------------------------------------
// <copyright file="AppId.cs" company="JDV Software Ltd">
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
    /// A struct to hold an Application Id alongside validation routines
    /// </summary>
    [DebuggerDisplay("{TheAppId}")]
    public readonly struct AppId : IEquatable<AppId>, IComparable<AppId>
    {
        /// <summary>
        /// The underlying type of the App Id
        /// </summary>
        public static readonly Type AppIdType = typeof(Int64);

        /// <summary>
        /// Database type of the underlying type
        /// </summary>
        public static readonly DbType DbType = DbType.Int64;

        /// <summary>
        /// Minimum numeric value that can be set as the underlying value of the Application Id
        /// </summary>
        public static Int64 MinValue => 0;

        /// <summary>
        /// Maximum numeric value that can be set as the underlying value of the Application Id
        /// </summary>
        public static Int64 MaxValue => Int64.MaxValue;

        /// <summary>
        /// Initialises a new instance of the <see cref="AppId"/> class.
        /// </summary>
        /// <param name="appId">The <see cref="Int64"/> version of the App Id.</param>
        public AppId(Int64 appId)
        {
            TheAppId = appId;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AppId"/> class.
        /// </summary>
        /// <param name="appId">The app id.</param>
        public AppId(AppId appId) 
        {
            TheAppId = appId.ToInteger();
        }

        /// <summary>
        /// Gets or sets the App Id.
        /// </summary>
        /// <value>
        /// The App Id.
        /// </value>
        public Int64 TheAppId { get; }

        /// <summary>
        /// Attempts to cast from generic base <see cref="Object"/> to an <see cref="AppId"/>
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// New instance of <see cref="AppId" />
        /// </returns>
        public static AppId FromObject(Object? x)
        {
            AppId retVal = new(0);

            if (x != null)
            {
                Type objectType = x.GetType();

                if (objectType == AppIdType)
                {
                    Int64 input = Convert.ToInt64(x);
                    retVal = new(input);
                }
                else if (objectType == typeof(AppId))
                {
                    AppId input = (AppId)x;
                    retVal = new(input);
                }
            }

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(AppId x, AppId y)
        {
            Boolean retVal = (x.TheAppId == y.TheAppId);

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(AppId x, AppId y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(AppId x, Object y)
        {
            Boolean retVal = false;

            if (y is AppId appIdY)
            {
                retVal = (x.TheAppId == appIdY.TheAppId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(AppId x, Object y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(Object x, AppId y)
        {
            Boolean retVal = false;

            if (x is AppId appIdX)
            {
                retVal = (appIdX.TheAppId == y.TheAppId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for AppId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(Object x, AppId y)
        {
            Boolean retVal = !(y == x);

            return retVal;
        }

        ///// <summary>
        ///// Implicit cast from an Int64 to AppId Object
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator AppId(Int64 x)
        //{
        //    AppId retVal = new(x);

        //    return retVal;
        //}

        ///// <summary>
        ///// Implicit cast from AppId Object to Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator Int64(AppId x)
        //{
        //    Int64 retVal = x.TheAppId;

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for AppId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(AppId x, Int64 y)
        //{
        //    Boolean retVal = (x.TheAppId == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for AppId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(Int64 x, AppId y)
        //{
        //    Boolean retVal = (y == x);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for AppId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(AppId x, Int64 y)
        //{
        //    Boolean retVal = !(x == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for AppId Object with a Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(Int64 x, AppId y)
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

                if (objectType == typeof(AppId))
                {
                    AppId input = (AppId)obj;
                    retVal = TheAppId.Equals(input.TheAppId);
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
            Int32 retVal = TheAppId.GetHashCode();

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
            return TheAppId.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.Int64" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Int64" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public Int64 ToInteger()
        {
            return TheAppId;
        }

        /// <summary>
        /// Compares the supplied <see cref="AppId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Boolean IEquatable<AppId>.Equals(AppId other)
        {
            Boolean retVal = Equals(other);

            return retVal;
        }

        /// <summary>
        /// Compares the supplied <see cref="AppId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Int32 IComparable<AppId>.CompareTo(AppId other)
        {
            Int32 retVal = TheAppId.CompareTo(other.TheAppId);

            return retVal;
        }

        /// <summary>
        /// Implements an Ascending Sort functionality for AppIds
        /// </summary>
        public class SortAscending : IComparer<AppId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied AppIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(AppId x, AppId y)
            {
                Int32 retVal = x.TheAppId.CompareTo(y.TheAppId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied AppIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, [NotNullWhen(true)] Object? y)
            {
                Int32 retVal = 0;
                if (x is AppId appIdX && y is AppId appIdY)
                {
                    retVal = Compare(appIdX, appIdY);
                }

                return retVal;
            }
        }

        /// <summary>
        /// Implements a Descending Sort functionality for AppIds
        /// </summary>
        public class SortDescending : IComparer<AppId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied AppIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(AppId x, AppId y)
            {
                Int32 retVal = y.TheAppId.CompareTo(x.TheAppId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied AppIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, [NotNullWhen(true)] Object? y)
            {
                Int32 retVal = 0;
                if (x is AppId appIdX && y is AppId appIdY)
                {
                    retVal = Compare(appIdX, appIdY);
                }

                return retVal;
            }
        }
    }
}
