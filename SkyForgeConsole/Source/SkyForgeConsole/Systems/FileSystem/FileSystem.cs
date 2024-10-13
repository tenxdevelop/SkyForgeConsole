/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{

    public static class FileSystem
    {
        public static bool IsInit => m_isInit;

        private const string NET_CORE_CONTROLLER = nameof(NetCoreIOController);
        private static IControllerIO m_controllerIO;

        private static bool m_isInit = false;

        public static void Init<T>() where T : IControllerIO
        {
            m_controllerIO = CreateContorller<T>();
            m_isInit = true;
        }

        public static bool IsHaveDirectory(string pathDirectory)
        {
            return m_controllerIO.IsHaveDirectory(pathDirectory);
        }

        public static bool CreateDirectory(string pathDirectory)
        {
            return m_controllerIO.CreateDirectory(pathDirectory);
        }

        public static bool WriteToFile(string message, string filePath, string fileName, bool isNewFile = false)
        {
            return m_controllerIO.WriteToFile(message, filePath, fileName, isNewFile);
        }

        public static bool IsHaveFile(string filePath, string fileName)
        {
            return m_controllerIO.IsHaveFile(filePath, fileName);
        }

        public static bool DeleteFile(string filePath, string fileName)
        {
            return m_controllerIO.DeleteFile(filePath, fileName);
        }

        private static IControllerIO CreateContorller<T>() where T : IControllerIO
        {
            var type = typeof(T);
            switch (type.Name)
            {
                case NET_CORE_CONTROLLER:
                    return new NetCoreIOController();
                default:
                    throw new ArgumentException($"you are using a controller that is not registered in the system: {type.Name}");
            }
        }
    }

}