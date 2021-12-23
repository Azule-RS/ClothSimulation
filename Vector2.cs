using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothSFML
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(SFML.System.Vector2f position, bool fromScreen = true)
        {
            this.x = (position.X - 8 - (SFML_Helper.Window.Size.X / 2)) / SFML_Helper.orthographicSize - SFML_Helper.cameraPosition.x;
            this.y = (-position.Y + 28 + (SFML_Helper.Window.Size.Y / 2)) / SFML_Helper.orthographicSize - SFML_Helper.cameraPosition.y;
        }

        public float length
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }
        }
        public Vector2 normalized
        {
            get
            {
                float length = this.length;
                if (length == 0)
                    return Vector2.zero;
                return new Vector2(x / length, y / length);
            }
        }
        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            if (lhs.length * rhs.length == 0 || float.IsNaN(lhs.length * rhs.length))
            {
                return 1; 
            }
            return (lhs.x * rhs.x + lhs.y * rhs.y) / (lhs.length * rhs.length);
        }
        public static Vector2 Lerp(Vector2 from, Vector2 to, float Time)
        {
            return from + Time * (to - from);
        }

        public SFML.System.Vector2f toVector2f(bool toScreen = true)
        {
            return new SFML.System.Vector2f((SFML_Helper.Window.Size.X / 2) + (x + SFML_Helper.cameraPosition.x) * (toScreen ? SFML_Helper.orthographicSize : 1), (SFML_Helper.Window.Size.Y / 2) - (y + SFML_Helper.cameraPosition.y) * (toScreen ? SFML_Helper.orthographicSize : 1));
        }

        public static Vector2 one
        {
            get
            {
                return new Vector2(1, 1);
            }
        }
        public static Vector2 zero
        {
            get
            {
                return new Vector2(0, 0);
            }
        }
        public static Vector2 up
        {
            get
            {
                return new Vector2(0, 1);
            }
        }
        public static Vector2 right
        {
            get
            {
                return new Vector2(1, 0);
            }
        }

        #region Operations
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x+b.x, a.y+b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
        #endregion
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
