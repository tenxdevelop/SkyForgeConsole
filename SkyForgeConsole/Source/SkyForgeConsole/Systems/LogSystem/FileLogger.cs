/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public class FileLogger : BaseLogger<FileLogger>
    {
        private const string BASIC_PATH = @".\Log";

        private readonly string m_filePath;
        public FileLogger(string filePath = null)
        {
            if (filePath is null)
                m_filePath = BASIC_PATH;
            else
                m_filePath = filePath;

            if (!FileSystem.IsInit)
                throw new Exception("Create FileLogger before init FileSystem");
        }

        public override void Dispose()
        {
            
        }

        public override void Logging(string message, LogLevel level)
        {
            var dateTime = DateTime.Now;
            var fileName = $"log-date({dateTime.Day}_{dateTime.Month}_{dateTime.Year}).txt";
            if (!FileSystem.WriteToFile(Patern(message, level), m_filePath, fileName))
                throw new Exception("can't write to file Log");
        }       
    }
}