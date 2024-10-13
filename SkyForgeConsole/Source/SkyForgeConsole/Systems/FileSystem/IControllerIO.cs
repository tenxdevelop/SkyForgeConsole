/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole
{
    public interface IControllerIO
    {
        bool IsHaveFile(string filePath, string fileName);
        bool DeleteFile(string filePath, string fileName);
        bool WriteToFile(string massage, string filePath, string fileName, bool isNewFile);
    }
}