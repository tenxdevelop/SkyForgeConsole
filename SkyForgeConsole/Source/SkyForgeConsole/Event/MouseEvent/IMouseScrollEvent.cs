/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Maths;

namespace SkyForgeConsole.Events
{
    public interface IMouseScrollEvent
    {
        Vector2 MousePositionOffset { get; }
    }
}

