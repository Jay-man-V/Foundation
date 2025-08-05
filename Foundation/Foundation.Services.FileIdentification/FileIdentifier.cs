//-----------------------------------------------------------------------
// <copyright file="FieldIdentifier.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Foundation.Services.FileIdentification
{
    public class FileIdentifier
    {
        /// <summary>
        /// MIME Type Detection in Windows Internet Explorer
        /// https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775147(v=vs.85)?redirectedfrom=MSDN
        /// 
        /// </summary>
            public static Int32 MimeSampleSize = 256;

            public static String DefaultMimeType = "application/octet-stream";

            [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
            static extern int FindMimeFromData
            (
                IntPtr pBc,
                [MarshalAs(UnmanagedType.LPWStr)] String? pwzUrl,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)]
                Byte[] pBuffer,
                Int32 cbSize,
                [MarshalAs(UnmanagedType.LPWStr)] String? pwzMimeProposed,
                Int32 dwMimeFlags,
                out IntPtr ppwzMimeOut,
                Int32 dwReserved
            );

            /// <summary>
            /// Check the first 256 bytes to determine the MIME type. This function is often used when the file extension name is unknown.
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            /// <remarks>There's some limitation of the api function, according to http://msdn.microsoft.com/en-us/library/ms775147%28VS.85%29.aspx#Known_MimeTypes
            /// and this implementation will return "application/octet-stream" if the file is smaller than 256 bytes.
            /// </remarks>
            public static String GetMimeFromBytes(Byte[] data)
            {
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                IntPtr mimeTypePointer = IntPtr.Zero;
                try
                {

                    FindMimeFromData(IntPtr.Zero, null, data, MimeSampleSize, null, 0, out mimeTypePointer, 0);
                    String? mime = Marshal.PtrToStringUni(mimeTypePointer);
                    return mime ?? DefaultMimeType;
                }
                catch (AccessViolationException e)
                {
                    Debug.WriteLine(e.ToString());
                    return DefaultMimeType;
                }
                finally
                {
                    if (mimeTypePointer != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(mimeTypePointer);
                    }
                }
            }
    }
}
