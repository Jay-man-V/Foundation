//-----------------------------------------------------------------------
// <copyright file="DeploymentItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

namespace Foundation.Tests.Unit.Support
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public class DeploymentItem : Attribute
    {
        public DeploymentItem(String fileProjectRelativePath, String p2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Marks an item to be relevant for a unit-test and copies it to deployment-directory for this unit-test.
        /// </summary>
        /// <param name="fileProjectRelativePath">The project-relative path to a file or a folder that will be copied into the deployment-directory of this unit-test.</param>
        public DeploymentItem(String fileProjectRelativePath)
        {
            // Escape input-path to correct back-slashes for Windows
            String filePath = fileProjectRelativePath.Replace("/", "\\");

            // Look up, where we are right now
            DirectoryInfo environmentDir = new DirectoryInfo(Environment.CurrentDirectory);

            DirectoryInfo? parent1 = environmentDir.Parent;
            if (parent1 == null)
            {
                String message = $"Cannot get parent directory of '{environmentDir.FullName}'";
                throw new DirectoryNotFoundException(message);
            }

            DirectoryInfo? parent2 = Directory.GetParent(parent1.FullName);
            if (parent2 == null)
            {
                String message = $"Cannot get parent directory of '{parent1.FullName}'";
                throw new DirectoryNotFoundException(message);
            }

            // Get the full item-path of the deployment item
            String itemPath = new Uri(Path.Combine(parent2.FullName, filePath)).LocalPath;

            // Get the target-path where to copy the deployment item to
            String? binFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (binFolderPath == null)
            {
                String message = $"Cannot get '{binFolderPath}'";
                throw new DirectoryNotFoundException(message);
            }

            // Assemble the target path
            String itemPathInBin = new Uri(Path.Combine(binFolderPath, filePath)).LocalPath;

            // Decide whether it's a file or a folder
            if (File.Exists(itemPath)) // It's a file
            {
                // If it already exists, remove it
                if (File.Exists(itemPathInBin))
                {
                    File.Delete(itemPathInBin);
                }

                // Assemble the parent folder path (because the item might be in multiple sub-folders.)
                DirectoryInfo parentFolder = new DirectoryInfo(itemPathInBin);
                if (parentFolder.Parent == null)
                {
                    String message = $"Cannot get '{itemPathInBin}'";
                    throw new DirectoryNotFoundException(message);
                }

                String parentFolderPathInBin = parentFolder.Parent.FullName;

                // If the target directory does not exist, create it
                if (!Directory.Exists(parentFolderPathInBin))
                {
                    Directory.CreateDirectory(parentFolderPathInBin);
                }

                // If the source-file exists, copy it to the destination
                if (File.Exists(itemPath))
                {
                    File.Copy(itemPath, itemPathInBin);
                }
            }
            else if (Directory.Exists(itemPath)) // It's a folder
            {
                // If it already exists, remove it
                if (Directory.Exists(itemPathInBin))
                {
                    Directory.Delete(itemPathInBin, true);
                }

                // If the source-directory exists, copy it to the destination
                if (Directory.Exists(itemPath))
                {
                    // Create target directory
                    Directory.CreateDirectory(itemPathInBin);

                    // Now Create all the subdirectories
                    foreach (String dirPath in Directory.GetDirectories(itemPath, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(itemPath, itemPathInBin));
                    }

                    //Copy all the files & Replaces any files with the same name
                    foreach (String newPath in Directory.GetFiles(itemPath, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace(itemPath, itemPathInBin), true);
                    }
                }
            }
        }
    }
}
