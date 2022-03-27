using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.injin.cast;

namespace OnWard.madu.cast
{
    public class Background : Actor
    {
        public Background(string path, int screenWidth, int screenHeight, float x=0, float y=0, float vx=0, float vy=0) : base(path, screenWidth, screenHeight, x, y, vx, vy)
        {
        }
    }
}