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
    public class DrawActorsAction : injin.script.Action
    {
        private RaylibScreenService screenService;
        public DrawActorsAction(int priority, RaylibScreenService screenService) : base(priority)
        {
            this.screenService = screenService;
        }
        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            // First, fill the screen with white every frame, get ready to draw more stuff
            this.screenService.FillScreen();

            this.screenService.DrawActors(cast.GetAllActors());
        }
    }
}