/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace ConsoleLogger
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IConsoleLog consoleLog = new ConsoleLog();
            consoleLog.Init();
            consoleLog.Run();
        }
    }
}