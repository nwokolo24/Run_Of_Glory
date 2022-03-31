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
        private float imageMotion = 0.0f;
        private float scrollRate;

        /// <summary>
        /// Constructs a new instance of Image.
        /// </summary>
        public Image(string filename, float scrollRate = 0.0f, double scale = 1.0, int rotation = 0, bool debug = false) : base(debug)
        {
            this.filename = filename;
            this.scale = scale;
            this.rotation = rotation;
            this.scrollRate = scrollRate;
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

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <returns>The rotation.</returns>
         public int GetRotation()
        {
            return rotation;
        }


        /// <summary>
        /// Gets the imageMotion.
        /// </summary>
        /// <returns>The imageMotion.</returns>
         public float GetImageMotion()
        {
            return this.imageMotion;
        }

        /// <summary>
        /// Gets the scrollRate.
        /// </summary>
        /// <returns>The scrollRate.</returns>
         public float GetScrollRate()
        {
            return this.scrollRate;
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
        /// Updates the imageMotion value by the scrollRate provided.
        /// </summary>
        /// <returns>The imageMotion</returns>
        public void UpdateImageMotion()
        {
            this.imageMotion -= this.scrollRate;
        }
        
        /// <summary>
        /// Set the imageMotion value to 0.
        /// </summary>
        public void ZeroImageMotion()
        {
            this.imageMotion = 0.0f;
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