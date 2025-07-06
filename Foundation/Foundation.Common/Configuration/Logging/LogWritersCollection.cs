//-----------------------------------------------------------------------
// <copyright file="LogWritersCollection.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the LogWriter
    /// </summary>
    /// <seealso cref="ConfigurationElementCollection" />
    public class LogWriterCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets the <see cref="LogWriterElement"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="LogWriterElement"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public LogWriterElement this[int index] => (LogWriterElement)BaseGet(index);
        //set
        //{
        //    if (BaseGet(index).IsNotNull())
        //    {
        //        BaseRemoveAt(index);
        //    }
        //    BaseAdd(index, value);
        //}
        //public void Add(LogWriterElement logWriter)
        //{
        //    BaseAdd(logWriter);
        //}

        //public void Clear()
        //{
        //    BaseClear();
        //}

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:ConfigurationElement" />.
        /// </summary>
        /// <returns>
        /// A newly created <see cref="T:ConfigurationElement" />.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new LogWriterElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:ConfigurationElement" /> to return the key for.</param>
        /// <returns>
        /// An <see cref="T:Object" /> that acts as the key for the specified <see cref="T:ConfigurationElement" />.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LogWriterElement)element).Key;
        }

        //public void Remove(LogWriterElement logWriter)
        //{
        //    BaseRemove(logWriter.Key);
        //}

        //public void RemoveAt(int index)
        //{
        //    BaseRemoveAt(index);
        //}

        //public void Remove(string name)
        //{
        //    BaseRemove(name);
        //}
    }
}
