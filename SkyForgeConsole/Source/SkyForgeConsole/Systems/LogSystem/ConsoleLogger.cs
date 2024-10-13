/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Diagnostics;
using System.IO.Pipes;
using System.IO;
using ConsoleLogger;
using System;

namespace SkyForgeConsole
{
    public class ConsoleLogger : BaseLogger<ConsoleLogger>
    {
        private static StreamWriter m_writer;
        private static NamedPipeServerStream m_pipeServer;
        private static Process m_process;

        public ConsoleLogger()
        {
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = Path.Combine(FileSystem.GetFullPath(FileSystem.GetCurrentDirectory()), ConsoleLog.FileName);
            startinfo.WindowStyle = ProcessWindowStyle.Normal;
            startinfo.UseShellExecute = true;

            m_process = new Process();
            m_process.StartInfo = startinfo;
            m_process.Start();

            m_pipeServer = new NamedPipeServerStream(ConsoleLog.PIPE_NAME, PipeDirection.InOut, 4);
            m_pipeServer.WaitForConnection();
            m_writer = new StreamWriter(m_pipeServer);
        }

        public override void Dispose()
        {
            m_process?.Kill();
        }

        public override void Logging(string message, LogLevel level)
        {
            if (m_writer is null)
            {
                Log.CoreLogger?.Logging("can't write to consoleLog stream write is null", LogLevel.Error);
                throw new Exception("can't write to consoleLog stream write is null");
            }

            m_writer.WriteLine(PaternForConsole(message, level));
            m_writer.Flush();


#if SKY_FORGE_WINDOWS
#pragma warning disable CA1416 // Проверка совместимости платформы
            m_pipeServer.WaitForPipeDrain();
#pragma warning restore CA1416 // Проверка совместимости платформы
#endif

        }


        private string PaternForConsole(string message, LogLevel logLevel)
        {
            var consoleColor = GetColorFromLevel(logLevel);

            return ((int)consoleColor) +  ConsoleLog.COLOR_SEPARATOR + Patern(message, logLevel);
        }

        private ConsoleColor GetColorFromLevel(LogLevel logLevel)
        {
            var writeToColor = ConsoleColor.White;
            if (logLevel.Equals(LogLevel.Defualt))
                writeToColor = ConsoleColor.Blue;
            else if (logLevel.Equals(LogLevel.Info))
                writeToColor = ConsoleColor.Green;
            else if (logLevel.Equals(LogLevel.Warn))
                writeToColor = ConsoleColor.Yellow;
            else if (logLevel.Equals(LogLevel.Error))
                writeToColor = ConsoleColor.Red;
            else if (logLevel.Equals(LogLevel.Crytical))
                writeToColor = ConsoleColor.DarkRed;
            return writeToColor;
        }
    }
}
