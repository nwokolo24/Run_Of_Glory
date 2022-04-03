using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnWard.Game.Casting;

namespace OnWard.Game.Scripts
{
    public class UpdateObstacleAction : Action
    {
        private static Random random = new Random();
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

                if (image.GetPosition().GetX() <= -0)
                {
                    if (image.GetFilename() == "Assets/Images/magic_box.png")
                    {
                        Point newPosition = new Point(random.Next(1800, 2100), random.Next(200, 700));
                        image.SetPosition(newPosition);
                    }
                    else if (image.GetFilename() == "Assets/Images/santa.png")
                    {
                        Point newPosition = new Point(random.Next(1700, 1900), random.Next(500, 700));
                        image.SetPosition(newPosition);
                    }
                    else if (image.GetFilename() == "Assets/Images/gift_box.png")
                    {
                        Point newPosition = new Point(random.Next(1650, 1850), random.Next(450, 700));
                        image.SetPosition(newPosition);
                    }
                    else
                    {
                        Point newPosition = new Point(random.Next(1600, 3000), 700);
                        image.SetPosition(newPosition);
                    }
                    
                }
            }
        }
    }
}