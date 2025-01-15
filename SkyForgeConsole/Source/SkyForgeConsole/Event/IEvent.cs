/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public interface IEvent
    {
        bool IsHandled { get; }
        
        EventType GetEventType();

        string GetName();
        bool IsEventCategory(EventCategory eventCategory);
    }
}

