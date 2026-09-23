// Include the namespaces (code libraries) you need below.
using System;
using System.Diagnostics.Tracing;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Interactive Eyes");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            //Guiding circles/dots for left eye
            Draw.SetLineColor(Color.Black);
            Draw.SetFillColor(Color.White);
            Draw.SetLineSize(5);
            Draw.Circle(110, 230, 100); //circle guide
            Draw.SetLineColor(Color.Red);
            Draw.Circle(110, 160, 1); //center point
            Draw.Circle(40, 160, 1); //left point
            Draw.Circle(180, 160, 1); //right point
            Draw.Circle(110, 130, 1); //top point
        }
    }

}
