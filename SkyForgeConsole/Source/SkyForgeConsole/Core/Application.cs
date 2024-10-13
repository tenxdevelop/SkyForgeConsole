/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


using System;

namespace SkyForgeConsole
{
    public abstract class Application : IApplication
    {
        private bool m_isInit;

        public Application()
        {
            m_isInit = false;
        }

        public void Init()
        {
            if (m_isInit)
            {
                //TODO: added info to log
                throw new MethodAccessException("Application was initialized, you have called initialization twice");
            }
            m_isInit = true;
        }

        public void Dispose()
        {
            
        }

        public void Exit()
        {
            
        }

        

        public void Run()
        {
            if (!m_isInit)
            {
                //TODO: added ifno to log
                throw new MethodAccessException("Application start run before Init");
            }

#if SKY_FORGE_DEBUG || SKY_FORGE_RELEASE

            while (true)
            {
                
            }
#endif
        }
    }
}