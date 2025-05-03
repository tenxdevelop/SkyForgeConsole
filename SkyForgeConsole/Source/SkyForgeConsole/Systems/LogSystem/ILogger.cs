/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface ILogger : IDisposable
    {
        void Logging(string message, LogLevel level);
        bool Equals(ILogger logger);
    }
}