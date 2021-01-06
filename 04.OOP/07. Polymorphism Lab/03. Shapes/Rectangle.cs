using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shapes
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return height * 2 + width * 2;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
           sb.AppendLine( DrawLine(this.width, "*", "*"));
            for (int i = 1; i < this.height - 1; ++i)
                sb.AppendLine(DrawLine(this.width, "*", " "));
            sb.AppendLine(DrawLine(this.width, "*", "*"));

            return sb.ToString();

        }


        private string DrawLine(double width, string end, string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(end);
            for (int i = 1; i < width - 1; ++i)
                sb.Append(mid);
            sb.AppendLine(end);

            return sb.ToString();

        }
    }
}
