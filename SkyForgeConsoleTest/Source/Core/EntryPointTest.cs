/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;

namespace SkyForgeConsoleTest
{
    public class EntryPointTest
    {
        [Test]
        public void CheckCalledExceptionWhenCalledInitWithoutApplcation()
        {
            var entryPoint = EntryPoint.GetEntryPoint();
            if (entryPoint.GetApplication() != null)
            {
                Assert.Throws<ArgumentNullException>(() => entryPoint.Init(null), "Application is null, Cannot find application!");
            }
            Assert.Throws<ArgumentNullException>(() => EntryPoint.Main(), "Application has not been initialized, Cannot find application!");
        }

        [Test]
        public void CheckCalledEntryPointInit()
        {
            var entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = FakeApplication.Create();
            entryPoint.Init(fakeApplication);
            fakeApplication.CheckCountCalledInit(1);
            fakeApplication.CheckCountCalledRun(0);
        }

        [Test]
        public void CheckCalledEntryPointStart()
        {
            var entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = FakeApplication.Create();
            entryPoint.Init(fakeApplication);
            EntryPoint.Main();
            fakeApplication.CheckCountCalledRun(1);
        }

        [Test]
        public void CheckCalledEntryPointDestroy()
        {
            var entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = FakeApplication.Create();
            entryPoint.Init(fakeApplication);
            EntryPoint.Main();
            fakeApplication.CheckCountCalledDispoce(1);
        }
    }
}