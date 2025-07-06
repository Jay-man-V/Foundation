////-----------------------------------------------------------------------
//// <copyright file="FieldInfoExtensionsMethods.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Reflection;

//namespace Foundation.Common
//{
//    /// <summary>
//    /// Defines extension methods for Fields
//    /// </summary>
//    public static class FieldInfoExtensionsMethods
//    {
//        /// <summary>
//        /// Gets the custom attributes.
//        /// </summary>
//        /// <param name="fieldInfo">The field information.</param>
//        /// <param name="theType">The type.</param>
//        /// <returns>Array of Attribute objects</returns>
//        public static Object[] GetCustomAttributes(FieldInfo fieldInfo, Type theType)
//        {
//            Object[] retVal = null;

//            retVal = fieldInfo.GetCustomAttributes(theType, false);

//            return retVal;
//        }
        
//        // <summary>
//        /// Descriptions the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <returns>The description</returns>
//        public static String Description(this FieldInfo val)
//        {
//            return Description(val, val.ToString());
//        }

//        /// <summary>
//        /// Descriptions the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <param name="defaultValue">The default value.</param>
//        /// <returns>The description</returns>
//        public static String Description(this FieldInfo val, String defaultValue)
//        {
//            String retVal = defaultValue;
//            DescriptionAttribute[] attributes = (DescriptionAttribute[])GetCustomAttributes(val, typeof(DescriptionAttribute));
//            if (attributes.Length > 0)
//            {
//                retVal = attributes[0].Description;
//            }

//            return retVal;
//        }

//        /// <summary>
//        /// Displays the format.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <returns>The display format</returns>
//        public static String DisplayFormat(this FieldInfo val)
//        {
//            return DisplayFormat(val, String.Empty);
//        }

//        /// <summary>
//        /// Displays the format.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <param name="defaultFormat">The default format.</param>
//        /// <returns>The display format</returns>
//        public static String DisplayFormat(this FieldInfo val, String defaultFormat)
//        {
//            String retVal = defaultFormat;
//            DisplayFormatAttribute[] attributes = (DisplayFormatAttribute[])GetCustomAttributes(val, typeof(DisplayFormatAttribute));
//            if (attributes.Length > 0)
//            {
//                retVal = attributes[0].DataFormatString;
//            }

//            return retVal;
//        }

//        /// <summary>
//        /// Defaults the value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <returns>The default value</returns>
//        public static Object DefaultValue(this FieldInfo val)
//        {
//            return DefaultValue(val, null);
//        }

//        /// <summary>
//        /// Defaults the value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <param name="defaultValue">The default value.</param>
//        /// <returns>The default value</returns>
//        public static Object DefaultValue(this FieldInfo val, Object defaultValue)
//        {
//            Object retVal = defaultValue;
//            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])GetCustomAttributes(val, typeof(DefaultValueAttribute));
//            if (attributes.Length > 0)
//            {
//                retVal = attributes[0].Value;
//            }

//            return retVal;
//        }

//        /// <summary>
//        /// Indexes the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <returns>The index</returns>
//        public static Int32 Index(this FieldInfo val)
//        {
//            return Index(val, 0);
//        }

//        /// <summary>
//        /// Indexes the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <param name="defaultValue">The default value.</param>
//        /// <returns>The index</returns>
//        public static Int32 Index(this FieldInfo val, Int32 defaultValue)
//        {
//            Int32 retVal = defaultValue;
//            IndexAttribute[] attributes = (IndexAttribute[])GetCustomAttributes(val, typeof(IndexAttribute));
//            if (attributes.Length > 0)
//            {
//                retVal = attributes[0].Index;
//            }

//            return retVal;
//        }

//        /// <summary>
//        /// Names the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <returns>The name</returns>
//        public static String Name(this FieldInfo val)
//        {
//            return Name(val, val.ToString());
//        }

//        /// <summary>
//        /// Names the specified value.
//        /// </summary>
//        /// <param name="val">The value.</param>
//        /// <param name="defaultValue">The default value.</param>
//        /// <returns>The name</returns>
//        public static String Name(this FieldInfo val, String defaultValue)
//        {
//            String retVal = defaultValue;
//            DisplayAttribute[] attributes = (DisplayAttribute[])GetCustomAttributes(val, typeof(DisplayAttribute));
//            if (attributes.Length > 0)
//            {
//                retVal = attributes[0].Name;
//            }

//            return retVal;
//        }
//    }
//}
