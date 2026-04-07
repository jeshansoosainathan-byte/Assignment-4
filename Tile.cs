using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4
{
    //Class handling Tiles, the building block of Pacman
    public class Tile
    {

        /*Enum classifying each Tile as one of several types. 
         *  GhostWall is a wall only ghosts can pass through, used for the center spawn area for Ghosts
         * 
         * 
         */
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
        //Removes tile from the board. Stops rendering it and can no longer be collided with
        public bool destroy = false;
        public Tile(int x, int y, Type type)
        {
            this.x = x * tilewidth + 70;
            this.y = y * tileheight + 80;
            this.type = type;
        }

        //Switch-case render function. 
        public void Render()
        {


            if (destroy) return;
            switch (type)
            {
                case Type.Wall:
                    //Draw.FillColor = Color.Blue;
                    //Draw.Rectangle(x, y, tilewidth, tileheight);
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
                    //Draw.FillColor = Color.Magenta;
                    //Draw.Rectangle(x, y, tilewidth, tileheight);
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

        //Handles pacman colliding with tile. Used for pickup tiles, such as pellets or food
       public void collide(Pacman pacman)
        {
            if (destroy) return;
            switch(type)
            {
                case Type.Pellet:
                    destroy = true;
                    pacman.score += 1;
                    break;
                case Type.PowerPellet:
                    destroy = true;
                    pacman.powertime = 10;
                    break;
                case Type.Food:
                    destroy = true;
                    pacman.score += 100;
                    break;
              


            }



        }




    }
}
