/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System.Runtime.InteropServices;

namespace SkyForgeConsole.Vendor.Win32
{
    internal class WinAPINative
    {
        
        [DllImport(WinAPIStruct.USER_32_DLL)]
        internal static extern bool GetCursorPos(out POINT lpPoint);
        
        [DllImport(WinAPIStruct.USER_32_DLL)]
        private static extern short GetAsyncKeyState(int vKey);

        internal static bool GetKeyState(int vKey)
        {
            return (GetAsyncKeyState(vKey) & WinAPIStruct.WM_KEYDOWN) != 0;
        }
    }
}

