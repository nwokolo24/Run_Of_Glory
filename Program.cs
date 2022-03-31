using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;
using OnWard.Game.Directing;
using OnWard.Game.Scripts;
using OnWard.Game.Services;
using OnWard.Game.Services.RaylibService;

namespace OnWard
{
    public class Program
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        static void Main(string[] args)
        {

             // create the actors
            Cast cast = new Cast();

            Image backgroundImage = new Image(Constants.BACKGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-1, 0), 2.0);
            Image midgroundImage = new Image(Constants.MIDGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-2, 0), 2.0);
            Image foregroundImage = new Image(Constants.FOREGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-3, 0), 2.0);
            
            Image backgroundImage2 = new Image(Constants.BACKGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-1, 0), 2.0);
            Image midgroundImage2 = new Image(Constants.MIDGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-2, 0), 2.0);
            Image foregroundImage2 = new Image(Constants.FOREGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-3, 0), 2.0);

            cast.AddActor("background", backgroundImage);
            cast.AddActor("midground", midgroundImage);
            cast.AddActor("foreground", foregroundImage);

            cast.AddActor("background", backgroundImage2);
            cast.AddActor("midground", midgroundImage2);
            cast.AddActor("foreground", foregroundImage2);

            Body body = new Body(new Point(700, 700), new Point(80, 120), new Point(0, 0));
            Animation animation = new Animation(new List<string>() { "Assets/Images/player_walk1.png", "Assets/Images/player_walk2.png" }, 10, 0);
            Player player = new Player(body, animation);

            cast.AddActor("player", player);

            Sound sound = new Sound("Assets/Sounds/background_music.wav");
            Music music = new Music(sound);

            cast.AddActor("music", music);

            // create the actions
            Script script = new Script();

            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, VideoService));
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
            
            script.AddAction(Constants.INPUT, new ControlPlayerAction(KeyboardService));
            
            script.AddAction(Constants.UPDATE, new UpdateBackgroundAction());
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new PlayMusicAction(AudioService));

            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, VideoService));

            Director director = new Director(VideoService);
            director.StartGame(cast, script);
        }
    }
}