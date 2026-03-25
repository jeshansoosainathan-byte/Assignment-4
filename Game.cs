// Include the namespaces (code libraries) you need below.
using Assignment_4;
using System;
using System.Numerics;
using static Assignment_4.Pacman;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:


        int screenwidth = 448;
        int screenheight = 512;
        bool paused = false;
    
        float time = 0;
        float previousTime = 0;
        Tile[] tiles = new Tile[2000];
        Pacman pacman;
        int[,] map =
{
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,2,2,2,2,2,2,2,1,1,2,2,2,2,2,2,2,2,1},
    {1,3,1,1,2,1,1,2,1,1,2,1,1,2,1,1,1,3,1},
    {1,2,1,1,2,1,1,2,1,1,2,1,1,2,1,1,1,2,1},
    {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
    {1,2,1,1,2,1,2,1,1,1,1,1,2,1,2,1,1,2,1},
    {1,2,2,2,2,1,2,2,2,1,2,2,2,1,2,2,2,2,1},
    {1,1,1,1,2,1,1,1,0,0,0,1,1,1,2,1,1,1,1},
    {0,0,0,1,2,1,0,0,0,0,0,0,0,1,2,1,0,0,0},
    {1,1,1,1,2,1,0,1,6,6,6,1,0,1,2,1,1,1,1},
    {1,0,0,0,2,0,0,1,0,0,0,1,0,0,2,0,0,0,1},
    {1,1,1,1,2,1,0,1,1,1,1,1,0,1,2,1,1,1,1},
    {0,0,0,1,2,1,0,0,0,0,0,0,0,1,2,1,0,0,0},
    {1,1,1,1,2,1,1,1,1,4,1,1,1,1,2,1,1,1,1},
    {1,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,1},
    {1,2,1,1,2,1,1,2,1,1,2,1,1,2,1,1,2,2,1},
    {1,3,2,1,2,2,2,2,0,5,0,2,2,2,1,2,2,3,1},
    {1,1,2,1,2,1,2,1,1,1,1,1,2,1,2,1,2,1,1},
    {1,2,2,2,2,1,2,2,2,1,2,2,2,1,2,2,2,2,1},
    {1,2,1,1,1,1,1,1,2,1,2,1,1,1,1,1,1,2,1},
    {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
};

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Pacman");
            Window.SetSize(screenwidth, screenheight);
            Window.TargetFPS = 60;
            pacman = new Pacman(tiles,this);



            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    int t = map[row, col];

                    if (t == 1)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Wall);
                        int cols = map.GetLength(1);
                        //  Console.WriteLine($"X: { tile.x} Y: {tile.y}" );

                        tiles[row * cols + col] = tile;



                    }
                    else if (t == 2)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Pellet);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;


                    }

                    else if (t == 3)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.PowerPellet);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;


                    }
                    else if (t == 4)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Food);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;


                    }
                    else if (t == 5)
                    {

                        pacman.x = col * 16 + 70;
                        pacman.y = row * 16 + 80;

                       
                    }
                    else if (t == 6)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.GhostWall);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;
                    }
                    else if (t == 7)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Portal);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;
                    }

                }
            }






        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            Render();



            time += Time.DeltaTime;

            if (time >= 1f)
            {
                time -= 1f;

                if (pacman.powertime > 0)
                {
                    pacman.powertime--;
                    Console.WriteLine($"Powertime: {pacman.powertime}");
                }
            }







            Text.Color = MohawkGame2D.Color.White;
            Text.Size = 32;
            Text.Draw($"Score: {pacman.score} Power: {pacman.powertime}",0 ,0);
        

            if (!paused)
            {
                pacman.Update();
            } else
            {
                Text.Color = MohawkGame2D.Color.White;
                Text.Size = 32;
                Text.Draw("PAUSED", Window.Width/2, Window.Height/2);


            }

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Q)  ) { paused = !paused; }



        }

        public void Render()
        {
            for (int i = 0; i < tiles.Length; i++)
            {

                if (tiles[i] != null)
                {

                    Tile tile = tiles[i];


                    tile.Render();

                }

            }
            pacman.Render();


        }

    }
    }
