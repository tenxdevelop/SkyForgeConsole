/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class KeyReleasedEvent : KeyEvent
    {
        public KeyReleasedEvent(KeyCode keyCode) : base(EventType.KeyReleased, keyCode)
        {
            
        }
        
        public override string GetName() => nameof(KeyReleasedEvent);
        
        public override string ToString() => $"event: {GetName()} releasedKey: {m_keyCode}";
    }
}