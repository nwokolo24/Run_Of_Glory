using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class DrawPlayerAction : Action
    {
        VideoService videoService;

        public DrawPlayerAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");

            string filename = player.animation.NextImage();
            Point size = player.body.GetSize();
            Point position = player.body.GetPosition();
            Point velocity = player.body.GetVelocity();
            double scale = 1D;
            int rotation = 0;
            Image image = new Image(filename, size, position, velocity, scale, rotation);

            videoService.DrawImageEx(image);
        }
    }
}