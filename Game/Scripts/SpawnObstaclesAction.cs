using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;

namespace OnWard.Game.Scripts
{
    public class SpawnObstaclesAction : Action
    {
        private Point? windowSize;
        private bool timerStarted;
        private bool obstacleSpawn;
        private DateTime lastSpawn;
        private float spawnInterval;
        private Random randomGenerator;
        public SpawnObstaclesAction(Point windowSizw, float spawnInterval)
        {
            this.windowSize = windowSize;
            this.spawnInterval = spawnInterval;
            this.timerStarted = false;
            this.obstacleSpawn = false;
            this.lastSpawn = new DateTime();
            this.randomGenerator = new Random();
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            throw new NotImplementedException();
        }
    }
}