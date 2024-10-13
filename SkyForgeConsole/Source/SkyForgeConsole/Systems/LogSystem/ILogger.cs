/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
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