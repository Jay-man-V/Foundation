//-----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// MenuItem class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IMenuItem" />
    /// <seealso cref="IEquatable{MenuItem}" />
    [DependencyInjectionTransient]
    public class MenuItem : FoundationModel, IMenuItem, IEquatable<IMenuItem>
    {
        private AppId _applicationId;
        private EntityId _parentMenuitemId;
        private String _name = String.Empty;
        private String _caption = String.Empty;
        private String _controllerAssembly = String.Empty;
        private String _controllerType = String.Empty;
        private String _viewAssembly = String.Empty;
        private String _viewType = String.Empty;
        private String _helpText = String.Empty;
        private Boolean _multiInstance;
        private Boolean _showInTa;
        private Byte[]? _icon;
        private Int32 _depth;

        /// <inheritdoc cref="IMenuItem.ApplicationId"/>
        [Column(nameof(FDC.MenuItem.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IMenuItem.ParentMenuItemId"/>
        [Column(nameof(FDC.MenuItem.ParentMenuItemId))]
        [RequiredEntityId(EntityName = "Parent Menu Item")]
        public EntityId ParentMenuItemId
        {
            get => this._parentMenuitemId;
            set => this.SetPropertyValue(ref _parentMenuitemId, value);
        }

        /// <inheritdoc cref="IMenuItem.Name"/>
        [Column(nameof(FDC.MenuItem.Name))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(Name) + " must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value);
        }

        /// <inheritdoc cref="IMenuItem.Caption"/>
        [Column(nameof(FDC.MenuItem.Caption))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(Caption) + " must be provided")]
        public String Caption
        {
            get => this._caption;
            set => this.SetPropertyValue(ref _caption, value);
        }

        /// <inheritdoc cref="IMenuItem.ControllerAssembly"/>
        [Column(nameof(FDC.MenuItem.ControllerAssembly))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(ControllerAssembly) + " must be provided")]
        public String ControllerAssembly
        {
            get => this._controllerAssembly;
            set => this.SetPropertyValue(ref _controllerAssembly, value);
        }

        /// <inheritdoc cref="IMenuItem.ControllerType"/>
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(ControllerType) + " must be provided")]
        [Column(nameof(FDC.MenuItem.ControllerType))]
        public String ControllerType
        {
            get => this._controllerType;
            set => this.SetPropertyValue(ref _controllerType, value);
        }

        /// <inheritdoc cref="IMenuItem.ViewAssembly"/>
        [Column(nameof(FDC.MenuItem.ViewAssembly))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(ViewAssembly) + " must be provided")]
        public String ViewAssembly
        {
            get => this._viewAssembly;
            set => this.SetPropertyValue(ref _viewAssembly, value);
        }

        /// <inheritdoc cref="IMenuItem.ViewType"/>
        [Column(nameof(FDC.MenuItem.ViewType))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(ViewType) + " must be provided")]
        public String ViewType
        {
            get => this._viewType;
            set => this.SetPropertyValue(ref _viewType, value);
        }

        /// <inheritdoc cref="IMenuItem.HelpText"/>
        [Column(nameof(FDC.MenuItem.HelpText))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(HelpText) + " must be provided")]
        public String HelpText
        {
            get => this._helpText;
            set => this.SetPropertyValue(ref _helpText, value);
        }

        /// <inheritdoc cref="IMenuItem.MultiInstance"/>
        [Column(nameof(FDC.MenuItem.MultiInstance))]
        public Boolean MultiInstance
        {
            get => this._multiInstance;
            set => this.SetPropertyValue(ref _multiInstance, value);
        }

        /// <inheritdoc cref="IMenuItem.ShowInTab"/>
        [Column(nameof(FDC.MenuItem.ShowInTab))]
        public Boolean ShowInTab
        {
            get => this._showInTa;
            set => this.SetPropertyValue(ref _showInTa, value);
        }

        /// <inheritdoc cref="IMenuItem.Icon"/>
        [Column(nameof(FDC.MenuItem.Icon))]
        public Byte[]? Icon
        {
            get => this._icon;
            set => this.SetPropertyValue(ref _icon, value);
        }

        /// <inheritdoc cref="IMenuItem.Depth"/>
        [Column(nameof(FDC.MenuItem.Depth))]
        [ReadOnly(true)]
        public Int32 Depth
        {
            get => this._depth;
            set => this.SetPropertyValue(ref _depth, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(ParentMenuItemId): retVal = ParentMenuItemId; break;
                case nameof(Name): retVal = Name; break;
                case nameof(Caption): retVal = Caption; break;
                case nameof(ControllerAssembly): retVal = ControllerAssembly; break;
                case nameof(ControllerType): retVal = ControllerType; break;
                case nameof(ViewAssembly): retVal = ViewAssembly; break;
                case nameof(ViewType): retVal = ViewType; break;
                case nameof(HelpText): retVal = HelpText; break;
                case nameof(MultiInstance): retVal = MultiInstance; break;
                case nameof(ShowInTab): retVal = ShowInTab; break;
                case nameof(Icon): retVal = Icon; break;
                case nameof(Depth): retVal = Depth; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            MenuItem retVal = (MenuItem)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._parentMenuitemId = this._parentMenuitemId;
            retVal._name = this._name;
            retVal._caption = this._caption;
            retVal._controllerAssembly = this._controllerAssembly;
            retVal._controllerType = this._controllerType;
            retVal._viewAssembly = this._viewAssembly;
            retVal._viewType = this._viewType;
            retVal._helpText = this._helpText;
            retVal._multiInstance = this._multiInstance;
            retVal._showInTa = this._showInTa;
            retVal._icon = this._icon;
            retVal._depth = this._depth;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IMenuItem? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is MenuItem menuItem)
            {
                retVal = InternalEquals(this, menuItem);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ParentMenuItemId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Caption);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ControllerAssembly);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ControllerType);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ViewAssembly);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ViewType);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(HelpText);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(MultiInstance);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(ShowInTab);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(Depth);

            if (Icon != null)
            {
                hashCode = hashCode * constant + StructuralComparisons.StructuralEqualityComparer.GetHashCode(Icon);
            }

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IMenuItem? left, IMenuItem? right)
        {
            Boolean retVal;

            if (left == null && right == null)
            {
                retVal = true;
            }
            else if (left == null || right == null)
            {
                retVal = false;
            }
            else
            {
                retVal = FoundationModel.InternalEquals(left, right);

                retVal &= EqualityComparer<AppId>.Default.Equals(left.ApplicationId, right.ApplicationId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ParentMenuItemId, right.ParentMenuItemId);
                retVal &= EqualityComparer<String>.Default.Equals(left.Name, right.Name);
                retVal &= EqualityComparer<String>.Default.Equals(left.Caption, right.Caption);
                retVal &= EqualityComparer<String>.Default.Equals(left.ControllerAssembly, right.ControllerAssembly);
                retVal &= EqualityComparer<String>.Default.Equals(left.ControllerType, right.ControllerType);
                retVal &= EqualityComparer<String>.Default.Equals(left.ViewAssembly, right.ViewAssembly);
                retVal &= EqualityComparer<String>.Default.Equals(left.ViewType, right.ViewType);
                retVal &= EqualityComparer<String>.Default.Equals(left.HelpText, right.HelpText);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.MultiInstance, right.MultiInstance);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.ShowInTab, right.ShowInTab);
                retVal &= EqualityComparer<Int32>.Default.Equals(left.Depth, right.Depth);
                retVal &= StructuralComparisons.StructuralEqualityComparer.Equals(left.Icon, left.Icon);
            }

            return retVal;
        }
    }
}
