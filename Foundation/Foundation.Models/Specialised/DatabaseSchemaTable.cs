//-----------------------------------------------------------------------
// <copyright file="DbSchemaTable.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns.Specialised;

namespace Foundation.Models.Specialised
{
    /// <summary>
    /// Db Schema Table class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IDatabaseSchemaTable" />
    [DependencyInjectionTransient]
    [DebuggerDisplay("{TableCatalog}.{TableSchema}.{TableName}")]
    public class DatabaseSchemaTable : FoundationModel, IDatabaseSchemaTable, IEquatable<IDatabaseSchemaTable>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseSchemaTable"/> class.
        /// </summary>
        public DatabaseSchemaTable()
        {
            TableCatalog = String.Empty;
            TableSchema = String.Empty;
            TableName = String.Empty;
            TableType = String.Empty;

            SchemaColumns = new List<IDatabaseSchemaColumn>();
        }

        /// <inheritdoc cref="IDatabaseSchemaTable.TableCatalog"/>
        [Column(nameof(FDC.DatabaseSchemaTable.TableCatalog))]
        public String TableCatalog { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaTable.TableSchema"/>
        [Column(nameof(FDC.DatabaseSchemaTable.TableSchema))]
        public String TableSchema { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaTable.TableName"/>
        [Column(nameof(FDC.DatabaseSchemaTable.TableName))]
        public String TableName { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaTable.TableType"/>
        [Column(nameof(FDC.DatabaseSchemaTable.TableType))]
        public String TableType { get; set; }

        /// <inheritdoc cref="IDatabaseSchemaTable.SchemaColumns"/>
        [NotMapped]
        public IList<IDatabaseSchemaColumn> SchemaColumns { get; private set; }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(TableCatalog): retVal = TableCatalog; break;
                case nameof(TableSchema): retVal = TableSchema; break;
                case nameof(TableName): retVal = TableName; break;
                case nameof(TableType): retVal = TableType; break;
                case nameof(SchemaColumns): retVal = SchemaColumns; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            DatabaseSchemaTable retVal = (DatabaseSchemaTable)base.Clone();

            retVal.TableCatalog = this.TableCatalog;
            retVal.TableSchema = this.TableSchema;
            retVal.TableName = this.TableName;
            retVal.TableType = this.TableType;

            retVal.SchemaColumns = this.SchemaColumns.Clone();

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IDatabaseSchemaTable? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is DatabaseSchemaTable dbSchemaTable)
            {
                retVal = InternalEquals(dbSchemaTable);
            }
            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TableCatalog);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TableSchema);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TableName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TableType);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IDatabaseSchemaTable? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.TableCatalog, right.TableCatalog);
                retVal &= EqualityComparer<String>.Default.Equals(this.TableSchema, right.TableSchema);
                retVal &= EqualityComparer<String>.Default.Equals(this.TableName, right.TableName);
                retVal &= EqualityComparer<String>.Default.Equals(this.TableType, right.TableType);
            }

            return retVal;
        }
    }
}
