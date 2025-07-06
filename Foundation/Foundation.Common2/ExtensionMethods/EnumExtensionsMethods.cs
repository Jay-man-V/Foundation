//-----------------------------------------------------------------------
// <copyright file="EnumExtensionsMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="Enum"/> type
    /// </summary>
    public static class EnumExtensionsMethods
    {
        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <param name="theEnum">The enumeration.</param>
        /// <returns>Returns the <see cref="FieldInfo"/> object</returns>
        public static FieldInfo GetField(Enum theEnum)
        {
            FieldInfo retVal;

            Type theType = theEnum.GetType();

            retVal = theType.GetField(theEnum.ToString());

            return retVal;
        }

        /// <summary>
        /// Gets the custom attributes.
        /// </summary>
        /// <param name="theEnum">The enumeration.</param>
        /// <param name="theType">The type.</param>
        /// <returns>Array of Attribute objects</returns>
        public static Object[] GetCustomAttributes(Enum theEnum, Type theType)
        {
            Object[] retVal;

            FieldInfo fieldInfo = GetField(theEnum);

            retVal = fieldInfo.GetCustomAttributes(theType, false);

            return retVal;
        }


        /// <summary>
        /// Returns the Display Order, if it is not set default value of 0 is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The description</returns>
        public static Int32 DisplayOrder(this Enum val)
        {
            return DisplayOrder(val, 0);
        }

        /// <summary>
        /// Returns the Display Order, if it is not set <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The description</returns>
        public static Int32 DisplayOrder(this Enum val, Int32 defaultValue)
        {
            Int32 retVal = defaultValue;
            DisplayAttribute[] attributes = (DisplayAttribute[])GetCustomAttributes(val, typeof(DisplayAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Order;
            }

            return retVal;
        }

        /// <summary>
        /// Returns the Display Name.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The description</returns>
        public static String DisplayName(this Enum val)
        {
            return DisplayName(val, val.ToString());
        }

        /// <summary>
        /// Returns the Display Name, if it is not set <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The description</returns>
        public static String DisplayName(this Enum val, String defaultValue)
        {
            String retVal = defaultValue;
            DisplayAttribute[] attributes = (DisplayAttribute[])GetCustomAttributes(val, typeof(DisplayAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Name;
            }

            return retVal;
        }

        /// <summary>
        /// Returns the Description.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The description</returns>
        public static String Description(this Enum val)
        {
            return Description(val, val.ToString());
        }

        /// <summary>
        /// Returns the Description, if it is not set <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The description</returns>
        public static String Description(this Enum val, String defaultValue)
        {
            String retVal = defaultValue;
            DescriptionAttribute[] attributes = (DescriptionAttribute[])GetCustomAttributes(val, typeof(DescriptionAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Description;
            }
            
            return retVal;
        }

        /// <summary>
        /// Returns the Display DotNetFormat.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The display format</returns>
        public static String DisplayFormat(this Enum val)
        {
            return DisplayFormat(val, String.Empty);
        }

        /// <summary>
        /// Returns the Display DotNetFormat, if it is not set <paramref name="defaultFormat"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultFormat">The default format.</param>
        /// <returns>The display format</returns>
        public static String DisplayFormat(this Enum val, String defaultFormat)
        {
            String retVal = defaultFormat;
            DisplayFormatAttribute[] attributes = (DisplayFormatAttribute[])GetCustomAttributes(val, typeof(DisplayFormatAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].DataFormatString;
            }
            
            return retVal;
        }

        /// <summary>
        /// Returns the Default Value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The default value</returns>
        public static Object DefaultValue(this Enum val)
        {
            return DefaultValue(val, null);
        }

        /// <summary>
        /// Returns the Default Value, if it is not set <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The default value</returns>
        public static Object DefaultValue(this Enum val, Object defaultValue)
        {
            Object retVal = defaultValue;
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])GetCustomAttributes(val, typeof(DefaultValueAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Value;
            }
            
            return retVal;
        }

        /// <summary>
        /// Returns the Id.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The index</returns>
        public static Int32 Id(this Enum val)
        {
            Int32 retVal = -1;
            IdAttribute[] attributes = (IdAttribute[])GetCustomAttributes(val, typeof(IdAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Id;
            }

            return retVal;
        }

        /// <summary>
        /// Returns the Index.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>The index</returns>
        public static Int32 Index(this Enum val)
        {
            return Index(val, 0);
        }

        /// <summary>
        /// Returns the Index, if it is not set <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The index</returns>
        public static Int32 Index(this Enum val, Int32 defaultValue)
        {
            Int32 retVal = defaultValue;
            IndexAttribute[] attributes = (IndexAttribute[])GetCustomAttributes(val, typeof(IndexAttribute));
            if (attributes.Length > 0)
            {
                retVal = attributes[0].Index;
            }

            return retVal;
        }
    }
}
