using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;

namespace OnWard.Game.Scripts
{
    public class UpdateObstacleAction : Action
    {
        public UpdateObstacleAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MoveObstacles("obstacles", cast);
        }

        private void MoveObstacles(string group, Cast cast)
        {
            List<Actor> obstacles = cast.GetActors(group);
            foreach (Actor actor in obstacles)
            {
                Image image = (Image)actor;
                image.Move();
                if (image.GetPosition().GetX() <= -1600)
                {
                    Point newPosition = new Point(1600, 700);
                    image.SetPosition(newPosition);
                }
            }
        }
    }
}