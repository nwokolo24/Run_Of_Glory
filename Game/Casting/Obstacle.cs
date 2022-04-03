using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.Game.Casting
{
    public class Obstacle : Actor
    {
        public Body body;
        public Animation animation;
        private int value;

        // Constructor
        public Obstacle(Body body, Animation animation, int value, bool debug = false) : base(debug)
        {
            this.value = value;
            this.body = body;
            this.animation = animation;
        }

        // Return the value of the obstacle
        public int GetObstacleValue()
        {
            return this.value;
        }
    }
}