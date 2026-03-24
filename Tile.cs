using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4
{
    public class Tile
    {

        public enum Type
        {
            Wall,
            Pellet,
            PowerPellet,
            Food,
            GhostWall,
            Portal
        }


        static int tilewidth = 16;
        static int tileheight = 16;
        public int x {  get; set; }
        public int y { get; set; }
        public Type type = Type.Wall;
        public bool destroy = false;
        public Tile(int x, int y, Type type)
        {
            this.x = x * tilewidth + 70;
            this.y = y * tileheight + 80;
            this.type = type;
        }

        public void Render()
        {

    

            switch (type)
            {
                case Type.Wall:
                    Draw.FillColor = Color.Blue;
                    Draw.Rectangle(x, y, tilewidth, tileheight);
                    break;
                    case Type.Pellet:
                    Draw.FillColor = Color.White;
                    Draw.Circle(x + 8, y + 8, 4);
                    break;
                case Type.PowerPellet:
                    Draw.FillColor = Color.Green;
                    Draw.Circle(x + 10, y + 10, 6);
                    break;
                case Type.GhostWall:
                     Draw.FillColor = Color.Magenta;
                    Draw.Rectangle(x, y, tilewidth, tileheight);
                    break;
                case Type.Portal:
                    Draw.FillColor = Color.LightGray;
                    Draw.Circle(x + 10, y + 10, 6);
                    break;
                case Type.Food:
                    Draw.FillColor = Color.Cyan;
                    Draw.Circle(x + 10, y + 10, 6);
                    break;

            }




        }

       




    }
}
