/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
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