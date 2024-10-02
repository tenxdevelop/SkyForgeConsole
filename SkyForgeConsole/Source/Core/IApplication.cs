/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface IApplication : IDisposable
    {
        void Init();
        void Exit();
        void Run();
    }
}