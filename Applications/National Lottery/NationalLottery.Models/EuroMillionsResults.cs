//-----------------------------------------------------------------------
// <copyright file="EuroMillionsResults.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using NationalLottery.Interfaces;

using System;

namespace NationalLottery.Models
{
    /// <summary>
    /// Euro Millions Results model
    /// </summary>
    /// <seealso cref="NationalLotteryModel" />
    /// <seealso cref="IEuroMillionsResults" />
    [DependencyInjectionTransient]
    public class EuroMillionsResults : NationalLotteryModel, IEuroMillionsResults
    {
        /// <inheritdoc cref="ICloneable.Clone"/>
        public override Object Clone()
        {
            EuroMillionsResults retVal = base.Clone() as EuroMillionsResults;
            retVal.Initialising = true;

            //retVal._drawDate = this._drawDate;
            //retVal._ball1 = this._ball1;
            //retVal._ball2 = this._ball2;
            //retVal._ball3 = this._ball3;
            //retVal._ball4 = this._ball4;
            //retVal._ball5 = this._ball5;
            //retVal._luckyStar1 = this._luckyStar1;
            //retVal._luckyStar2 = this._luckyStar2;
            //retVal._jackpot = this._jackpot;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is EuroMillionsResults euroMillionsResults)
            {
                retVal = InternalEquals(this, euroMillionsResults);
            }

            return retVal;
        }

        /// <summary>
        /// Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public Boolean Equals(EuroMillionsResults other)
        {
            Boolean retVal = false;

            if (other.IsNotNull())
            {
                retVal = InternalEquals(this, other);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            const Int32 hashCode = 746720419;
            //const Int32 constant = -1521134295;

            //hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(_drawDate);
            //hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball1);
            //hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball2);
            //hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball3);
            //hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball4);
            //hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball5);
            //hashCode = hashCode * constant + EqualityComparer<Decimal>.Default.GetHashCode(_jackpot);

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
        public static Boolean operator ==(EuroMillionsResults left, EuroMillionsResults right)
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
        public static Boolean operator !=(EuroMillionsResults left, EuroMillionsResults right)
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
        private static Boolean InternalEquals(EuroMillionsResults left, EuroMillionsResults right)
        {
            Boolean retVal = true;

            //retVal &= left._drawDate == right._drawDate;
            //retVal &= left._ball1 == right._ball1;
            //retVal &= left._ball2 == right._ball2;
            //retVal &= left._ball3 == right._ball3;
            //retVal &= left._ball4 == right._ball4;
            //retVal &= left._ball5 == right._ball5;
            //retVal &= left._jackpot == right._jackpot;

            return retVal;
        }
    }
}
