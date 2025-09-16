/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
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
                var errorMessage = "Application hasn't been initialized, i can't find application!";
                Log.CoreLogger?.Logging(errorMessage, LogLevel.Error);
                throw new ArgumentNullException(errorMessage);
            }
            
            m_application.Run();

            m_instance.Dispose();
        }


        public void Dispose()
        {
            m_application.Dispose();
            Log.Destroy();
        }

        public IApplication GetApplication() => m_application;

        public void Init(IApplication application)
        {
            //INIt FileSystem
            FileSystem.Init<NetCoreIOController>();

            //Init LogSystem
            Log.Init();

            m_application = application;

            if (m_application is null)
            {
                var errorMessage = "Application hasn't been initialized, system can't find application!";
                Log.CoreLogger?.Logging(errorMessage, LogLevel.Error);
                throw new ArgumentNullException(errorMessage);
            }
            
            m_application.Init();
        }
        
    }
}