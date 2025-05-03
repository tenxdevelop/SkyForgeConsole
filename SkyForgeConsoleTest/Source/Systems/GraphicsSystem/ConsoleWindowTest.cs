/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Maths;
using NUnit.Framework;

namespace SkyForgeConsoleTest
{
    public class ConsoleWindowTest
    {
        [Test]
        public void CreateWindowTest()
        {
            var heightWindow = 400;
            var widthWindow = 400;
            
            var consoleWindow = new ConsoleWindow(widthWindow, heightWindow);
            Assert.That(consoleWindow.Height, Is.EqualTo(heightWindow));
            Assert.That(consoleWindow.Width, Is.EqualTo(widthWindow));
            Assert.That(consoleWindow.Size, Is.EqualTo(new Vector2(widthWindow, heightWindow)));
        }
        
        [Test]
        public void CreateWindowTest2()
        {
            var windowSize = new Vector2(400, 400);
            
            var consoleWindow = new ConsoleWindow(windowSize);
            
            Assert.That(consoleWindow.Height, Is.EqualTo(windowSize.y));
            Assert.That(consoleWindow.Width, Is.EqualTo(windowSize.x));
            
            Assert.That(consoleWindow.Size, Is.EqualTo(windowSize));
        }
        
        [Test]
        public void CharRenderTest()
        {
            var buffer = new char[] { '*' };

            var fakeRenderPipeline = new FakeRenderPipeline();
            var consoleWindow = new ConsoleWindow(400, 400);
            consoleWindow.Init(fakeRenderPipeline);
            
            var position = new Vector2(10, 10);
            consoleWindow.Render(buffer, position);
            
            fakeRenderPipeline.CheckRender(buffer, position);
        }
        
        [Test]
        public void CheckInitRenderPipelineTest()
        {
            var fakeRenderPipeline = new FakeRenderPipeline();
            var consoleWindow = new ConsoleWindow(400, 400);
            consoleWindow.Init(fakeRenderPipeline);
            
            fakeRenderPipeline.CheckBufferInit(400, 400);
            fakeRenderPipeline.CheckCountCalledInit(1);
        }
        
        [Test]
        public void SpriteRenderTest()
        {
            var buffer = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };;

            var sprite = new Sprite(buffer, new Vector2(4, 3));
            var fakeRenderPipeline = new FakeRenderPipeline();
            var consoleWindow = new ConsoleWindow(400, 400);
            consoleWindow.Init(fakeRenderPipeline);
            
            var position = new Vector2(10, 10);
            consoleWindow.Render(sprite, position);
            
            fakeRenderPipeline.CheckRender(buffer, position);
        }
    }
}