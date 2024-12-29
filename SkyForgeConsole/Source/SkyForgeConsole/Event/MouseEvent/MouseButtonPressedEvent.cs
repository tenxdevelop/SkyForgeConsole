/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Event
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

