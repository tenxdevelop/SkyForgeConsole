/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;

namespace SkyForgeConsoleTest
{
    public class LayerStackTest
    {
        [Test]
        public void CheckImplementEnumerableLayerStack()
        {
            var firstFakeLayer = new FakeLayer("layer1");
            var secondFakeLayer = new FakeLayer("layer2");

            var layerStack = new LayerStack();

            layerStack.PushLayer(firstFakeLayer);
            layerStack.PushLayer(secondFakeLayer);

            var layers = new Layer[] { secondFakeLayer, firstFakeLayer };

            var index = 0;

            foreach (var layer in layerStack)
            {
                Assert.That(layer.GetName(), Is.EqualTo(layers[index++].GetName()));
            }
        }

        [Test]
        public void CheckPushLayerAndGetLenth()
        {
            var fakeLayer = new FakeLayer();

            var layerStack = new LayerStack();
            
            layerStack.PushLayer(fakeLayer);
            
            Assert.That(layerStack.GetLength(), Is.EqualTo(1));
        }

        [Test]
        public void CheckErrorWhenPushLayerIsNull()
        {
            var layerStack = new LayerStack();
            
            Assert.Throws<ArgumentException>(() => layerStack.PushLayer(null), "We push layer is null in layerStack");
        }

        [Test]
        public void CheckErrorWhenPopLayerIsNull()
        {
            var layerStack = new LayerStack();
            
            Assert.Throws<ArgumentException>(() => layerStack.PopLayer(null), "We pop layer is null in layerStack");
        }

        [Test]
        public void CheckErrorWhenPushOverlayIsNull()
        {
            var layerStack = new LayerStack();
            
            Assert.Throws<ArgumentException>(() => layerStack.PushOverlay(null), "We push overlay is null in layerStack");
            
        }

        [Test]
        public void CheckErrorWhenPopOverlayIsNull()
        {
            var layerStack = new LayerStack();

            Assert.Throws<ArgumentException>(() => layerStack.PopOverlay(null), "We pop overlay is null in layerStack");
        }
        
        [Test]
        public void CheckPopLayerByLayer()
        {
            var fakeLayer = new FakeLayer();
            var layerStack = new LayerStack();

            layerStack.PushLayer(fakeLayer);
            Assert.IsNotEmpty(layerStack);
            layerStack.PopLayer(fakeLayer);
            Assert.IsEmpty(layerStack);
        }

        [Test]
        public void CheckPopOverlayByLayer()
        {
            var fakeLayer = new FakeLayer();
            var layerStack = new LayerStack();
            layerStack.PushOverlay(fakeLayer);
            Assert.IsNotEmpty(layerStack);
            layerStack.PopOverlay(fakeLayer);
            Assert.IsEmpty(layerStack);
        }

        [Test]
        public void CheckGetLayerById()
        {
            var firstFakeLayer = new FakeLayer("layer1");
            var secondFakeLayer = new FakeLayer("layer2");
            var thirdFakeLayer = new FakeLayer("layer3");

            var layerStack = new LayerStack();
            
            layerStack.PushLayer(firstFakeLayer);
            
            layerStack.PushOverlay(secondFakeLayer);
            
            layerStack.PushLayer(thirdFakeLayer);
            
            Assert.That(layerStack.GetLayer(1), Is.EqualTo(thirdFakeLayer));
        }
        
        [Test]
        public void CheckPushOverlayLayer()
        {
            var fisrtFakeLayer = new FakeLayer("layer1");
            var secondFakeLayer = new FakeLayer("layer2");

            var layerStack = new LayerStack();
            
            layerStack.PushOverlay(secondFakeLayer);
            layerStack.PushLayer(fisrtFakeLayer);
            
            var layers = new Layer[] { secondFakeLayer, fisrtFakeLayer };
            var index = 0;
            
            foreach (var layer in layerStack)
            {
                Assert.That(layer.GetName(), Is.EqualTo(layers[index++].GetName()));
            }
        }

        [Test]
        public void CheckLengthWhenLayerStackIsEmpty()
        {
            var layerStack = new LayerStack();
            
            Assert.That(layerStack.GetLength(), Is.EqualTo(0));
        }

        [Test]
        public void CheckGetLayersMethod()
        {
            var firstFakeLayer = new FakeLayer("layer1");
            var secondFakeLayer = new FakeLayer("layer2");

            var layerStack = new LayerStack();
            layerStack.PushLayer(firstFakeLayer);
            layerStack.PushLayer(secondFakeLayer);
            var result = layerStack.GetLayers();
            Assert.IsTrue(result[0] == secondFakeLayer);
            Assert.IsTrue(result[1] == firstFakeLayer);
        }
        
        [Test]
        public void CheckGetLayersWithOverlay()
        {
            var firstFakeLayer = new FakeLayer("layer1");
            var secondFakeLayer = new FakeLayer("layer2");
            var thirdFakeLayer = new FakeLayer("layer3");

            var layerStack = new LayerStack();
            layerStack.PushLayer(firstFakeLayer);
            layerStack.PushOverlay(secondFakeLayer);
            layerStack.PushLayer(thirdFakeLayer);
            var result = layerStack.GetLayers();
            Assert.IsTrue(result[0] == secondFakeLayer);
            Assert.IsTrue(result[1] == thirdFakeLayer);
            Assert.IsTrue(result[2] == firstFakeLayer);
        }

        [Test]
        public void CheckAddedToLogInfoWhenCalledErrorPushLayerIsNull()
        {
            FileSystem.Init<NetCoreIOController>();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            var layerStack = new LayerStack();
            Assert.Throws<ArgumentException>(() => layerStack.PushLayer(null), "We push layer is null in layerStack");
            fakeLogger.CheckLog(" CoreLogger : We push layer is null in layerStack", 1);
            fakeLogger.CheckLogLevelLogging(LogLevel.Error);
        }

        [Test]
        public void CheckAddedToLogInfoWhenCalledErrorPopLayerIsNull()
        {
            FileSystem.Init<NetCoreIOController>();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            var layerStack = new LayerStack();
            Assert.Throws<ArgumentException>(() => layerStack.PopLayer(null), "We pop layer is null in layerStack");
            fakeLogger.CheckLog(" CoreLogger : We pop layer is null in layerStack", 1);
            fakeLogger.CheckLogLevelLogging(LogLevel.Error);
        }
        
        [Test]
        public void CheckAddedToLogInfoWhenCalledErrorPushOverlayIsNull()
        {
            FileSystem.Init<NetCoreIOController>();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            var layerStack = new LayerStack();
            Assert.Throws<ArgumentException>(() => layerStack.PushOverlay(null), "We push overlay is null in layerStack");
            fakeLogger.CheckLog(" CoreLogger : We push overlay is null in layerStack");
            fakeLogger.CheckLogLevelLogging(LogLevel.Error);
        }

        [Test]
        public void CheckAddedToLogInfoWhenCalledErrorPopOverlayIsNull()
        {
            FileSystem.Init<NetCoreIOController>();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            var layerStack = new LayerStack();
            Assert.Throws<ArgumentException>(() => layerStack.PopOverlay(null), "We pop overlay is null in layerStack");
            fakeLogger.CheckLog(" CoreLogger : We pop overlay is null in layerStack");
            fakeLogger.CheckLogLevelLogging(LogLevel.Error);
        }
    }
}

