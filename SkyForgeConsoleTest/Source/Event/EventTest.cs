/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Event;

namespace SkyForgeConsoleTest
{
    public class EventTest
    {
        [Test]
        public void CheckEventType()
        {
            var fakeEvent = new FakeEvent(EventType.MouseButtonPressed, EventCategory.MouseEvent);
            Assert.That(fakeEvent.GetEventType(), Is.EqualTo(EventType.MouseButtonPressed));
            
            fakeEvent = new FakeEvent(EventType.MouseButtonReleased, EventCategory.MouseEvent);
            Assert.That(fakeEvent.GetEventType(), Is.EqualTo(EventType.MouseButtonReleased));

            fakeEvent = new FakeEvent(EventType.KeyPressed, EventCategory.KeyboardEvent);
            Assert.That(fakeEvent.GetEventType(), Is.EqualTo(EventType.KeyPressed));
            
            fakeEvent = new FakeEvent(EventType.ApplicationResize, EventCategory.ApplicationEvent);
            Assert.That(fakeEvent.GetEventType(), Is.EqualTo(EventType.ApplicationResize));
        }

        [Test]
        public void CheckIsEventCategory()
        {
            var fakeEvent = new FakeEvent(EventType.MouseButtonPressed, EventCategory.MouseEvent);
            Assert.True(fakeEvent.IsEventCategory(EventCategory.MouseEvent));
            Assert.False(fakeEvent.IsEventCategory(EventCategory.ApplicationEvent));
            Assert.False(fakeEvent.IsEventCategory(EventCategory.KeyboardEvent));
            
            fakeEvent = new FakeEvent(EventType.KeyPressed, EventCategory.KeyboardEvent);
            Assert.True(fakeEvent.IsEventCategory(EventCategory.KeyboardEvent));
            Assert.False(fakeEvent.IsEventCategory(EventCategory.ApplicationEvent));
            Assert.False(fakeEvent.IsEventCategory(EventCategory.MouseEvent));
            
            fakeEvent = new FakeEvent(EventType.ApplicationResize, EventCategory.MouseEvent | EventCategory.KeyboardEvent);
            Assert.False(fakeEvent.IsEventCategory(EventCategory.ApplicationEvent));
            Assert.True(fakeEvent.IsEventCategory(EventCategory.KeyboardEvent));
            Assert.True(fakeEvent.IsEventCategory(EventCategory.MouseEvent));
        }
    }

    internal class FakeEvent : Event
    {
        public FakeEvent(EventType eventType, EventCategory eventCategory) : base(eventType, eventCategory)
        {
            
        }

        public override string GetName()
        {
            return string.Empty;
        }
    }
}