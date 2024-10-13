/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;

namespace SkyForgeConsole
{

    public class LogSystem : ILogSystem
    {
        public string Name => m_nameLogSystem;

        private List<ILogger> m_loggers = new List<ILogger>();

        private string m_nameLogSystem;

        public LogSystem(string nameLogSystem)
        {
            m_nameLogSystem = nameLogSystem;
        }

        public void AddLogger(ILogger logger)
        {
            if(!m_loggers.Contains(logger))
                m_loggers.Add(logger);
        }

        public void Logging(string message, LogLevel level)
        {
            foreach (var logger in m_loggers)
            {
#if SKY_FORGE_TEST || SKY_FORGE_DEBUG
                if(level >= LogLevel.Defualt)
                    logger.Logging(Patern(message), level);
#else
                if(level >= LogLevel.Warn)
                    logger.Logging(Patern(message), level);
#endif
            }
        }

        private string Patern(string message)
        {
            return $" {m_nameLogSystem} : " + message;
        }

        public void Dispose()
        {
            foreach (var logger in m_loggers)
            {
                logger.Dispose();
            }
        }
    }
}