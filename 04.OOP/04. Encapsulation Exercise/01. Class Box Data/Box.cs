using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }

            private set
            {
                ValidateSides(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                ValidateSides(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                ValidateSides(value, nameof(Height));
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return
                (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        }

        public double CalculateLateralSurface()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }

        public double CalculateVolume()
        {

            return Length * Height * Width;
        }
        public void ValidateSides(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{paramName} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurface():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
