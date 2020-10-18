using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        } = Vector2.Zero;

        public float Acceleration
        {
            get; private set;
        } = 0;

        public float mass = 1.0f;
        public float frictionCoefficient;
        public float normalForce;

        public void UpdateVelocityWithForce(Vector2 forceDirection, float forceNewton, float deltaTime)
        {
            Vector2 acceleration = ((forceDirection * forceNewton) / mass) * deltaTime;
            Vector2 velocity = (1 / frictionCoefficient) * (float)Math.Exp(-frictionCoefficient / mass * deltaTime) * (Velocity * frictionCoefficient + acceleration * mass) - (acceleration * mass / frictionCoefficient);

            Velocity = velocity;
            Acceleration = acceleration.Magnitude;
        }
    }
}
