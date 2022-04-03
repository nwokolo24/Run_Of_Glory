using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class PlayMusicAction : Action
    {
        private AudioService audioService;
        private Music? music;
        private bool backgroundPlaying;

        public PlayMusicAction(AudioService audioService)
        {
            this.audioService = audioService;
            this.backgroundPlaying = false;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (!this.backgroundPlaying)
            {
                this.music = (Music)cast.GetFirstActor("backgroundMusic");
                if (music != null)
                {
                    audioService.PlaySound(music.sound);
                    this.backgroundPlaying = true;
                    cast.RemoveActor("backgroundMusic", music);
                }

            }  
        }
    }
}