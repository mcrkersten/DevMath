using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        } = Vector2.Zero;

        public float Radius
        {
            get; set;
        } = 0;

        public bool CollidesWith(Circle circle)
        {
            float distance = (float)Math.Sqrt(Math.Pow(circle.Position.x - Position.x, 2) + Math.Pow(circle.Position.y - Position.y, 2));
            return (distance - circle.Radius - Radius) <= 0 ? true : false;
        }
    }
}
