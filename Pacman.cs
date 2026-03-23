using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4
{
    public class Pacman
    {
        public enum Direction
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT

        }

        public Pacman()
        {

            direction = Direction.NONE;
            x = 10;
            y = 10;
            speed = 2;
        }

        public int x { get; set; }
        public int y { get; set; }
        public int lives { get; set;  }
        public int score { get; set; }
        public int speed { get; set; }
        public Direction direction { get; set; }
        public int radius = 10;


        public void update()
        {







        }

        public void render()
        {

            Draw.FillColor = Color.Yellow;
            Draw.Circle(x, y, radius);

        }

        public void handle

    }
}
