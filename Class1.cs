namespace Squarer
{
    public abstract class Figure
    {
        public string name;
        internal double radius;
        internal double[] sides;
        internal double[] angles;
        public abstract double Square(); 
    }

    public class Circle : Figure 
    {        
        /// <summary>
        /// Constructor class Circle
        /// </summary>
        /// <param name="radiusOrDiametr">The length of the estimated radius or diameter</param>
        /// <param name="isRadius">true- if the radius is obtained;false if the diameter is obtained</param>
        public Circle(double radiusOrDiametr,bool isRadius=true)
        {
            name = "Circle";
            if (isRadius)
            {
                //if the radius is obtained
                radius = radiusOrDiametr;
            }
            else
            {
                //if the diameter is obtained
                radius = radiusOrDiametr/2;
            }

        }
        public double Radius { get { return radius; } }
        public double Diametr { get { return radius * 2; } }
        override public double Square()
        {
            return Math.PI * (radius * radius);
        }
    }
    public class Triangle:Figure
    {
        public double SideA { get { return sides[0]; } }
        public double SideB { get { return sides[1]; } }
        public double SideC { get { return sides[2]; } }

        public double AngleAC { get { return angles[0]; } }
        public double AngleAB { get { return angles[1]; } }
        public double AngleCB { get { return angles[2]; } }

        public Triangle(double[] sides)
        {
            if (sides.Length > 3 || sides.Length < 3) throw new Exception("a triangle must have 3 sides");
            else
            {
                name = "triangle";
                base.sides = sides;
                angles = new double[3];
                angles[0] = GetAngle(sides[0]/*A*/,sides[1]/*B*/,sides[2]/*C*/);
                angles[1] = GetAngle(sides[1], sides[2], sides[0]);
                angles[2] = GetAngle(sides[2], sides[0], sides[1]);  
            } 
        }
        public Triangle(double firstSide, double twoSide, double threeSide) 
            : this(new double[] { firstSide, twoSide, threeSide }) { }
        double GetAngle(double a, double b, double c)
        { 
            double firstStep = (a * a )+ (c * c)- (b * b);
            double twoStep = firstStep / (2 * a * c);
            double threeStep = Math.Round(twoStep,2);
            double lastStep = Math.Acos(threeStep)*180/Math.PI;
            return lastStep; ;
        }
        override public double Square()
        {
            return (sides[0]+sides[1]+sides[2])/2;
        }
    }


}