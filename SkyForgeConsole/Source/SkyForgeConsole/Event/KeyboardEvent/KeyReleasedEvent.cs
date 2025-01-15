/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
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