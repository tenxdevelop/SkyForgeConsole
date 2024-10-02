/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public class EntryPoint : IEntryPoint
    {
        private static IApplication m_application;
        private static IEntryPoint m_instance;

        private EntryPoint()
        {
            
        }

        public static IEntryPoint GetEntryPoint()
        {
            if (m_instance is null)
                m_instance = new EntryPoint();
            return m_instance;     
        }

        public static void Main(string[] args = null)
        {
            if (m_application is null)
            {
                //TODO: added exception to log
                throw new ArgumentNullException("Application has not been initialized, I cannot find application!");
            }
     
            m_application.Run();

            m_instance.Dispose();
        }


        public void Dispose()
        {
            m_application.Dispose();
        }

        public IApplication GetApplication() => m_application;

        public void Init(IApplication application)
        {
            m_application = application;

            if (m_application is null)
            {
                //TODO: added exception to Log
                throw new ArgumentNullException("Application is null, Cannot find application!");
            }

            m_application.Init();
        }
        
    }
}