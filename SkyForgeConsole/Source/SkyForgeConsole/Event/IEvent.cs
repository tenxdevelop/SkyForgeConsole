/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
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

