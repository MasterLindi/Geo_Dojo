using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCalculator_Refactoring
{
	class ReferencedEnvelope
	{
		public enum CoordinateReferenceSystem
		{
			Epsg48
		}

	
		private readonly double _minY;
		private readonly double _maxY;
		private readonly double _minX;
		private readonly double _maxX;
		private readonly CoordinateReferenceSystem _cordRef;

		public ReferencedEnvelope(double minY, double maxY, double minX, double maxX, CoordinateReferenceSystem cordRef)
		{
			_minY = minY;
			_maxY = maxY;
			_minX = minX;
			_maxX = maxX;
			_cordRef = cordRef;
		}

		public double MinX
		{
			get { return _minX; }
		}

		public double MinY
		{
			get { return _minY; }
		}

		public double MaxX
		{
			get { return _maxX; }
		}

		public double MaxY
		{
			get { return _maxY; }
		}

		public CoordinateReferenceSystem CordRef
		{
			get { return _cordRef; }
		}
	}
}
