

namespace OnWard.Game.Casting
{
    /// <summary>
    /// An image.
    /// </summary>
    public class Music : Actor
    {
        public Sound sound;
        
        /// <summary>
        /// Constructs a new instance of Image.
        /// </summary>
        public Music(Sound sound) : base(false)
        {
            this.sound = sound; 
        }

    }
}