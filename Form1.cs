using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDemo
{
    public partial class Form1 : Form
    {
        private SimulationBox sb;
        private BBox bb;
        public Form1()
        {
            InitializeComponent();

            bb = new BBox(400,400);

            var rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int RRadius = 40;

                float x = rnd.Next(0, bb.Width - RRadius);
                float y = rnd.Next(0, bb.Height - RRadius);

                bb.Balls.Add(new Ball() { Radius = 20, Position = new Vec2D(x, y) , Velocity = new Vec2D(2.0f,2.0f) });
            }

            bb.Balls.Add(new Ball() { Radius = 20, Position = new Vec2D(0, 0), Velocity = new Vec2D(2.0f, 0) });
            bb.Balls.Add(new Ball() { Radius = 20, Position = new Vec2D(350, 0), Velocity = new Vec2D(2.0f, 0) });

            //            sb = new SimulationBox(bb, new NaiveAlgo());
            sb = new SimulationBox(bb, new Naive2Algo());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timMain.Enabled = !timMain.Enabled;

            btnStart.Text = (timMain.Enabled) ? "Stop" : "Start";

        }

        //rysowac scene na podstawie
        int shiftX = 100;
        int shiftY = 100;
        private void PaintBB()
        {
            using (var g = CreateGraphics())
            {
                g.FillRectangle(Brushes.Blue,
                     new Rectangle(shiftX, shiftY, bb.Width, bb.Width)
                     );

                foreach (var ball in bb.Balls)
                {
                    g.DrawEllipse(Pens.Black,
                        shiftX + ball.Position.X,
                        shiftY + ball.Position.Y,
                        ball.Radius*2,
                        ball.Radius*2
                        ); ;
                }
            }
        }



        private void timMain_Tick(object sender, EventArgs e)
        {
            sb.NextStep();

            PaintBB();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PaintBB();
        }
    }
}
