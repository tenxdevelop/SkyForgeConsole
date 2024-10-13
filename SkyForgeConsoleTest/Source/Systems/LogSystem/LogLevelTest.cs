/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;
using System.Collections.Generic;

namespace SkyForgeConsoleTest
{
    public class LogLevelTest
    {
        [Test]
        public void CheckGetLogLevelFromLevel()
        {
            var logLevel = LogLevel.GetLogLevelFromLevel(0);
            CheckLogLevel(logLevel, LogLevel.Defualt);

            logLevel = LogLevel.GetLogLevelFromLevel(1);
            CheckLogLevel(logLevel, LogLevel.Info);

            logLevel = LogLevel.GetLogLevelFromLevel(2);
            CheckLogLevel(logLevel, LogLevel.Warn);

            logLevel = LogLevel.GetLogLevelFromLevel(3);
            CheckLogLevel(logLevel, LogLevel.Error);

            logLevel = LogLevel.GetLogLevelFromLevel(4);
            CheckLogLevel(logLevel, LogLevel.Crytical);

            Assert.Throws<ArgumentException>(() => LogLevel.GetLogLevelFromLevel(5), "Could not found LogLevel with level: 5");
        }

        [Test]
        public void CheckGetLogLevelFromName()
        {
            var logLevel = LogLevel.GetLogLevelFromName(nameof(LogLevel.Defualt));
            CheckLogLevel(logLevel, LogLevel.Defualt);

            logLevel = LogLevel.GetLogLevelFromName(nameof(LogLevel.Info));
            CheckLogLevel(logLevel, LogLevel.Info);

            logLevel = LogLevel.GetLogLevelFromName(nameof(LogLevel.Warn));
            CheckLogLevel(logLevel, LogLevel.Warn);

            logLevel = LogLevel.GetLogLevelFromName(nameof(LogLevel.Error));
            CheckLogLevel(logLevel, LogLevel.Error);

            logLevel = LogLevel.GetLogLevelFromName(nameof(LogLevel.Crytical));
            CheckLogLevel(logLevel, LogLevel.Crytical);

            Assert.Throws<ArgumentException>(() => LogLevel.GetLogLevelFromName("OtherLogLevel"), 
                                             "Could not found LogLevel with name: OtherLogLevel");
        }

        [Test]
        public void CheckMaxLogLevel()
        {
            Assert.That(LogLevel.Max, Is.EqualTo(LogLevel.Crytical));
        }

        [Test]
        public void ChekcMinLogLevel()
        {
            Assert.That(LogLevel.Min, Is.EqualTo(LogLevel.Defualt));
        }


        [Test]
        public void CheckInfoLogLevelMoreDefualtLogLevel()
        {
            Assert.IsTrue(LogLevel.Info > LogLevel.Defualt);
        }

        [Test]
        public void CheckErrorLogLevelMoreInfoLogLevel()
        {
            Assert.IsTrue(LogLevel.Error > LogLevel.Info);
        }

        [Test]
        public void CheckWarnLogLevelMoreInfoLogLevel()
        {
            Assert.IsTrue(LogLevel.Warn >= LogLevel.Info);
        }

        [Test]
        public void CheckErrorLogLevelMoreWarnLogLevel()
        {
            Assert.IsTrue(LogLevel.Error > LogLevel.Warn);
        }

        [Test]
        public void CheckWarnLogLevelLessErrorLogLevel()
        {
            Assert.IsTrue(LogLevel.Warn < LogLevel.Error);
        }

        [Test]
        public void CheckInfoLogLevelLessErrorLogLevel()
        {
            Assert.IsTrue(LogLevel.Info < LogLevel.Error);
        }

        [Test]
        public void CheckInfoLogLevelLessWarnLogLevel()
        {
            Assert.IsTrue(LogLevel.Info <= LogLevel.Warn);
        }

        [Test]
        public void CheckLogLevelCompareToOtherLogLevel()
        {
            var logLevel = LogLevel.Info;
            Assert.That(logLevel.CompareTo(LogLevel.Info), Is.EqualTo(0));
            Assert.That(logLevel.CompareTo(LogLevel.Warn), Is.EqualTo(-1));
            Assert.That(logLevel.CompareTo(LogLevel.Defualt), Is.EqualTo(1));
        }

        [Test]
        public void CheckLogLLevelCompareToOtherIsNotLogLevel()
        {
            var logLevel = LogLevel.Info;
            var obj = new List<int>(1) as object;
            Assert.Throws<ArgumentException>(() => logLevel.CompareTo(obj), "object is not LogLevel");
        }

        [Test]
        public void CheckLogLevelCompareToWithNull()
        {
            var logLevel = LogLevel.Info;
            Assert.Throws<ArgumentNullException>(() => logLevel.CompareTo(null), "logLevel is null");
        }


        private void CheckLogLevel(ILogLevel actualLogLevel, LogLevel logLevelCorrect)
        {
            var actualLevel = actualLogLevel as LogLevel;
            Assert.That(actualLogLevel.Level, Is.EqualTo(logLevelCorrect.Level));
            Assert.That(actualLogLevel.Name, Is.EqualTo(logLevelCorrect.Name));
            Assert.That(logLevelCorrect == (actualLevel));
            Assert.That(logLevelCorrect >= (actualLevel));
            Assert.That(logLevelCorrect <= (actualLevel));
        }
    }
}