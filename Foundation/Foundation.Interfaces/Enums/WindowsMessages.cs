//-----------------------------------------------------------------------
// <copyright file="WindowsMessages.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>Windows Messages</summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the Windows message")]
    public enum WindowsMessages
    {
        /// <summary>The wm null</summary>
        [Id(0), Display(Order = 0, Name = "WmNull")]
        WmNull = 0x0000,

        /// <summary>The wm create</summary>
        [Id(1), Display(Order = 1, Name = "WmCreate")]
        WmCreate = 0x0001,

        /// <summary>The wm destroy</summary>
        [Id(2), Display(Order = 2, Name = "WmDestroy")]
        WmDestroy = 0x0002,

        /// <summary>The wm move</summary>
        [Id(3), Display(Order = 3, Name = "WmMove")]
        WmMove = 0x0003,

        /// <summary>The wm size</summary>
        [Id(5), Display(Order = 5, Name = "WmSize")]
        WmSize = 0x0005,

        /// <summary>The wm activate</summary>
        [Id(6), Display(Order = 6, Name = "WmActivate")]
        WmActivate = 0x0006,

        /// <summary>The wm set focus</summary>
        [Id(7), Display(Order = 7, Name = "WmSetFocus")]
        WmSetFocus = 0x0007,

        /// <summary>The wm kill focus</summary>
        [Id(8), Display(Order = 8, Name = "WmKillFocus")]
        WmKillFocus = 0x0008,

        /// <summary>The wm enable</summary>
        [Id(10), Display(Order = 10, Name = "WmEnable")]
        WmEnable = 0x000A,

        /// <summary>The wm set redraw</summary>
        [Id(11), Display(Order = 11, Name = "WmSetRedraw")]
        WmSetRedraw = 0x000B,

        /// <summary>The wm set text</summary>
        [Id(12), Display(Order = 12, Name = "WmSetText")]
        WmSetText = 0x000C,

        /// <summary>The wm get text</summary>
        [Id(13), Display(Order = 13, Name = "WmGetText")]
        WmGetText = 0x000D,

        /// <summary>The wm get text length</summary>
        [Id(14), Display(Order = 14, Name = "WmGetTextLength")]
        WmGetTextLength = 0x000E,

        /// <summary>The wm paint</summary>
        [Id(15), Display(Order = 15, Name = "WmPaint")]
        WmPaint = 0x000F,

        /// <summary>The wm close</summary>
        [Id(16), Display(Order = 16, Name = "WmClose")]
        WmClose = 0x0010,

        /// <summary>The wm query end session</summary>
        [Id(17), Display(Order = 17, Name = "WmQueryEndSession")]
        WmQueryEndSession = 0x0011,

        /// <summary>The wm quit</summary>
        [Id(18), Display(Order = 18, Name = "WmQuit")]
        WmQuit = 0x0012,

        /// <summary>The wm query open</summary>
        [Id(19), Display(Order = 19, Name = "WmQueryOpen")]
        WmQueryOpen = 0x0013,

        /// <summary>The wm erase background</summary>
        [Id(20), Display(Order = 20, Name = "WmEraseBackground")]
        WmEraseBackground = 0x0014,

        /// <summary>The wm system color change</summary>
        [Id(21), Display(Order = 21, Name = "WmSysColorChange")]
        WmSysColorChange = 0x0015,

        /// <summary>The wm end session</summary>
        [Id(22), Display(Order = 22, Name = "WmEndSession")]
        WmEndSession = 0x0016,

        /// <summary>The wm show window</summary>
        [Id(24), Display(Order = 24, Name = "WmShowWindow")]
        WmShowWindow = 0x0018,

        /// <summary>The wm win ini change</summary>
        [Id(26), Display(Order = 26, Name = "WmWinIniChange")]
        WmWinIniChange = 0x001A,

        /// <summary>The wm setting change</summary>
        [Id(26), Display(Order = 26, Name = "WmSettingChange")]
        WmSettingChange = 0x001A,

        /// <summary>The wm dev mode change</summary>
        [Id(27), Display(Order = 27, Name = "WmDevModeChange")]
        WmDevModeChange = 0x001B,

        /// <summary>The wm activate application</summary>
        [Id(28), Display(Order = 28, Name = "WmActivateApp")]
        WmActivateApp = 0x001C,

        /// <summary>The wm font change</summary>
        [Id(29), Display(Order = 29, Name = "WmFontChange")]
        WmFontChange = 0x001D,

        /// <summary>The wm time change</summary>
        [Id(30), Display(Order = 30, Name = "WmTimeChange")]
        WmTimeChange = 0x001E,

        /// <summary>The wm cancel mode</summary>
        [Id(31), Display(Order = 31, Name = "WmCancelMode")]
        WmCancelMode = 0x001F,

        /// <summary>The wm set cursor</summary>
        [Id(32), Display(Order = 32, Name = "WmSetCursor")]
        WmSetCursor = 0x0020,

        /// <summary>The wm mouse activate</summary>
        [Id(33), Display(Order = 33, Name = "WmMouseActivate")]
        WmMouseActivate = 0x0021,

        /// <summary>The wm child activate</summary>
        [Id(34), Display(Order = 34, Name = "WmChildActivate")]
        WmChildActivate = 0x0022,

        /// <summary>The wm queue synchronize</summary>
        [Id(35), Display(Order = 35, Name = "WmQueueSync")]
        WmQueueSync = 0x0023,

        /// <summary>The wm get minimum maximum information</summary>
        [Id(36), Display(Order = 36, Name = "WmGetMinMaxInfo")]
        WmGetMinMaxInfo = 0x0024,

        /// <summary>The wm paint icon</summary>
        [Id(38), Display(Order = 38, Name = "WmGetMinMaxInfo")]
        WmPaintIcon = 0x0026,

        /// <summary>The wm icon erase background</summary>
        [Id(39), Display(Order = 39, Name = "WmGetMinMaxInfo")]
        WmIconEraseBackground = 0x0027,

        /// <summary>The wm next dialog control</summary>
        [Id(40), Display(Order = 40, Name = "WmGetMinMaxInfo")]
        WmNextDialogControl = 0x0028,

        /// <summary>The wm spooler status</summary>
        [Id(42), Display(Order = 42, Name = "WmGetMinMaxInfo")]
        WmSpoolerStatus = 0x002A,

        /// <summary>The wm draw item</summary>
        [Id(43), Display(Order = 43, Name = "WmGetMinMaxInfo")]
        WmDrawItem = 0x002B,

        /// <summary>The wm measure item</summary>
        [Id(44), Display(Order = 44, Name = "WmGetMinMaxInfo")]
        WmMeasureItem = 0x002C,

        /// <summary>The wm delete item</summary>
        [Id(45), Display(Order = 45, Name = "WmGetMinMaxInfo")]
        WmDeleteItem = 0x002D,

        /// <summary>The wm v key to item</summary>
        [Id(46), Display(Order = 46, Name = "WmGetMinMaxInfo")]
        WmVKeyToItem = 0x002E,

        /// <summary>The wm character to item</summary>
        [Id(47), Display(Order = 47, Name = "WmGetMinMaxInfo")]
        WmCharToItem = 0x002F,

        /// <summary>The wm set font</summary>
        [Id(48), Display(Order = 48, Name = "WmGetMinMaxInfo")]
        WmSetFont = 0x0030,

        /// <summary>The wm get font</summary>
        [Id(49), Display(Order = 49, Name = "WmGetMinMaxInfo")]
        WmGetFont = 0x0031,

        /// <summary>The wm set hot key</summary>
        [Id(50), Display(Order = 50, Name = "WmGetMinMaxInfo")]
        WmSetHotKey = 0x0032,

        /// <summary>The wm get hot key</summary>
        [Id(51), Display(Order = 51, Name = "WmGetMinMaxInfo")]
        WmGetHotKey = 0x0033,

        /// <summary>The wm query drag icon</summary>
        [Id(55), Display(Order = 55, Name = "WmGetMinMaxInfo")]
        WmQueryDragIcon = 0x0037,

        /// <summary>The wm compare item</summary>
        [Id(57), Display(Order = 57, Name = "WmGetMinMaxInfo")]
        WmCompareItem = 0x0039,

        /// <summary>The wm get object</summary>
        [Id(61), Display(Order = 61, Name = "WmGetMinMaxInfo")]
        WmGetObject = 0x003D,

        /// <summary>The wm compacting</summary>
        [Id(65), Display(Order = 65, Name = "WmGetMinMaxInfo")]
        WmCompacting = 0x0041,

        /// <summary>The wm command notify</summary>
        [Id(68), Display(Order = 68, Name = "WmGetMinMaxInfo")]
        WmCommandNotify = 0x0044,

        /// <summary>The wm window position changing</summary>
        [Id(70), Display(Order = 70, Name = "WmGetMinMaxInfo")]
        WmWindowPosChanging = 0x0046,

        /// <summary>The wm window position changed</summary>
        [Id(71), Display(Order = 71, Name = "WmGetMinMaxInfo")]
        WmWindowPosChanged = 0x0047,

        /// <summary>The wm power</summary>
        [Id(72), Display(Order = 72, Name = "WmGetMinMaxInfo")]
        WmPower = 0x0048,

        /// <summary>The wm copy data</summary>
        [Id(74), Display(Order = 74, Name = "WmGetMinMaxInfo")]
        WmCopyData = 0x004A,

        /// <summary>The wm cancel journal</summary>
        [Id(75), Display(Order = 75, Name = "WmGetMinMaxInfo")]
        WmCancelJournal = 0x004B,

        /// <summary>The wm notify</summary>
        [Id(78), Display(Order = 78, Name = "WmGetMinMaxInfo")]
        WmNotify = 0x004E,

        /// <summary>The wm input language change request</summary>
        [Id(80), Display(Order = 80, Name = "WmGetMinMaxInfo")]
        WmInputLanguageChangeRequest = 0x0050,

        /// <summary>The wm input language change</summary>
        [Id(81), Display(Order = 81, Name = "WmGetMinMaxInfo")]
        WmInputLanguageChange = 0x0051,

        /// <summary>The wm training card</summary>
        [Id(82), Display(Order = 82, Name = "WmGetMinMaxInfo")]
        WmTrainingCard = 0x0052,

        /// <summary>The wm help</summary>
        [Id(83), Display(Order = 83, Name = "WmGetMinMaxInfo")]
        WmHelp = 0x0053,

        /// <summary>The wm user changed</summary>
        [Id(84), Display(Order = 84, Name = "WmGetMinMaxInfo")]
        WmUserChanged = 0x0054,

        /// <summary>The wm notify format</summary>
        [Id(85), Display(Order = 85, Name = "WmNotifyFormat")]
        WmNotifyFormat = 0x0055,

        /// <summary>The wm context menu</summary>
        [Id(123), Display(Order = 123, Name = "WmContextMenu")]
        WmContextMenu = 0x007B,

        /// <summary>The wm style changing</summary>
        [Id(124), Display(Order = 124, Name = "WmStyleChanging")]
        WmStyleChanging = 0x007C,

        /// <summary>The wm style changed</summary>
        [Id(125), Display(Order = 125, Name = "WmStyleChanged")]
        WmStyleChanged = 0x007D,

        /// <summary>The wm display change</summary>
        [Id(126), Display(Order = 126, Name = "WmDisplayChange")]
        WmDisplayChange = 0x007E,

        /// <summary>The wm get icon</summary>
        [Id(127), Display(Order = 127, Name = "WmGetIcon")]
        WmGetIcon = 0x007F,

        /// <summary>The wm set icon</summary>
        [Id(128), Display(Order = 128, Name = "WmSetIcon")]
        WmSetIcon = 0x0080,

        /// <summary>The wm nc create</summary>
        [Id(129), Display(Order = 129, Name = "WmNcCreate")]
        WmNcCreate = 0x0081,

        /// <summary>The wm nc destroy</summary>
        [Id(130), Display(Order = 130, Name = "WmNcDestroy")]
        WmNcDestroy = 0x0082,

        /// <summary>The wm nc calculate size</summary>
        [Id(131), Display(Order = 131, Name = "WmNcCalcSize")]
        WmNcCalcSize = 0x0083,

        /// <summary>The wm nc hit test</summary>
        [Id(132), Display(Order = 132, Name = "WmNcHitTest")]
        WmNcHitTest = 0x0084,

        /// <summary>The wm nc paint</summary>
        [Id(133), Display(Order = 133, Name = "WmNcPaint")]
        WmNcPaint = 0x0085,

        /// <summary>The wm nc activate</summary>
        [Id(134), Display(Order = 134, Name = "WmNcActivate")]
        WmNcActivate = 0x0086,

        /// <summary>The wm get dialog code</summary>
        [Id(135), Display(Order = 135, Name = "WmGetDialogCode")]
        WmGetDialogCode = 0x0087,

        /// <summary>The wm synchronize paint</summary>
        [Id(136), Display(Order = 136, Name = "WmSyncPaint")]
        WmSyncPaint = 0x0088,

        /// <summary>The wm nc mouse move</summary>
        [Id(160), Display(Order = 160, Name = "WmNcMouseMove")]
        WmNcMouseMove = 0x00A0,

        /// <summary>The wm nc left button down</summary>
        [Id(161), Display(Order = 161, Name = "WmNcLeftButtonDown")]
        WmNcLeftButtonDown = 0x00A1,

        /// <summary>The wm nc left button up</summary>
        [Id(162), Display(Order = 162, Name = "WmNcLeftButtonUp")]
        WmNcLeftButtonUp = 0x00A2,

        /// <summary>The wm nc left button double click</summary>
        [Id(163), Display(Order = 163, Name = "WmNcLeftButtonDoubleClick")]
        WmNcLeftButtonDoubleClick = 0x00A3,

        /// <summary>The wm nc right button down</summary>
        [Id(164), Display(Order = 164, Name = "WmNcRightButtonDown")]
        WmNcRightButtonDown = 0x00A4,

        /// <summary>The wm nc right button up</summary>
        [Id(165), Display(Order = 165, Name = "WmNcRightButtonUp")]
        WmNcRightButtonUp = 0x00A5,

        /// <summary>The wm nc right button double click</summary>
        [Id(166), Display(Order = 166, Name = "WmNcRightButtonDoubleClick")]
        WmNcRightButtonDoubleClick = 0x00A6,

        /// <summary>The wm nc middle button down</summary>
        [Id(167), Display(Order = 167, Name = "WmNcRightButtonDoubleClick")]
        WmNcMiddleButtonDown = 0x00A7,

        /// <summary>The wm nc middle Button up</summary>
        [Id(168), Display(Order = 168, Name = "WmNcRightButtonDoubleClick")]
        WmNcMiddleButtonUp = 0x00A8,

        /// <summary>The wm nc middle button double click</summary>
        [Id(169), Display(Order = 169, Name = "WmNcRightButtonDoubleClick")]
        WmNcMiddleButtonDoubleClick = 0x00A9,

        /// <summary>The wm nc x button down</summary>
        [Id(171), Display(Order = 171, Name = "WmNcRightButtonDoubleClick")]
        WmNcXButtonDown = 0x00AB,

        /// <summary>The wm nc x button up</summary>
        [Id(172), Display(Order = 172, Name = "WmNcRightButtonDoubleClick")]
        WmNcXButtonUp = 0x00AC,

        /// <summary>The wm nc x button double click</summary>
        [Id(173), Display(Order = 173, Name = "WmNcRightButtonDoubleClick")]
        WmNcXButtonDoubleClick = 0x00AD,

        /// <summary>The wm input device change</summary>
        [Id(254), Display(Order = 254, Name = "WmNcRightButtonDoubleClick")]
        WmInputDeviceChange = 0x00FE,

        /// <summary>The wm input</summary>
        [Id(255), Display(Order = 255, Name = "WmNcRightButtonDoubleClick")]
        WmInput = 0x00FF,

        /// <summary>The wm key first</summary>
        [Id(256), Display(Order = 256, Name = "WmNcRightButtonDoubleClick")]
        WmKeyFirst = 0x0100,

        /// <summary>The wm key down</summary>
        [Id(256), Display(Order = 256, Name = "WmNcRightButtonDoubleClick")]
        WmKeyDown = 0x0100,

        /// <summary>The wm key up</summary>
        [Id(257), Display(Order = 257, Name = "WmNcRightButtonDoubleClick")]
        WmKeyUp = 0x0101,

        /// <summary>The wm character</summary>
        [Id(258), Display(Order = 258, Name = "WmNcRightButtonDoubleClick")]
        WmChar = 0x0102,

        /// <summary>The wm dead character</summary>
        [Id(259), Display(Order = 259, Name = "WmNcRightButtonDoubleClick")]
        WmDeadChar = 0x0103,

        /// <summary>The wm system key down</summary>
        [Id(260), Display(Order = 260, Name = "WmNcRightButtonDoubleClick")]
        WmSysKeyDown = 0x0104,

        /// <summary>The wm system key up</summary>
        [Id(261), Display(Order = 261, Name = "WmNcRightButtonDoubleClick")]
        WmSysKeyUp = 0x0105,

        /// <summary>The wm system character</summary>
        [Id(262), Display(Order = 262, Name = "WmNcRightButtonDoubleClick")]
        WmSysChar = 0x0106,

        /// <summary>The wm system dead character</summary>
        [Id(263), Display(Order = 263, Name = "WmNcRightButtonDoubleClick")]
        WmSysDeadChar = 0x0107,

        /// <summary>The wm uni character</summary>
        [Id(265), Display(Order = 265, Name = "WmNcRightButtonDoubleClick")]
        WmUniChar = 0x0109,

        /// <summary>The wm key last</summary>
        [Id(265), Display(Order = 265, Name = "WmNcRightButtonDoubleClick")]
        WmKeyLast = 0x0109,

        /// <summary>The wm IME start composition</summary>
        [Id(269), Display(Order = 269, Name = "WmNcRightButtonDoubleClick")]
        WmImeStartComposition = 0x010D,

        /// <summary>The wm IME end composition</summary>
        [Id(270), Display(Order = 270, Name = "WmNcRightButtonDoubleClick")]
        WmImeEndComposition = 0x010E,

        /// <summary>The wm IME composition</summary>
        [Id(271), Display(Order = 271, Name = "WmNcRightButtonDoubleClick")]
        WmImeComposition = 0x010F,

        /// <summary>The wm IME key last</summary>
        [Id(271), Display(Order = 271, Name = "WmNcRightButtonDoubleClick")]
        WmImeKeyLast = 0x010F,

        /// <summary>The wm initialize dialog</summary>
        [Id(272), Display(Order = 272, Name = "WmNcRightButtonDoubleClick")]
        WmInitDialog = 0x0110,

        /// <summary>The wm command</summary>
        [Id(273), Display(Order = 273, Name = "WmNcRightButtonDoubleClick")]
        WmCommand = 0x0111,

        /// <summary>The wm system command</summary>
        [Id(274), Display(Order = 274, Name = "WmNcRightButtonDoubleClick")]
        WmSysCommand = 0x0112,

        /// <summary>The wm timer</summary>
        [Id(275), Display(Order = 275, Name = "WmNcRightButtonDoubleClick")]
        WmTimer = 0x0113,

        /// <summary>The wm horizontal scroll</summary>
        [Id(276), Display(Order = 276, Name = "WmNcRightButtonDoubleClick")]
        WmHorizontalScroll = 0x0114,

        /// <summary>The wm vertical scroll</summary>
        [Id(277), Display(Order = 277, Name = "WmNcRightButtonDoubleClick")]
        WmVerticalScroll = 0x0115,

        /// <summary>The wm initialize menu</summary>
        [Id(278), Display(Order = 278, Name = "WmNcRightButtonDoubleClick")]
        WmInitMenu = 0x0116,

        /// <summary>The wm initialize menu popup</summary>
        [Id(279), Display(Order = 279, Name = "WmInitMenuPopup")]
        WmInitMenuPopup = 0x0117,

        /// <summary>The wm menu select</summary>
        [Id(287), Display(Order = 287, Name = "WmMenuSelect")]
        WmMenuSelect = 0x011F,

        /// <summary>The wm menu character</summary>
        [Id(288), Display(Order = 288, Name = "WmMenuChar")]
        WmMenuChar = 0x0120,

        /// <summary>The wm enter idle</summary>
        [Id(289), Display(Order = 289, Name = "WmEnterIdle")]
        WmEnterIdle = 0x0121,

        /// <summary>The wm menu right button up</summary>
        [Id(290), Display(Order = 290, Name = "WmMenuRightButtonUp")]
        WmMenuRightButtonUp = 0x0122,

        /// <summary>The wm menu drag</summary>
        [Id(291), Display(Order = 291, Name = "WmMenuDrag")]
        WmMenuDrag = 0x0123,

        /// <summary>The wm menu get object</summary>
        [Id(292), Display(Order = 292, Name = "WmMenuGetObject")]
        WmMenuGetObject = 0x0124,

        /// <summary>The wm unInit menu pop up</summary>
        [Id(293), Display(Order = 293, Name = "WmUnInitMenuPopUp")]
        WmUnInitMenuPopUp = 0x0125,

        /// <summary>The wm menu command</summary>
        [Id(294), Display(Order = 294, Name = "WmMenuCommand")]
        WmMenuCommand = 0x0126,

        /// <summary>The wm change UI state</summary>
        [Id(295), Display(Order = 295, Name = "WmChangeUiState")]
        WmChangeUiState = 0x0127,

        /// <summary>The wm update UI state</summary>
        [Id(296), Display(Order = 296, Name = "WmUpdateUiState")]
        WmUpdateUiState = 0x0128,

        /// <summary>The wm query UI state</summary>
        [Id(297), Display(Order = 297, Name = "WmQueryUiState")]
        WmQueryUiState = 0x0129,

        /// <summary>The wm control color message box</summary>
        [Id(306), Display(Order = 306, Name = "WmCtlColorMessageBox")]
        WmCtlColorMessageBox = 0x0132,

        /// <summary>The wm control color edit</summary>
        [Id(307), Display(Order = 307, Name = "WmCtlColorEdit")]
        WmCtlColorEdit = 0x0133,

        /// <summary>The wm control color ListBox</summary>
        [Id(308), Display(Order = 308, Name = "WmCtlColorListBox")]
        WmCtlColorListBox = 0x0134,

        /// <summary>The wm control color button</summary>
        [Id(309), Display(Order = 309, Name = "WmCtlColorButton")]
        WmCtlColorButton = 0x0135,

        /// <summary>The wm control color dialog</summary>
        [Id(310), Display(Order = 310, Name = "WmCtlColorDialog")]
        WmCtlColorDialog = 0x0136,

        /// <summary>The wm control color scroll bar</summary>
        [Id(311), Display(Order = 311, Name = "WmCtlColorScrollBar")]
        WmCtlColorScrollBar = 0x0137,

        /// <summary>The wm control color static</summary>
        [Id(312), Display(Order = 312, Name = "WmCtlColorStatic")]
        WmCtlColorStatic = 0x0138,

        /// <summary>The mn get horizontal menu</summary>
        [Id(481), Display(Order = 481, Name = "MnGetHorizontalMenu")]
        MnGetHorizontalMenu = 0x01E1,

        /// <summary>The wm mouse first</summary>
        [Id(512), Display(Order = 512, Name = "WmMouseFirst")]
        WmMouseFirst = 0x0200,

        /// <summary>The wm mouse move</summary>
        [Id(512), Display(Order = 512, Name = "WmMouseMove")]
        WmMouseMove = 0x0200,

        /// <summary>The wm l button down</summary>
        [Id(513), Display(Order = 513, Name = "WmLButtonDown")]
        WmLButtonDown = 0x0201,

        /// <summary>The wm left button up</summary>
        [Id(514), Display(Order = 514, Name = "WmLeftButtonUp")]
        WmLeftButtonUp = 0x0202,

        /// <summary>The wm left button double click</summary>
        [Id(515), Display(Order = 515, Name = "WmLeftButtonDoubleClick")]
        WmLeftButtonDoubleClick = 0x0203,

        /// <summary>The wm right button down</summary>
        [Id(516), Display(Order = 516, Name = "WmRightButtonDown")]
        WmRightButtonDown = 0x0204,

        /// <summary>The wm right button up</summary>
        [Id(517), Display(Order = 517, Name = "WmRightButtonUp")]
        WmRightButtonUp = 0x0205,

        /// <summary>The wm right button double click</summary>
        [Id(518), Display(Order = 518, Name = "WmRightButtonDoubleClick")]
        WmRightButtonDoubleClick = 0x0206,

        /// <summary>The wm middle button down</summary>
        [Id(519), Display(Order = 519, Name = "WmMiddleButtonDown")]
        WmMiddleButtonDown = 0x0207,

        /// <summary>The wm middle button up</summary>
        [Id(520), Display(Order = 520, Name = "WmMiddleButtonUp")]
        WmMiddleButtonUp = 0x0208,

        /// <summary>The wm middle button double click</summary>
        [Id(521), Display(Order = 521, Name = "WmMiddleButtonDoubleClick")]
        WmMiddleButtonDoubleClick = 0x0209,

        /// <summary>The wm mouse wheel</summary>
        [Id(522), Display(Order = 522, Name = "WmMouseWheel")]
        WmMouseWheel = 0x020A,

        /// <summary>The wm x button down</summary>
        [Id(523), Display(Order = 523, Name = "WmXButtonDown")]
        WmXButtonDown = 0x020B,

        /// <summary>The wm x button up</summary>
        [Id(524), Display(Order = 524, Name = "WmXButtonUp")]
        WmXButtonUp = 0x020C,

        /// <summary>The wm x button double click</summary>
        [Id(525), Display(Order = 525, Name = "WmXButtonDoubleClick")]
        WmXButtonDoubleClick = 0x020D,

        /// <summary>The wm mouse horizontal wheel</summary>
        [Id(526), Display(Order = 526, Name = "WmMouseHorizontalWheel")]
        WmMouseHorizontalWheel = 0x020E,

        /// <summary>The wm parent notify</summary>
        [Id(528), Display(Order = 528, Name = "WmParentNotify")]
        WmParentNotify = 0x0210,

        /// <summary>The wm enter menu loop</summary>
        [Id(529), Display(Order = 529, Name = "WmEnterMenuLoop")]
        WmEnterMenuLoop = 0x0211,

        /// <summary>The wm exit menu loop</summary>
        [Id(530), Display(Order = 530, Name = "WmExitMenuLoop")]
        WmExitMenuLoop = 0x0212,

        /// <summary>The wm next menu</summary>
        [Id(531), Display(Order = 531, Name = "WmNextMenu")]
        WmNextMenu = 0x0213,

        /// <summary>The wm sizing</summary>
        [Id(532), Display(Order = 532, Name = "WmSizing")]
        WmSizing = 0x0214,

        /// <summary>The wm capture changed</summary>
        [Id(533), Display(Order = 533, Name = "WmCaptureChanged")]
        WmCaptureChanged = 0x0215,

        /// <summary>The wm moving</summary>
        [Id(534), Display(Order = 534, Name = "WmMoving")]
        WmMoving = 0x0216,

        /// <summary>The wm power broadcast</summary>
        [Id(536), Display(Order = 536, Name = "WmPowerBroadcast")]
        WmPowerBroadcast = 0x0218,

        /// <summary>The wm device change</summary>
        [Id(537), Display(Order = 537, Name = "WmDeviceChange")]
        WmDeviceChange = 0x0219,

        /// <summary>The wm MDI create</summary>
        [Id(544), Display(Order = 544, Name = "WmMdiCreate")]
        WmMdiCreate = 0x0220,

        /// <summary>The wm MDI destroy</summary>
        [Id(545), Display(Order = 545, Name = "WmMdiDestroy")]
        WmMdiDestroy = 0x0221,

        /// <summary>The wm MDI activate</summary>
        [Id(546), Display(Order = 546, Name = "WmMdiActivate")]
        WmMdiActivate = 0x0222,

        /// <summary>The wm MDI restore</summary>
        [Id(547), Display(Order = 547, Name = "WmMdiRestore")]
        WmMdiRestore = 0x0223,

        /// <summary>The wm MDI next</summary>
        [Id(548), Display(Order = 548, Name = "WmMdiNext")]
        WmMdiNext = 0x0224,

        /// <summary>The wm MDI maximize</summary>
        [Id(549), Display(Order = 549, Name = "WmMdiMaximize")]
        WmMdiMaximize = 0x0225,

        /// <summary>The wm MDI tile</summary>
        [Id(550), Display(Order = 550, Name = "WmMdiTile")]
        WmMdiTile = 0x0226,

        /// <summary>The wm MDI cascade</summary>
        [Id(551), Display(Order = 551, Name = "WmMdiCascade")]
        WmMdiCascade = 0x0227,

        /// <summary>The wm MDI icon arrange</summary>
        [Id(552), Display(Order = 552, Name = "WmMdiIconArrange")]
        WmMdiIconArrange = 0x0228,

        /// <summary>The wm MDI get active</summary>
        [Id(553), Display(Order = 553, Name = "WmMdiGetActive")]
        WmMdiGetActive = 0x0229,

        /// <summary>The wm MDI set menu</summary>
        [Id(560), Display(Order = 560, Name = "WmMdiSetMenu")]
        WmMdiSetMenu = 0x0230,

        /// <summary>The wm enter size move</summary>
        [Id(561), Display(Order = 561, Name = "WmEnterSizeMove")]
        WmEnterSizeMove = 0x0231,

        /// <summary>The wm exit size move</summary>
        [Id(562), Display(Order = 562, Name = "WmExitSizeMove")]
        WmExitSizeMove = 0x0232,

        /// <summary>The wm drop files</summary>
        [Id(563), Display(Order = 563, Name = "WmDropFiles")]
        WmDropFiles = 0x0233,

        /// <summary>The wm MDI refresh menu</summary>
        [Id(564), Display(Order = 564, Name = "WmMdiRefreshMenu")]
        WmMdiRefreshMenu = 0x0234,

        /// <summary>The wm IME set context</summary>
        [Id(641), Display(Order = 641, Name = "WmImeSetContext")]
        WmImeSetContext = 0x0281,

        /// <summary>The wm IME notify</summary>
        [Id(642), Display(Order = 642, Name = "WmImeNotify")]
        WmImeNotify = 0x0282,

        /// <summary>The wm IME control</summary>
        [Id(643), Display(Order = 643, Name = "WmImeControl")]
        WmImeControl = 0x0283,

        /// <summary>The wm IME composition full</summary>
        [Id(644), Display(Order = 644, Name = "WmImeCompositionFull")]
        WmImeCompositionFull = 0x0284,

        /// <summary>The wm IME select</summary>
        [Id(645), Display(Order = 645, Name = "WmImeSelect")]
        WmImeSelect = 0x0285,

        /// <summary>The wm IME character</summary>
        [Id(646), Display(Order = 646, Name = "WmImeChar")]
        WmImeChar = 0x0286,

        /// <summary>The wm IME request</summary>
        [Id(648), Display(Order = 648, Name = "WmImeRequest")]
        WmImeRequest = 0x0288,

        /// <summary>The wm IME key down</summary>
        [Id(656), Display(Order = 656, Name = "WmImeKeyDown")]
        WmImeKeyDown = 0x0290,

        /// <summary>The wm IME key up</summary>
        [Id(657), Display(Order = 657, Name = "WmImeKeyUp")]
        WmImeKeyUp = 0x0291,

        /// <summary>The wm nc mouse hover</summary>
        [Id(672), Display(Order = 672, Name = "WmImeKeyUp")]
        WmNcMouseHover = 0x02A0,

        /// <summary>The wm mouse hover</summary>
        [Id(673), Display(Order = 673, Name = "WmImeKeyUp")]
        WmMouseHover = 0x02A1,

        /// <summary>The wm nc mouse leave</summary>
        [Id(674), Display(Order = 674, Name = "WmImeKeyUp")]
        WmNcMouseLeave = 0x02A2,

        /// <summary>The wm mouse leave</summary>
        [Id(675), Display(Order = 675, Name = "WmImeKeyUp")]
        WmMouseLeave = 0x02A3,

        /// <summary>The wm WTS session change</summary>
        [Id(689), Display(Order = 689, Name = "WmImeKeyUp")]
        WmWtsSessionChange = 0x02B1,

        /// <summary>The wm tablet first</summary>
        [Id(704), Display(Order = 704, Name = "WmImeKeyUp")]
        WmTabletFirst = 0x02C0,

        /// <summary>The wm tablet last</summary>
        [Id(735), Display(Order = 735, Name = "WmImeKeyUp")]
        WmTabletLast = 0x02DF,

        /// <summary>The wm cut</summary>
        [Id(768), Display(Order = 768, Name = "WmImeKeyUp")]
        WmCut = 0x0300,

        /// <summary>The wm copy</summary>
        [Id(769), Display(Order = 769, Name = "WmImeKeyUp")]
        WmCopy = 0x0301,

        /// <summary>The wm paste</summary>
        [Id(770), Display(Order = 770, Name = "WmImeKeyUp")]
        WmPaste = 0x0302,

        /// <summary>The wm clear</summary>
        [Id(771), Display(Order = 771, Name = "WmImeKeyUp")]
        WmClear = 0x0303,

        /// <summary>The wm undo</summary>
        [Id(772), Display(Order = 772, Name = "WmImeKeyUp")]
        WmUndo = 0x0304,

        /// <summary>The wm render format</summary>
        [Id(773), Display(Order = 773, Name = "WmImeKeyUp")]
        WmRenderFormat = 0x0305,

        /// <summary>The wm render all formats</summary>
        [Id(774), Display(Order = 774, Name = "WmImeKeyUp")]
        WmRenderAllFormats = 0x0306,

        /// <summary>The wm destroy clipboard</summary>
        [Id(775), Display(Order = 775, Name = "WmImeKeyUp")]
        WmDestroyClipboard = 0x0307,

        /// <summary>The wm draw clipboard</summary>
        [Id(776), Display(Order = 776, Name = "WmImeKeyUp")]
        WmDrawClipboard = 0x0308,

        /// <summary>The wm paint clipboard</summary>
        [Id(777), Display(Order = 777, Name = "WmImeKeyUp")]
        WmPaintClipboard = 0x0309,

        /// <summary>The wm vertical scroll clipboard</summary>
        [Id(778), Display(Order = 778, Name = "WmImeKeyUp")]
        WmVerticalScrollClipboard = 0x030A,

        /// <summary>The wm size clipboard</summary>
        [Id(779), Display(Order = 779, Name = "WmSizeClipboard")]
        WmSizeClipboard = 0x030B,

        /// <summary>The wm ask cb format name</summary>
        [Id(780), Display(Order = 780, Name = "WmAskCbFormatName")]
        WmAskCbFormatName = 0x030C,

        /// <summary>The wm change cb chain</summary>
        [Id(781), Display(Order = 781, Name = "WmAskCbFormatName")]
        WmChangeCbChain = 0x030D,

        /// <summary>The wm horizontal scroll clipboard</summary>
        [Id(782), Display(Order = 782, Name = "WmAskCbFormatName")]
        WmHorizontalScrollClipboard = 0x030E,

        /// <summary>The wm query new palette</summary>
        [Id(783), Display(Order = 783, Name = "WmAskCbFormatName")]
        WmQueryNewPalette = 0x030F,

        /// <summary>The wm palette is changing</summary>
        [Id(784), Display(Order = 784, Name = "WmAskCbFormatName")]
        WmPaletteIsChanging = 0x0310,

        /// <summary>The wm palette changed</summary>
        [Id(785), Display(Order = 785, Name = "WmAskCbFormatName")]
        WmPaletteChanged = 0x0311,

        /// <summary>The wm hot key</summary>
        [Id(786), Display(Order = 786, Name = "WmAskCbFormatName")]
        WmHotKey = 0x0312,

        /// <summary>The wm print</summary>
        [Id(791), Display(Order = 791, Name = "WmAskCbFormatName")]
        WmPrint = 0x0317,

        /// <summary>The wm print client</summary>
        [Id(792), Display(Order = 792, Name = "WmAskCbFormatName")]
        WmPrintClient = 0x0318,

        /// <summary>The wm application command</summary>
        [Id(793), Display(Order = 793, Name = "WmAskCbFormatName")]
        WmAppCommand = 0x0319,

        /// <summary>The wm theme changed</summary>
        [Id(794), Display(Order = 794, Name = "WmAskCbFormatName")]
        WmThemeChanged = 0x031A,

        /// <summary>The wm clipboard update</summary>
        [Id(797), Display(Order = 797, Name = "WmAskCbFormatName")]
        WmClipboardUpdate = 0x031D,

        /// <summary>The wm DWM composition changed</summary>
        [Id(798), Display(Order = 798, Name = "WmAskCbFormatName")]
        WmDwmCompositionChanged = 0x031E,

        /// <summary>The wm DWM nc rendering changed</summary>
        [Id(799), Display(Order = 799, Name = "WmAskCbFormatName")]
        WmDwmNcRenderingChanged = 0x031F,

        /// <summary>The wm DWM colorization color changed</summary>
        [Id(800), Display(Order = 800, Name = "WmAskCbFormatName")]
        WmDwmColorizationColorChanged = 0x0320,

        /// <summary>The wm DWM window maximized change</summary>
        [Id(801), Display(Order = 801, Name = "WmAskCbFormatName")]
        WmDwmWindowMaximizedChange = 0x0321,

        /// <summary>The wm get titlebar information ex</summary>
        [Id(831), Display(Order = 831, Name = "WmAskCbFormatName")]
        WmGetTitlebarInfoEx = 0x033F,

        /// <summary>The wm handheld first</summary>
        [Id(856), Display(Order = 856, Name = "WmAskCbFormatName")]
        WmHandheldFirst = 0x0358,

        /// <summary>The wm handheld last</summary>
        [Id(863), Display(Order = 863, Name = "WmAskCbFormatName")]
        WmHandheldLast = 0x035F,

        /// <summary>The wm afx first</summary>
        [Id(864), Display(Order = 864, Name = "WmAfxFirst")]
        WmAfxFirst = 0x0360,

        /// <summary>The wm afx last</summary>
        [Id(895), Display(Order = 895, Name = "WmAfxLast")]
        WmAfxLast = 0x037F,

        /// <summary>The wm pen win first</summary>
        [Id(896), Display(Order = 896, Name = "WmPenWinFirst")]
        WmPenWinFirst = 0x0380,

        /// <summary>The wm pen win last</summary>
        [Id(911), Display(Order = 911, Name = "WmPenWinLast")]
        WmPenWinLast = 0x038F,

        /// <summary>The wm user</summary>
        [Id(1024), Display(Order = 1024, Name = "WmUser")]
        WmUser = 0x0400,

        /// <summary>The wm reflect</summary>
        [Id(8192), Display(Order = 8192, Name = "WmReflect")]
        WmReflect = 0x2000,

        /// <summary>The wm application</summary>
        [Id(32768), Display(Order = 32768, Name = "WmApp")]
        WmApp = 0x8000,
    }
}
