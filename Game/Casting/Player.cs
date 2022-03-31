using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.Game.Casting
{
    /// <summary>
    /// An image.
    /// </summary>
    public class Player : Actor
    {
        public Body body;
        public Animation animation;

        /// <summary>
        /// Constructs a new instance of Image.
        /// </summary>
        public Player(Body body, Animation animation) : base(false)
        {
            this.body = body;
            this.animation = animation;
        }

    }
}