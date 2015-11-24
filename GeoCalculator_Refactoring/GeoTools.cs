using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoCalculator_Refactoring
{
	internal class GeoTools
	{
		public static Point createPoint(double x, double y)
		{
			return new Point(x, y);
		}

		public static Double findMaxDouble(List<Double> doubleList)
		{
			Assert.IsNotNull(doubleList);
			Assert.IsTrue(doubleList.Count > 0);

			Double maxDouble = doubleList.ElementAt(0);
			foreach (var aDouble in doubleList.GetRange(1, doubleList.Count -1))
			{
				if (aDouble > maxDouble) maxDouble = aDouble;
			}
			return maxDouble;
		}

		public static Double findMinDouble(List<Double> doubleList)
		{
			Assert.IsNotNull(doubleList);
			Assert.IsTrue(doubleList.Count > 0);
			Double minDouble = doubleList.ElementAt(0);
			foreach (var aDouble in doubleList.GetRange(1, doubleList.Count -1))
			{
				if (aDouble < minDouble) minDouble = aDouble;
			}

			return minDouble;
		}

		public static List<Double> filterOutXCoordinates(List<Point> pointList)
		{
			var xlist = new List<Double>();
			pointList.ForEach(elem => xlist.Add(elem.X));
			return xlist;

		}

		public static List<Double> filterOutYCoordinates(List<Point> pointList)
		{
			var ylist = new List<Double>();
			pointList.ForEach(elem => ylist.Add(elem.Y));
			return ylist;
		}
	}
}
