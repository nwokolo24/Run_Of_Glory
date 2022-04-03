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
        private static Point obstacleSize = new Point(64, 64);
        private static Random random = new Random();

        static void Main(string[] args)
        {

             // create the cast
            Cast cast = new Cast();

            // Create first background images
            Image backgroundImage = new Image(Constants.BACKGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-1, 0), 2.0);
            Image midgroundImage = new Image(Constants.MIDGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-2, 0), 2.0);
            Image foregroundImage = new Image(Constants.FOREGROUND_IMAGE, new Point(800, 450), new Point(0, 0), new Point(-4, 0), 2.0);
            // Create second background images
            Image backgroundImage2 = new Image(Constants.BACKGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-1, 0), 2.0);
            Image midgroundImage2 = new Image(Constants.MIDGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-2, 0), 2.0);
            Image foregroundImage2 = new Image(Constants.FOREGROUND_IMAGE, new Point(800, 450), new Point(1600, 0), new Point(-4, 0), 2.0);

            // Add first background to cast
            cast.AddActor("background", backgroundImage);
            cast.AddActor("midground", midgroundImage);
            cast.AddActor("foreground", foregroundImage);
            // Add second background to cast
            cast.AddActor("background", backgroundImage2);
            cast.AddActor("midground", midgroundImage2);
            cast.AddActor("foreground", foregroundImage2);


            // Create Obstacles
            int randNum = random.Next(1700, 2500);
            Obstacle loveBox = new Obstacle("Assets/Images/gift_box.png", 50, obstacleSize, new Point(1600, 700), new Point(-3, 0));
            Obstacle fire = new Obstacle("Assets/Images/fire.png", -30, obstacleSize, new Point(1900, 700), new Point(-3, 0));
            Obstacle santa = new Obstacle("Assets/Images/santa.png", 70, obstacleSize, new Point(2300, 450), new Point(-3, 0));
            Obstacle magic_box = new Obstacle("Assets/Images/magic_box.png", 100, obstacleSize, new Point(2700, 500), new Point(-3, 0));
            Obstacle danger = new Obstacle("Assets/Images/danger.png", 100, obstacleSize, new Point(3000, 700), new Point(-3, 0));
            // Adde obstacles to cast
            cast.AddActor("obstacles", loveBox);
            cast.AddActor("obstacles", fire);
            cast.AddActor("obstacles", santa);
            cast.AddActor("obstacles", magic_box);
            cast.AddActor("obstacles", danger);

            // Create and add Player to cast
            Body body = new Body(new Point(350, 100), new Point(60, 90), new Point(0, 0));
            Animation animation = 
            new Animation(new List<string>() 
                { 
                    "Assets/Images/player_walk1.png",
                    "Assets/Images/player_walk2.png" 
                }, 10, 0);

            Player player = new Player(body, animation);
            cast.AddActor("player", player);

            // Create and add Background musice to cast
            Sound backgroundSound = new Sound("Assets/Sounds/mr_clown.mp3", 1, true);
            Music backgroundMusic = new Music(backgroundSound);

            cast.AddActor("backgroundMusic", backgroundMusic);


            // Create and add Lives to cast
            Text lifeText = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, Constants.ALIGN_RIGHT, Constants.WHITE);
            Point lifePosition = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, Constants.HUD_MARGIN);
            Label lifeLabel = new Label(lifeText, lifePosition);
            cast.AddActor(Constants.LIVES_GROUP, lifeLabel);

            // Create and add score to cast
            Text scoreText = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, Constants.ALIGN_CENTER, Constants.WHITE);
            Point scorePosition = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            Label scoreLabel = new Label(scoreText, scorePosition);
            cast.AddActor(Constants.SCORE_GROUP, scoreLabel);

            // Create and add stats group
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);




            // create the actions
            Script script = new Script();

            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, VideoService));
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
            
            script.AddAction(Constants.INPUT, new ControlPlayerAction(KeyboardService));
            
            script.AddAction(Constants.UPDATE, new UpdateBackgroundAction());
            script.AddAction(Constants.UPDATE, new UpdateObstacleAction());
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            
            script.AddAction(Constants.OUTPUT, new PlayMusicAction(AudioService));
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawObstacleAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));

            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, VideoService));

            Director director = new Director(VideoService);
            director.StartGame(cast, script);
        }
    }
}