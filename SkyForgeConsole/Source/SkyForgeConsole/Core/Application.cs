/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public abstract class Application : IApplication
    {
        private bool m_isInit;
        private bool m_isRunning;

        public Application()
        {
            m_isInit = false;
            m_isRunning = true;
        }

        public void Init()
        {
            if (m_isInit)
            {
                Log.CoreLogger.Logging("Application was initialized, you have called initialization twice", LogLevel.Error);
                throw new MethodAccessException("Application was initialized, you have called initialization twice");
            }
            m_isInit = true;

            Log.CoreLogger.Logging("Init SkyForgeEngine !!", LogLevel.Info);
        }

        public void Dispose()
        {
            
        }

        public void Exit()
        {
            m_isRunning = false;
        }

        public void Run()
        {
            if (!m_isInit)
            {
                Log.CoreLogger.Logging("Application start run before Init", LogLevel.Error);
                throw new MethodAccessException("Application start run before Init");
            }

#if SKY_FORGE_DEBUG || SKY_FORGE_RELEASE

            while (m_isRunning)
            {
                
            }
#endif
        }
    }
}