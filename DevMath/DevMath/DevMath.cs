using System;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            return (startVelocity * time) + (0.5f * acceleration * time * time);
        }

        public static float Clamp(float value, float min, float max)
        {
            float percentage = value / (max - min);
            return Lerp(min, max, percentage);
        }

        public static float RadToDeg(float angle)
        {
            return angle * (float)(180 / Math.PI);
        }

        public static float DegToRad(float angle)
        {
            return angle * (float)(Math.PI / 180);
        }
    }
}
