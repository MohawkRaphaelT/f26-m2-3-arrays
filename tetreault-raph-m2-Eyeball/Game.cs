// Include the namespaces (code libraries) you need below.
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
        Eyeball[] eyeballs = new Eyeball[500];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Eyeball");
            Window.SetSize(800, 600);

            // Iterate over array, for each element in array, call Setup()
            for (int i = 0; i < eyeballs.Length; i += 1)
            {
                // For each element in array, create a new eyeball
                eyeballs[i] = new Eyeball();
                // Set up that eyeball
                eyeballs[i].Setup();
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            for (int i = 0; i < eyeballs.Length; i++)
            {
                eyeballs[i].Update();
            }
        }
    }

}
