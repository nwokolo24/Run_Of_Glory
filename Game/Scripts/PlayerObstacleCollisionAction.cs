using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;
using OnWard.Game.Services;

namespace OnWard.Game.Scripts
{
    public class PlayerObstacleCollisionAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        public PlayerObstacleCollisionAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor("player");
            List<Actor> obstacles = cast.GetActors("obstacles");
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            foreach (Actor actor in obstacles)
            {
                
            }
        }
    }
}