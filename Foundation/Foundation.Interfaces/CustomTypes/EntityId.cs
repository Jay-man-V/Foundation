//-----------------------------------------------------------------------
// <copyright file="EntityId.cs" company="JDV Software Ltd">
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
    /// A struct to hold an Entity Id alongside validation routines
    /// </summary>
    [DebuggerDisplay("{TheEntityId}")]
    public readonly struct EntityId : IEquatable<EntityId>, IComparable<EntityId>//, IConvertible
    {
        /// <summary>
        /// The underlying type of the Entity Id
        /// </summary>
        public static readonly Type EntityIdType = typeof(Int64);

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
        /// Initialises a new instance of the <see cref="EntityId"/> class.
        /// </summary>
        /// <param name="entityId">The <see cref="Int64"/> version of the Entity Id.</param>
        public EntityId(Int64 entityId)
        {
            TheEntityId = entityId;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityId"/> class.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        public EntityId(EntityId entityId)
        {
            TheEntityId = entityId.ToInteger();
        }

        /// <summary>
        /// Gets or sets the Entity Id.
        /// </summary>
        /// <value>
        /// The Entity Id.
        /// </value>
        public Int64 TheEntityId { get; }

        /// <summary>
        /// Attempts to cast from generic base <see cref="Object"/> to an <see cref="EntityId"/>
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// New instance of <see cref="EntityId" />
        /// </returns>
        public static EntityId FromObject(Object? x)
        {
            EntityId retVal = new(0);

            if (x != null)
            {
                Type objectType = x.GetType();

                if (objectType == EntityIdType)
                {
                    Int64 input = Convert.ToInt64(x);
                    retVal = new(input);
                }
                else if (objectType == typeof(EntityId))
                {
                    EntityId input = (EntityId)x;
                    retVal = new(input);
                }
            }

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(EntityId x, EntityId y)
        {
            Boolean retVal = (x.TheEntityId == y.TheEntityId);

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(EntityId x, EntityId y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(EntityId x, Object y)
        {
            Boolean retVal = false;

            if (y is EntityId entityIdY)
            {
                retVal = (x.TheEntityId == entityIdY.TheEntityId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(EntityId x, Object y)
        {
            Boolean retVal = !(x == y);

            return retVal;
        }

        /// <summary>
        /// == (equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator ==(Object x, EntityId y)
        {
            Boolean retVal = false;

            if (x is EntityId entityIdX)
            {
                retVal = (entityIdX.TheEntityId == y.TheEntityId);
            }

            return retVal;
        }

        /// <summary>
        /// != (not equals) operator for EntityId Objects
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Boolean operator !=(Object x, EntityId y)
        {
            Boolean retVal = !(y == x);

            return retVal;
        }

        ///// <summary>
        ///// Implicit cast from an Int64 to EntityId Object
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator EntityId(Int64 x)
        //{
        //    EntityId retVal = new EntityId(x);

        //    return retVal;
        //}

        ///// <summary>
        ///// Implicit cast from EntityId Object to Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator Int64(EntityId x)
        //{
        //    Int64 retVal = x.TheEntityId;

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for EntityId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(EntityId x, Int64 y)
        //{
        //    Boolean retVal = (x.TheEntityId == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// == (equals) operator for EntityId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator ==(Int64 x, EntityId y)
        //{
        //    Boolean retVal = (y == x);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for EntityId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(EntityId x, Int64 y)
        //{
        //    Boolean retVal = !(x == y);

        //    return retVal;
        //}

        ///// <summary>
        ///// != (not equals) operator for EntityId Object with an Int64
        ///// </summary>
        ///// <param name="x">The x.</param>
        ///// <param name="y">The y.</param>
        ///// <returns>
        ///// The result of the operator.
        ///// </returns>
        //public static Boolean operator !=(Int64 x, EntityId y)
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

                if (objectType == typeof(EntityId))
                {
                    EntityId input = (EntityId)obj;
                    retVal = TheEntityId.Equals(input.TheEntityId);
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
            Int32 retVal = TheEntityId.GetHashCode();

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
            return TheEntityId.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.Int64" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Int64" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public Int64 ToInteger()
        {
            return TheEntityId;
        }

        /// <summary>
        /// Compares the supplied <see cref="EntityId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Boolean IEquatable<EntityId>.Equals(EntityId other)
        {
            Boolean retVal = Equals(other);

            return retVal;
        }

        /// <summary>
        /// Compares the supplied <see cref="EntityId"/> with the encapsulated value
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        Int32 IComparable<EntityId>.CompareTo(EntityId other)
        {
            Int32 retVal = TheEntityId.CompareTo(other.TheEntityId);

            return retVal;
        }

        /// <summary>
        /// Implements an Ascending Sort functionality for EntityIds
        /// </summary>
        public class SortAscending : IComparer<EntityId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied EntityIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(EntityId x, EntityId y)
            {
                Int32 retVal = x.TheEntityId.CompareTo(y.TheEntityId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied EntityIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, [NotNullWhen(true)] Object? y)
            {
                Int32 retVal = 0;
                if (x is EntityId entityIdX && y is EntityId entityIdY)
                {
                    retVal = Compare(entityIdX, entityIdY);
                }

                return retVal;
            }
        }

        /// <summary>
        /// Implements a Descending Sort functionality for EntityIds
        /// </summary>
        public class SortDescending : IComparer<EntityId>, IComparer
        {
            /// <summary>
            /// Compares the two supplied EntityIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare(EntityId x, EntityId y)
            {
                Int32 retVal = y.TheEntityId.CompareTo(x.TheEntityId);

                return retVal;
            }

            /// <summary>
            /// Compares the two supplied EntityIds for sorting
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Int32 Compare([NotNullWhen(true)] Object? x, [NotNullWhen(true)] Object? y)
            {
                Int32 retVal = 0;
                if (x is EntityId entityIdX && y is EntityId entityIdY)
                {
                    retVal = Compare(entityIdX, entityIdY);
                }

                return retVal;
            }
        }

        //public TypeCode GetTypeCode()
        //{
        //    return TypeCode.Int64;
        //}

        //public bool ToBoolean(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public byte ToByte(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public char ToChar(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public DateTime ToDateTime(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public decimal ToDecimal(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public double ToDouble(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public short ToInt16(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public int ToInt32(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public long ToInt64(IFormatProvider? provider)
        //{
        //    return TheEntityId;
        //}

        //public sbyte ToSByte(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public float ToSingle(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public string ToString(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public object ToType(Type conversionType, IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public ushort ToUInt16(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public uint ToUInt32(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public ulong ToUInt64(IFormatProvider? provider)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
