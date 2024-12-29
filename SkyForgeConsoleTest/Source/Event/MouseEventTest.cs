/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole.Event;

namespace SkyForgeConsoleTest
{
    public class MouseEventTest
    {
        [Test]
        public void CheckGetMouseButton()
        {
            var mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.LeftButton);
            Assert.That(mouseButtonPressed.GetMouseButton(), Is.EqualTo(MouseButton.LeftButton));
            
            mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.MiddleButton);
            Assert.That(mouseButtonPressed.GetMouseButton(), Is.EqualTo(MouseButton.MiddleButton));
            
            var mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.None);
            Assert.That(mouseButtonReleased.GetMouseButton(), Is.EqualTo(MouseButton.None));
            
            mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.RightButton);
            Assert.That(mouseButtonReleased.GetMouseButton(), Is.EqualTo(MouseButton.RightButton));
        }

        [Test]
        public void CheckMouseButtonEventType()
        {
            var mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.LeftButton);
            Assert.That(mouseButtonPressed.GetEventType(), Is.EqualTo(EventType.MouseButtonPressed));
            
            var mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.None);
            Assert.That(mouseButtonReleased.GetEventType(), Is.EqualTo(EventType.MouseButtonReleased));
        }

        [Test]
        public void CheckMouseButtonEventCategory()
        {
            var mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.LeftButton);
            Assert.True(mouseButtonPressed.IsEventCategory(EventCategory.InputEvent));
            Assert.True(mouseButtonPressed.IsEventCategory(EventCategory.MouseEvent));
            Assert.False(mouseButtonPressed.IsEventCategory(EventCategory.ApplicationEvent));
            
            var mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.None);
            Assert.True(mouseButtonReleased.IsEventCategory(EventCategory.MouseEvent));
            Assert.True(mouseButtonReleased.IsEventCategory(EventCategory.InputEvent));
            Assert.False(mouseButtonReleased.IsEventCategory(EventCategory.KeyboardEvent));
        }

        [Test]
        public void CheckMouseButtonGetName()
        {
            var mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.LeftButton);
            Assert.That(mouseButtonPressed.GetName(), Is.EqualTo(nameof(MouseButtonPressedEvent)));
            
            var mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.None);
            Assert.That(mouseButtonReleased.GetName(), Is.EqualTo(nameof(MouseButtonReleasedEvent)));
        }

        [Test]
        public void CheckMouseButtonToString()
        {
            var mouseButtonPressed = new MouseButtonPressedEvent(MouseButton.LeftButton);
            Assert.That(mouseButtonPressed.ToString(), Is.EqualTo("event: MouseButtonPressedEvent pressedButton: LeftButton"));
            
            var mouseButtonReleased = new MouseButtonReleasedEvent(MouseButton.MiddleButton);
            Assert.That(mouseButtonReleased.ToString(), Is.EqualTo("event: MouseButtonReleasedEvent releasedButton: MiddleButton"));
        }


        [Test]
        public void CheckMouseMovedGetMovedPosition()
        {
            var mouseMovedEvent = new MouseMovedEvent(12.3f, 12.3f);
            Assert.That(mouseMovedEvent.GetX(), Is.EqualTo(12.3f));
            Assert.That(mouseMovedEvent.GetY(), Is.EqualTo(12.3f));

            mouseMovedEvent = new MouseMovedEvent(4.4f, 5.3f);
            Assert.That(mouseMovedEvent.GetX(), Is.EqualTo(4.4f));
            Assert.That(mouseMovedEvent.GetY(), Is.EqualTo(5.3f));
        }

        [Test]
        public void CheckMouseMovedEventType()
        {
            var mouseMovedEvent = new MouseMovedEvent(12.3f, 12.3f);
            Assert.That(mouseMovedEvent.GetEventType(), Is.EqualTo(EventType.MouseMoved));
        }

        [Test]
        public void CheckMouseMovedEventCategory()
        {
            var mouseMovedEvent = new MouseMovedEvent(12.3f, 12.3f);
            Assert.False(mouseMovedEvent.IsEventCategory(EventCategory.ApplicationEvent));
            Assert.True(mouseMovedEvent.IsEventCategory(EventCategory.MouseEvent));
            Assert.False(mouseMovedEvent.IsEventCategory(EventCategory.InputEvent));
        }
        
        [Test]
        public void CheckMouseMovedGetName()
        {
            var mouseMovedEvent = new MouseMovedEvent(1, 1);
            Assert.That(mouseMovedEvent.GetName(), Is.EqualTo(nameof(MouseMovedEvent)));
        }
        
        [Test]
        public void CheckMouseMovedToString()
        {
            var mouseMovedEvent = new MouseMovedEvent(1, 1);
            Assert.That(mouseMovedEvent.ToString(), Is.EqualTo("event: MouseMovedEvent (x: 1, y: 1)"));
            
            mouseMovedEvent = new MouseMovedEvent(14.3f, 4.7f);
            Assert.That(mouseMovedEvent.ToString(), Is.EqualTo("event: MouseMovedEvent (x: 14.3, y: 4.7)"));
        }

        [Test]
        public void CheckMouseScrollGetScrollDelta()
        {
            var mouseScrollEvent = new MouseScrollEvent(10f, 20f);
            Assert.That(mouseScrollEvent.GetXOffest(), Is.EqualTo(10f));
            Assert.That(mouseScrollEvent.GetYOffest(), Is.EqualTo(20f));
            
            mouseScrollEvent = new MouseScrollEvent(87f, 45f);
            Assert.That(mouseScrollEvent.GetXOffest(), Is.EqualTo(87f));
            Assert.That(mouseScrollEvent.GetYOffest(), Is.EqualTo(45f));
        }

        [Test]
        public void CheckMouseScrollEventType()
        {
            var mouseScrollEvent = new MouseScrollEvent(1, 1);
            Assert.That(mouseScrollEvent.GetEventType(), Is.EqualTo(EventType.MouseScrolled));
            
        }

        [Test]
        public void CheckMouseScrollEventCategory()
        {
            var mouseScrollEvent = new MouseScrollEvent(1, 1);
            Assert.False(mouseScrollEvent.IsEventCategory(EventCategory.ApplicationEvent));
            Assert.True(mouseScrollEvent.IsEventCategory(EventCategory.MouseEvent));
            Assert.False(mouseScrollEvent.IsEventCategory(EventCategory.InputEvent));
            Assert.False(mouseScrollEvent.IsEventCategory(EventCategory.KeyboardEvent));
        }

        [Test]
        public void CheckMouseScrollGetName()
        {
            var mouseScrollEvent = new MouseScrollEvent(1, 1);
            Assert.That(mouseScrollEvent.GetName(), Is.EqualTo(nameof(MouseScrollEvent)));
        }

        [Test]
        public void CheckMouseScrollToString()
        {
            var mouseScrollEvent = new MouseScrollEvent(1, 1);
            Assert.That(mouseScrollEvent.ToString(), Is.EqualTo("event: MouseScrollEvent (xOffset: 1, yOffset: 1)"));
            
            mouseScrollEvent = new MouseScrollEvent(14.3f, 4.7f);
            Assert.That(mouseScrollEvent.ToString(), Is.EqualTo("event: MouseScrollEvent (xOffset: 14.3, yOffset: 4.7)"));
        }
    }
}

