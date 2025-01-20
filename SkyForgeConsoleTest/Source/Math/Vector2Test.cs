/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using NUnit.Framework;

namespace SkyForgeConsoleTest
{
    public class Vector2Test
    {
        [Test]
        public void CheckCreateVector2WithAtribute()
        {
            var vector = new Vector2(10, 15);
            
            Assert.That(vector.x, Is.EqualTo(10));
            Assert.That(vector.y, Is.EqualTo(15));
            
        }

        [Test]
        public void CheckCreateVector2Default()
        {
            var vector = new Vector2();
            
            Assert.That(vector.x, Is.EqualTo(0));
            Assert.That(vector.y, Is.EqualTo(0));
        }

        [Test]
        public void CheckTypeValueInVector2()
        {
            var vector = new Vector2();
            
            Assert.That(vector.x.GetType(), Is.EqualTo(typeof(float)));
            Assert.That(vector.y.GetType(), Is.EqualTo(typeof(float)));
        }

        [Test]
        public void CheckEqualsVector2()
        {
            var firstVector = new Vector2(10, 12);

            var secondVector = new Vector2(10, 12);
            
            Assert.IsTrue(firstVector.Equals(secondVector));
        }

        [Test]
        public void CheckVectorEqualsWhenAtributeIsNegative()
        {
            var firstVector = new Vector2(-1, 2);
            var secondVector = new Vector2(-1, 2);
            
            Assert.IsTrue(firstVector.Equals(secondVector));
        }

        [Test]
        public void CheckVectorZero()
        {
            var vectorZero = Vector2.Zero;
            
            Assert.That(vectorZero, Is.EqualTo(new Vector(0, 0)));
        }

        [Test]
        public void CheckVectorUp()
        {
            var vectorUp = Vector2.Up;
            
            Assert.That(vectorUp, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void CheckVectorDown()
        {
            var vectorDown = Vector2.Down;
            
            Assert.That(vectorDown, Is.EqualTo(new Vector2(0, -1)));
        }

        [Test]
        public void CheckVectorRight()
        {
            var vectorRight = Vector2.Right;
            
            Assert.That(vectorRight, Is.EqualTo(new Vector2(1, 0)));
        }

        [Test]
        public void CheckVectorLeft()
        {
            var vectorLeft = Vector2.Left;
            
            Assert.That(vectorLeft, Is.EqualTo(new Vector2(-1, 0)));
        }

        [Test]
        public void CheckVectorMoreOtherVector1()
        {
            var firstVector = new Vector2(10, 10);

            var secondVector = new Vector2(5, 5);
            
            Assert.IsTrue(firstVector > secondVector);
        }

        [Test]
        public void CheckVectorLessOtherVector1()
        {
            var firstVector = new Vector2(3, 3);

            var secondVector = new Vector2(12, 2);
            
            Assert.That(firstVector < secondVector);
        }

        [Test]
        public void CheckVectorGetMagnitude()
        {
            var vector = new Vector2(3, 4);
            
            Assert.That(vector.GetMagnitude, Is.EqualTo(5));
        }

        [Test]
        public void CheckVectorGetMagnitude2()
        {
            var vector = new Vector2(12, 25);

            var errorArea = 0.00000001f;
            
            Assert.IsTrue(27.730849247f - errorArea <= vector.GetMagnitude <= 27.730849247f + errorArea);
        }

        [Test]
        public void CheckVectorGetNormalized()
        {
            var vector = new Vector2(3, 4);

            vector = vector.GetNormalized();
            
            Assert.That(vector, Is.EqualTo(new Vector2(0.6, 0.8)));
        }

        [Test]
        public void CheckVectorNormalize()
        {
            var vector = new Vector2(3, 4);

            vector.Normalize();
            
            Assert.That(vector, Is.EqualTo(new Vector2(0.6, 0.8)));
        }

        [Test]
        public void CheckVectorGetNormalized2()
        {
            var vector = new Vector2(12, 12);

            vector = vector.GetNormalized();
            
            var errorArea = 0.0000001f;
            
            Assert.IsTrue(0.707106781 - errorArea <= vector.x <= 0.707106781 + errorArea);
            Assert.IsTrue(0.707106781 - errorArea <= vector.y <= 0.707106781 + errorArea);
        }

        [Test]
        public void CheckVectorNormalize2()
        {
            var vector = new Vector2(12, 12);

            vector.Normalize();

            var expression = new Vector2(0.707106781, 0.707106781);
            
            var errorArea = 0.0000001f;
            
            Assert.IsTrue(expression - errorArea <= vector <= expression + errorArea);
        }

        [Test]
        public void CheckVectorAddValue()
        {
            var vector = new Vector2(7, 3);

            vector = vector + 2;
            
            Assert.That(vector, Is.EqualTo(new Vector2(9, 5)));
        }

        [Test]
        public void CheckVectorAddValue2()
        {
            var vector = new Vector2(-12, 6);

            vector = vector + 2.4;
            
            Assert.That(vector, Is.EqualTo(new Vector2(-9.6, 8.4)));
        }

        [Test]
        public void CheckVectorAddVector()
        {
            var firstVector = new Vector2(1, 1);

            var secondVector = new Vector2(-1, 3);
            
            Assert.That(firstVector + secondVector, Is.EqualTo(new Vector2(0, 4)));
        }

        [Test]
        public void CheckVectorAddVector2()
        {
            //TODO: impl test
        }
        
        [Test]
        public void CheckVectorSubtractValue()
        {
            var vector = new Vector2(10, 10);

            vector = vector - 4.4;
            
            Assert.That(vector, Is.EqualTo(new Vector(5.6, 5.6)));
        }

        [Test]
        public void CheckVectorSubtractValue2()
        {
            var vector = new Vector2(4, 3);

            vector = vector - 5.2;
            
            Assert.That(vector, Is.EqualTo(new Vector2(-1.2, -2.2)));
        }

        [Test]
        public void CheckVectorSubtractVector()
        {
            var firstVector = new Vector2(12, 4);

            var secondVector = new Vector2(5, 6);
            
            Assert.That(firstVector - secondVector, Is.EqualTo(new Vector2(7, -2)));
        }

        [Test]
        public void CheckVectorSubtractVector2()
        {
            var firstVector = new Vector2(7, 2);

            var secondVector = new Vector2(6, 3);
            
            Assert.That(firstVector - secondVector, Is.EqualTo(new Vector2(1, -1)));
        }
        
        [Test]
        public void CheckVectorMultiplyValue()
        {
            var firstVector = new Vector2(3, 7);

            firstVector = firstVector * 1.5;
            
            Assert.That(firstVector, Is.EqualTo(new Vector2(4.5, 10.5)));
        }

        [Test]
        public void CheckVectorMultiplyValue2()
        {
            var firstVector = new Vector2(4, 3);

            firstVector = firstVector * 5;
            
            Assert.That(firstVector, Is.EqualTo(new Vector2(20, 15)));
        }

        [Test]
        public void CheckVectorDivideValue()
        {
            var firstVector = new Vector2(3, 8);

            firstVector = firstVector / 2;
            
            Assert.That(firstVector, Is.EqualTo(new Vector2(1.5, 4)));
        }

        [Test]
        public void CheckVectorDivideValue2()
        {
            var firstVector = new Vector2(12, 12);

            firstVector = firstVector / 0.5;
            
            Assert.That(firstVector, Is.EqualTo(new Vector2(24, 24)));
        }
        
        [Test]
        public void CheckVectorToString()
        {
            var vector = new Vector2(24, 3.5);
            
            Assert.That(vector.ToString(), Is.EqualTo(" (x: 24; y: 3.5) "));
        }

        [Test]
        public void CheckVectorToString2()
        {
            var vector = new Vector2(-5.4, 3.4);
            
            Assert.That(vector.ToString(), Is.EqualTo(" (x: -5.4, y: 3.4) "));
        }
    }
}

