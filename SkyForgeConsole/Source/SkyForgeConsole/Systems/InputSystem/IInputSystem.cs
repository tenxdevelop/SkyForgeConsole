/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface IInputSystem : IDisposable
    {
        event Action<Events.Event> OnEvent;
        
        void Init();

        void Run();
    }
}

