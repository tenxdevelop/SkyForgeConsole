/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{

    public interface ILogSystem : IDisposable
    {
        string Name { get; }
        void Logging(string message, LogLevel level);
        void AddLogger(ILogger logger);
    }

}