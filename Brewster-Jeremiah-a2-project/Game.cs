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
        float agitation_left = 0;
        float degree = MathF.PI / 180;
        float small_radius = 97 + 2/3;
        float big_radius = 127 + 2/3;

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
            float start_angle_small = 43.6f * degree;
            float delta_angle_small = 9.28f * degree;
            float start_angle_big = 31.27f * degree;
            float delta_angle_big = 11.7f * degree;

            //Decrement agitation avery frame
            if (agitation_left > 0) {
                agitation_left -= 0.0025f;
            }
            //Clicking logic for left eye; hitbox is the rectangle bounding the eye
            if (Input.GetMouseX() > 40 && Input.GetMouseX() < 180 && Input.GetMouseY() > 130 && Input.GetMouseY() < 190 && Input.IsMouseButtonPressed(MouseButton.Left)) {
                agitation_left += 0.2f;
            }
            //Cap agitation to 1
            if (agitation_left > 1) {
                agitation_left = 1;
            }

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
            //-Eye white-
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, (int)(255*(1-agitation_left)), (int)(255*(1-agitation_left)));
            Draw.Rectangle(40, 130, 140, 60);

            //-Pupil and iris-
            //Calcuate amount to shift; based on square root of distace
            float Xdiff = Input.GetMouseX() - baseX_left;
            float Ydiff = Input.GetMouseY() - baseY_left;
            float displacement = MathF.Sqrt(MathF.Sqrt(MathF.Pow(Xdiff, 2) + MathF.Pow(Ydiff, 2)));
            //Calcuate the direction to shift with sin and cos
            float angle = MathF.Atan(Xdiff / MathF.Abs(Ydiff));
            Xdiff = MathF.Sin(angle);
            Ydiff = MathF.Cos(angle) * MathF.Sign(Ydiff);

            Draw.SetLineSize(0);
            Draw.SetFillColor("#64C4FF");
            Draw.Circle(baseX_left + Xdiff*displacement, baseY_left + Ydiff*displacement, 30);
            Draw.SetFillColor(Color.Black);
            Draw.Circle(baseX_left + Xdiff*displacement*1.3f, baseY_left + Ydiff*displacement*1.3f, 15);

            ////Guide for testing the eye movement
            //Draw.SetFillColor(Color.Red);
            //Draw.Circle(baseX_left, baseY_left, 5);
            //Draw.SetLineColor(Color.Red);
            //Draw.SetLineSize(1);
            //Draw.Line(baseX_left, baseY_left, Input.GetMouseX(), Input.GetMouseY());
            //Draw.SetFillColor(Color.Green);
            //Draw.Circle(baseX_left + Xdiff*displacement, baseY_left + Ydiff*displacement, 2);

            //-Eye boundries-
            Draw.SetLineColor(Color.Black);
            Draw.SetLineSize(1);
            //Top
            //Use sin and cos to draw lines mapped onto a circle
            //           X                                  Y                                 movement
            {
                Draw.Line(baseX_left - small_radius * MathF.Cos(43.6f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(43.6f * degree),
                    baseX_left - small_radius * MathF.Cos(52.88f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(52.88f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(52.88f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(52.88f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(52.88f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(52.88f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(62.16f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(62.16f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(62.16f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(62.16f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(62.16f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(62.16f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(71.44f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(71.44f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(71.44f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(71.44f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(71.44f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(71.44f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(80.72f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(80.72f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(80.72f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(80.72f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(80.72f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(80.72f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(90 * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(90 * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(90 * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(90 * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(90 * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(90 * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(99.28f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(99.28f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(99.28f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(99.28f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(99.28f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(99.28f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(108.56f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(108.56f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(108.56f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(108.56f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(108.56f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(108.56f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(117.84f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(117.84f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(117.84f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(117.84f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(117.84f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(117.84f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(127.12f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(127.12f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(127.12f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left - small_radius * MathF.Cos(127.12f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(127.12f * degree) - (baseY_left-30+small_radius - small_radius * MathF.Sin(127.12f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left - small_radius * MathF.Cos(136.4f * degree), baseY_left-30+small_radius - small_radius * MathF.Sin(136.4f * degree));
            }
            //Bottom
            //           X                                  Y                                 movement
            {
                Draw.Line(baseX_left + small_radius * MathF.Cos(43.6f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(43.6f * degree),
                    baseX_left + small_radius * MathF.Cos(52.88f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(52.88f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(52.88f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(52.88f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(52.88f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(52.88f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(62.16f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(62.16f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(62.16f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(62.16f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(62.16f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(62.16f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(71.44f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(71.44f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(71.44f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(71.44f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(71.44f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(71.44f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(80.72f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(80.72f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(80.72f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(80.72f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(80.72f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(80.72f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(90 * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(90 * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(90 * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(90 * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(90 * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(90 * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(99.28f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(99.28f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(99.28f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(99.28f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(99.28f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(99.28f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(108.56f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(108.56f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(108.56f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(108.56f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(108.56f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(108.56f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(117.84f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(117.84f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(117.84f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(117.84f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(117.84f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(117.84f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(127.12f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(127.12f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(127.12f * degree) - 160) * 0.75f * agitation_left);
                Draw.Line(baseX_left + small_radius * MathF.Cos(127.12f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(127.12f * degree) - (baseY_left+30-small_radius + small_radius * MathF.Sin(127.12f * degree) - 160) * 0.75f * agitation_left,
                    baseX_left + small_radius * MathF.Cos(136.4f * degree), baseY_left+30-small_radius + small_radius * MathF.Sin(136.4f * degree));
            }
            
            //-Eyelids-
            //Identical to the boundries, but thicker, and shifted up and down
            //hides the pupil and iris when outside of eye boundries
            Draw.SetLineColor(Color.OffWhite);
            Draw.SetLineSize(58);
            //Top
            //           X                                     Y                                          movement
            {
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big),
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 1), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 1) - (baseY_left-30+small_radius-small_radius * MathF.Sin(start_angle_small+delta_angle_small*1)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 1), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 1) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*1)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 2), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 2) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*2)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 2), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 2) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*2)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 3), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 3) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*3)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 3), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 3) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*3)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 4), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 4) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*4)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 4), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 4) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*4)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 5), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 5) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*5)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 5), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 5) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*5)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 6), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 6) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*6)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 6), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 6) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*6)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 7), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 7) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*7)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 7), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 7) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*7)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 8), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 8) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*8)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 8), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 8) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*8)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 9), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 9) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*9)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 9), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 9) - (baseY_left-30+small_radius-small_radius*MathF.Sin(start_angle_small+delta_angle_small*9)-160)*0.75f*agitation_left,
                    baseX_left - big_radius * MathF.Cos(start_angle_big + delta_angle_big * 10), baseY_left-30+small_radius - big_radius * MathF.Sin(start_angle_big + delta_angle_big * 10));
            }
            //Bottom
            //           X                                     Y                                          movement
            {
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big),
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 1), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 1) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*1)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 1), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 1) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*1)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 2), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 2) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*2)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 2), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 2) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*2)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 3), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 3) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*3)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 3), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 3) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*3)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 4), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 4) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*4)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 4), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 4) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*4)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 5), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 5) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*5)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 5), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 5) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*5)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 6), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 6) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*6)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 6), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 6) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*6)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 7), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 7) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*7)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 7), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 7) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*7)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 8), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 8) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*8)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 8), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 8) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*8)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 9), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 9) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*9)-160)*0.75f*agitation_left);
                Draw.Line(baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 9), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 9) - (baseY_left+30-small_radius+small_radius * MathF.Sin(start_angle_small+delta_angle_small*9)-160)*0.75f*agitation_left,
                    baseX_left + big_radius * MathF.Cos(start_angle_big + delta_angle_big * 10), baseY_left+30-small_radius + big_radius * MathF.Sin(start_angle_big + delta_angle_big * 10));
            }
        }
    }

}
