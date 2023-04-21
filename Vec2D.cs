using System;
using System.Collections.Generic;
using System.Text;

namespace BBDemo
{
    public class Vec2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vec2D():this(1.0f,1.0f) //constructor chain
        {
            /*
            X = 1.0f;
            Y = 1.0f;
            */
        }

        /// <summary>
        /// Konstruktor wektora 2D
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vec2D(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
