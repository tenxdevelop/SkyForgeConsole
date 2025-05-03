/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface IApplication : IDisposable
    {
        void PushLayer(Layer layer);
        void PopLayer(Layer layer);
        void PushOverlay(Layer layer);
        void PopOverlay(Layer layer);
        void Init();
        void Exit();
        void Run();
    }
}