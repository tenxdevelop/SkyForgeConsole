/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using NUnit.Framework;
using SkyForgeConsole;
using System;

namespace SkyForgeConsoleTest
{
    public class InputSystemTest
    {
        
        [Test]
        public void CheckErrorRunInputSystemBeforeInit()
        {
            IInputSystem inputSystem = new InputSystem();
            Assert.Throws<MethodAccessException>(() => inputSystem.Run(), "InputSystem start run before Init");
        }

        [Test]
        public void CheckInitInputSystemAfterInit()
        {
            IInputSystem inputSystem = new InputSystem();
            inputSystem.Init();
            Assert.Throws<MethodAccessException>(() => inputSystem.Init(), "InputSystem was initialized, you have called initialization twice or more");
        }

        [Test]
        public void CheckOnEventInputSystem()
        {
            //TODO: check input event key and mouse event
            
        }
    }
    
}