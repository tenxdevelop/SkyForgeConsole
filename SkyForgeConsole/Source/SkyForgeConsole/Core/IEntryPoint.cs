/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface IEntryPoint : IDisposable
    {
        void Init(IApplication application);
        IApplication GetApplication();
    }
}