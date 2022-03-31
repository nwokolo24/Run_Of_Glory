using OnWard.Game.Casting;
using OnWard.Game.Services;
using OnWard.Game.Services.RaylibService;

namespace OnWard.Game.Scripts
{
    public class UpdateBackgroundAction : Action
    {
        VideoService videoService;
        public UpdateBackgroundAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> backgroundImages = cast.GetActors(Constants.BACKGROUND_GROUP);
            foreach (Image image in backgroundImages)
            {
                this.videoService.UpdateBackgroundMotion(image);
            }
        }
    }
}