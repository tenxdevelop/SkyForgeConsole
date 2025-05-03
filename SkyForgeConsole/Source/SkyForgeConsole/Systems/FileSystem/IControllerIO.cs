/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace SkyForgeConsole
{
    public interface IControllerIO
    {
        string GetFullPath(string currentDirectory);

        string GetCurrentDirectory();

        bool IsHaveDirectory(string pathDirectory);

        bool CreateDirectory(string pathDirectory);

        bool IsHaveFile(string filePath, string fileName);

        bool DeleteFile(string filePath, string fileName);

        bool WriteToFile(string message, string filePath, string fileName, bool isNewFile);
    }
}