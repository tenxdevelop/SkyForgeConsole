/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Maths;
using NUnit.Framework;

namespace SkyForgeConsoleTest
{
    
    public class SpriteTest
    {
        public void CreateSpriteTest()
        {
            var chars = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };

            var spriteSize = new Vector2(4, 3);
            
            var sprite = new Sprite(chars, spriteSize);
            
            Assert.That(sprite.Width, Is.EqualTo(spriteSize.x));
            Assert.That(sprite.Height, Is.EqualTo(spriteSize.y));
        }


        public void CreateSpriteWithoutSizeTest()
        {
            var chars = new char[][]
            {
                [ '*', '*', '*', '*' ],
                [ '*', ' ', ' ', '*' ],
                [ '*', '*', '*', '*' ]
            };
            
            var sprite = new Sprite(chars);
            
            Assert.That(sprite.Width, Is.EqualTo(4));
            Assert.That(sprite.Height, Is.EqualTo(3));
        }

        public void CheckSpriteSizeTest()
        {
            var spriteSize = new Vector2(4, 3);
            
            var chars = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };

            var sprite = new Sprite(chars, spriteSize);
            
            Assert.That(sprite.Size, Is.EqualTo(spriteSize));
        }

        public void GetBufferSpriteTest()
        {
            
            var chars = new char[][]
            {
                [ '*', '*', '*', '*' ],
                [ '*', ' ', ' ', '*' ],
                [ '*', '*', '*', '*' ]
            };
            
            var actualChars = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };
            
            var sprite = new Sprite(chars);
            
            Assert.That(sprite.GetBuffer(), Is.EqualTo(actualChars));
        }

        public void GetSpriteFromImageTest()
        {
            var urlImage = "testImages/testImage.png";
            
            var sprite = Sprite.LoadFromImage(urlImage);
            
            Assert.That(sprite.Width, Is.EqualTo(0));
            Assert.That(sprite.Height, Is.EqualTo(0));
            
            var actualChars = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };
            
            Assert.That(sprite.GetBuffer(), Is.EqualTo(actualChars));
        }
    }
}