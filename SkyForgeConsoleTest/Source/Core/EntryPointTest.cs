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
            IEntryPoint entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = new FakeApplication();
            entryPoint.Init(fakeApplication);
            fakeApplication.CheckCountCalledInit(1);
            fakeApplication.CheckCountCalledRun(0);
        }

        [Test]
        public void CheckCalledEntryPointStart()
        {
            IEntryPoint entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = new FakeApplication();
            entryPoint.Init(fakeApplication);
            EntryPoint.Main();
            fakeApplication.CheckCountCalledRun(1);
        }

        [Test]
        public void CheckCalledEntryPointDestroy()
        {
            IEntryPoint entryPoint = EntryPoint.GetEntryPoint();
            var fakeApplication = new FakeApplication();
            entryPoint.Init(fakeApplication);
            EntryPoint.Main();
            fakeApplication.CheckCountCalledDispoce(1);
        }
    }

    internal interface IFakeApplication : IApplication
    {
        void CheckCountCalledInit(int correctCount);
        void CheckCountCalledRun(int correctCount);

        void CheckCountCalledDispoce(int correctCount);
    }

    internal class FakeApplication : IFakeApplication
    {
        private int m_countCalledInit;
        private int m_countCalledRun;
        private int m_countCalledDispoce;
        internal FakeApplication()
        {
            m_countCalledInit = 0;
            m_countCalledRun = 0;
            m_countCalledDispoce = 0;
        }

        public void CheckCountCalledDispoce(int correctCount)
        {
            Assert.IsTrue(m_countCalledDispoce == correctCount);
        }

        public void CheckCountCalledInit(int correctCount)
        {
            Assert.IsTrue(m_countCalledInit == correctCount);
        }

        public void CheckCountCalledRun(int correctCount)
        {
            Assert.IsTrue(m_countCalledRun == correctCount);
        }

        public void Dispose()
        {
            m_countCalledDispoce++;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            m_countCalledInit++;
        }

        public void Run()
        {
            m_countCalledRun++;
        }
    }

}