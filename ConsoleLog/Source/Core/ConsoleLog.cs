/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.IO;
using System.IO.Pipes;

#if SKY_FORGE_WINDOWS
using ConsoleLogger.Win32;
#endif

namespace ConsoleLogger
{
    public class ConsoleLog : IConsoleLog
    {
        public const string PIPE_NAME = "LogServer";
        public const string FileName = "ConsoleLog.exe";
        public const string COLOR_SEPARATOR = "^";

        private NamedPipeClientStream m_pipeClient;

        public void Init()
        {
            m_pipeClient = new NamedPipeClientStream(".", PIPE_NAME, PipeDirection.InOut, PipeOptions.None);
            if (m_pipeClient.IsConnected != true)
                m_pipeClient.Connect();
        }

        public void Run()
        {
            if (m_pipeClient == null)
                throw new Exception("Can't called Init ConsoleLog");

            StreamReader reader = new StreamReader(m_pipeClient);
#if SKY_FORGE_WINDOWS
            WinAPINative.EnableButtonMenu(WinAPINative.BUTTON_CLOSE, WinAPINative.LB_COMMAND | WinAPINative.LB_DISABLE);
#endif
            while (m_pipeClient.IsConnected)
            {
                string[]? line = reader.ReadLine()?.Split(COLOR_SEPARATOR);
                if (line != null)
                {
                    if (int.TryParse(line[0], out var colorValue))
                    {
                        Console.ForegroundColor = (ConsoleColor)colorValue;
                    }
                    Console.WriteLine(line[1]);
                }
            }
        }
    }
}