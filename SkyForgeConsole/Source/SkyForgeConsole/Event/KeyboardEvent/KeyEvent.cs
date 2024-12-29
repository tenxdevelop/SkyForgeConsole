/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Event
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