/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface IInputSystem : IDisposable
    {
        event Action<Event.Event> OnEvent;
        
        void Init();

        void Run();
    }
}

