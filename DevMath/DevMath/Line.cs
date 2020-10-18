using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Line
    {
        public Vector2 Position
        {
            get; set;
        }

        public Vector2 Direction
        {
            get; set;
        }

        public float Length
        {
            get; set;
        }
        public Line(Vector2 position, Vector2 direction, float length)
        {
            Position = position;
            Direction = direction;
            Length = length;
        }

        public bool IntersectsWith(Vector2 point)
        {
            float distanceBeginning = Vector2.Distance(Position, point);
            float distanceEnd = Vector2.Distance(Position + (Direction * Length), point);
            return (distanceBeginning + distanceEnd <= Length + 0.001f && distanceBeginning + distanceEnd >= Length - 0.001f) ? true : false;
        }

        public bool IntersectsWith(Circle circle)
        {
            Vector2 endPoint = Position + (Direction * Length);
            if (Vector2.Distance(circle.Position, Position) - circle.Radius <= 0 || Vector2.Distance(circle.Position, endPoint) - circle.Radius <= 0)
            {
                return true;
            }

            float distanceToLine = (float)(((circle.Position.x - Position.x) * (endPoint.x - Position.x) + (circle.Position.y - Position.y) * (endPoint.y - Position.y)) / Math.Pow(Length, 2));

            Vector2 closestPoint = new Vector2(Position.x + (distanceToLine * (endPoint.x - Position.x)), Position.y + (distanceToLine * (endPoint.y - Position.y)));

            if (!IntersectsWith(closestPoint))
            {
                return false;
            }

            if (Vector2.Distance(circle.Position, closestPoint) - circle.Radius <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
