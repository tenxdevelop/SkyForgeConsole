/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Maths;

namespace SkyForgeConsole
{
    public class ConsoleWindow : IWindow
    {
        public int Height { get; private set; }
        
        public int Width { get; private set; }
        
        public Vector2 Size { get; private set; }

        public ConsoleWindow(int width, int height)
        {
            
        }

        public ConsoleWindow(Vector2 windowSize)
        {
            
        }
        
        public void Init(IRenderPipeline renderPipeline)
        {
            
        }

        public void Render(char[] spriteBuffer, Vector2 position)
        {
            
        }

        public void Render(Sprite sprite, Vector2 position)
        {
            
        }
    }
}