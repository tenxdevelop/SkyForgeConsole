/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;

namespace SkyForgeConsoleTest
{
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
        private int m_countCalledDispose;
        internal FakeApplication()
        {
            m_countCalledInit = 0;
            m_countCalledRun = 0;
            m_countCalledDispose = 0;
        }

        public void CheckCountCalledDispoce(int correctCount)
        {
            Assert.That(m_countCalledDispose, Is.EqualTo(correctCount));
        }

        public void CheckCountCalledInit(int correctCount)
        {
            Assert.That(m_countCalledInit, Is.EqualTo(correctCount));
        }

        public void CheckCountCalledRun(int correctCount)
        {
            Assert.That(m_countCalledRun, Is.EqualTo(correctCount));
        }
        
        public void Dispose()
        {
            m_countCalledDispose++;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void PushLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void PopLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void PushOverlay(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void PopOverlay(Layer layer)
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

        public static IFakeApplication Create()
        {
            return new FakeApplication();
        }
    }
}

