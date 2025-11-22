//-----------------------------------------------------------------------
// <copyright file="ActiveDirectoryUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Active Directory User data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ActiveDirectoryUser : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public class User
        {
            //public class Lengths
            //{
            //    public const Int32 ObjectSid = 25;
            //    public const Int32 Name = 150;
            //    public const Int32 FullName = 150;
            //}

            /// <summary>
            /// Gets the schema class user.
            /// </summary>
            /// <value>
            /// The schema class user.
            /// </value>
            public static String SchemaClass_User => "User";

            /// <summary>
            /// Gets the user flags.
            /// </summary>
            /// <value>
            /// The user flags.
            /// </value>
            public static String UserFlags => "UserFlags";

            /// <summary>
            /// Gets the object sid.
            /// </summary>
            /// <value>
            /// The object sid.
            /// </value>
            public static String objectSid => "objectSid";

            /// <summary>
            /// Gets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public static String Name => "Name";

            /// <summary>
            /// Gets the full name.
            /// </summary>
            /// <value>
            /// The full name.
            /// </value>
            public static String FullName => "FullName";
        }

        /// <summary>
        /// 
        /// </summary>
        public class Lengths
        {

            /// <summary>
            /// The object sid
            /// </summary>
            public const Int32 ObjectSid = 100;

            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 100;

            /// <summary>
            /// The full name
            /// </summary>
            public const Int32 FullName = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "ActiveDirectoryUser";

        /// <summary>
        /// Gets the object s identifier.
        /// </summary>
        /// <value>
        /// The object s identifier.
        /// </value>
        public static String ObjectSId => "ObjectSId";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static String FullName => "FullName";
    }
}
