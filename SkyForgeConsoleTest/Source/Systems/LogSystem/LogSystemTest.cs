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
            fakeLogger.CheckLog(string.Empty, 0);
        }

        [Test]
        public void CheckAddedLoggerForLogSystem()
        {
            ILogSystem logSystem = new LogSystem("test");
            var fakeLogger = new FakeLogger();
            logSystem.AddLogger(fakeLogger);
            logSystem.Logging("test", LogLevel.Info);
            fakeLogger.CheckLog(" test : test", 1);
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
            fakeLogger.CheckLog(" test : test", 3);
        }
    }
}