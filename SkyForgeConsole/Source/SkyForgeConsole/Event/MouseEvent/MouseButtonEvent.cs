/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public abstract class MouseButtonEvent : Event, IMouseButtonEvent
    {
        protected MouseButton m_mouseButton;
        
        public MouseButtonEvent(EventType eventType, MouseButton mouseButton) : base(eventType, EventCategory.InputEvent | EventCategory.MouseEvent)
        {
            m_mouseButton = mouseButton;
        }
        
        public MouseButton GetMouseButton() => m_mouseButton;
        
    }
}