/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole;

namespace SandBox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var entryPoint = EntryPoint.GetEntryPoint();
            var sandBox = new SandBox();
            entryPoint.Init(sandBox);


            EntryPoint.Main(args);
        }
    }
}