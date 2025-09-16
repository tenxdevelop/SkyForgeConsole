/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using SkyForgeConsole.Maths;
using System;

namespace SkyForgeConsole
{
    public class Sprite
    {
        public static Sprite None => new Sprite(new char[][] {});
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Vector2 Size { get; private set; }
        
        private char[] m_buffer;

        public static Sprite LoadFromImage(string imagePath)
        {
            return None;
        }
        
        public Sprite(char[] spriteBuffer, Vector2 spriteSize)
        {
            m_buffer = spriteBuffer;

            Height = Convert.ToInt32(spriteSize.y);
            Width = Convert.ToInt32(spriteSize.x);
            Size = spriteSize;
            
        }

        public Sprite(char[][] spriteBuffer)
        {
            //TODO: need dimension for char[][] to char[]
            //m_buffer = spriteBuffer
            
        }

        public char[] GetBuffer()
        {
            return m_buffer;
        }
        
    }
}