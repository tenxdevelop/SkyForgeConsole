/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole
{
    public interface ILogger
    {
        void Logging(string message, LogLevel level);
        bool Equals(ILogger logger);
    }
}