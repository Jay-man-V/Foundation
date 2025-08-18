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
    }
}
