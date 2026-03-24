using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

        public Pacman(Tile[] tiles, int[,] map)
        {

            currentdir = Direction.NONE;
   
            speed = 200;
            this.tiles = tiles;
            this.map = map;
        }

        public float x { get; set; }
        public float y { get; set; }
        public int lives { get; set; }
        public int score { get; set; }
        public int speed { get; set; }
        public Direction currentdir { get; set; }
        public Direction desireddir { get; set; }
        public bool isPowered = false;
        public int powertime = 0;

        public int size = 12;
        private Tile[] tiles;
        private int[,] map;



        public void Update()
        {
            HandleMovement();
            Render();

       

            float dx = 0, dy = 0;

            switch (desireddir)
            {
                case Direction.UP: dy = -speed * Time.DeltaTime; break;
                case Direction.DOWN: dy = speed * Time.DeltaTime; break;
                case Direction.LEFT: dx = -speed * Time.DeltaTime; break;
                case Direction.RIGHT: dx = speed * Time.DeltaTime; break;
            }

            if (CanMove(x + dx, y + dy))
            {
                currentdir = desireddir;
                
            }


            Move();


        }

        public void Render()
        {

            Draw.FillColor = Color.Yellow;
            Draw.Rectangle(x, y, size, size);

        }

        public void HandleMovement()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up)) { desireddir = Direction.UP; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) { desireddir = Direction.LEFT; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S) || Input.IsKeyboardKeyDown(KeyboardInput.Down)) { desireddir = Direction.DOWN; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) { desireddir = Direction.RIGHT; }


        }


        void Move()
        {
            float dx = 0;
            float dy = 0;

            switch (currentdir)
            {
                case Direction.UP: dy = -speed * Time.DeltaTime; break;
                case Direction.DOWN: dy = speed * Time.DeltaTime; break;
                case Direction.LEFT: dx = -speed * Time.DeltaTime; break;
                case Direction.RIGHT: dx = speed * Time.DeltaTime; break;
            }

            float nextx = x + dx;
            float nexty = y + dy;

            if (CanMove(nextx, nexty))
            {
                x = nextx;
                y = nexty;
            }

        }
        bool CanMove(float xnext, float ynext)
        {

            foreach (Tile tile in tiles)
            {
             
                if (tile == null) { continue; }

                float leftEdge1 = xnext;
                float rightEdge1 = xnext + size;
                float topEdge1 = ynext ;
                float bottomEdge1 = ynext + size;
 
                float leftEdge2 = tile.x;
                float rightEdge2 =tile.x + 16;
                float topEdge2 =  tile.y;
                float bottomEdge2 =tile.y + 16;

               
                bool doesOverlapLeft = leftEdge1 < rightEdge2;
                bool doesOverlapRight = rightEdge1 > leftEdge2;
                bool doesOverlapTop = topEdge1 < bottomEdge2;
                bool doesOverlapBottom = bottomEdge1 > topEdge2;

          
                bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

                if (doesOverlap && (tile.type == Tile.Type.Wall || tile.type == Tile.Type.GhostWall)) {
                    Console.WriteLine($"Blocked! Tile X: {leftEdge2} Tile Y: {topEdge2} X: {x} Y: {y}");
                    return false;
                }
            }



            return true;

        }




    }
}
