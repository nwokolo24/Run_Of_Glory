using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.Game.Casting
{
    public class Obstacle : Image
    {
        public Obstacle(string filename, Point size, Point position, Point velocity, double scale = 1, int rotation = 0, bool debug = false) : base(filename, size, position, velocity, scale, rotation, debug)
        {
        }
    }
}