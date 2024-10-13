/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.IO;

namespace SkyForgeConsole
{
    public class NetCoreIOController : IControllerIO
    {
        public bool CreateDirectory(string pathDirectory)
        {
            try
            {
                Directory.CreateDirectory(pathDirectory);
                return true;
            }
            catch (Exception ex) 
            {
                Log.CoreLogger?.Logging($"Error can't create directory: {pathDirectory}. Exception {ex}", LogLevel.Error);
                return false; 
            }

        }

        public bool DeleteFile(string filePath, string fileName)
        {
            try
            {
                File.Delete(Path.Combine(filePath, fileName));
                return true;
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't delete file: {filePath}. Exception {ex}", LogLevel.Error);
                return false;
            }

        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public string GetFullPath(string currentDirectory)
        {
            try
            {
                return Path.GetFullPath(currentDirectory);
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't Get full Path from directory: {currentDirectory}. Exception {ex}", LogLevel.Error);
                return null;
            }
        }

        public bool IsHaveDirectory(string pathDirectory)
        {
            try
            {
                return Directory.Exists(pathDirectory);
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't check directory: {pathDirectory}. Exception {ex}", LogLevel.Error);
                return false;
            }
        }

        public bool IsHaveFile(string filePath, string fileName)
        {
            try
            {
                return File.Exists(Path.Combine(filePath, fileName));
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't check file: {filePath}. Exception {ex}", LogLevel.Error);
                return false;
            }
        }

        public bool WriteToFile(string message, string filePath, string fileName, bool isNewFile)
        {
            try
            {
                if (IsHaveFile(filePath, fileName))
                {
                    if (isNewFile && !DeleteFile(filePath, fileName))
                        throw new Exception($"Don't can delete file: {fileName}");
                }
                else if(!IsHaveDirectory(filePath))
                {
                    if (!CreateDirectory(filePath))
                        throw new Exception($"Don't create directory: {filePath}");
                }

                using (var textWriter = File.AppendText(Path.Combine(filePath, fileName)))
                {
                    textWriter.WriteLine(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.CoreLogger?.Logging($"Error can't write to file: {filePath}. Exception {ex}", LogLevel.Error);
                return false;
            }
        }
    }
}