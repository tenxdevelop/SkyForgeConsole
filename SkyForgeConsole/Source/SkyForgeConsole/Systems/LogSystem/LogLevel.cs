/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.Xml.Linq;

namespace SkyForgeConsole
{
    public class LogLevel : ILogLevel
    {
        private const string DEFUALT_NAME = "Defualt";
        private const string INFO_NAME = "Info";
        private const string WARN_NAME = "Warn";
        private const string ERROR_NAME = "Error";
        private const string CRYTICAL_NAME = "Crytical";

        public static LogLevel Defualt = new LogLevel(DEFUALT_NAME, 0);
        public static LogLevel Info = new LogLevel(INFO_NAME, 1);
        public static LogLevel Warn = new LogLevel(WARN_NAME, 2);
        public static LogLevel Error = new LogLevel(ERROR_NAME, 3);
        public static LogLevel Crytical = new LogLevel(CRYTICAL_NAME, 4);

        public static LogLevel Min = Defualt;
        public static LogLevel Max = Crytical;
        
        public int Level => m_level;
        public string Name => m_name;

        private string m_name;
        private int m_level;

        public LogLevel(string name, int level)
        {
            m_name = name;
            m_level = level;
        }

        public int CompareTo(object obj)
        {
            if (obj is LogLevel logLevel)
            {
                return CompareTo(logLevel);
            }
            Log.CoreLogger?.Logging("object is not LogLevel", LogLevel.Error);
            throw new ArgumentException("object is not LogLevel");
        }

        public int CompareTo(ILogLevel logLevel)
        {
            if (logLevel is null)
            {
                Log.CoreLogger?.Logging("logLevel is null", LogLevel.Error);
                throw new ArgumentNullException("logLevel is null");
            }
            return m_level - logLevel.Level;
        }

        public static ILogLevel GetLogLevelFromLevel(int value)
        {
            switch (value)
            {
                case 0:
                    return Defualt;
                case 1:
                    return Info;
                case 2:
                    return Warn;
                case 3:
                    return Error;
                case 4: 
                    return Crytical;
                default:
                    Log.CoreLogger?.Logging($"Could not found LogLevel with level: {value}", LogLevel.Error);
                    throw new ArgumentException($"Could not found LogLevel with level: {value}");
            }
        }

        public static ILogLevel GetLogLevelFromName(string name)
        {
            switch (name)
            {
                case DEFUALT_NAME:
                    return Defualt;
                case INFO_NAME:
                    return Info;
                case WARN_NAME:
                    return Warn;
                case ERROR_NAME:
                    return Error;
                case CRYTICAL_NAME:
                    return Crytical;
                default:
                    Log.CoreLogger?.Logging($"Could not found LogLevel with name: {name}", LogLevel.Error);
                    throw new ArgumentException($"Could not found LogLevel with name: {name}");
            }
        }

        public override string ToString()
        {
            return m_name;
        }

        public static bool operator >(LogLevel logLevel, LogLevel otherLogLevel)
        {
            return logLevel.CompareTo(otherLogLevel) > 0;
        }

        public static bool operator <(LogLevel logLevel, LogLevel otherLogLevel)
        {
            return logLevel.CompareTo(otherLogLevel) < 0;
        }

        public static bool operator >=(LogLevel logLevel, LogLevel otherLogLevel)
        {
            return logLevel.CompareTo(otherLogLevel) >= 0;
        }

        public static bool operator <=(LogLevel logLevel, LogLevel otherLogLevel)
        {
            return logLevel.CompareTo(otherLogLevel) <= 0;
        }

        public bool Equals(ILogLevel other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj is ILogLevel logLevel)
            {
                return Equals(logLevel);
            }
            return false;
        }
    }
}
