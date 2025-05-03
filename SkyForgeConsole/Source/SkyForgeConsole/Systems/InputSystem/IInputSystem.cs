/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
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

