using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class InitializeDevicesAction : Action
    {
        private AudioService audioService;
        private VideoService videoService;
        
        public InitializeDevicesAction(AudioService audioService, VideoService videoService)
        {
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            audioService.Initialize();
            videoService.Initialize();
        }
    }
}