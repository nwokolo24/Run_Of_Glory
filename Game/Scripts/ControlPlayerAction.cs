using OnWard.Game.Casting;
using OnWard.Game.Services;
using Raylib_cs;

namespace OnWard.Game.Scripts
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService keyboardService;

        public ControlPlayerAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");
            if (keyboardService.IsKeyDown("space"))
            {
                Point newVelocity = new Point(0, -25);
                player.body.SetVelocity(newVelocity);
            }
        }
    }
}