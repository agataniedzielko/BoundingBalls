using System;
using System.Collections.Generic;
using System.Text;

namespace BBDemo
{
    class Naive2Algo : IAlgo
    {
        double Distance(Ball b1, Ball b2)
        {
            float a;
            a = b1.Position.X - b2.Position.X;
            float b;
            b = b1.Position.Y - b2.Position.Y;
            double d;
            d = Math.Sqrt(a * a + b * b);
            return d;
        }
        public void NextStep(BBox box)
        {
            foreach (var ball1 in box.Balls)
            {
                ball1.Position.X += ball1.Velocity.X;
                ball1.Position.Y += ball1.Velocity.Y;
                foreach (var ball2 in box.Balls)
                {
                 
                    if (ball1 != ball2)
                    {
                        if ((Distance(ball1, ball2)) <= (ball1.Radius + ball2.Radius))
                        {                            
                           /* if ((Distance(ball1, ball2)) < (ball1.Radius + ball2.Radius))
                            {
                                ball1.Position.X += 2*ball1.Velocity.X;
                                ball1.Position.Y += 2*ball1.Velocity.Y;
                                ball2.Position.X -= 2*ball1.Velocity.X;
                                ball2.Position.Y -= 2*ball1.Velocity.Y;
                            }*/
                            int m1 = ball1.Mass;
                            int m2 = ball2.Mass;
                            double theta = Math.Atan((ball2.Position.Y - ball1.Position.Y) / (ball2.Position.X - ball1.Position.X));

                            //obracamy o theta 
                            double V1xnew = ball1.Velocity.X * Math.Cos(theta) - ball1.Velocity.Y * Math.Sin(theta);
                            double V2xnew = ball2.Velocity.X * Math.Cos(theta) - ball2.Velocity.Y * Math.Sin(theta);
                            double V1ynew = ball1.Velocity.X * Math.Sin(theta) + ball1.Velocity.Y * Math.Cos(theta);
                            double V2ynew = ball2.Velocity.X * Math.Sin(theta) + ball2.Velocity.Y * Math.Cos(theta);

                            //stosujemy wzory na odwróconych wetorach
                            double v1_x = ((m1 - m2) * V1xnew + 2 * m2 * V2xnew) / (m1 + m2);
                            //float v1_y = ((m1 - m2) * ball1.Velocity.Y + 2 * m2 * ball2.Velocity.Y) / (m1 + m2);
                            double v2_x = (2 * m1 * V1xnew + (m2 - m1) * V2xnew) / (m1 + m2);
                            //float v2_y = (2 * m1 * ball1.Velocity.Y + (m2 - m1) * ball2.Velocity.Y) / (m1 + m2);


                            //odwracamy z powrotem uklad
                            double u1_x = v1_x * Math.Cos(-theta) - V1ynew * Math.Sin(-theta);
                            double u1_y = v1_x * Math.Sin(-theta) + V1ynew * Math.Cos(-theta);
                            double u2_x = v2_x * Math.Cos(-theta) - V2ynew * Math.Sin(-theta);
                            double u2_y = v2_x * Math.Sin(-theta) + V2ynew * Math.Cos(-theta);



                            ball1.Velocity.X = (float)u1_x;
                            ball1.Velocity.Y = (float)u1_y;
                            ball2.Velocity.X = (float)u2_x;
                            ball2.Velocity.Y = (float)u2_y;


                        }

                    }

                }

                
                if ((ball1.Position.X <= 0) || ((ball1.Position.X) >= (box.Width - ball1.Radius*2)))
                {
                    ball1.Velocity.X = -ball1.Velocity.X;
                }

               
                if ((ball1.Position.Y <= 0) || ((ball1.Position.Y) >= (box.Height - ball1.Radius*2)))
                {
                    ball1.Velocity.Y = -ball1.Velocity.Y;
                }


                /*
                 * algorytm ...
                 */

            }



        }
    }
}
