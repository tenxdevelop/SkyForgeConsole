/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForgeConsole.Events
{
    public static class KeyCodeExtension
    {
        public static KeyCode GetKeyCodeFromConsoleKey(this ConsoleKey consoleKey)
        {
            var keyCode = KeyCode.None;
            switch (consoleKey)
            {
                case ConsoleKey.D1: 
                    keyCode = KeyCode.One; 
                    break;
                case ConsoleKey.D2: 
                    keyCode = KeyCode.Two; 
                    break;
                case ConsoleKey.D3: 
                    keyCode = KeyCode.Three; 
                    break;
                case ConsoleKey.D4: 
                    keyCode = KeyCode.Four; 
                    break;
                case ConsoleKey.D5: 
                    keyCode = KeyCode.Five; 
                    break;
                case ConsoleKey.D6: 
                    keyCode = KeyCode.Six; 
                    break;
                case ConsoleKey.D7: 
                    keyCode = KeyCode.Seven; 
                    break;
                case ConsoleKey.D8: 
                    keyCode = KeyCode.Eight; 
                    break;
                case ConsoleKey.D9: 
                    keyCode = KeyCode.Nine; 
                    break;
                case ConsoleKey.D0: 
                    keyCode = KeyCode.Zero; 
                    break;
                case ConsoleKey.Q: 
                    keyCode = KeyCode.Q; 
                    break;
                case ConsoleKey.W: 
                    keyCode = KeyCode.W; 
                    break;
                case ConsoleKey.E: 
                    keyCode = KeyCode.E; 
                    break;
                case ConsoleKey.R: 
                    keyCode = KeyCode.R; 
                    break;
                case ConsoleKey.T: 
                    keyCode = KeyCode.T; 
                    break;
                case ConsoleKey.Y: 
                    keyCode = KeyCode.Y; 
                    break;
                case ConsoleKey.U: 
                    keyCode = KeyCode.U; 
                    break; 
                case ConsoleKey.I: 
                    keyCode = KeyCode.I; 
                    break;
                case ConsoleKey.O: 
                    keyCode = KeyCode.O; 
                    break;
                case ConsoleKey.P: 
                    keyCode = KeyCode.P; 
                    break;
                case ConsoleKey.A: 
                    keyCode = KeyCode.A; 
                    break;
                case ConsoleKey.S: 
                    keyCode = KeyCode.S; 
                    break;
                case ConsoleKey.D: 
                    keyCode = KeyCode.D; 
                    break;
                case ConsoleKey.F: 
                    keyCode = KeyCode.F; 
                    break;
                case ConsoleKey.G: 
                    keyCode = KeyCode.G; 
                    break;
                case ConsoleKey.H: 
                    keyCode = KeyCode.H; 
                    break;
                case ConsoleKey.J: 
                    keyCode = KeyCode.J; 
                    break;
                case ConsoleKey.K: 
                    keyCode = KeyCode.K; 
                    break;
                case ConsoleKey.L: 
                    keyCode = KeyCode.L; 
                    break;
                case ConsoleKey.Z: 
                    keyCode = KeyCode.Z; 
                    break;
                case ConsoleKey.X: 
                    keyCode = KeyCode.X; 
                    break;
                case ConsoleKey.C: 
                    keyCode = KeyCode.C; 
                    break;
                case ConsoleKey.V: 
                    keyCode = KeyCode.V; 
                    break;
                case ConsoleKey.B: 
                    keyCode = KeyCode.B; 
                    break;
                case ConsoleKey.N: 
                    keyCode = KeyCode.N; 
                    break;
                case ConsoleKey.M: 
                    keyCode = KeyCode.M; 
                    break;
                case ConsoleKey.Spacebar: 
                    keyCode = KeyCode.Space; 
                    break;
                case ConsoleKey.Escape: 
                    keyCode = KeyCode.Escape; 
                    break;
                case ConsoleKey.Enter: 
                    keyCode = KeyCode.Enter; 
                    break;
                case ConsoleKey.DownArrow: 
                    keyCode = KeyCode.PageDown; 
                    break;
                case ConsoleKey.UpArrow: 
                    keyCode = KeyCode.PageUp; 
                    break;
                case ConsoleKey.LeftArrow: 
                    keyCode = KeyCode.PageLeft; 
                    break;
                case ConsoleKey.RightArrow: 
                    keyCode = KeyCode.PageRight; 
                    break;
                case ConsoleKey.Tab: 
                    keyCode = KeyCode.Tab; 
                    break;
            }
            
            return keyCode;
        }
    }
}

