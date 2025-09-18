/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using NUnit.Framework;

namespace SkyForgeConsoleTest
{

    public class ArrayExtensionTest
    {
        [Test]
        public void DimensionCharsArray2DTo1DArrayTest()
        {
            var actualArray = new char[][]
            {
                ['*', '*', '*', '*'],
                ['*', ' ', ' ', '*'],
                ['*', '*', '*', '*']
            };

            var result = actualArray.DimensionArray();

            var actualResult = new char[]
            {
                '*', '*', '*', '*',
                '*', ' ', ' ', '*',
                '*', '*', '*', '*'
            };
            
            Assert.That(result, Is.EqualTo(actualResult));
        }
        
        [Test]
        public void DimensionCharsArray2DTo1DArrayTestSecond()
        {
            var actualArray = new char[][]
            {
                ['*', '*', '*'],
                ['*', ' ', '*']
            };
            
            var result = actualArray.DimensionArray();
            
            var actualResult = new char[]
            {
                '*', '*', '*',
                '*', ' ', '*'
            };
            
            Assert.That(result, Is.EqualTo(actualResult));
        }
        
        [Test]
        public void DimensionCharsArray2DTo1DArrayTestSecond()
        {
            var actualArray = new char[][]
            {
                ['*', '+'],
                ['*', '*']
            };
            
            var result = actualArray.DimensionArray();
            
            var actualResult = new char[]
            {
                '*', '+',
                '*', '*'
            };
            
            Assert.That(result, Is.EqualTo(actualResult));
        }
    }
    
}