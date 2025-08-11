//-----------------------------------------------------------------------
// <copyright file="RandomUtils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Cryptography;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="IRandomService"/>
    [DependencyInjectionTransient]
    public class RandomService : ServiceBase, IRandomService
    {
        private static readonly Random Random = new();

        /// <summary>
        /// 
        /// </summary>
        public RandomService
        (
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }


        /// <inheritdoc cref="IRandomService.AlphaUpperCaseOnly"/>
        public String AlphaUpperCaseOnly => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <inheritdoc cref="IRandomService.AlphaLowerCaseOnly"/>
        public String AlphaLowerCaseOnly => "abcdefghijklmnopqrstuvwxyz";

        /// <inheritdoc cref="IRandomService.NumericOnly"/>
        public String NumericOnly => "0123456789";

        /// <inheritdoc cref="IRandomService.NonAlphaChars"/>
        public String NonAlphaChars => @"!""£$%^&*() _-+={}[]#:@;'<>?,./|\";

        /// <inheritdoc cref="IRandomService.AlphaNumeric"/>
        public String AlphaNumeric => AlphaUpperCaseOnly + AlphaLowerCaseOnly + NumericOnly;

        /// <inheritdoc cref="IRandomService.AllChars"/>
        public String AllChars => AlphaUpperCaseOnly + AlphaLowerCaseOnly + NumericOnly + NonAlphaChars;

        /// <inheritdoc cref="IRandomService.NextInt32()"/>
        public Int32 NextInt32()
        {
            LoggingHelpers.TraceCallEnter();

            Int32 retVal = Random.Next();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRandomService.NextInt32(Int32)"/>
        public Int32 NextInt32(Int32 maxValue)
        {
            LoggingHelpers.TraceCallEnter(maxValue);

            Int32 retVal = Random.Next(maxValue);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRandomService.NextInt32(Int32, Int32)"/>
        public Int32 NextInt32(Int32 minValue, Int32 maxValue)
        {
            LoggingHelpers.TraceCallEnter(minValue, maxValue);

            Int32 retVal = Random.Next(minValue, maxValue);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRandomService.SimpleRandomString(Int32, String)"/>
        public String SimpleRandomString(Int32 length, String validCharacters)
        {
            LoggingHelpers.TraceCallEnter(length, validCharacters);

            String retVal = new String(Enumerable.Repeat(1, length).Select(_ => validCharacters[Random.Next(validCharacters.Length)]).ToArray());

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IRandomService.RandomPassword(Int32, String)"/>
        public String RandomPassword(Int32 length, String validCharacters)
        {
            LoggingHelpers.TraceCallEnter(length, validCharacters);

            StringBuilder retVal = new StringBuilder(length);
            using (RandomNumberGenerator cryptoServiceProvider = RandomNumberGenerator.Create())
            {
                Int32 count = (Int32)Math.Ceiling(Math.Log(validCharacters.Length, 2) / 8.0);
                Int32 offset = BitConverter.IsLittleEndian ? 0 : sizeof(UInt32) - count;
                Int32 max = (Int32)(Math.Pow(2, count * 8) / validCharacters.Length) * validCharacters.Length;
                Byte[] uintBuffer = new Byte[sizeof(UInt32)];

                cryptoServiceProvider.GetBytes(uintBuffer, offset, count);
                UInt32 lastNum = BitConverter.ToUInt32(uintBuffer, 0);
                while (retVal.Length < length)
                {
                    cryptoServiceProvider.GetBytes(uintBuffer, offset, count);
                    UInt32 num = BitConverter.ToUInt32(uintBuffer, 0);

                    // num must be outside the range of the last num +/- 3 to avoid potential consecutive or closeness of characters
                    Boolean isAcceptable = !lastNum.IsBetween(num - 3, num + 3);

                    if (isAcceptable &&
                        num < max)
                    {
                        retVal.Append(validCharacters[(Int32)(num % validCharacters.Length)]);
                        lastNum = num;
                    }
                }
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal.ToString();
        }
    }
}
