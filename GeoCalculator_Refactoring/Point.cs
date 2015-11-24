using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCalculator_Refactoring
{
	class Point
	{
		private readonly double _x;
		private readonly double _y;

		public Point(double x, double y)
		{
			_x = x;
			_y = y;
		}

		public double Y
		{
			get { return _y; }
		}

		public double X
		{
			get { return _x; }
		}

		public double distance(Point other)
		{
			//Workaround: correct calculation is done by seperate library
			return _x - other.X;
		}
	}
}
