//-----------------------------------------------------------------------
// <copyright file="ResourceLoader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Foundation.Resources
{
    /// <summary>
    /// The Resource Loader
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// Gets the resource file as stream.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>
        ///   Stream representing the Resource File
        /// </returns>
        /// <exception cref="MissingManifestResourceException"></exception>
        public static Stream GetResourceFileAsStream(String resourceName)
        {
            Assembly targetAssembly = Assembly.GetExecutingAssembly();

#if(DEBUG)
            // Handy bit of debug code to list all the resource names in case there
            // is an issue trying to find/load a resource
            String[] resourceNames = targetAssembly.GetManifestResourceNames();
            resourceNames.ToList().ForEach(rn => Debug.WriteLine(rn));
#endif

            Stream? retVal = targetAssembly.GetManifestResourceStream(resourceName);

            if (retVal == null)
            {
                String resourceName2 = targetAssembly.GetName().Name + "." + resourceName;
                retVal = targetAssembly.GetManifestResourceStream(resourceName2);
            }

            if (retVal == null)
            {
                String errorMessage = $"Resource File '{resourceName}' does not exist in the Assembly '{targetAssembly.FullName}'";
                throw new MissingManifestResourceException(errorMessage);
            }

            return retVal;
        }

        /// <summary>
        /// Gets the resource file as text.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>
        ///   Content of the file
        /// </returns>
        public static String GetResourceFileAsText(String resourceName)
        {
            String retVal;
            using (Stream resourceStream = GetResourceFileAsStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    retVal = reader.ReadToEnd();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Gets the resource image.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>
        ///   The Image
        /// </returns>
        public static Image GetResourceImage(String resourceName)
        {
            Image retVal;

            Stream imageStream = GetResourceFileAsStream(resourceName);

            retVal = new Bitmap(imageStream);

            return retVal;
        }
    }
}
