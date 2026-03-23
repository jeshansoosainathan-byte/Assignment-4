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
            PowerPellet
        }


        static int tilewidth = 16;
        static int tileheight = 16;
        public int x {  get; set; }
        public int y { get; set; }
        public Type type = Type.Wall;

        public Tile(int x, int y, Type type)
        {
            this.x = x * tilewidth + 70;
            this.y = y * tileheight + 80;
            this.type = type;
        }

        public void render()
        {

            Draw.FillColor = Color.Blue;

            switch (type)
            {
                case Type.Wall:
                    Draw.FillColor = Color.Blue;
                    break;
                    case Type.Pellet:
                    Draw.FillColor = Color.White;
                    break;

            }



            if (type == Type.Wall)
            {
                Draw.Rectangle(x, y, tilewidth, tileheight);

            }
            else
            {
                Draw.Circle(x+10, y+10,6);

            }



        }





    }
}
