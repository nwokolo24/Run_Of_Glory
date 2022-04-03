using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class DrawObstacleAction : Action
    {
        VideoService videoService;
        public DrawObstacleAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DrawObstacle("obstacles", cast);
        }

         private void DrawObstacle(string group, Cast cast)
        {
            List<Actor> obstacles = cast.GetActors(group);
            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                string filename = obstacle.animation.NextImage();
                Point size = obstacle.body.GetSize();
                Point position = obstacle.body.GetPosition();
                Point velocity = obstacle.body.GetVelocity();
                double scale = 1D;
                int rotation = 0;
                Image image = new Image(filename, size, position, velocity, scale, rotation);

                videoService.DrawImageEx(image);
            }       
        }
    }
}