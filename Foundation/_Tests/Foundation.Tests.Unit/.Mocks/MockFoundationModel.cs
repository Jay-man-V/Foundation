//-----------------------------------------------------------------------
// <copyright file="MockFoundationModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

using Foundation.Interfaces;

using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Mocks
{
    public interface IMockFoundationModel : IFoundationModel
    {
        Boolean IsOpen { get; set; }
        Boolean IsClosed { get; set; }
        Decimal UnitPrice { get; set; }
        Decimal Quantity { get; set; }
        Int32 Count { get; set; }
        String Name { get; set; }
        String Code { get; set; }
        String Description { get; set; }
        Image? ImagePicture { get; set; }
        TimeSpan Duration { get; set; }
        DateTime ExecutionTime { get; set; }
    }

    [DependencyInjectionTransient]
    public class MockFoundationModel : FModels.FoundationModel, IMockFoundationModel
    {
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 10;

            /// <summary>
            /// The code
            /// </summary>
            public const Int32 Code = 10;
        }

        private Boolean _isOpen;
        private Boolean _isClosed;
        private Decimal _unitPrice;
        private Decimal _quantity;
        private Int32 _count;
        private String _name = String.Empty;
        private String _code = String.Empty;
        private String _description = String.Empty;
        private Image? _imagePicture;
        private TimeSpan _duration;
        private DateTime _executionTime;

        public MockFoundationModel(IDateTimeService dateTimeService)
        {
            ValidFrom = dateTimeService.SystemDateTimeNow;
            ValidTo = new DateTime(2100, 12, 31, 23, 59, 59);
        }

        public MockFoundationModel(Int32 id) : this()
        {
            Id = new EntityId(id);
        }

        public MockFoundationModel()
        {
            ValidFrom = DateTime.Now;
            ValidTo = new DateTime(2100, 12, 31, 23, 59, 59);
        }

        [Column("IsOpen")]
        public Boolean IsOpen
        {
            get => this._isOpen;
            set => this.SetPropertyValue(ref _isOpen, value);
        }

        [Column("IsClosed")]
        public Boolean IsClosed
        {
            get => this._isClosed;
            set => this.SetPropertyValue(ref _isClosed, value);
        }

        [Column("UnitPrice")]
        public Decimal UnitPrice
        {
            get => this._unitPrice;
            set => this.SetPropertyValue(ref _unitPrice, value);
        }

        [Column("Quantity")]
        public Decimal Quantity
        {
            get => this._quantity;
            set => this.SetPropertyValue(ref _quantity, value);
        }

        [Column("Count")]
        public Int32 Count
        {
            get => this._count;
            set => this.SetPropertyValue(ref _count, value);
        }

        [Column("Name"), MaxLength(Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be supplied")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, Lengths.Name);
        }

        [Column("Code"), MaxLength(Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(Code) + " must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, Lengths.Code);
        }

        [Column("Description")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, -1);
        }

        [Column("ImagePicture")]
        public Image? ImagePicture
        {
            get => _imagePicture;
            set => this.SetPropertyValue(ref _imagePicture, value);
        }

        [Column("Duration")]
        public TimeSpan Duration
        {
            get => _duration;
            set => this.SetPropertyValue(ref _duration, value);
        }

        [Column("ExecutionTime")]
        public DateTime ExecutionTime
        {
            get => _executionTime;
            set => this.SetPropertyValue(ref _executionTime, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)" />
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(IsOpen): retVal = IsOpen; break;
                case nameof(IsClosed) : retVal = IsClosed; break;
                case nameof(UnitPrice) : retVal = UnitPrice; break;
                case nameof(Quantity) : retVal = Quantity; break;
                case nameof(Count) : retVal = Count; break;
                case nameof(Name) : retVal = Name; break;
                case nameof(Code) : retVal = Code; break;
                case nameof(Description) : retVal = Description; break;
                case nameof(ImagePicture) : retVal = ImagePicture; break;
                case nameof(Duration) : retVal = Duration; break;
                case nameof(ExecutionTime) : retVal = ExecutionTime; break;
            }

            return retVal;
        }

        public override Object Clone()
        {
            MockFoundationModel retVal = (MockFoundationModel)base.Clone();

            retVal._name = _name;
            retVal._code = _code;
            retVal._description = _description;

            if (_imagePicture != null)
            {
                retVal._imagePicture = _imagePicture.Clone() as Image;
            }

            retVal._duration = _duration;


            return retVal;
        }
    }
}
