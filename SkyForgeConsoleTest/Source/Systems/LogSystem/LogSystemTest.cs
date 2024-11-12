/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;

namespace SkyForgeConsoleTest
{

    public class LogSystemTest
    {

        [Test]
        public void CheckNameLogSystem()
        {
            var logSystemName = "LogSystemTest";
            ILogSystem logSystem = new LogSystem(logSystemName);
            Assert.That(logSystem.Name, Is.EqualTo(logSystemName));
        }

        [Test]
        public void CheckLoggingWithoudAddedLoggerForLogSystem()
        {
            ILogSystem logSystem = new LogSystem("test");
            var fakeLogger = new FakeLogger();
            logSystem.Logging("test", LogLevel.Info);
            fakeLogger.CkeckLog(string.Empty, 0);
        }

        [Test]
        public void CheckAddedLoggerForLogSystem()
        {
            ILogSystem logSystem = new LogSystem("test");
            var fakeLogger = new FakeLogger();
            logSystem.AddLogger(fakeLogger);
            logSystem.Logging("test", LogLevel.Info);
            fakeLogger.CkeckLog(" test : test", 1);
        }

        [Test]
        public void CheckGetLevelForLogger()
        {
            ILogSystem logSystem = new LogSystem("test");
            var fakeLogger = new FakeLogger();
            logSystem.AddLogger(fakeLogger);
            logSystem.Logging("test", LogLevel.Info);
            fakeLogger.CheckLogLevelLogging(LogLevel.Info);
        }

        [Test]
        public void CheckLoggingForLogger()
        {
            ILogSystem logSystem = new LogSystem("test");
            var fakeLogger = new FakeLogger();
            logSystem.AddLogger(fakeLogger);
            logSystem.Logging("test", LogLevel.Info);
            logSystem.Logging("test", LogLevel.Info);
            logSystem.Logging("test", LogLevel.Info);
            fakeLogger.CkeckLog(" test : test", 3);
        }
    }

    internal interface IFakeLogger : ILogger
    {
        void CkeckLog(string message, int countLogging);
        void CheckLogLevelLogging(LogLevel level);
    }

    internal class FakeLogger : IFakeLogger
    {
        private string m_messageCalled;
        private int m_countLogging;
        private LogLevel m_logLevel;

        public FakeLogger()
        {
            m_countLogging = 0;
            m_messageCalled = string.Empty;
            m_logLevel = LogLevel.Test;
        }

        public void CheckLogLevelLogging(LogLevel level)
        {
            Assert.That(m_logLevel, Is.EqualTo(level));
        }

        public void CkeckLog(string message, int countLogging)
        {
            Assert.That(message, Is.EqualTo(m_messageCalled));
            Assert.That(countLogging, Is.EqualTo(m_countLogging));
        }

        public void Dispose()
        {
            
        }

        public bool Equals(ILogger logger)
        {
            return false;
        }

        public void Logging(string message, LogLevel level)
        {
            m_messageCalled = message;
            m_logLevel = level;
            m_countLogging++;
        }
    }
}