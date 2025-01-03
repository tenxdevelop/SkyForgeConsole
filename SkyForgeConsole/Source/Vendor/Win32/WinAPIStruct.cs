/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace SkyForgeConsole.Vendor.Win32
{
    internal class WinAPIStruct
    {
        internal const IntPtr WM_KEYDOWN = 0x8000;
        internal const string USER_32_DLL = "user32.dll";
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;
    }
}

