/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole
{

    public static class FileSystem
    {
        private const string NET_CORE_CONTROLLER = nameof(NetCoreIOController);
        private static IControllerIO m_controllerIO;
        public static void Init<T>() where T : IControllerIO
        {
            m_controllerIO = CreateContorller<T>();
        }

        public static bool WriteToFile(string massage, string filePath, string fileName, bool isNewFile = false)
        {
            return m_controllerIO.WriteToFile(massage, filePath, fileName, isNewFile);
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