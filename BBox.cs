using System;
using System.Collections.Generic;
using System.Text;

namespace BBDemo
{
    public class BBox
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private List<Ball> balls = new List<Ball>();


        public List<Ball> Balls
        {
            get { return balls; }            
        }

        public BBox(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
