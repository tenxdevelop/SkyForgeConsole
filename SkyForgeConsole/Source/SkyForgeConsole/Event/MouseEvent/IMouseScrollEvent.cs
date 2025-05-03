/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Maths;

namespace SkyForgeConsole.Events
{
    public interface IMouseScrollEvent
    {
        Vector2 MousePositionOffset { get; }
    }
}

