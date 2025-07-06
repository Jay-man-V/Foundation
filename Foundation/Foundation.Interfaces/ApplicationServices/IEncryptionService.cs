//-----------------------------------------------------------------------
// <copyright file="IEncryptionService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Standard Encryption Helper routines.
    /// <para>
    /// Functions include:
    /// </para>
    /// <para>
    /// * Generate Salt
    /// </para>
    /// <para>
    /// * GenerateKeys (IV and Key)
    /// </para>
    /// <para>
    /// * EncryptData and DecryptData
    /// </para>
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Uses the <see cref="System.Security.Cryptography.SymmetricAlgorithm"/> to create a Cryptographically secure random salt
        /// </summary>
        /// <param name="saltSize">Size of the salt to generate</param>
        /// <returns></returns>
        Byte[] GenerateSalt(Int32 saltSize = 1024);

        /// <summary>
        /// Generates a new set of Keys (IV and Key) for use in Cryptographic functions.
        /// The <paramref name="key"/> and <paramref name="iv"/> are generated based on the supplied
        /// <paramref name="keyPassword"/> and <paramref name="salt"/>
        /// </summary>
        /// <param name="keyPassword"></param>
        /// <param name="salt"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        void GenerateKeys(String keyPassword, Byte[] salt, out Byte[] key, out Byte[] iv);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyPassword"></param>
        /// <param name="salt"></param>
        /// <param name="outputFolder"></param>
        /// <param name="keyName"></param>
        void GenerateKeys(String keyPassword, byte[] salt, String outputFolder, String keyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        void GenerateKeys(out Byte[] key, out Byte[] iv);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFolder"></param>
        /// <param name="keyName"></param>
        void GenerateKeys(String outputFolder, String keyName);

        /* String encryption/decryption functions */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyLocation"></param>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        String EncryptData(String keyLocation, String dataToEncrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        String EncryptData(Byte[] key, Byte[] iv, String dataToEncrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyLocation"></param>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        String DecryptData(String keyLocation, String dataToDecrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        String DecryptData(Byte[] key, Byte[] iv, String dataToDecrypt);

        /* Byte[] encryption/decryption functions */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyLocation"></param>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        Byte[] EncryptData(String keyLocation, Byte[] dataToEncrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        Byte[] EncryptData(Byte[] key, Byte[] iv, Byte[] dataToEncrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyLocation"></param>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        Byte[] DecryptData(String keyLocation, Byte[] dataToDecrypt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        Byte[] DecryptData(Byte[] key, Byte[] iv, Byte[] dataToDecrypt);
    }
}
