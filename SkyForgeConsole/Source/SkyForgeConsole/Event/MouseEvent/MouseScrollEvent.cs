/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Maths;

namespace SkyForgeConsole.Events
{
    public class MouseScrollEvent : Event, IMouseScrollEvent
    {
        public Vector2 MousePositionOffset => m_mousePositionOffset;
        private Vector2 m_mousePositionOffset;
        public MouseScrollEvent(Vector2 positionOffset) : base(EventType.MouseScrolled, EventCategory.MouseEvent)
        {
            m_mousePositionOffset = positionOffset;
        }
        public override string GetName() => nameof(MouseScrollEvent);

        public override string ToString() => $"event: {GetName()} offset:{m_mousePositionOffset}";
    }
}