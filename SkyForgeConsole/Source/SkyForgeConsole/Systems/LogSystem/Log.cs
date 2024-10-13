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

            var consoleLogger = new ConsoleLogger();
            var FileLogger = new FileLogger();

            m_coreLogger.AddLogger(consoleLogger);
            m_coreLogger.AddLogger(FileLogger);

            m_clientLogger.AddLogger(consoleLogger);
            m_clientLogger.AddLogger(FileLogger);


            m_coreLogger.Logging("Init Log System", LogLevel.Info);
        }

        public static void Destroy()
        {
            m_coreLogger.Dispose();
            m_clientLogger.Dispose();
        }
    }
}