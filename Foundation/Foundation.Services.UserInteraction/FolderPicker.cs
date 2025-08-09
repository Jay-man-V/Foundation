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
        private readonly List<String> _resultPaths = [];
        private readonly List<String> _resultNames = [];

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
        public String ResultPath => ResultPaths.FirstOrDefault() ?? String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public String ResultName => ResultNames.FirstOrDefault() ?? String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public virtual String InputPath { get; set; } = String.Empty;

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
        public virtual String Title { get; set; } = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public virtual String OkButtonLabel { get; set; } = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public virtual String FileNameLabel { get; set; } = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected virtual Int32 SetOptions(Int32 options)
        {
            if (ForceFileSystem)
            {
                options |= (Int32)Fos.ForceFileSystem;
            }

            if (MultiSelect)
            {
                options |= (Int32)Fos.AllowMultiSelect;
            }

            return options;
        }

        /// <summary>
        /// for WPF support
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public Boolean? ShowDialog(Window? owner = null, Boolean throwOnError = false)
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

            Fos options = Fos.PickFolders;
            options = (Fos)SetOptions((Int32)options);
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
            if (hr == ErrorCancelled)
                return null;

            if (CheckHr(hr, throwOnError) != 0)
                return null;

            if (CheckHr(dialog.GetResults(out var items), throwOnError) != 0)
                return null;

            items.GetCount(out var count);
            for (var i = 0; i < count; i++)
            {
                items.GetItemAt(i, out var item);
                CheckHr(item.GetDisplayName(Sigdn.DesktopAbsoluteParsing, out var path), throwOnError);
                CheckHr(item.GetDisplayName(Sigdn.DesktopAbsoluteEditing, out var name), throwOnError);
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

        private const Int32 ErrorCancelled = unchecked((Int32)0x800704C7);

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
            [PreserveSig] Int32 UnAdvise();
            [PreserveSig] Int32 SetOptions(Fos fos);
            [PreserveSig] Int32 GetOptions(out Fos pfos);
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
            [PreserveSig] Int32 GetDisplayName(Sigdn sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out String ppszName);
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

        protected enum Sigdn : UInt32
        {
            DesktopAbsoluteEditing = 0x8004c000,
            DesktopAbsoluteParsing = 0x80028000,
            FileSysPath = 0x80058000,
            NormalDisplay = 0,
            ParentRelative = 0x80080001,
            ParentRelativeEditing = 0x80031001,
            ParentRelativeForAddressBar = 0x8007c001,
            ParentRelativeParsing = 0x80018001,
            Url = 0x80068000
        }

        [Flags]
        protected enum Fos
        {
            OverwritePrompt = 0x2,
            StrictFileTypes = 0x4,
            NoChangeDir = 0x8,
            PickFolders = 0x20,
            ForceFileSystem = 0x40,
            AllNonStorageItems = 0x80,
            Novalidate = 0x100,
            AllowMultiSelect = 0x200,
            PathMustExist = 0x800,
            FileMustExist = 0x1000,
            CreatePrompt = 0x2000,
            ShareAware = 0x4000,
            NoReadOnlyReturn = 0x8000,
            NoTestFileCreate = 0x10000,
            HideMruPlaces = 0x20000,
            HidePinnedPlaces = 0x40000,
            NoDereferenceLinks = 0x100000,
            OkButtonNeedsInteraction = 0x200000,
            DoNotAddToRecent = 0x2000000,
            ForceShowHidden = 0x10000000,
            DefaultNoMiniMode = 0x20000000,
            ForcePreviewPaneOn = 0x40000000,
            SupportStreamableItems = unchecked((Int32)0x80000000)
        }
    }
}
