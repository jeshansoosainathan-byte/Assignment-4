// Include the namespaces (code libraries) you need below.
using Assignment_4;
using System;
using System.Numerics;

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
        Pacman pacman = new Pacman();

        Tile[] tiles = new Tile[2000];

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
    {1,1,1,1,2,1,0,1,1,1,1,1,0,1,2,1,1,1,1},
    {0,0,0,0,2,0,0,1,0,0,0,1,0,0,2,0,0,0,0},
    {1,1,1,1,2,1,0,1,1,1,1,1,0,1,2,1,1,1,1},
    {0,0,0,1,2,1,0,0,0,0,0,0,0,1,2,1,0,0,0},
    {1,1,1,1,2,1,1,1,1,0,1,1,1,1,2,1,1,1,1},
    {1,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,1},
    {1,2,1,1,2,1,1,2,1,1,2,1,1,2,1,1,2,2,1},
    {1,3,2,1,2,2,2,2,0,0,0,2,2,2,1,2,2,3,1},
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

           



            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    int t = map[row, col];

                    if (t == 1)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Wall);
                        int cols = map.GetLength(1);

                        tiles[row * cols + col] = tile;



                    }
                    else if (t== 2)
                    {

                        Tile tile = new Tile(col, row, Tile.Type.Pellet);
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
            pacman.Update();
             

            foreach (Tile tile in tiles)
            {

                if (tile != null )
                {

                    tile.render();

                }
              


            }


        }


        








    }


}
