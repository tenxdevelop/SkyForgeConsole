/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class MouseMovedEvent : Event, IMouseMovedEvent
    {
        private float m_x;
        private float m_y;
        
        public MouseMovedEvent(float xMoved, float yMoved) : base(EventType.MouseMoved, EventCategory.MouseEvent)
        {
            m_x = xMoved;
            m_y = yMoved;
        }
        public override string GetName() => nameof(MouseMovedEvent);
        
        public override string ToString() => $"event: {GetName()} (x: {GetX().ToString().Replace(',', '.')}, y: {GetY().ToString().Replace(',', '.')})";
        public float GetX() => m_x;
        public float GetY() => m_y;
    }
}

