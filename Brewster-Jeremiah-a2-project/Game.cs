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
        //Left eye variables
        float baseX_left = 110;
        float baseY_left = 160;
        float degree = MathF.PI / 180;

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

            ////Guiding circles/dots for left eye
            //Draw.SetLineColor(Color.Green);
            //Draw.SetFillColor(Color.White);
            //Draw.SetLineSize(5);
            //Draw.Circle(110, 230, 100); //circle guide
            //Draw.Circle(110, 160, 70);
            //Draw.SetLineColor(Color.Red);
            //Draw.Circle(110, 160, 1); //center point
            //Draw.Circle(40, 160, 1); //left point
            //Draw.Circle(180, 160, 1); //right point
            //Draw.Circle(110, 130, 1); //top point

            //----LEFT EYE----
            //-Eye boundries-
            Draw.SetLineColor(Color.Black);
            Draw.SetLineSize(2); 
            //Top
            //center point for top circle is (110, 227); rotation per point is 9.28 degrees
            Draw.Line(110 - 97*MathF.Cos(43.6f*degree), 227 - 97*MathF.Sin(43.6f*degree),
                110 - 97*MathF.Cos(52.88f*degree), 227 - 97*MathF.Sin(52.88f*degree));
            Draw.Line(110 - 97*MathF.Cos(52.88f*degree), 227 - 97*MathF.Sin(52.88f*degree),
                110 - 97*MathF.Cos(62.16f*degree), 227 - 97*MathF.Sin(62.16f*degree));
            Draw.Line(110 - 97*MathF.Cos(62.16f*degree), 227 - 97*MathF.Sin(62.16f*degree),
                110 - 97*MathF.Cos(71.44f*degree), 227 - 97*MathF.Sin(71.44f*degree));
            Draw.Line(110 - 97*MathF.Cos(71.44f*degree), 227 - 97*MathF.Sin(71.44f*degree),
                110 - 97*MathF.Cos(80.72f*degree), 227 - 97*MathF.Sin(80.72f*degree));
            Draw.Line(110 - 97*MathF.Cos(80.72f*degree), 227 - 97*MathF.Sin(80.72f*degree),
                110 - 97*MathF.Cos(90*degree), 227 - 97*MathF.Sin(90*degree));
            Draw.Line(110 - 97*MathF.Cos(90*degree), 227 - 97*MathF.Sin(90*degree),
                110 - 97*MathF.Cos(99.28f*degree), 227 - 97*MathF.Sin(99.28f*degree));
            Draw.Line(110 - 97*MathF.Cos(99.28f*degree), 227 - 97*MathF.Sin(99.28f*degree),
                110 - 97*MathF.Cos(108.56f*degree), 227 - 97*MathF.Sin(108.56f*degree));
            Draw.Line(110 - 97*MathF.Cos(108.56f*degree), 227 - 97*MathF.Sin(108.56f*degree),
                110 - 97*MathF.Cos(117.84f*degree), 227 - 97*MathF.Sin(117.84f*degree));
            Draw.Line(110 - 97*MathF.Cos(117.84f*degree), 227 - 97*MathF.Sin(117.84f*degree),
                110 - 97*MathF.Cos(127.12f*degree), 227 - 97*MathF.Sin(127.12f*degree));
            Draw.Line(110 - 97*MathF.Cos(127.12f*degree), 227 - 97*MathF.Sin(127.12f*degree),
                110 - 97*MathF.Cos(136.4f*degree), 227 - 97*MathF.Sin(136.4f*degree));
            //Bottom
            //center point for top circle is (110, 93); rotation per point is 9.28 degrees
            Draw.Line(110 + 97*MathF.Cos(43.6f*degree), 93 + 97*MathF.Sin(43.6f*degree),
                110 + 97*MathF.Cos(52.88f*degree), 93 + 97*MathF.Sin(52.88f*degree));
            Draw.Line(110 + 97*MathF.Cos(52.88f*degree), 93 + 97*MathF.Sin(52.88f*degree),
                110 + 97*MathF.Cos(62.16f*degree), 93 + 97*MathF.Sin(62.16f*degree));
            Draw.Line(110 + 97*MathF.Cos(62.16f*degree), 93 + 97*MathF.Sin(62.16f*degree),
                110 + 97*MathF.Cos(71.44f*degree), 93 + 97*MathF.Sin(71.44f*degree));
            Draw.Line(110 + 97*MathF.Cos(71.44f*degree), 93 + 97*MathF.Sin(71.44f*degree),
                110 + 97*MathF.Cos(80.72f*degree), 93 + 97*MathF.Sin(80.72f*degree));
            Draw.Line(110 + 97*MathF.Cos(80.72f*degree), 93 + 97*MathF.Sin(80.72f*degree),
                110 + 97*MathF.Cos(90*degree), 93 + 97*MathF.Sin(90*degree));
            Draw.Line(110 + 97*MathF.Cos(90*degree), 93 + 97*MathF.Sin(90*degree),
                110 + 97*MathF.Cos(99.28f*degree), 93 + 97*MathF.Sin(99.28f*degree));
            Draw.Line(110 + 97*MathF.Cos(99.28f*degree), 93 + 97*MathF.Sin(99.28f*degree),
                110 + 97*MathF.Cos(108.56f*degree), 93 + 97*MathF.Sin(108.56f*degree));
            Draw.Line(110 + 97*MathF.Cos(108.56f*degree), 93 + 97*MathF.Sin(108.56f*degree),
                110 + 97*MathF.Cos(117.84f*degree), 93 + 97*MathF.Sin(117.84f*degree));
            Draw.Line(110 + 97*MathF.Cos(117.84f*degree), 93 + 97*MathF.Sin(117.84f*degree),
                110 + 97*MathF.Cos(127.12f*degree), 93 + 97*MathF.Sin(127.12f*degree));
            Draw.Line(110 + 97*MathF.Cos(127.12f*degree), 93 + 97*MathF.Sin(127.12f*degree),
                110 + 97*MathF.Cos(136.4f*degree), 93 + 97*MathF.Sin(136.4f*degree));
        }
    }

}
