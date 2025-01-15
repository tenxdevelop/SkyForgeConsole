/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class MouseScrollEvent : Event, IMouseScrollEvent
    {
        private float m_xOffset;
        private float m_yOffset;
        
        public MouseScrollEvent(float xOffset, float yOffset) : base(EventType.MouseScrolled, EventCategory.MouseEvent)
        {
            m_xOffset = xOffset;
            m_yOffset = yOffset;
        }

        public override string GetName() => nameof(MouseScrollEvent);

        public override string ToString() => $"event: {GetName()} (xOffset: {GetXOffest().ToString().Replace(',', '.')}, yOffset: {GetYOffest().ToString().Replace(',', '.')})";
        
        public float GetXOffest() => m_xOffset;
        
        public float GetYOffest() => m_yOffset;
    }
}