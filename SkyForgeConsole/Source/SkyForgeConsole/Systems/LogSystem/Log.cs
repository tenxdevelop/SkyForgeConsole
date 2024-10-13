/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForgeConsole
{
    public static class Log
    {
        public static ILogSystem CoreLogger => m_coreLogger;
        public static ILogSystem ClientLogger => m_clientLogger;


        private static ILogSystem m_clientLogger;
        private static ILogSystem m_coreLogger;

        public static void Init()
        {
            m_coreLogger = new LogSystem("CoreLogger");
            m_clientLogger = new LogSystem("ClientLogger");

            
            m_coreLogger.AddLogger(new FileLogger());

            m_clientLogger.AddLogger(new FileLogger());


            m_coreLogger.Logging("Init Log System", LogLevel.Info);
        }
    }
}