/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class MouseButtonPressedEvent : MouseButtonEvent
    {
        public MouseButtonPressedEvent(MouseButton mouseButton) : base(EventType.MouseButtonPressed, mouseButton)
        {
            
        }
        public override string GetName() => nameof(MouseButtonPressedEvent);

        public override string ToString() => $"event: {GetName()} pressedButton: {GetMouseButton()}";
    }
}

