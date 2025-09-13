////-----------------------------------------------------------------------
//// <copyright file="ImageToMediaImageConverter.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System.Drawing;
//using System.Globalization;
//using System.Runtime.InteropServices;
//using System.Windows;
//using System.Windows.Data;
//using System.Windows.Interop;
//using System.Windows.Media.Imaging;

//namespace Foundation.Views.Converters
//{
//    [ValueConversion(typeof(Image), typeof(BitmapSource))]
//    public class ImageToMediaImageConverter : IValueConverter
//    {
//        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        public static extern Boolean DeleteObject([In] IntPtr hObject);

//        public Object? Convert(Object? value, Type targetType, Object? parameter, CultureInfo culture)
//        {
//            BitmapSource retVal = null;
//            if (value != null && value.GetType() == typeof(Bitmap))
//            {
//                Bitmap bitmap = value as Bitmap;
//                retVal = BitmapSourceForBitmap(bitmap);
//            }

//            return retVal;
//        }

//        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
//        {
//            Bitmap retVal = null;

//            if (value != null &&
//                ((value.GetType() == typeof(BitmapSource)) ||
//                 (value.GetType() == typeof(InteropBitmap))
//                )
//               )
//            {
//                BitmapSource bitmapSource = value as BitmapSource;
//                retVal = BitmapSourceToBitmap(bitmapSource);
//            }

//            return retVal;
//        }

//        private BitmapSource BitmapSourceForBitmap(Bitmap bitmap)
//        {
//            BitmapSource retVal = null;
//            IntPtr handle = bitmap.GetHbitmap();
//            try
//            {
//                IntPtr pallette = IntPtr.Zero;
//                Int32Rect sourceRect = Int32Rect.Empty;
//                BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
//                retVal = Imaging.CreateBitmapSourceFromHBitmap(handle, pallette, sourceRect, sizeOptions);
//            }
//            catch
//            {
//                // Do nothing with the exception, just don't want it to break the application at run time
//            }
//            finally
//            {
//                DeleteObject(handle);
//            }

//            return retVal;
//        }

//        private Bitmap BitmapSourceToBitmap(BitmapSource bitmapSource)
//        {
//            Bitmap retVal = null;
//            IntPtr ptr = IntPtr.Zero;
//            try
//            {
//                Int32 width = bitmapSource.PixelWidth;
//                Int32 height = bitmapSource.PixelHeight;
//                Int32 stride = width * ((bitmapSource.DotNetFormat.BitsPerPixel + 7) / 8);

//                ptr = Marshal.AllocHGlobal(height * stride);
//                bitmapSource.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
//                using (Bitmap bitmap = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr))
//                {
//                    // Clone the bitmap so that we can dispose it and release the unmanaged memory at ptr
//                    retVal = new Bitmap(bitmap);
//                }
//            }
//            catch
//            {
//                // Do nothing with the exception, just don't want it to break the application at run time
//            }
//            finally
//            {
//                if (ptr != IntPtr.Zero)
//                {
//                    Marshal.FreeHGlobal(ptr);
//                }
//            }

//            return retVal;
//        }
//    }
//}
