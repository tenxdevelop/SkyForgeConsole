/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Event
{
    public abstract class Event : IEvent
    {
        public bool IsHandled => m_isHandled;

        protected bool m_isHandled;
        
        private EventCategory m_eventCategory;
        private EventType m_eventType;

        public Event(EventType eventType, EventCategory eventCategory)
        {
            m_eventCategory = eventCategory;
            m_eventType = eventType;
        }
        
        public EventType GetEventType() => m_eventType;

        public bool IsEventCategory(EventCategory eventCategory)
        {
            return (m_eventCategory & eventCategory) == eventCategory;
        }
    }
}

