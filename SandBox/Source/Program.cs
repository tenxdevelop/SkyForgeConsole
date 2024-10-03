/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole;
using System;

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