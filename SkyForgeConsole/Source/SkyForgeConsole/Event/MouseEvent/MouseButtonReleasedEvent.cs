/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class MouseButtonReleasedEvent : MouseButtonEvent
    {
        public MouseButtonReleasedEvent(MouseButton mouseButton) : base(EventType.MouseButtonReleased, mouseButton)
        {
            
        }

        public override string GetName() => nameof(MouseButtonReleasedEvent);
        
        public override string ToString() => $"event: {GetName()} releasedButton: {GetMouseButton()}";
    }
}

