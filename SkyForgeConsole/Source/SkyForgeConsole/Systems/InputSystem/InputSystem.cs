/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;
using System.Threading;
using System;
using SkyForgeConsole.Vendor.Win32;

namespace SkyForgeConsole
{
    public class InputSystem : IInputSystem
    {
        public event Action<Events.Event> OnEvent;
        
        private bool m_isInit;
        private bool m_isRunning;
        
        private Thread m_inputPressedThread;
        private Thread m_inputReleasedThread;

        private int m_xMousePosition;
        private int m_yMousePosition;
        
        private KeyEventTime m_lastInputKeyEvent;
        
        private bool m_isReleasedMouseLeftButton;
        private bool m_isReleasedMouseRightButton;
        private bool m_isReleasedMouseMiddleButton;
        public void Init()
        {
            if (m_isInit)
            {
                Log.CoreLogger?.Logging("InputSystem was initialized, you have called initialization twice or more", LogLevel.Error);
                throw new MethodAccessException("InputSystem was initialized, you have called initialization twice or more");
            }
            
            m_isRunning = true;
            
            m_isReleasedMouseLeftButton = true;
            m_isReleasedMouseRightButton = true;
            m_isReleasedMouseMiddleButton = true;
            
            var inputPressedThreadStart = new ThreadStart(UpdateInputPressedSystem);
            m_inputPressedThread = new Thread(inputPressedThreadStart);
            
            var inputReleasedThreadStart = new ThreadStart(UpdateInputReleasedSystem);
            m_inputReleasedThread = new Thread(inputReleasedThreadStart);
            
            m_isInit = true;
            Log.CoreLogger?.Logging("InputSystem initialized !", LogLevel.Info);
        }
        
        public void Run()
        {
            if (!m_isInit)
            {
                Log.CoreLogger?.Logging("InputSystem start run before Init", LogLevel.Error);
                throw new MethodAccessException("InputSystem start run before Init");
            }
            
            m_inputPressedThread.Start();
            m_inputReleasedThread.Start();
        }
        
        
        private void UpdateInputPressedSystem()
        {
            while (m_isRunning)
            {
                var keyCode = Console.ReadKey(true).Key.GetKeyCodeFromConsoleKey();
                if (m_lastInputKeyEvent?.GetEvent().GetKeyCode() == keyCode)
                {
                    m_lastInputKeyEvent.Reset();
                    m_lastInputKeyEvent.GetEvent().Pressed();
                }
                else
                {
                    if (m_lastInputKeyEvent is not null && m_lastInputKeyEvent.IsValidEvent())
                    {
                        var keyReleasedEvent = new KeyReleasedEvent(m_lastInputKeyEvent.GetEvent().GetKeyCode());
                        OnEvent?.Invoke(keyReleasedEvent);
                        m_lastInputKeyEvent = null;
                    }
                    
                    var keyEvent = new KeyPressedEvent(keyCode);
                    keyEvent.Pressed();
                    m_lastInputKeyEvent = new KeyEventTime(keyEvent);
                    
                }
                
                OnEvent?.Invoke(m_lastInputKeyEvent.GetEvent());
                
                Thread.Sleep(5);
            }
        }

        private void UpdateInputReleasedSystem()
        {
            while (m_isRunning)
            {
                if (m_lastInputKeyEvent is not null)
                {
                    m_lastInputKeyEvent.Update(0.1f);
                    
                    if (!m_lastInputKeyEvent.IsValidEvent())
                    {
                        var keyReleasedEvent = new KeyReleasedEvent(m_lastInputKeyEvent.GetEvent().GetKeyCode());
                        OnEvent?.Invoke(keyReleasedEvent);
                        m_lastInputKeyEvent = null;
                    }
                }
                
                UpdateMouseMovedEvent();
                UpdateMouseButtonEvent();
                
                Thread.Sleep(10);
            }
        }

        private void UpdateMouseMovedEvent()
        {
            if (WinAPINative.GetCursorPos(out var mousePoint))
            {

                if (m_xMousePosition != mousePoint.X || m_yMousePosition != mousePoint.Y)
                {
                    m_xMousePosition = mousePoint.X;
                    m_yMousePosition = mousePoint.Y;
                    var mouseMovedEvent = new MouseMovedEvent(m_xMousePosition, m_yMousePosition);
                    OnEvent?.Invoke(mouseMovedEvent);
                }
            }
        }

        private void UpdateMouseButtonEvent()
        {
            if (WinAPINative.GetKeyState(0x01))
            {
                m_isReleasedMouseLeftButton = false;
                var mouseButtonEvent = new MouseButtonPressedEvent(MouseButton.LeftButton);
                OnEvent?.Invoke(mouseButtonEvent);
            }
            else
            {
                if (!m_isReleasedMouseLeftButton)
                {
                    m_isReleasedMouseLeftButton = true;
                    var mouseButtonEvent = new MouseButtonReleasedEvent(MouseButton.LeftButton);
                    OnEvent?.Invoke(mouseButtonEvent);
                }
            }

            if (WinAPINative.GetKeyState(0x02))
            {
                m_isReleasedMouseRightButton = false;
                var mouseButtonEvent = new MouseButtonPressedEvent(MouseButton.RightButton);
                OnEvent?.Invoke(mouseButtonEvent);
            }
            else
            {
                if (!m_isReleasedMouseRightButton)
                {
                    m_isReleasedMouseRightButton = true;
                    var mouseButtonEvent = new MouseButtonReleasedEvent(MouseButton.RightButton);
                    OnEvent?.Invoke(mouseButtonEvent);
                }
            }

            if (WinAPINative.GetKeyState(0x04))
            {
                m_isReleasedMouseMiddleButton = false;
                var mouseButtonEvent = new MouseButtonPressedEvent(MouseButton.MiddleButton);
                OnEvent?.Invoke(mouseButtonEvent);
            }
            else
            {
                if (!m_isReleasedMouseMiddleButton)
                {
                    m_isReleasedMouseMiddleButton = true;
                    var mouseButtonEvent = new MouseButtonReleasedEvent(MouseButton.MiddleButton);
                    OnEvent?.Invoke(mouseButtonEvent);
                }
            }
        }
        
        public void Dispose()
        {
            m_isRunning = false;
        }
    }

    internal class KeyEventTime
    {
        private const float TIME_TO_LIVE_EVENT = 1.0f;
        private KeyPressedEvent m_keyPressedEvent;
        private float m_currentTime;
        public KeyEventTime(KeyPressedEvent keyPressedEvent)
        {
            m_keyPressedEvent = keyPressedEvent;
            Reset();
        }

        public KeyPressedEvent GetEvent() => m_keyPressedEvent;

        public void Update(float deltaTime)
        {
            m_currentTime -= deltaTime;
        }

        public bool IsValidEvent()
        {
            return m_currentTime > 0;
        }
        
        public void Reset()
        {
            m_currentTime = TIME_TO_LIVE_EVENT;
        }
    }
}

