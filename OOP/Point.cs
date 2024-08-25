using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	internal class Point
	{
		
		double x;
		double y;

		public double X
		{
			get { return x; }
			set
			{
				if (value > 100) value = 100;
				x = value;
			}
		}

		public double Y
		{
			get => y;
			set { y = value; }
		}

		
		public double GetX()
		{
			return x;
		}
		public double GetY()
		{
			return y;
		}

		public void SetX(double x)
		{
			this.x = x;
		}
		public void SetY(double y)
		{
			this.y = y;
		}
		

		// Можно использовать автосвойства
		//public double X { get; set; }
		//public double Y { get; set; }

		public Point(double x = 0, double y = 0)
		{
			X = x;
			Y = y;
            Console.WriteLine($"Constructor: \t {this.GetHashCode()}");
        }

		~Point()
		{
			Console.WriteLine($"Destructor: \t {this.GetHashCode()}");
		}
	}
	
}
