/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;

namespace SkyForgeConsoleTest
{
    public class ApplicationTest
    {
        [Test]
        public void CheckCalledRunBeforeInit()
        {
            var application = new TestApplication();
            Assert.Throws<MethodAccessException>(() => application.Run(), "Application start run before Init");
        }

        [Test]
        public void CheckCalledInitAfterInit()
        {
            var application = new TestApplication();
            application.Init();
            Assert.Throws<MethodAccessException>(() => application.Init(), "Application was initialized, you have called initialization twice");
        }


        [Test]
        public void CheckAddedToLogInfoWhenCalledInitAfterInit()
        {
            //TODO: check log
        }

        [Test]
        public void CheckAddedToLogInfoWhenCalledRunBeforeInit()
        {
            //TODO: check log
        }
    }


    internal class TestApplication : Application
    {

    } 
}