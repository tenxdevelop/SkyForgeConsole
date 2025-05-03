/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{
    public interface ILogLevel : IComparable
    {
        int Level { get; }
        string Name { get; }
        int CompareTo(ILogLevel logLevel);       
    }
}