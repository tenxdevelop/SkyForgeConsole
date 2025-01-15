/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;

namespace SkyForgeConsoleTest
{
    internal interface IFakeLogger : ILogger
    {
        void CheckLog(string message);
        void CheckLog(string message, int countLogging);
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

        public void CheckLog(string message, int countLogging)
        {
            Assert.That(message, Is.EqualTo(m_messageCalled));
            Assert.That(countLogging, Is.EqualTo(m_countLogging));
        }

        public void CheckLog(string message)
        {
            Assert.That(message, Is.EqualTo(m_messageCalled));
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

