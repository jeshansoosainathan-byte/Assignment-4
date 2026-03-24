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

        public Pacman(Tile[] tiles, int[,] map)
        {

            currentdir = Direction.NONE;
            x = 230;
            y = 350;
            speed = 200;
            this.tiles = tiles;
            this.map = map;
        }

        public float x { get; set; }
        public float y { get; set; }
        public int lives { get; set;  }
        public int score { get; set; }
        public int speed { get; set; }
        public Direction currentdir { get; set; }
        public Direction desireddir { get; set; }
        public bool isPowered = false;
        public int powertime = 0;

        public int size = 16;
        private Tile[] tiles;
        private int[,] map;



        public void Update()
        {
            HandleMovement();
            Render();
            float nextX = x;
            float nextY = y;

            currentdir = desireddir;
      
                Move();
            
           



        }
       
        public void Render()
        {

            Draw.FillColor = Color.Yellow;
            Draw.Rectangle(x, y, size, size);

        }

        public void HandleMovement()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up)) { desireddir=Direction.UP;   }
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

              x = x + dx;
              y = y + dy;

         
        }





    }
}
