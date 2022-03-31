using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;

namespace OnWard.Game.Scripts
{
    public class TimedChangeSceneAction : Action
    {
        private string nextScene;
        private double delay;
        private DateTime start;
        
        public TimedChangeSceneAction(string nextScene, double delay, DateTime start)
        {
            this.nextScene = nextScene;
            this.delay = delay;
            this.start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            if (elapsedTime.Seconds > delay)
            {
                callback.OnNext(nextScene);
            }
        }
    }
}