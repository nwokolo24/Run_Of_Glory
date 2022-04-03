using OnWard.Game.Casting;
using OnWard.Game.Services;
// using Raylib_cs;

namespace OnWard.Game.Scripts
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService keyboardService;
        private AudioService audioService;

        public ControlPlayerAction(KeyboardService keyboardService, AudioService audioService)
        {
            this.keyboardService = keyboardService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");
            if (keyboardService.IsKeyDown("space"))
            {
                Sound sound = new Sound(Constants.JUMP_SOUND, 4);
                audioService.PlaySound(sound);
                Point newVelocity = new Point(0, -20);
                player.body.SetVelocity(newVelocity);
            }
        }
    }
}