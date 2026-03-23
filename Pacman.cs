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
        public int radius = 8;


        public void Update()
        {
            HandleMovement();
            Render();
            switch (direction)
            {
                case Direction.UP:
                    y -= (int)(speed);
                    break;

                case Direction.DOWN:
                    y += (int)(speed);
                    break;

                case Direction.LEFT:
                    x -= (int)(speed);
                    break;

                case Direction.RIGHT:
                    x += (int)(speed);
                    break;
            }



        }

        public void Render()
        {

            Draw.FillColor = Color.Yellow;
            Draw.Circle(x, y, radius);

        }

        public void HandleMovement()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up)) { direction=Direction.UP;   }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) { direction = Direction.LEFT; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S) || Input.IsKeyboardKeyDown(KeyboardInput.Down)) { direction = Direction.DOWN; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) { direction = Direction.RIGHT; }

        }

    }
}
