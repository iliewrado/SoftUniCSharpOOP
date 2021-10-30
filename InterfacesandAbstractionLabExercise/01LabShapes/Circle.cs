using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            double innerRadius = radius - 0.4;
            double outerRadius = radius + 0.4;

            for (double i = radius; i >= -radius; --i)
            {
                for (double j = -radius; j < outerRadius; j+=0.5)
                {
                    double value = i * i + j * j;
                    if (value >= innerRadius * innerRadius 
                        && value <= outerRadius * outerRadius)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
