using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.Game.Casting
{
    /// <summary>
    /// An image.
    /// </summary>
    public class Image : Actor
    {
        private string filename;
        private double scale;
        private int rotation;
        private Point velocity;
        private Point size;
        private Point position;

        /// <summary>
        /// Constructs a new instance of Image.
        /// </summary>
        public Image(string filename, Point size, Point position, Point velocity, double scale = 1.0, int rotation = 0, bool debug = false) : base(debug)
        {
            this.filename = filename;
            this.scale = scale;
            this.rotation = rotation;
            this.velocity = velocity;
            this.size = size;
            this.position = position;
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <returns>The filename.</returns>
        public string GetFilename()
        {
            return filename;
        }

        /// <summary>
        /// Gets the scale.
        /// </summary>
        /// <returns>The scale.</returns>
        public double GetScale()
        {
            return scale;
        }

        public Point GetPosition()
        {
            return position;
        }

        public Point GetSize()
        {
            return size;
        }


        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <returns>The rotation.</returns>
         public int GetRotation()
        {
            return rotation;
        }

        /// <summary>
        /// Gets the velocity.
        /// </summary>
        /// <returns>The velocity.</returns>
         public Point GetVelocity()
        {
            return this.velocity;
        }

        /// <summary>
        /// Sets the rotation to the given value.
        /// </summary>
        /// <param name="rotation">The given rotation.</param>
        public void SetRotation(int rotation)
        {
            this.rotation = rotation;
        }

        /// <summary>
        /// Updates the imageMotion value by the velocity provided.
        /// </summary>
        /// <returns>The imageMotion</returns>
        public void Move()
        {
            this.position = this.position.Add(this.velocity);
        }
        
        /// <summary>
        /// Set the imageMotion value to 0.
        /// </summary>
        public void StopMoving()
        {
            this.velocity = new Point(0, 0);
        }
        
        public void SetPosition(Point position)
        {
            this.position = position;
        }
        

        /// <summary>
        /// Sets the scale to the given value.
        /// </summary>
        /// <param name="scale">The given scale.</param>
        public void SetScale(double scale)
        {
            this.scale = scale;
        }
        
    }
}