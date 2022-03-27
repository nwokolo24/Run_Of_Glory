using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.injin;
using OnWard.injin.cast;
using OnWard.injin.script;
using OnWard.injin.services.raylib_services;
using OnWard.madu.cast;
using OnWard.madu.script;

namespace OnWard
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // A few game constants
            (int, int) W_SIZE = (1000, 1000);
            (int, int) START_POSITION = (500, 700);
            string SCREEN_TITLE = "Run Of Glory";
            int FPS = 60;

            // Initiate all services
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);


            // Create the director
            Director director = new Director();


            // Create the cast
            Cast cast = new Cast();

            // Create the background
            Background motionBackground = new Background("./madu/assets/cyberpunk-street.png", W_SIZE.Item1, W_SIZE.Item2,  W_SIZE.Item1/2, W_SIZE.Item2/2);


            // Give actors to cast
            cast.AddActor("background_image", motionBackground);

            // Create the script
            Script script = new Script();

            // Add all input actions
            script.AddAction("input", new HandleQuitAction(1,screenService));

            // Add actions that must be added to the script when the game starts:
            Dictionary<string, List<injin.script.Action>> startGameActions = new Dictionary<string, List<injin.script.Action>>();
            startGameActions["input"] = new List<injin.script.Action>();
            startGameActions["update"] = new List<injin.script.Action>();
            startGameActions["output"] = new List<injin.script.Action>();

            // Add all output actions
            script.AddAction("output", new DrawActorsAction(1, screenService));
            script.AddAction("output", new UpdateScreenAction(2, screenService));

            // Yo, director, do your thing!
            director.DirectScene(cast, script);
        }
    }
}