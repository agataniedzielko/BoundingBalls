using System;
using System.Collections.Generic;
using System.Text;

namespace BBDemo
{
    public class Ball
    {

        public int Radius { get; set; }
        public int Mass { get; set; }
        public Vec2D Velocity { get; set; }
        public Vec2D Position { get; set; }

        public Ball()
        {
            Radius = 1;
            Mass = 1;
        }


    }
}
