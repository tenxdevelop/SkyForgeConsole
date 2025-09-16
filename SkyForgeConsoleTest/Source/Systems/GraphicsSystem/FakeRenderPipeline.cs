/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Maths;
using SkyForgeConsole;
using NUnit.Framework;

namespace SkyForgeConsoleTest
{
    public class FakeRenderPipeline : IRenderPipeline
    {
        private int m_countCalledInit = 0;
        public void CheckCountCalledInit(int countCalled)
        {
            Assert.That(m_countCalledInit, Is.EqualTo(countCalled));
        }
        
        public void CheckBufferInit(int width, int height)
        {
            
        }
        
        public void CheckRender(char[] symbol, Vector2 position)
        {
            
        }

        public void BeginRender()
        {
            
        }

        public void EndRender()
        {
            
        }
    }
}
