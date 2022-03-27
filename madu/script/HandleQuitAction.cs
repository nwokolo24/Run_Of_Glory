using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.injin;
using OnWard.injin.cast;
using OnWard.injin.script;
using OnWard.injin.services.raylib_services;

namespace OnWard.madu.script
{
    public class HandleQuitAction : injin.script.Action
    {
         private RaylibScreenService screenService;

        public HandleQuitAction(int priority, RaylibScreenService screenService) : base(priority)
        {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            // If the X (close) button on the top right of game window is clicked, stop the game 
            if (this.screenService.IsQuit()) {
                callback.OnStop();
            }
        }
    }
}