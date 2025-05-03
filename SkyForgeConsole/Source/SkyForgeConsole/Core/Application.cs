/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Events;
using System;

namespace SkyForgeConsole
{
    public abstract class Application : IApplication
    {
        private bool m_isInit;
        private bool m_isRunning;
        
        private LayerStack m_layerStack;
        private InputSystem m_inputSystem;
        
        public Application()
        {
            m_isInit = false;
            m_isRunning = true;
            m_layerStack = new LayerStack();
        }

        public void PushLayer(Layer layer)
        {
            m_layerStack.PushLayer(layer);
            layer.OnEnter();
        }

        public void PopLayer(Layer layer)
        {
            m_layerStack.PopLayer(layer);
            layer.OnExit();
        }   

        public void PushOverlay(Layer layer)
        {
            m_layerStack.PushOverlay(layer);
            layer.OnEnter();
        }

        public void PopOverlay(Layer layer)
        {
            m_layerStack.PopOverlay(layer);
            layer.OnExit();
        }

        public void Init()
        {
            if (m_isInit)
            {
                Log.CoreLogger?.Logging("Application was initialized, you have called initialization twice or more", LogLevel.Error);
                throw new MethodAccessException("Application was initialized, you have called initialization twice or more");
            }
            
            m_inputSystem = new InputSystem();
            m_inputSystem.Init();
            m_inputSystem.OnEvent += OnEvent;
            m_inputSystem.Run();
            
            m_isInit = true;
            Log.CoreLogger?.Logging("Init SkyForgeEngine !!", LogLevel.Info);
        }

        public void Dispose()
        {
            m_inputSystem.OnEvent -= OnEvent;
            m_inputSystem.Dispose();
        }

        public void Exit()
        {
            m_isRunning = false;
        }

        public void Run()
        {
            if (!m_isInit)
            {
                Log.CoreLogger?.Logging("Application start run before Init", LogLevel.Error);
                throw new MethodAccessException("Application start run before Init");
            }

#if SKY_FORGE_DEBUG || SKY_FORGE_RELEASE

            while (m_isRunning)
            {
                foreach (var layer in m_layerStack)
                {
                    layer.OnUpdate();
                }
            }
#endif
        }

        private void OnEvent(Event eventArg)
        {
            foreach (var layer in m_layerStack)
            {
                layer.OnEvent(eventArg);
            }
        }
    }
}