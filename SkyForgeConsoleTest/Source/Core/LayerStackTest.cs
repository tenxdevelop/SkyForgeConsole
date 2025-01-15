/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using NUnit.Framework;

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
            Assert.That(result[0], Is.EqualTo(secondFakeLayer));
            Assert.That(result[1], Is.EqualTo(firstFakeLayer));
        }
    }
}

