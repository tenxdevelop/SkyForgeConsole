/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System;

namespace SkyForgeConsole.Maths
{
    public class Vector2
    {
        public static Vector2 Zero = new Vector2(0, 0);
        public static Vector2 Up = new Vector2(0, 1);
        public static Vector2 Down = new Vector2(0, -1);
        public static Vector2 Left = new Vector2(-1, 0);
        public static Vector2 Right = new Vector2(1, 0);
        public float x { get; private set; }
        public float y { get; private set; }
        
        public Vector2() : this(0, 0) { }
        
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (obj is Vector2 otherVector2)
                return Equals(otherVector2);
            
            return false;
        }
        
        public bool Equals(Vector2 other)
        {
            return x.Equals(other.x) && y.Equals(other.y);
        }
        
        public float GetMagnitude()
        {
            return Convert.ToSingle(Math.Sqrt(x * x + y * y));
        }

        public Vector2 GetNormalized()
        {
            var magnitude = GetMagnitude();
            return new Vector2(x / magnitude, y / magnitude);
        }

        public void Normalize()
        {
            var magnitude = GetMagnitude();
            x /= magnitude;
            y /= magnitude;
        }

        public override string ToString()
        {
            return $" (x: {x.ToString().Replace(',', '.')}; y: {y.ToString().Replace(',', '.')}) ";
        }

        public static bool operator >(Vector2 left, Vector2 right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(Vector2 left, Vector2 right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        public static bool operator >=(Vector2 left, Vector2 right)
        {
            return left.CompareTo(right) > 0 || left.Equals(right);
        }

        public static bool operator <=(Vector2 left, Vector2 right)
        {
            return left.CompareTo(right) < 0 || left.Equals(right);
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }

        public static Vector2 operator +(Vector2 vector, float value)
        {
            return new Vector2(vector.x + value, vector.y + value);
        }
        
        public static Vector2 operator -(Vector2 vector, float value)
        {
            return new Vector2(vector.x - value, vector.y - value);
        }
        
        public static Vector2 operator /(Vector2 vector, float value)
        {
            return new Vector2(vector.x / value, vector.y / value);
        }
        
        public static Vector2 operator *(Vector2 vector, float value)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        private float CompareTo(Vector2 otherVector)
        {
            return x - otherVector.x + y - otherVector.y;
        }
    }
}