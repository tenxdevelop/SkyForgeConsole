/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Event
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

