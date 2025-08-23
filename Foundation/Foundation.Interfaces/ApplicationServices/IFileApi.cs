//-----------------------------------------------------------------------
// <copyright file="IFileApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Reflection;
using System.Text;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the File Api
    /// </summary>
    public interface IFileApi : IRemoteServiceApi
    {
        /// <summary>
        /// Retrieves the UserDataPath from configuration
        /// </summary>
        String UserDataPath { get; }

        /// <summary>
        /// Retrieves the SystemDataPath from the configuration
        /// </summary>
        String SystemDataPath { get; }

        /// <summary>
        /// Combines the <paramref name="baseFolder"/> and the <paramref name="targetFolder"/> to make a valid folder path.
        /// Function will ensure a trailing '\' is added to the returned value
        /// </summary>
        /// <param name="baseFolder">The base folder</param>
        /// <param name="targetFolder">The target folder</param>
        /// <returns></returns>
        String MakeDataPath(String baseFolder, String targetFolder);

        /// <summary>
        /// Combines the <paramref name="baseFolder"/> and the <paramref name="targetFolder"/> and <paramref name="targetFileName"/> to make a valid file path
        /// </summary>
        /// <param name="baseFolder">The base folder</param>
        /// <param name="targetFolder">The target folder</param>
        /// <param name="targetFileName">The target file name</param>
        /// <returns></returns>
        String MakeDataPath(String baseFolder, String targetFolder, string targetFileName);

        /// <summary>
        /// Gets the new temporary file path.
        /// </summary>
        /// <param name="baseFolder">The base folder.</param>
        /// <param name="filePrefix">The file prefix.</param>
        /// <returns></returns>
        String GetNewTempFilePath(String baseFolder, String filePrefix);

        /// <summary>
        /// Ensures the file exists.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="FileNotFoundException"> When the file does not exist or access to it is denied</exception>
        void EnsureFileExists(String filePath);

        /// <summary>
        /// Ensures the file does not exist.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="FileAlreadyExistsException"> When the file does not exist or access to it is denied</exception>
        void EnsureFileDoesNotExist(String filePath);

        /// <summary>
        /// Ensures the Directory exists.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <exception cref="DirectoryNotFoundException"> When the directory does not exist or access to it is denied</exception>
        void EnsureDirectoryExists(String directoryPath);

        /// <summary>
        /// Ensures the file does not exist.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="FileAlreadyExistsException"> When the file does not exist or access to it is denied</exception>
        void EnsureDirectoryDoesNotExist(String filePath);

        /// <summary>
        /// Checks to see if a file exists
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns></returns>
        Boolean DoesFileExist(String filePath);

        /// <summary>
        /// Checks to see if the directory exists
        /// </summary>
        /// <param name="directoryPath">The directory path</param>
        /// <returns></returns>
        Boolean DoesDirectoryExist(String directoryPath);

        /// <summary>
        /// Gets the file contents as a stream.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The file contents</returns>
        Stream GetFileContentsAsStream(String filePath);

        /// <summary>
        /// Gets the file contents as text.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="encoding">Encoding to use for the file</param>
        /// <returns>The file contents</returns>
        String GetFileContentsAsText(String filePath, Encoding encoding);

        /// <summary>
        /// Gets the file contents as byte array.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Byte array of the loaded file</returns>
        Byte[] GetFileContentsAsByteArray(String filePath);

        /// <summary>
        /// Returns the requested resource from the given Assembly
        /// </summary>
        /// <param name="targetAssembly">Assembly containing the resource</param>
        /// <param name="resourceName">Path and name of the resource. Use "." in place of slashes "\". Example: "AssemblyName.Full.Path.To.File"</param>
        /// <returns>Open <see cref="Stream"/> with the resource file content</returns>
        Stream GetAssemblyResource(Assembly targetAssembly, String resourceName);

        /// <summary>
        /// Gets the file content from the Assembly
        /// </summary>
        /// <param name="targetAssembly"></param>
        /// <param name="filePath">Path and name of the resource. Use "." in place of slashes "\". Example: "AssemblyName.Full.Path.To.File"</param>
        /// <param name="encoding">Encoding to use for the file</param>
        /// <returns>The file contents</returns>
        String GetFileContentsAsTextFromAssembly(Assembly targetAssembly, String filePath, Encoding encoding);

        /// <summary>
        /// Gets the file content from the Assembly
        /// </summary>
        /// <param name="filePath">Path and name of the resource. Use "." in place of slashes "\". Example: "AssemblyName.Full.Path.To.File"</param>
        /// <param name="targetAssembly"></param>
        /// <returns>Byte array of the loaded file</returns>
        Byte[] GetFileContentsAsByteArrayFromAssembly(Assembly targetAssembly, String filePath);

        /// <summary>
        /// Opens a Text file for reading
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="encoding">Encoding to use for the file</param>
        /// <returns></returns>
        TextReader OpenFileForReading(String filePath, Encoding encoding);

        /// <summary>
        /// Opens a Text file for writing
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="encoding">Encoding to use for the file</param>
        /// <param name="appendToFile">If the file should be appended to or overwritten</param>
        /// <returns></returns>
        TextWriter OpenFileForWriting(String filePath, Encoding encoding, Boolean appendToFile = false);

        /// <summary>
        /// Makes a copy of the file in the <paramref name="destinationFilePath"/>
        /// </summary>
        /// <param name="sourceFilePath">The full path to the source file</param>
        /// <param name="destinationFilePath">The full path to the destination file</param>
        void CopyFile(String sourceFilePath, String destinationFilePath);

        /// <summary>
        /// Moves the file from the <paramref name="sourceFilePath"/> to the <paramref name="destinationFilePath"/>
        /// </summary>
        /// <param name="sourceFilePath">The full oath to the source file</param>
        /// <param name="destinationFilePath">The full oath to the destination file</param>
        void MoveFile(String sourceFilePath, String destinationFilePath);

        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="filePath">Location of file to delete</param>
        void DeleteFile(String filePath);

        /// <summary>
        /// Creates the <paramref name="newDirectoryName"/> as a subdirectory of <paramref name="basePath"/>
        /// </summary>
        /// <param name="basePath">The base path of the directory</param>
        /// <param name="newDirectoryName">Name of new subdirectory to create</param>
        /// <param name="throwExceptionIfExists">Routine will throw an exception if the directory already exists</param>
        /// <returns></returns>
        DirectoryInfo CreateDirectory(String basePath, String newDirectoryName, Boolean throwExceptionIfExists);

        /// <summary>
        /// Deletes the directory
        /// </summary>
        /// <param name="directoryPath">Location of directory to delete</param>
        /// <param name="recursive">true to delete this directory, its subdirectories, and all files; otherwise, false</param>
        void DeleteDirectory(String directoryPath, Boolean recursive);

        /// <summary>
        /// Gets the new temporary folder path.
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <param name="createFolder">if set to <c>true</c> [create folder].</param>
        /// <returns></returns>
        String GetNewTempFolderPath(String folderName, Boolean createFolder);

        /// <summary>
        /// Gets the file contents as a stream.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileContent">The file content</param>
        /// <param name="overwriteIfFileExists"></param>
        /// <returns>The file contents</returns>
        String WriteFileContent(String filePath, Stream fileContent, Boolean overwriteIfFileExists = false);
    }
}
