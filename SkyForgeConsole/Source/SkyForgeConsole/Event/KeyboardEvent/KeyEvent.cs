/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public abstract class KeyEvent : Event, IKeyEvent
    {
        protected KeyCode m_keyCode;

        public KeyEvent(EventType eventType, KeyCode keyCode) : 
               base(eventType, EventCategory.KeyboardEvent | EventCategory.InputEvent)
        {
            m_keyCode = keyCode;
        }

        public KeyCode GetKeyCode() => m_keyCode;
    }
}