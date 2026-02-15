//-----------------------------------------------------------------------
// <copyright file="EncryptionUtils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Security.Cryptography;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes?view=net-9.0
    /// <inheritdoc cref="IEncryptionService"/>
    [DependencyInjectionTransient]
    public class EncryptionService : IEncryptionService
    {
        private static Int16 Iterations => 10_000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileApi">The file API service</param>
        public EncryptionService
        (
            IFileApi fileApi
        )
        {
            FileApi = fileApi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An implementation of the currently used <see cref="SymmetricAlgorithm"/></returns>
        private SymmetricAlgorithm Create() { return Aes.Create(); }

        private IFileApi FileApi { get; }

        /// <inheritdoc cref="IEncryptionService.GenerateSalt(Int32)"/>
        public Byte[] GenerateSalt(Int32 saltSize = 1024)
        {
            LoggingHelpers.TraceCallEnter(saltSize);

            Byte[] retVal = new Byte[saltSize];

            using (RandomNumberGenerator cryptoServiceProvider = RandomNumberGenerator.Create())
            {
                // Fill the array with a random value.
                cryptoServiceProvider.GetBytes(retVal);
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.GenerateKeys(String, Byte[], out Byte[], out Byte[])"/>
        public void GenerateKeys(String keyPassword, Byte[]? salt, out Byte[] key, out Byte[] iv)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(keyPassword)} not logged", $"{nameof(salt)} not logged");

            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt));
            }


            using (SymmetricAlgorithm crypto = Create())
            {
                // TODO: Move HashAlgorithmName.SHA3_512 to constants or loaded configuration
                key = Rfc2898DeriveBytes.Pbkdf2(keyPassword, salt, Iterations, HashAlgorithmName.SHA3_512, crypto.KeySize / 8);
                iv = Rfc2898DeriveBytes.Pbkdf2(keyPassword, salt, Iterations, HashAlgorithmName.SHA3_512, crypto.BlockSize / 8);

                crypto.Clear();
            }

            LoggingHelpers.TraceCallReturn($"{nameof(key)} not logged, {nameof(iv)} not logged");
        }

        /// <inheritdoc cref="IEncryptionService.GenerateKeys(String, String, String, Byte[])"/>
        public void GenerateKeys(String outputFolder, String keyName, String keyPassword, Byte[]? salt)
        {
            LoggingHelpers.TraceCallEnter(outputFolder, keyName, $"{nameof(keyPassword)} not logged");

            FileApi.EnsureDirectoryExists(outputFolder);

            // Don't want to overwrite any existing key file
            String keyOutputFile = Path.Combine(outputFolder, keyName + ".key");
            FileApi.EnsureFileDoesNotExist(keyOutputFile);

            // Don't want to overwrite any existing iv file
            String ivOutputFile = Path.Combine(outputFolder, keyName + ".iv");
            FileApi.EnsureFileDoesNotExist(ivOutputFile);

            salt ??= GenerateSalt();

            GenerateKeys(keyPassword, salt, out Byte[] key, out Byte[] iv);

            File.WriteAllBytes(keyOutputFile, key);
            File.WriteAllBytes(ivOutputFile, iv);

            Array.Clear(key, 0, key.Length);
            Array.Clear(iv, 0, iv.Length);

            LoggingHelpers.TraceCallReturn();
        }

        /* String encryption/decryption functions */

        /// <inheritdoc cref="IEncryptionService.EncryptData(String, String, String)"/>
        public String EncryptData(String keyLocation, String keyName, String dataToEncrypt)
        {
            LoggingHelpers.TraceCallEnter(keyLocation, keyName, $"{nameof(dataToEncrypt)} not logged");

            LoadKeysFromFile(keyLocation, keyName, out Byte[] key, out Byte[] iv);

            String retVal = EncryptData(key, iv, dataToEncrypt);

            Array.Clear(key, 0, key.Length);
            Array.Clear(iv, 0, iv.Length);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.EncryptData(Byte[], Byte[], String)"/>
        public String EncryptData(Byte[] key, Byte[] iv, String dataToEncrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(key)} not logged", $"{nameof(iv)} not logged", $"{nameof(dataToEncrypt)} not logged");

            String retVal;

            using (SymmetricAlgorithm crypto = Create())
            {
                crypto.Key = key;
                crypto.IV = iv;
                crypto.Padding = PaddingMode.Zeros;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform transformer = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, transformer, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream.
                            swEncrypt.Write(dataToEncrypt);
                            swEncrypt.Flush();
                            swEncrypt.Close();
                        }

                        retVal = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }

                crypto.Clear();
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.EncryptData(String, String)"/>
        public String EncryptData(String passPhrase, String dataToEncrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(passPhrase)} not logged", $"{nameof(dataToEncrypt)} not logged");

            Byte[] salt = Encoding.ASCII.GetBytes(passPhrase);

            GenerateKeys(passPhrase, salt, out Byte[] key, out Byte[] iv);

            String retVal = EncryptData(key, iv, dataToEncrypt);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.DecryptData(String, String, String)"/>
        public String DecryptData(String keyLocation, String keyName, String dataToDecrypt)
        {
            LoggingHelpers.TraceCallEnter(keyLocation, keyName, $"{nameof(dataToDecrypt)} not logged");

            LoadKeysFromFile(keyLocation, keyName, out Byte[] key, out Byte[] iv);

            String retVal = DecryptData(key, iv, dataToDecrypt);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.DecryptData(Byte[], Byte[], String)"/>
        public String DecryptData(Byte[] key, Byte[] iv, String dataToDecrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(key)} not logged", $"{nameof(iv)} not logged", $"{nameof(dataToDecrypt)} not logged");

            String retVal;

            using (SymmetricAlgorithm crypto = Create())
            {
                crypto.Key = key;
                crypto.IV = iv;
                crypto.Padding = PaddingMode.Zeros;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform transformer = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                // Create the streams used for encryption.
                Byte[] dataArray = Convert.FromBase64String(dataToDecrypt);
                using (MemoryStream msDecrypt = new MemoryStream(dataArray))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, transformer, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            retVal = srDecrypt.ReadToEnd();
                        }
                    }
                }

                crypto.Clear();
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.DecryptData(String, String)"/>
        public String DecryptData(String passPhrase, String dataToDecrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(passPhrase)} not logged", $"{nameof(dataToDecrypt)} not logged");

            Byte[] salt = Encoding.ASCII.GetBytes(passPhrase);

            GenerateKeys(passPhrase, salt, out Byte[] key, out Byte[] iv);

            String retVal = DecryptData(key, iv, dataToDecrypt);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /* Byte[] encryption/decryption functions */

        /// <inheritdoc cref="IEncryptionService.EncryptData(String, String, Byte[])"/>
        public Byte[] EncryptData(String keyLocation, String keyName, Byte[] dataToEncrypt)
        {
            LoggingHelpers.TraceCallEnter(keyLocation, keyName, $"{nameof(dataToEncrypt)} not logged");

            LoadKeysFromFile(keyLocation, keyName, out Byte[] key, out Byte[] iv);

            Byte[] retVal = EncryptDecryptData(key, iv, dataToEncrypt, true);

            Array.Clear(key, 0, key.Length);
            Array.Clear(iv, 0, iv.Length);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.EncryptData(Byte[], Byte[], Byte[])"/>
        public Byte[] EncryptData(Byte[] key, Byte[] iv, Byte[] dataToEncrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(key)} not logged", $"{nameof(iv)} not logged", $"{nameof(dataToEncrypt)} not logged");

            Byte[] retVal = EncryptDecryptData(key, iv, dataToEncrypt, true);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.DecryptData(String, String, Byte[])"/>
        public Byte[] DecryptData(String keyLocation, String keyName, Byte[] dataToDecrypt)
        {
            LoggingHelpers.TraceCallEnter(keyLocation, keyName, $"{nameof(dataToDecrypt)} not logged");

            LoadKeysFromFile(keyLocation, keyName, out Byte[] key, out Byte[] iv);

            Byte[] retVal = EncryptDecryptData(key, iv, dataToDecrypt, false);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IEncryptionService.DecryptData(Byte[], Byte[], Byte[])"/>
        public Byte[] DecryptData(Byte[] key, Byte[] iv, Byte[] dataToDecrypt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(key)} not logged", $"{nameof(iv)} not logged", $"{nameof(dataToDecrypt)} not logged");

            Byte[] retVal = EncryptDecryptData(key, iv, dataToDecrypt, false);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="data"></param>
        /// <param name="isEncryption"></param>
        /// <returns></returns>
        private Byte[] EncryptDecryptData(Byte[] key, Byte[] iv, Byte[] data, Boolean isEncryption)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(key)} not logged", $"{nameof(iv)} not logged", $"{nameof(data)} not logged", isEncryption);

            Byte[] retVal;

            using (SymmetricAlgorithm crypto = Create())
            {
                crypto.Key = key;
                crypto.IV = iv;
                crypto.Padding = PaddingMode.Zeros;

                // Create an Encryptor or Decryptor to perform the stream transform.
                ICryptoTransform transformer;

                if (isEncryption)
                {
                    transformer = crypto.CreateEncryptor(crypto.Key, crypto.IV);
                }
                else
                {
                    transformer = crypto.CreateDecryptor(crypto.Key, crypto.IV);
                }

                // Create the streams used for encryption.
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, transformer, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(data, 0, data.Length);
                        csDecrypt.Flush();
                        csDecrypt.Close();
                    }

                    retVal = msDecrypt.ToArray();
                }

                crypto.Clear();
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <summary>
        /// Loads the content of the <paramref name="key"/> and <paramref name="iv"/> from the <paramref name="keyLocation"/>
        /// <para>
        /// When using a file based <paramref name="keyLocation"/>, the <paramref name="key"/> must have an extension of <value>.KEY</value> and
        /// <paramref name="iv"/> must have an extension of <value>.IV</value>.
        /// </para>
        /// </summary>
        /// <param name="keyLocation"></param>
        /// <param name="keyName"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        private void LoadKeysFromFile(String keyLocation, String keyName, out Byte[] key, out Byte[] iv)
        {
            LoggingHelpers.TraceCallEnter(keyLocation, keyName);

            String keyFile = Path.Combine(keyLocation, keyName + ".key");
            String ivFile = Path.Combine(keyLocation, keyName + ".iv");

            key = File.ReadAllBytes(keyFile);
            iv = File.ReadAllBytes(ivFile);

            LoggingHelpers.TraceCallReturn($"{nameof(key)} not logged, {nameof(iv)} not logged");
        }
    }
}
