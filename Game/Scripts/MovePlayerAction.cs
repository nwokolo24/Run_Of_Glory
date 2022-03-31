using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class MovePlayerAction : Action
    {
        public MovePlayerAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");
            
            Point gravity = new Point(0, 1);

            Point newVelocity = player.body.GetVelocity().Add(gravity);
            player.body.SetVelocity(newVelocity);

            Point newPosition = player.body.GetPosition().Add(newVelocity);
            player.body.SetPosition(newPosition);

            if (player.body.GetPosition().GetY() > 700)
            {
                int x = player.body.GetPosition().GetX();
                int y = 700;
                Point position = new Point(x, y);
                player.body.SetPosition(position);
            }
        }
    }
}