using OnWard.Game.Casting;
using OnWard.Game.Services;
using OnWard.Game.Services.RaylibService;

namespace OnWard.Game.Scripts
{
    public class UpdateBackgroundAction : Action
    {
        
        public UpdateBackgroundAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MoveBackgrounds("background", cast);
            MoveBackgrounds("midground", cast);
            MoveBackgrounds("foreground", cast);
        }

        private void MoveBackgrounds(string group, Cast cast)
        {
            List<Actor> backgrounds = cast.GetActors(group);
            foreach (Actor actor in backgrounds)
            {
                Image image = (Image)actor;
                image.Move();
                if (image.GetPosition().GetX() <= -1600)
                {
                    Point newPosition = new Point(1600, 0);
                    image.SetPosition(newPosition);
                }
            }
        }
    }
}