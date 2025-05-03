/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    
    public class KeyPressedEvent : KeyEvent
    {
        private int m_pressedCount;
        
        public KeyPressedEvent(KeyCode keyCode, int pressedCount = 0) : base(EventType.KeyPressed, keyCode)
        {
            m_pressedCount = pressedCount;
        }
        
        public int GetRepeatCount() => m_pressedCount;
        public void Pressed()
        {
            m_pressedCount++;
        }
        
        public override string GetName() => nameof(KeyPressedEvent);

        public override string ToString() => $"event: {GetName()} pressedKey: {m_keyCode}";
    }
}