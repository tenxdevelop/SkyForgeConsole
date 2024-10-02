
using NUnit.Framework;
using SkyForgeConsole;

namespace SkyForgeConsoleTest
{
    public class EntryPointTest
    {
        [Test]
        public void CheckCalledApplicationInit()
        {
            EntryPoint.Init();
            Assert.Pass();
        }
    }
}