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
            List<Actor> backgroundImages = cast.GetActors(Constants.BACKGROUND_GROUP);
            foreach (Image image in backgroundImages)
            {
                videoService.DrawImageEx(image);
            }
        }
    }
}