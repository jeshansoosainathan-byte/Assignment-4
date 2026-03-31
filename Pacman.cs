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
        public Direction currentdir { get; set; }
        public Direction desireddir { get; set; }
        public int powertime = 0;
        public int size = 13;
        public int currentFrame = 0; // current animation frame. 0-3 are standard frames, 4-7 are death frames.
        public float frameStep = 1/16; // time left in seconds until animation frame advances
        private Tile[] tiles;
        private Game game;



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
            frameStep %= 1/16; //reset frameStep ticker, compensating for overlap
         
            Move();
            CheckOverlap();
           

        }

        public void Render()
        {

            // draw the pac
            Draw.FillColor = Color.Yellow;
            switch (currentFrame)
            {
                // NORMAL: FIRST FRAME. FULL CIRCLE
                case 0:
                    switch (currentdir)
                    {
                        case Direction.RIGHT:
                            break;
                        case Direction.DOWN:
                            break;
                        case Direction.UP:
                            break;
                        case Direction.LEFT:
                            break;
                    }
                    break;
                // NORMAL: SECOND AND FOURTH FRAME. MOUTH OPEN MEDIUM
                case 1 or 3:
                    switch (currentdir)
                    {
                        case Direction.RIGHT:
                            break;
                        case Direction.DOWN:
                            break;
                        case Direction.UP:
                            break;
                        case Direction.LEFT:
                            break;
                    }
                    break;
                // NORMAL: THIRD FRAME. MOUTH WIDE OPEN
                case 2:
                    switch (currentdir)
                    {
                        case Direction.RIGHT:
                            break;
                        case Direction.DOWN:
                            break;
                        case Direction.UP:
                            break;
                        case Direction.LEFT:
                            break;
                    }
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

        }

        public void HandleInput()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up)) { desireddir = Direction.UP; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) { desireddir = Direction.LEFT; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S) || Input.IsKeyboardKeyDown(KeyboardInput.Down)) { desireddir = Direction.DOWN; }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) { desireddir = Direction.RIGHT; }


        }

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
