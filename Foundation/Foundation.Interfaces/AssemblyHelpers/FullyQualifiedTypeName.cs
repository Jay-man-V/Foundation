//-----------------------------------------------------------------------
// <copyright file="FullyQualifiedTypeName.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Fully Qualified Type Name
    /// </summary>
    public class FullyQualifiedTypeName
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FullyQualifiedTypeName"/> class.
        /// </summary>
        public FullyQualifiedTypeName() 
        {
            Value = String.Empty;
            AssemblyName = String.Empty;
            TypeName = String.Empty;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="FullyQualifiedTypeName"/> class.
        /// </summary>
        /// <param name="xmlTypeName">Name of the XML type.</param>
        public FullyQualifiedTypeName(String xmlTypeName)
        {
            Value = xmlTypeName;

            XmlDocument xmlDocument = new();
            xmlDocument.LoadXml(Value);

            AssemblyName = xmlDocument?.DocumentElement?.GetAttribute("assembly") ?? "Unknown assembly attribute";
            TypeName = xmlDocument?.DocumentElement?.GetAttribute("type") ?? "Unknown type attribute";
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private String Value { get; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>
        /// The name of the assembly.
        /// </value>
        public String AssemblyName { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public String TypeName { get; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            return Value;
        }

        /// <summary>
        /// Implicit cast from String to FullyQualifiedTypeName Object
        /// </summary>
        /// <param name="fullyQualifiedTypeName">The fullyQualifiedTypeName.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator FullyQualifiedTypeName(String fullyQualifiedTypeName)
        {
            return new(fullyQualifiedTypeName);
        }

        /// <summary>
        /// Implicit cast from EmailAddress Object to String
        /// </summary>
        /// <param name="fullyQualifiedTypeName">The fullyQualifiedTypeName.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator String(FullyQualifiedTypeName fullyQualifiedTypeName)
        {
            String retVal = String.Empty;

            Object o = fullyQualifiedTypeName;

            if (o != null)
            {
                retVal = fullyQualifiedTypeName.Value;
            }

            return retVal;
        }
    }
}
