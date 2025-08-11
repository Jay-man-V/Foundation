//-----------------------------------------------------------------------
// <copyright file="HashingUtils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Cryptography;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="IHashingService"/>
    [DependencyInjectionTransient]
    public class HashingService : ServiceBase, IHashingService
    {
        private static Int16 Iterations => 1000;

        /// <summary>
        /// 
        /// </summary>
        public HashingService
        (
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }


        /// <inheritdoc cref="IHashingService.GenerateSalt(Int32)"/>
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

        /// <inheritdoc cref="IHashingService.GenerateHash(String, Byte[])"/>
        public String GenerateHash(String input, Byte[] salt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(input)} not logged", $"{nameof(salt)} not logged");

            // Convert the input string to a byte array and compute the hash.
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedData = GenerateHash(inputBytes, salt);

            // Create a new StringBuilder to collect the bytes and create a string.
            StringBuilder hashedText = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            foreach (Byte data in hashedData)
            {
                hashedText.Append(data.ToString("x2"));
            }

            String retVal = hashedText.ToString();

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IHashingService.GenerateHash(Byte[], Byte[])"/>
        public Byte[] GenerateHash(Byte[] input, Byte[] salt)
        {
            LoggingHelpers.TraceCallEnter($"{nameof(input)} not logged", $"{nameof(salt)} not logged");

            Byte[] retVal;

            // TODO: Move HashAlgorithmName.SHA3_512 to constants or loaded configuration
            using (Rfc2898DeriveBytes hashAlgorithm = new Rfc2898DeriveBytes(input, salt, Iterations, HashAlgorithmName.SHA3_512))
            {
                retVal = hashAlgorithm.GetBytes(input.Length);
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        //public Byte[] GenerateHash(Byte[] input, Byte[] salt)
        //{
        //    Byte[] retVal = null;

        //    using (MemoryStream ms = new MemoryStream(input))
        //    {
        //        retVal = GenerateHash(ms, salt);
        //    }

        //    return retVal;
        //}

        //public Byte[] GenerateHash(Stream input, Byte[] salt)
        //{
        //    Byte[] retVal = null;

        //    input.Position = 0;

        //    using (HashAlgorithm hashAlgorithm = SHA512.Create())
        //    {
        //        retVal = hashAlgorithm.ComputeHash(input);
        //    }

        //    return retVal;
        //}
    }
}
