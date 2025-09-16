/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/


using SkyForgeConsole.Maths;

namespace SkyForgeConsole
{

    public interface IWindow
    {
        int Height { get; }
        
        int Width { get; }

        Vector2 Size { get; }

        void Init(IRenderPipeline renderPipeline);

        void Render(char[] spriteBuffer, Vector2 position);

        void Render(Sprite sprite, Vector2 position);
    }
    
}