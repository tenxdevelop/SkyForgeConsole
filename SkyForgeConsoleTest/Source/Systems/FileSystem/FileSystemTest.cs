/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;
using System.IO;

namespace SkyForgeConsoleTest
{
    public class FileSystemTest
    {

        [Test]
        public void CheckWriteToFileMassage()
        {
            var message = "massage trutrurtu!!!";
            FileSystem.Init<NetCoreIOController>();
            FileSystem.WriteToFile(message, "", "test.txt", true);
            FileSystem.WriteToFile("heheh", "", "test.txt");
            string resultText = "";
            using (StreamReader streamReader = new StreamReader("test.txt"))
            {
                var tempread = streamReader.ReadLine();
                while (tempread != null)
                { 
                    resultText += tempread;
                    tempread = streamReader.ReadLine();
                }
            }

            Assert.That(message + "heheh", Is.EqualTo(resultText));
        }

        [Test]
        public void CheckIsHaveFile()
        {
            FileSystem.Init<NetCoreIOController>();
            FileSystem.WriteToFile("hehe", "", "test.txt", true);
            Assert.IsTrue(FileSystem.IsHaveFile("", "test.txt"));
        }

        [Test]
        public void CheckInitWithOtherController()
        {
            Assert.Throws<ArgumentException>(() => FileSystem.Init<FakeControllerIO>(), "you are using a controller that is not registered in the system: FakeControllerIO");
        }
    }

    internal class FakeControllerIO : IControllerIO
    {
        public bool DeleteFile(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool IsHaveFile(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool WriteToFile(string message, string filePath, string fileName, bool isNewFile = false)
        {
            throw new NotImplementedException();
        }
    }
}