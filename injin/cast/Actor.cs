using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.injin.cast
{
    /***********************************************************
    * Actor:
    *    A thing that participates in an animation. Anything that either MOVES, can be DRAWN
    *    on the screen, or BOTH is an actor.
    *    For the purpose of collision checking, all actors are represented with the shape of a RECTANGLE.
    *    
    *    Attributes:
    *        _path : The file path of the image of the actor. Should be a path to a .png file
    *        _width : Width of the actor. Used to scale the image AND to determine the hit box
    *        _height : Height of the actor. Used to scale the image AND to determine the hit box
    *        
    *        _x : the x coordinate of the center of the rectangle
    *        _y : the y coordinate of the position
    *        
    *        _vx : the horizontal velocity
    *        _vy : the vertical velocity
            when an actor is passed to draw_actors() in the screen service. All you need
            to do is setting these values correctly here.
    ************************************************************/
    public class Actor
    {
        // Private member variables (Fields)
        private string path;
        private int width;
        private int height;
        
        private float x;
        private float y;
        private float vx;
        private float vy;

        public Actor(string path, int width, int height, float x, float y, float vx, float vy)
        {
            this.path = path;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
        }

        // Set/Get methods for path
        public string GetPath() {
            return this.path;
        }

        public void SetPath(string path) {
            this.path = path;
        }

        
        // Set/Get methods for width and height
        public int GetWidth() {
            return this.width;
        }

        public void SetWidth(int width) {
            this.width = width;
        }

        public int GetHeight() {
            return this.height;
        }

        public void SetHeight(int height) {
            this.height = height;
        }

        // Actor
        public (float x, float y) GetPosition() {
            return (this.x, this.y);
        }

        // Set/Get methods for x and y
        public float GetX() {
            return this.x;
        }

        public void SetX(float x) {
            this.x = x;
        }

        public float GetY() {
            return this.y;
        }

        public void SetY(float y) {
            this.y = y;
        }

        // Set/Get methods for vx and vy
        public float GetVx() {
            return this.vx;
        }

        public void SetVx(float vx) {
            this.vx = vx;
        }

        public float GetVy() {
            return this.vy;
        }

        public void SetVy(float vy) {
            this.vy = vy;
        }

        // Getters for top-left corner of the rectangle
        public (float, float) GetTopLeft() {
            return (this.x - this.width/2, this.y - this.height/2);
        }
        
        public (float, float) GetTopRight()
        {
            return (this.x + this.width / 2, this.y - this.height / 2);
        }

        public (float, float) GetBottomLeft()
        {
            return (this.x - this.width / 2, this.y + this.height / 2);
        }

        public (float, float) GetBottomRight()
        {
            return (this.x + this.width / 2, this.y + this.height / 2);
        }
    }
}