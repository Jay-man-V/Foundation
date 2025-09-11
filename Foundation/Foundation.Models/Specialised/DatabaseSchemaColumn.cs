//-----------------------------------------------------------------------
// <copyright file="DbSchemaColumn.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns.Specialised;

namespace Foundation.Models.Specialised
{
    /// <summary>
    /// Db Schema Column class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IDatabaseSchemaColumn" />
    [DependencyInjectionTransient]
    [DebuggerDisplay("{TableName}.{ColumnName} ({DataType})")]
    public class DatabaseSchemaColumn : FoundationModel, IDatabaseSchemaColumn, IEquatable<IDatabaseSchemaColumn>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseSchemaColumn"/> class.
        /// </summary>
        public DatabaseSchemaColumn()
        {
            TableName = String.Empty;
            ColumnName = String.Empty;
            DataType = typeof(Object);
        }

        /// <inheritdoc cref="IDatabaseSchemaColumn.TableName"/>
        [Column(nameof(FDC.DatabaseSchemaColumn.TableName))]
        public String TableName { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaColumn.ColumnName"/>
        [Column(nameof(FDC.DatabaseSchemaColumn.ColumnName))]
        public String ColumnName { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaColumn.DataType"/>
        [Column(nameof(FDC.DatabaseSchemaColumn.DataType))]
        public Type DataType { get; set; }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(TableName): retVal = TableName; break;
                case nameof(ColumnName): retVal = ColumnName; break;
                case nameof(DataType): retVal = DataType; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            DatabaseSchemaColumn retVal = (DatabaseSchemaColumn)base.Clone();

            retVal.TableName = this.TableName;
            retVal.ColumnName = this.ColumnName;
            retVal.DataType = this.DataType;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IDatabaseSchemaColumn? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is DatabaseSchemaColumn dbSchemaColumn)
            {
                retVal = InternalEquals(dbSchemaColumn);
            }
            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TableName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ColumnName);
            hashCode = hashCode * constant + EqualityComparer<Type>.Default.GetHashCode(DataType);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IDatabaseSchemaColumn? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.TableName, right.TableName);
                retVal &= EqualityComparer<String>.Default.Equals(this.ColumnName, right.ColumnName);
                retVal &= EqualityComparer<Type>.Default.Equals(this.DataType, right.DataType);
            }

            return retVal;
        }
    }
}
