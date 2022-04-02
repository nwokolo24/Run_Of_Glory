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
            foreach (Image image in obstacles)
            {
                videoService.DrawImageEx(image);
            }
        }
    }
}