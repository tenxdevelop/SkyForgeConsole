/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Event
{
    public interface IEvent
    {
        bool IsHandled { get; }
        
        EventType GetEventType();
        
        bool IsEventCategory(EventCategory eventCategory);
    }
}

