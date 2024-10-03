/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
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