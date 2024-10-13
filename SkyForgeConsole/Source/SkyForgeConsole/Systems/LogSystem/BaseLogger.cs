/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


using System;

namespace SkyForgeConsole
{
    public abstract class BaseLogger<T> : ILogger
    {
        public abstract void Dispose();

        public bool Equals(ILogger logger)
        {
            return logger != null && logger is T;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ILogger logger)
                return Equals(logger);
            return false;
        }

        public override int GetHashCode()
        {
            var typeName = typeof(T).Name;
            return typeName.GetHashCode();
        }

        public abstract void Logging(string message, LogLevel level);

        protected string Patern(in string msg, LogLevel level)
        {
            var time = DateTime.Now;
            return $"[{time.Hour}:{time.Minute}:{time.Second}] -> ({level}) {msg}";
        }
    }
}