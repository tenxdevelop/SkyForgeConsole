/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System.Reflection;
using NUnit.Framework;
using SkyForgeConsole;
using System.Linq;
using System;

namespace SkyForgeConsoleTest
{
    public class ApplicationTest
    {
        [Test]
        public void CheckCalledRunBeforeInit()
        {
            var application = TestApplication.Create();
            Assert.Throws<MethodAccessException>(() => application.Run(), "Application start run before Init");
        }

        [Test]
        public void CheckCalledInitAfterInit()
        {
            var application = TestApplication.Create();
            application.Init();
            Assert.Throws<MethodAccessException>(() => application.Init(), "Application was initialized, you have called initialization twice or more");
        }


        [Test]
        public void CheckAddedToLogInfoWhenCalledInitAfterInit()
        {
            FileSystem.Init<NetCoreIOController>();
            var application = TestApplication.Create();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            application.Init();
            Assert.Throws<MethodAccessException>(() => application.Init(), "Application was initialized, you have called initialization twice or more");
            fakeLogger.CheckLog(" CoreLogger : Application was initialized, you have called initialization twice or more");
        }

        [Test]
        public void CheckAddedToLogInfoWhenCalledRunBeforeInit()
        {
            FileSystem.Init<NetCoreIOController>();
            var application = TestApplication.Create();
            Log.Init();
            var fakeLogger = new FakeLogger();
            Log.CoreLogger.AddLogger(fakeLogger);
            Assert.Throws<MethodAccessException>(() => application.Run(), "Application start run before Init");
            fakeLogger.CheckLog(" CoreLogger : Application start run before Init");
        }
        
        [Test]
        public void CheckPushLayer()
        {
            var fakeLayer = new FakeLayer();
            var testApplication = TestApplication.Create();
            
            testApplication.PushLayer(fakeLayer);
            var result = testApplication.CheckIsContainsLayer(fakeLayer);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CheckPopLayer()
        {
            var testApplication = TestApplication.Create();
            
            var fakeLayer = new FakeLayer();
            testApplication.PushLayer(fakeLayer);
            Assert.IsTrue(testApplication.CheckIsContainsLayer(fakeLayer));
            
            testApplication.PopLayer(fakeLayer);
            Assert.IsFalse(testApplication.CheckIsContainsLayer(fakeLayer));
        }
        
        [Test]
        public void CheckCalledOnEnterWhenPushLayer()
        {
            var testApplication = TestApplication.Create();
            var fakeLayer = new FakeLayer();
            
            testApplication.PushLayer(fakeLayer);
            fakeLayer.CheckCalledOnEnter(1);
        }
        
        [Test]
        public void CheckCalledOnExitWhenPopLayer()
        {
            var testApplication = TestApplication.Create();
            var fakeLayer = new FakeLayer();
            
            testApplication.PushLayer(fakeLayer);
            fakeLayer.CheckCalledOnExit(0);
            testApplication.PopLayer(fakeLayer);

            fakeLayer.CheckCalledOnExit(1);
        }
        
        [Test]
        public void CheckPushLayerAsStack()
        {
            var testApplication = TestApplication.Create();
            
            var firstFakeLayer = new FakeLayer();
            var secondFakeLayer = new FakeLayer();
            
            testApplication.PushLayer(firstFakeLayer);
            testApplication.PushLayer(secondFakeLayer);

            var layers = new Layer[]
            {
                secondFakeLayer,
                firstFakeLayer
            };
            
            testApplication.CheckLayers(layers);
        }
        
        [Test]
        public void CheckPushOverlayLayer()
        {
            var fakeLayer = new FakeLayer();
            var fakeOverlayLayer = new FakeLayer();
            
            var testApplication = TestApplication.Create();
            testApplication.PushOverlay(fakeOverlayLayer);
            Assert.IsTrue(testApplication.CheckIsContainsLayer(fakeOverlayLayer));
            
            testApplication.PushLayer(fakeLayer);
            var layers = new Layer[]
            {
                fakeOverlayLayer,
                fakeLayer
            };
            
            testApplication.CheckLayers(layers);
        }
        
        [Test]
        public void CheckPopOverlayLayer()
        {
            var fakeOverlayLayer = new FakeLayer();
            var testApplication = TestApplication.Create();
            testApplication.PushOverlay(fakeOverlayLayer);
            Assert.IsTrue(testApplication.CheckIsContainsLayer(fakeOverlayLayer));
            testApplication.PopOverlay(fakeOverlayLayer);
            Assert.IsFalse(testApplication.CheckIsContainsLayer(fakeOverlayLayer));
        }

        [Test]
        public void CheckCalledOnEnterWhenPushOverlayLayer()
        {
            var testApplication = TestApplication.Create();
            var fakeOverlayLayer = new FakeLayer();
            testApplication.PushOverlay(fakeOverlayLayer);
            fakeOverlayLayer.CheckCalledOnEnter(1);
        }

        [Test]
        public void CheckCalledOnExitWhenPopOverlayLayer()
        {
            var testApplication = TestApplication.Create();
            var fakeOverlayLayer = new FakeLayer();
            testApplication.PushOverlay(fakeOverlayLayer);
            fakeOverlayLayer.CheckCalledOnExit(0);
            testApplication.PopOverlay(fakeOverlayLayer);
            fakeOverlayLayer.CheckCalledOnExit(1);
        }
    }

    internal interface ITestApplication : IApplication
    {
        bool CheckIsContainsLayer(Layer checkLayer);
        
        void CheckLayers(Layer[] checkLayers);
    }
    
    internal class TestApplication : Application, ITestApplication
    {
        public bool CheckIsContainsLayer(Layer checkLayer)
        {
            var layerStack = GetSelfLayerStack();
            
            if(layerStack is null)
                return false;
            
            foreach(var layer in layerStack)
            {
                if (layer.GetHashCode().Equals(checkLayer.GetHashCode()))
                    return true;
            }
            return false;
        }

        public void CheckLayers(Layer[] checkLayers)
        {
            var layerStack = GetSelfLayerStack();
            
            if(layerStack is null)
                Assert.Fail();

            int index = 0;
            foreach (var layer in layerStack)
            {
                var currentCheckLayer = checkLayers[index++];
                if (!currentCheckLayer.GetHashCode().Equals(layer.GetHashCode()))
                    Assert.Fail();
            }
            
            Assert.Pass();
        }

        private LayerStack GetSelfLayerStack()
        {
            var applicationType = typeof(Application);
            var field = applicationType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(fieldInfo => fieldInfo.FieldType.Equals(typeof(LayerStack))).FirstOrDefault();
            
            if(field is null)
                Assert.Fail();
            
            return field.GetValue(this) as LayerStack;
        }
        
        public static ITestApplication Create()
        {
            return new TestApplication();
        }
    }
}