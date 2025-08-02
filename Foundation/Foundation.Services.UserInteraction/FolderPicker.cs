//-----------------------------------------------------------------------
// <copyright file="FolderPicker.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Interop;

namespace Foundation.Services.UserInteraction
{
    /// <summary>
    /// 
    /// </summary>
    public class FolderPicker
    {
        private readonly List<String> _resultPaths = new List<String>();
        private readonly List<String> _resultNames = new List<String>();

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<String> ResultPaths => _resultPaths;
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<String> ResultNames => _resultNames;
        /// <summary>
        /// 
        /// </summary>
        public String ResultPath => ResultPaths.FirstOrDefault();
        /// <summary>
        /// 
        /// </summary>
        public String ResultName => ResultNames.FirstOrDefault();
        /// <summary>
        /// 
        /// </summary>
        public virtual String InputPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Boolean ForceFileSystem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Boolean MultiSelect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String OkButtonLabel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String FileNameLabel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected virtual Int32 SetOptions(Int32 options)
        {
            if (ForceFileSystem)
            {
                options |= (Int32)FOS.FOS_FORCEFILESYSTEM;
            }

            if (MultiSelect)
            {
                options |= (Int32)FOS.FOS_ALLOWMULTISELECT;
            }
            return options;
        }

        /// <summary>
        /// for WPF support
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public Boolean? ShowDialog(Window owner = null, Boolean throwOnError = false)
        {
            owner = owner ?? Application.Current?.MainWindow;
            return ShowDialog(owner != null ? new WindowInteropHelper(owner).Handle : IntPtr.Zero, throwOnError);
        }

        /// <summary>
        /// for all .NET
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public virtual Boolean? ShowDialog(IntPtr owner, Boolean throwOnError = false)
        {
            var dialog = (IFileOpenDialog)new FileOpenDialog();
            if (!String.IsNullOrEmpty(InputPath))
            {
                if (CheckHr(SHCreateItemFromParsingName(InputPath, null, typeof(IShellItem).GUID, out var item), throwOnError) != 0)
                    return null;

                dialog.SetFolder(item);
            }

            FOS options = FOS.FOS_PICKFOLDERS;
            options = (FOS)SetOptions((Int32)options);
            dialog.SetOptions(options);

            if (!String.IsNullOrEmpty(Title))
            {
                dialog.SetTitle(Title);
            }

            if (!String.IsNullOrEmpty(OkButtonLabel))
            {
                dialog.SetOkButtonLabel(OkButtonLabel);
            }

            if (!String.IsNullOrEmpty(FileNameLabel))
            {
                dialog.SetFileName(FileNameLabel);
            }

            if (owner == IntPtr.Zero)
            {
                owner = Process.GetCurrentProcess().MainWindowHandle;
                if (owner == IntPtr.Zero)
                {
                    owner = GetDesktopWindow();
                }
            }

            var hr = dialog.Show(owner);
            if (hr == ERROR_CANCELLED)
                return null;

            if (CheckHr(hr, throwOnError) != 0)
                return null;

            if (CheckHr(dialog.GetResults(out var items), throwOnError) != 0)
                return null;

            items.GetCount(out var count);
            for (var i = 0; i < count; i++)
            {
                items.GetItemAt(i, out var item);
                CheckHr(item.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out var path), throwOnError);
                CheckHr(item.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEEDITING, out var name), throwOnError);
                if (!String.IsNullOrEmpty(path) || !String.IsNullOrEmpty(name))
                {
                    _resultPaths.Add(path);
                    _resultNames.Add(name);
                }
            }
            return true;
        }

        private static Int32 CheckHr(Int32 hr, Boolean throwOnError)
        {
            if (hr != 0 && throwOnError) Marshal.ThrowExceptionForHR(hr);
            return hr;
        }

        [DllImport("shell32")]
        private static extern Int32 SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] String pszPath, IBindCtx pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItem ppv);

        [DllImport("user32")]
        private static extern IntPtr GetDesktopWindow();

#pragma warning disable IDE1006 // Naming Styles
        private const Int32 ERROR_CANCELLED = unchecked((Int32)0x800704C7);
#pragma warning restore IDE1006 // Naming Styles

        [ComImport, Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")] // CLSID_FileOpenDialog
        private class FileOpenDialog { }

        [ComImport, Guid("d57c7288-d4ad-4768-be02-9d969532d960"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFileOpenDialog
        {
            [PreserveSig] Int32 Show(IntPtr parent); // IModalWindow
            [PreserveSig] Int32 SetFileTypes();  // not fully defined
            [PreserveSig] Int32 SetFileTypeIndex(Int32 iFileType);
            [PreserveSig] Int32 GetFileTypeIndex(out Int32 piFileType);
            [PreserveSig] Int32 Advise(); // not fully defined
            [PreserveSig] Int32 Unadvise();
            [PreserveSig] Int32 SetOptions(FOS fos);
            [PreserveSig] Int32 GetOptions(out FOS pfos);
            [PreserveSig] Int32 SetDefaultFolder(IShellItem psi);
            [PreserveSig] Int32 SetFolder(IShellItem psi);
            [PreserveSig] Int32 GetFolder(out IShellItem ppsi);
            [PreserveSig] Int32 GetCurrentSelection(out IShellItem ppsi);
            [PreserveSig] Int32 SetFileName([MarshalAs(UnmanagedType.LPWStr)] String pszName);
            [PreserveSig] Int32 GetFileName([MarshalAs(UnmanagedType.LPWStr)] out String pszName);
            [PreserveSig] Int32 SetTitle([MarshalAs(UnmanagedType.LPWStr)] String pszTitle);
            [PreserveSig] Int32 SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] String pszText);
            [PreserveSig] Int32 SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] String pszLabel);
            [PreserveSig] Int32 GetResult(out IShellItem ppsi);
            [PreserveSig] Int32 AddPlace(IShellItem psi, Int32 alignment);
            [PreserveSig] Int32 SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] String pszDefaultExtension);
            [PreserveSig] Int32 Close(Int32 hr);
            [PreserveSig] Int32 SetClientGuid();  // not fully defined
            [PreserveSig] Int32 ClearClientData();
            [PreserveSig] Int32 SetFilter([MarshalAs(UnmanagedType.IUnknown)] object pFilter);
            [PreserveSig] Int32 GetResults(out IShellItemArray ppenum);
            [PreserveSig] Int32 GetSelectedItems([MarshalAs(UnmanagedType.IUnknown)] out object ppsai);
        }

        [ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem
        {
            [PreserveSig] Int32 BindToHandler(); // not fully defined
            [PreserveSig] Int32 GetParent(); // not fully defined
            [PreserveSig] Int32 GetDisplayName(SIGDN sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out String ppszName);
            [PreserveSig] Int32 GetAttributes();  // not fully defined
            [PreserveSig] Int32 Compare();  // not fully defined
        }

        [ComImport, Guid("b63ea76d-1f85-456f-a19c-48159efa858b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItemArray
        {
            [PreserveSig] Int32 BindToHandler();  // not fully defined
            [PreserveSig] Int32 GetPropertyStore();  // not fully defined
            [PreserveSig] Int32 GetPropertyDescriptionList();  // not fully defined
            [PreserveSig] Int32 GetAttributes();  // not fully defined
            [PreserveSig] Int32 GetCount(out Int32 pdwNumItems);
            [PreserveSig] Int32 GetItemAt(Int32 dwIndex, out IShellItem ppsi);
            [PreserveSig] Int32 EnumItems();  // not fully defined
        }

#pragma warning disable CA1712 // Do not prefix enum values with type name
        private enum SIGDN : UInt32
        {
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,
            SIGDN_FILESYSPATH = 0x80058000,
            SIGDN_NORMALDISPLAY = 0,
            SIGDN_PARENTRELATIVE = 0x80080001,
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,
            SIGDN_URL = 0x80068000
        }

        [Flags]
        private enum FOS
        {
            FOS_OVERWRITEPROMPT = 0x2,
            FOS_STRICTFILETYPES = 0x4,
            FOS_NOCHANGEDIR = 0x8,
            FOS_PICKFOLDERS = 0x20,
            FOS_FORCEFILESYSTEM = 0x40,
            FOS_ALLNONSTORAGEITEMS = 0x80,
            FOS_NOVALIDATE = 0x100,
            FOS_ALLOWMULTISELECT = 0x200,
            FOS_PATHMUSTEXIST = 0x800,
            FOS_FILEMUSTEXIST = 0x1000,
            FOS_CREATEPROMPT = 0x2000,
            FOS_SHAREAWARE = 0x4000,
            FOS_NOREADONLYRETURN = 0x8000,
            FOS_NOTESTFILECREATE = 0x10000,
            FOS_HIDEMRUPLACES = 0x20000,
            FOS_HIDEPINNEDPLACES = 0x40000,
            FOS_NODEREFERENCELINKS = 0x100000,
            FOS_OKBUTTONNEEDSInt32ERACTION = 0x200000,
            FOS_DONTADDTORECENT = 0x2000000,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_DEFAULTNOMINIMODE = 0x20000000,
            FOS_FORCEPREVIEWPANEON = 0x40000000,
            FOS_SUPPORTSTREAMABLEITEMS = unchecked((Int32)0x80000000)
        }
#pragma warning restore CA1712 // Do not prefix enum values with type name
    }
}
