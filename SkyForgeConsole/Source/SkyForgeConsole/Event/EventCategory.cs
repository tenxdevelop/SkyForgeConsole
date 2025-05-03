/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public enum EventCategory
    {
        MouseEvent = 1 << 0,
        KeyboardEvent = 1 << 1,
        ApplicationEvent = 1 << 2,
        InputEvent = 1 << 3
    }
}

