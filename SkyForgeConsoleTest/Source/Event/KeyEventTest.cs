/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using NUnit.Framework;
using SkyForgeConsole.Event;

namespace SkyForgeConsoleTest
{
    public class KeyEventTest
    {
        [Test]
        public void CheckGetKeyCode()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.B));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.C);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.C));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.D);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.D));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.RCtrl);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.RCtrl));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.Space);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.Space));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.Tab);
            Assert.That(keyPressedEvent.GetKeyCode(), Is.EqualTo(KeyCode.Tab));
            
            
            var keyReleasedEvent = new KeyReleasedEvent(KeyCode.B);
            Assert.That(keyReleasedEvent.GetKeyCode(), Is.EqualTo(KeyCode.B));
            
            keyReleasedEvent = new KeyReleasedEvent(KeyCode.C);
            Assert.That(keyReleasedEvent.GetKeyCode(), Is.EqualTo(KeyCode.C));
            
            keyReleasedEvent = new KeyReleasedEvent(KeyCode.D);
            Assert.That(keyReleasedEvent.GetKeyCode(), Is.EqualTo(KeyCode.D));
            
            keyReleasedEvent = new KeyReleasedEvent(KeyCode.One);
            Assert.That(keyReleasedEvent.GetKeyCode(), Is.EqualTo(KeyCode.One));
            
            keyReleasedEvent = new KeyReleasedEvent(KeyCode.PageUp);
            Assert.That(keyReleasedEvent.GetKeyCode(), Is.EqualTo(KeyCode.PageUp));
        }

        [Test]
        public void CheckGetKeyName()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B);
            Assert.That(keyPressedEvent.GetName(), Is.EqualTo(nameof(KeyPressedEvent)));
            
            var keyReleasedEvent = new KeyReleasedEvent(KeyCode.B);
            Assert.That(keyReleasedEvent.GetName(), Is.EqualTo(nameof(KeyReleasedEvent)));
            
        }

        [Test]
        public void CheckGetString()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B);
            Assert.That(keyPressedEvent.ToString(), Is.EqualTo($"event: {keyPressedEvent.GetName()} pressedKey: {keyPressedEvent.GetKeyCode()}"));
            
            var keyReleasedEvent = new KeyReleasedEvent(KeyCode.B);
            Assert.That(keyReleasedEvent.ToString(), Is.EqualTo($"event: {keyReleasedEvent.GetName()} releasedKey: {keyReleasedEvent.GetKeyCode()}"));
        }


        [Test]
        public void CheckEventType()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B);
            Assert.That(keyPressedEvent.GetEventType(), Is.EqualTo(EventType.KeyPressed));
            
            var keyReleasedEvent = new KeyReleasedEvent(KeyCode.B);
            Assert.That(keyReleasedEvent.GetEventType(), Is.EqualTo(EventType.KeyReleased));
        }

        [Test]
        public void CheckEventCategory()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B);
            Assert.True(keyPressedEvent.IsEventCategory(EventCategory.InputEvent));
            
            Assert.True(keyPressedEvent.IsEventCategory(EventCategory.KeyboardEvent));
            
            Assert.False(keyPressedEvent.IsEventCategory(EventCategory.MouseEvent));
            
            var keyReleasedEvent = new KeyReleasedEvent(KeyCode.B);
            Assert.False(keyPressedEvent.IsEventCategory(EventCategory.MouseEvent));
            
            Assert.True(keyReleasedEvent.IsEventCategory(EventCategory.KeyboardEvent));
            
            Assert.True(keyReleasedEvent.IsEventCategory(EventCategory.InputEvent));
        }

        [Test]
        public void CheckRepeatCountPressed()
        {
            var keyPressedEvent = new KeyPressedEvent(KeyCode.B, 1);
            Assert.That(keyPressedEvent.GetRepeatCount(), Is.EqualTo(1));
            
            keyPressedEvent.Pressed();
            keyPressedEvent.Pressed();
            
            Assert.That(keyPressedEvent.GetRepeatCount(), Is.EqualTo(3));
            
            keyPressedEvent.Pressed();
            Assert.That(keyPressedEvent.GetRepeatCount(), Is.EqualTo(4));
            
            keyPressedEvent = new KeyPressedEvent(KeyCode.D);
            Assert.That(keyPressedEvent.GetRepeatCount(), Is.EqualTo(0));
        }

        [Test]
        public void CheckGetKeyCodeFromConsolekey()
        {
            
            var keyCode = ConsoleKey.D1.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.One));
            
            keyCode = ConsoleKey.D2.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Two));
            
            keyCode = ConsoleKey.D3.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Three));
            
            keyCode = ConsoleKey.D4.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Four));
            
            keyCode = ConsoleKey.D0.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Zero));
            
            keyCode = ConsoleKey.D9.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Nine));
            
            keyCode = ConsoleKey.Spacebar.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Space));
            
            keyCode = ConsoleKey.UpArrow.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.PageUp));
            
            keyCode = ConsoleKey.DownArrow.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.PageDown));
            
            keyCode = ConsoleKey.LeftArrow.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.PageLeft));
            
            keyCode = ConsoleKey.RightArrow.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.PageRight));
            
            keyCode = ConsoleKey.Enter.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Enter));
            
            keyCode = ConsoleKey.Escape.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.Escape));

            keyCode = ConsoleKey.W.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.W));
            
            keyCode = ConsoleKey.S.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.S));
            
            keyCode = ConsoleKey.A.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.A));
            
            keyCode = ConsoleKey.D.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.D));

            keyCode = ConsoleKey.E.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.E));
            
            keyCode = ConsoleKey.F.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.F));
            
            keyCode = ConsoleKey.G.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.G));
            
            keyCode = ConsoleKey.H.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.H));
            
            keyCode = ConsoleKey.I.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.I));
            
            keyCode = ConsoleKey.J.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.J));
            
            keyCode = ConsoleKey.K.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.K));
            
            keyCode = ConsoleKey.L.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.L));
            
            keyCode = ConsoleKey.M.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.M));
            
            keyCode = ConsoleKey.N.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.N));
            
            keyCode = ConsoleKey.O.GetKeyCodeFromConsoleKey();
            Assert.That(keyCode, Is.EqualTo(KeyCode.O));
        }
    }
}

