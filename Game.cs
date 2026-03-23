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

        int tilewidth = 16;
        int tileheight = 16;
        int rows = 36;
        int columns = 28;
        int screenwidth = 448;
        int screenheight = 512;
        Pacman pacman = new Pacman();
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Pacman");
            Window.SetSize(screenwidth, screenheight);


        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            render();
            pacman.update();



        }


        public void render()
        {

            pacman.render();



        }








    }


}
