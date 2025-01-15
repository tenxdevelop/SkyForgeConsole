/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using SkyForgeConsole.Events;

namespace SkyForgeConsoleTest
{
    public class LayerTest
    {
        [Test]
        public void CheckGetName()
        {
            var fakeLayer = new FakeLayer("customNameLayer");
            Assert.That(fakeLayer.GetName(), Is.EqualTo("customNameLayer"));
        }

        [Test]
        public void CheckDefaultGetName()
        {
            var fakeLayer = new FakeLayer();
            Assert.That(fakeLayer.GetName(), Is.EqualTo(nameof(FakeLayer)));
        }

        [Test]
        public void CheckGetHashCode()
        {
            var firstFakeLayer = new FakeLayer();
            var secondFakeLayer = new FakeLayer();
            Assert.That(firstFakeLayer.GetHashCode(), Is.Not.EqualTo(secondFakeLayer.GetHashCode()));
        }

        [Test]
        public void CheckContainsMethod()
        {
            var fakeLayer = new FakeLayer();
            fakeLayer.OnEnter();
            fakeLayer.OnExit();
            fakeLayer.OnUpdate();
            var fakeEvent = new FakeEvent(EventType.ApplicationClose, EventCategory.ApplicationEvent);
            fakeLayer.OnEvent(fakeEvent);
            Assert.Pass();
        }
    }

    internal interface IFakeLayer
    {
        void CheckCalledOnEnter(int countCalled);
        void CheckCalledOnExit(int countCalled);
    }
    
    internal class FakeLayer : Layer, IFakeLayer
    {
        private int m_countCalledOnEnter;
        private int m_countCalledOnExit;

        internal FakeLayer() : base(nameof(FakeLayer))
        {
            
        }
        
        internal FakeLayer(string layerName) : base(layerName)
        {
            
        }

        public override void OnEnter()
        {
            m_countCalledOnEnter++;
        }

        public override void OnExit()
        {
            m_countCalledOnExit++;
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnEvent(Event eventArgs)
        {
            
        }
        
        public void CheckCalledOnEnter(int countCalled)
        {
            Assert.That(m_countCalledOnEnter, Is.EqualTo(countCalled));
        }

        public void CheckCalledOnExit(int countCalled)
        {
            Assert.That(m_countCalledOnExit, Is.EqualTo(countCalled));
        }
    }
    
}

