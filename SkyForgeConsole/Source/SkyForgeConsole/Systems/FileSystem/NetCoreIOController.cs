/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.IO;

namespace SkyForgeConsole
{
    public class NetCoreIOController : IControllerIO
    {
        public bool DeleteFile(string filePath, string fileName)
        {
            try
            {
                File.Delete(Path.Combine(filePath, fileName));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool IsHaveFile(string filePath, string fileName)
        {
            return File.Exists(Path.Combine(filePath, fileName));
        }

        public bool WriteToFile(string massage, string filePath, string fileName, bool isNewFile)
        {
            try
            {
                if (IsHaveFile(filePath, fileName))
                {
                    if (isNewFile && !DeleteFile(filePath, fileName))
                        throw new Exception($"Don't can delete file: {fileName}");
                }

                using (var textWriter = File.AppendText(Path.Combine(filePath, fileName)))
                {
                    textWriter.WriteLine(massage);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}