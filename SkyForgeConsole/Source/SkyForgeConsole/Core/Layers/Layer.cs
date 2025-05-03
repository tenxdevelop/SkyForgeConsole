/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole
{
    public abstract class Layer
    {
        private string m_layerName;
        public Layer(string layerName)
        {
            m_layerName = layerName;
        }
        
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnEvent(Event eventArgs);
        public abstract void OnExit();
        public string GetName() => m_layerName;
    }
}

