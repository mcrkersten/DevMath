using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public static Vector2 Zero => new Vector2(0, 0);

        public float Magnitude
        {
            get { return (float)Math.Sqrt(x * x + y * y); }
        }

        public Vector2 Normalized
        {
            get {
                if (x == 0 && y == 0)
                {
                    return new Vector2(0, 0);
                }
                return new Vector2((x / Magnitude), (y / Magnitude));
            }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return a + (b - a) * t;
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            return (float)Math.Atan2(rhs.y - lhs.y, rhs.x - lhs.x);
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            float r_angle = DevMath.DegToRad(angle);
            return new Vector2((float)Math.Cos(r_angle), (float)Math.Sin(r_angle));
        }

        public static float Distance(Vector2 lhs, Vector2 rhs)
        {
            return (float)Math.Sqrt(Math.Pow(rhs.x - lhs.x, 2) + Math.Pow(rhs.y - lhs.y, 2));
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x * scalar, lhs.y * scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 lhs)
        {
            return new Vector2(lhs.x * scalar, lhs.y * scalar);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x / scalar, lhs.y / scalar);
        }
    }
}
