using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class PlayerObstacleCollisionAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private static Random random = new Random();
        public PlayerObstacleCollisionAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");
            List<Actor> obstacles = cast.GetActors("obstacles");
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                Body obstacleBody = obstacle.body;
                Body playerBody = player.body;

                if (physicsService.HasCollided(obstacleBody, playerBody))
                {
                    Sound sound = new Sound(Constants.COLLIDE_SOUND);
                    Sound magicBox = new Sound("Assets/Sounds/magic_box.wav");
                    Sound lossPoint = new Sound("Assets/Sounds/losspoint.wav");
                    int points = obstacle.GetObstacleValue();
                    stats.AddPoints(points);


                     if (obstacle.animation.GetFilename() == "Assets/Images/magic_box.png")
                    {
                        audioService.PlaySound(magicBox);
                        Point newPosition = new Point(random.Next(1800, 2100), random.Next(200, 700));
                        obstacle.body.SetPosition(newPosition);
                    }
                    else if (obstacle.animation.GetFilename() == "Assets/Images/santa.png")
                    {
                        audioService.PlaySound(sound);
                        Point newPosition = new Point(random.Next(1700, 1900), random.Next(500, 700));
                        obstacle.body.SetPosition(newPosition);
                    }
                    else if (obstacle.animation.GetFilename() == "Assets/Images/gift_box.png")
                    {
                        audioService.PlaySound(sound);
                        Point newPosition = new Point(random.Next(1650, 1850), random.Next(450, 700));
                        obstacle.body.SetPosition(newPosition);
                    }
                    else
                    {
                        audioService.PlaySound(lossPoint);
                        Point newPosition = new Point(random.Next(1600, 3000), 700);
                        obstacle.body.SetPosition(newPosition);
                    }
                }
                
            }
        }
    }
}