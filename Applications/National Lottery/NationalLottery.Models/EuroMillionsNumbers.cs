//-----------------------------------------------------------------------
// <copyright file="EuroMillionsNumbers.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using NationalLottery.Interfaces;

using NLDC = NationalLottery.Common.DataColumns;

namespace NationalLottery.Models
{
    /// <summary>
    /// Euro Millions Numbers model
    /// </summary>
    /// <seealso cref="NationalLotteryModel" />
    /// <seealso cref="IEuroMillionsNumbers" />
    [DependencyInjectionTransient]
    public class EuroMillionsNumbers : NationalLotteryModel, IEuroMillionsNumbers
    {
        private DateTime _drawDate;
        private Int32 _ball1;
        private Int32 _ball2;
        private Int32 _ball3;
        private Int32 _ball4;
        private Int32 _ball5;
        private Int32 _luckyStar1;
        private Int32 _luckyStar2;
        private Decimal _jackpot;

        /// <inheritdoc cref="IEuroMillionsNumbers.DrawDate"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.DrawDate))]
        public DateTime DrawDate
        {
            get => this._drawDate;
            set => this.SetPropertyValue(ref _drawDate, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Ball1"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.Ball1))]
        public Int32 Ball1
        {
            get => this._ball1;
            set => this.SetPropertyValue(ref _ball1, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Ball2"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.Ball2))]
        public Int32 Ball2
        {
            get => this._ball2;
            set => this.SetPropertyValue(ref _ball2, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Ball3"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.Ball3))]
        public Int32 Ball3
        {
            get => this._ball3;
            set => this.SetPropertyValue(ref _ball3, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Ball4"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.Ball4))]
        public Int32 Ball4
        {
            get => this._ball4;
            set => this.SetPropertyValue(ref _ball4, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Ball5"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.Ball5))]
        public Int32 Ball5
        {
            get => this._ball5;
            set => this.SetPropertyValue(ref _ball5, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.LuckyStar1"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.LuckyStar1))]
        public Int32 LuckyStar1
        {
            get => this._luckyStar1;
            set => this.SetPropertyValue(ref _luckyStar1, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.LuckyStar2"/>
        [Column(nameof(NLDC.EuroMillionsNumbers.LuckyStar2))]
        public Int32 LuckyStar2
        {
            get => this._luckyStar2;
            set => this.SetPropertyValue(ref _luckyStar2, value);
        }

        /// <inheritdoc cref="IEuroMillionsNumbers.Jackpot"/>
        [NotMapped]
        public Decimal Jackpot
        {
            get => this._jackpot;
            set => this.SetPropertyValue(ref _jackpot, value);
        }

        /// <inheritdoc cref="ICloneable.Clone"/>
        public override Object Clone()
        {
            EuroMillionsNumbers retVal = base.Clone() as EuroMillionsNumbers;
            retVal.Initialising = true;

            retVal._drawDate = this._drawDate;
            retVal._ball1 = this._ball1;
            retVal._ball2 = this._ball2;
            retVal._ball3 = this._ball3;
            retVal._ball4 = this._ball4;
            retVal._ball5 = this._ball5;
            retVal._luckyStar1 = this._luckyStar1;
            retVal._luckyStar2 = this._luckyStar2;
            retVal._jackpot = this._jackpot;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is EuroMillionsNumbers euroMillionsNumbers)
            {
                retVal = InternalEquals(this, euroMillionsNumbers);
            }

            return retVal;
        }

        /// <summary>
        /// Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public Boolean Equals(EuroMillionsNumbers other)
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
            Int32 hashCode = 746720419;
            Int32 constant = -1521134295;

            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(_drawDate);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball1);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball2);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball3);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball4);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(_ball5);
            hashCode = hashCode * constant + EqualityComparer<Decimal>.Default.GetHashCode(_jackpot);

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
        public static Boolean operator ==(EuroMillionsNumbers left, EuroMillionsNumbers right)
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
        public static Boolean operator !=(EuroMillionsNumbers left, EuroMillionsNumbers right)
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
        private static Boolean InternalEquals(EuroMillionsNumbers left, EuroMillionsNumbers right)
        {
            Boolean retVal = true;

            retVal &= left._drawDate == right._drawDate;
            retVal &= left._ball1 == right._ball1;
            retVal &= left._ball2 == right._ball2;
            retVal &= left._ball3 == right._ball3;
            retVal &= left._ball4 == right._ball4;
            retVal &= left._ball5 == right._ball5;
            retVal &= left._jackpot == right._jackpot;

            return retVal;
        }
    }
}
