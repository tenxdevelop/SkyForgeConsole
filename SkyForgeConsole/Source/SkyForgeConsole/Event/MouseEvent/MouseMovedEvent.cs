/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Maths;

namespace SkyForgeConsole.Events
{
    public class MouseMovedEvent : Event, IMouseMovedEvent
    {
        public Vector2 MousePosition => m_mousePosition;
        
        private Vector2 m_mousePosition;
        public MouseMovedEvent(Vector2 movedPosition) : base(EventType.MouseMoved, EventCategory.MouseEvent)
        {
            m_mousePosition = movedPosition;
        }
        
        public override string GetName() => nameof(MouseMovedEvent);
        
        public override string ToString() => $"event: {GetName()}{m_mousePosition}";
    }
}

