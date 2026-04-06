using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment_4
{
    public class Pacman
    {
        //Direction enum for the ways Pacman can move
        public enum Direction
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT

        }


        public Pacman(Tile[] tiles, Game game )
        {

            currentdir = Direction.NONE;
   
            speed = 200;
            this.tiles = tiles;
            this.game = game;
        }

        public float x { get; set; }
        public float y { get; set; }
        public int lives { get; set; }
        public int score { get; set; }
        public int speed { get; set; }

        //The direction Pacman is currently moving in
        public Direction currentdir { get; set; }
        //The direction the player inputs which will be qued
        public Direction desireddir { get; set; }
        public int powertime = 0;
        public int size = 12;
        public int currentFrame = 0; // current animation frame. 0-3 are standard frames, 4-7 are death frames.
        const float FRAME_STEP = 0.125f; // default frameStep value to reset to
        public float frameStep = FRAME_STEP; // time left in seconds until animation frame advances

        // tiles
        private Tile[] tiles;
        private Game game;


        //Handles all movement-related code. HandleInput handles player input, swapping desireddirect to match input. Checks if the desired direct is valid before committing a move to it
        public void Update()
        {
            HandleInput();

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

            //advance animation frames
            frameStep -= Time.DeltaTime;
            if (frameStep < 0) // if animation ready to advance
            {
                if (currentFrame < 4) { currentFrame++; currentFrame %= 4; } // advance frame of standard anim
                else { currentFrame++; }; // advance death anim frames
            }
            if (frameStep < 0) { frameStep += FRAME_STEP; }
            frameStep %= FRAME_STEP; //reset frameStep ticker, compensating for overlap
         
            Move();
            CheckOverlap();
           

        }

        public void Render()
        {

            // draw the pac
            Draw.FillColor = Color.Yellow;
            Draw.LineSize = 0;
            //Console.WriteLine($"pac frame {currentFrame} is facing {currentdir}");
            switch (currentFrame)
            {
                // NORMAL: FIRST AND THIRD FRAME. FULL CIRCLE
                case 0 or 2:
                    Draw.Rectangle(x + 4, y, 5, 13);
                    Draw.Rectangle(x + 2, y + 1, 9, 11);
                    Draw.Rectangle(x + 1, y + 2, 11, 9);
                    Draw.Rectangle(x, y + 4, 13, 5);
                    break;
                // NORMAL: SECOND AND FOURTH FRAME. MOUTH OPEN MEDIUM
                case 1 or 3:
                    Draw.Rectangle(x + 4, y, 5, 13);
                    Draw.Rectangle(x + 2, y + 1, 9, 11);
                    Draw.Rectangle(x + 1, y + 2, 11, 9);
                    Draw.Rectangle(x, y + 4, 13, 5);
                    Draw.FillColor = Color.Black; // cut into circle with black overlay to draw mouth
                    switch (currentdir)
                    {
                        case Direction.RIGHT or Direction.NONE:
                            Draw.Rectangle(x + 10, y + 4, 3, 5);
                            Draw.Rectangle(x + 7, y + 5, 3, 3);
                            Draw.Rectangle(x + 4, y + 6, 3, 1);
                            break;
                        case Direction.DOWN:
                            Draw.Rectangle(x + 4, y + 10, 5, 3);
                            Draw.Rectangle(x + 5, y + 7, 3, 3);
                            Draw.Rectangle(x + 6, y + 5, 1, 2);
                            break;
                        case Direction.UP:
                            Draw.Rectangle(x + 4, y, 5, 3);
                            Draw.Rectangle(x + 5, y + 3, 3, 3);
                            Draw.Rectangle(x + 6, y + 6, 1, 2);
                            break;
                        case Direction.LEFT:
                            Draw.Rectangle(x, y + 4, 3, 5);
                            Draw.Rectangle(x + 3, y + 5, 3, 3);
                            Draw.Rectangle(x + 6, y + 6, 3, 1);
                            break;
                    }
                    Draw.FillColor = Color.Yellow;
                    break;
                // DYING: FIRST FRAME. LOWER SEMICIRCLE
                case 4:
                    break;
                // DYING: SECOND FRAME. LOW VERTICAL LINE
                case 5:
                    break;
                // DYING: THIRD FRAME. POP
                case 6:
                    break;
                // DYING: FOURTH FRAME. GONE FOREVER. OOPS.
                case 7:
                    // intentionally left blank.
                    break;
            }
            Draw.LineSize = 1;

        }

        public void HandleInput()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up)) { desireddir = Direction.UP; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) { desireddir = Direction.LEFT; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S) || Input.IsKeyboardKeyDown(KeyboardInput.Down)) { desireddir = Direction.DOWN; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) { desireddir = Direction.RIGHT; }


        }

        //Checks if Pacman overlaps with a tile. Used for collecting pickups
        public void CheckOverlap()
        {

            foreach(Tile tile in tiles)
            {
                if (tile == null ) continue;

                if (IsOverlapping(x,y,tile.x,tile.y))
                {

                    tile.collide(this);


                }


            }

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
 
                bool doesOverlap = IsOverlapping(xnext, ynext, tile.x, tile.y);

                if (doesOverlap && (tile.type == Tile.Type.Wall || tile.type == Tile.Type.GhostWall)) {
                  
                    return false;
                }
            }



            return true;

        }

        bool IsOverlapping(float x, float y, int tileX, int tileY)
        {
            float leftEdge1 = x;
            float rightEdge1 = x + size;
            float topEdge1 = y;
            float bottomEdge1 = y + size;

            float leftEdge2 = tileX;
            float rightEdge2 = tileX + 16;
            float topEdge2 = tileY;
            float bottomEdge2 = tileY + 16;


            bool doesOverlapLeft = leftEdge1 < rightEdge2;
            bool doesOverlapRight = rightEdge1 > leftEdge2;
            bool doesOverlapTop = topEdge1 < bottomEdge2;
            bool doesOverlapBottom = bottomEdge1 > topEdge2;


            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

            return doesOverlap;

        }


    }
}
