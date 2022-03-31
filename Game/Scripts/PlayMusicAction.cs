using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class PlayMusicAction : Action
    {
        private AudioService audioService;

        public PlayMusicAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Music music = (Music)cast.GetFirstActor("music");
            if (music != null)
            {
                audioService.PlaySound(music.sound);
                cast.RemoveActor("music", music);
            }
            
        }
    }
}