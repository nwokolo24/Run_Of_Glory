using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class DrawBackgroundAction : Action
    {
        VideoService videoService;
        public DrawBackgroundAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DrawBackground("background", cast);
            DrawBackground("midground", cast);
            DrawBackground("foreground", cast);
        }

        private void DrawBackground(string group, Cast cast)
        {
            List<Actor> backgroundImages = cast.GetActors(group);
            foreach (Image image in backgroundImages)
            {
                videoService.DrawImageEx(image);
            }
        }
    }
}