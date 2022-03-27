using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using OnWard.injin.cast;
using Raylib_cs;

namespace OnWard.injin.services.raylib_services
{
    public class RaylibScreenService
    {
         private int fps;
         float scrollingBack = 0.0f;
        private Dictionary<string, Texture2D> textureCache;

        /***************************************************************
        * Constructor:
        *   - Initialize window
        *   - Set target FPS
        *
        * Input:
        *   - windowSize: int 2-tuple, example: (600, 800)
        *   - title: string, the name of the window of the game. Default value is "OnWard Game"
                    But you can change this to something else when you create the object
                    (example: "madu")
        *   - fps: int, what frame rate do you want to use? Default is 60.
        ****************************************************************/
        public RaylibScreenService((int, int) windowSize, string title = "OnWard Game", int fps = 60)
        {
            Raylib.InitWindow(windowSize.Item1, windowSize.Item2, title);
            this.SetFPS(fps);
            this.textureCache = new Dictionary<string, Texture2D>();
        }

        /***************************************************************
        * Whatever needs to be done to initialize / re-initialize Screen Service
        ****************************************************************/
        public void Initialize() {
            // Nothing for now
        }

        // Once you figure out how to make one image load and move, your can come back here and make the actors 3 so you can provide background, midground, and foreground images
        private Texture2D LoadTexture(Actor actor)
        {
            string imagePath = actor.GetPath();
            Texture2D texture = Raylib.LoadTexture(imagePath);

            // When saving a texture, save both the normal image
            // and the flipped image
            if (!this.textureCache.Keys.Contains(imagePath)) {
                this.textureCache.Add(imagePath, texture);
            }

            return texture;
        }

        public float UpdateScrolling()
        {
            return this.scrollingBack -= 1.0f;
        }

        public void TextureUpdate(Texture2D texture, float scroll)
        {
            if(scroll <= -texture.width*2) scroll = 0;
        }

        public void SetFPS(int fps = 60) {
            this.fps = fps;
            Raylib.SetTargetFPS(fps);
        }

        /***************************************************************
        * Load textures
        ****************************************************************/
        public void LoadTexturesToCache(List<Actor> actors) {
            foreach (Actor actor in actors) {
                this.LoadTexture(actor);
            }
        }

         /***************************************************************
        * BeginDrawing()
        ****************************************************************/
        public void BeginDrawing()
        {
            Raylib.BeginDrawing();
        }

        /***************************************************************
        * BeginDrawing()
        ****************************************************************/
        public void FillScreen()
        {
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);
        }

        /***************************************************************
        * UpdateScreen()
        ****************************************************************/
        public void UpdateScreen()
        {
            Raylib.EndDrawing();
        }

        /***************************************************************
        * CloseWindow()
        ****************************************************************/
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /***************************************************************
        * Check to see if the X mark on the top right of the game window
        * is clicked
        ****************************************************************/
        public bool IsQuit() {
            return Raylib.WindowShouldClose();
        }

        public void DrawActor(Actor actor)
        {
            string path = actor.GetPath();
            Texture2D texture = new Texture2D();
            float scrollUpdate = UpdateScrolling();

            try{
                if (this.textureCache.Keys.Contains(path))
                {
                    texture = this.textureCache[path];
                }
                else 
                {
                    texture = LoadTexture(actor);
                }

                int frameWidth = actor.GetWidth();
                int frameHeight = actor.GetHeight();

                Raylib.DrawTextureEx(texture, new Vector2(scrollUpdate, 70), 0.0f, 2.0f, Raylib_cs.Color.WHITE);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }


        /***************************************************************
        * DrawActors():
        *   Draw all the actors in the "actors" list in order:
        *        First thing in the list gets drawn first.
        *
        *   actors: actors that need to be drawn
        *   lerp: linear interpolation (don't worry about this)
        ****************************************************************/
        public void DrawActors(List<Actor> actors) {
            foreach (Actor actor in actors) {
                this.DrawActor(actor);
            }
        }

    }
}