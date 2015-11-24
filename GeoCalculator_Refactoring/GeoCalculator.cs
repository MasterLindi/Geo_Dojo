using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCalculator_Refactoring
{
	class GeoCalculator
	{
		private const double minDistance = 0.0015;
		private const double ratio = 1.6433;
		private const double berlinZoom_minX = 12.970889112363615;
		private const double berlinZoom_maxX = 13.810921568663067;
		private const double berlinZoom_minY = 52.30051932540991;
		private const double berlinZoom_maxY = 52.69535660334186;

		public static ReferencedEnvelope createBoundingBoxWithMarginFrom(List<Point> pointList, ReferencedEnvelope.CoordinateReferenceSystem coordRefSystem)
		{

			//Calculate minX, maxX, minY, maxY
			List<Double> xCoordList = GeoTools.filterOutXCoordinates(pointList);
			Double minX = GeoTools.findMinDouble(xCoordList);
			if (minX < berlinZoom_minX) minX = berlinZoom_minX;
			Double maxX = GeoTools.findMaxDouble(xCoordList);
			if (maxX > berlinZoom_maxX) maxX = berlinZoom_maxX;
			List<Double> yCoordList = GeoTools.filterOutYCoordinates(pointList);
			Double minY = GeoTools.findMinDouble(yCoordList);
			if (minY < berlinZoom_minY) minY = berlinZoom_minY;
			Double maxY = GeoTools.findMaxDouble(yCoordList);
			if (maxY > berlinZoom_maxY) maxY = berlinZoom_maxY;

			if (minX > berlinZoom_maxX || maxX < berlinZoom_minX || minY > berlinZoom_maxY || maxY < berlinZoom_minY)
			{
				return new ReferencedEnvelope(berlinZoom_minY, berlinZoom_maxY, berlinZoom_minX, berlinZoom_maxX, coordRefSystem);
			}

			//Create Point for each Corner
			Point minXPoint = GeoTools.createPoint(minX, minY);
			Point maxXPoint = GeoTools.createPoint(maxX, minY);
			Point minYPoint = GeoTools.createPoint(maxX, minY);
			Point maxYPoint = GeoTools.createPoint(maxX, maxY);

			//Calculate distance between minX, maxX, minY, maxY
			double distanceX = maxXPoint.distance(minXPoint);
			double distanceY = maxYPoint.distance(minYPoint);

			//Add margin for distances < minDistance
			if (distanceX < minDistance)
			{
				double minCorrFactor = (minDistance - distanceX) / 2;
				minX -= minCorrFactor;
				maxX += minCorrFactor;
				minY -= minCorrFactor;
				maxY += minCorrFactor;
			}
			if (distanceY < minDistance)
			{
				double minCorrFactor = (minDistance - distanceY) / 2;
				minX -= minCorrFactor;
				maxX += minCorrFactor;
				minY -= minCorrFactor;
				maxY += minCorrFactor;
			}

			double dist = Math.Abs((maxX - minX) - (maxY - minY));
			//Add a margin to the square
			double margin = dist / 5;
			minY -= margin;
			minX -= margin;
			maxY += margin;
			maxX += margin;

			distanceX = maxX - minX;
			distanceY = maxY - minY;

			//Make a square with correctionFactor
			double corrLenght;
			if ((distanceY * ratio) > distanceX)
			{
				corrLenght = (distanceY * ratio);
				minX = (minX + distanceX / 2) - corrLenght / 2;
				maxX = (maxX - distanceX / 2) + corrLenght / 2;
			}
			else
			{
				corrLenght = (distanceX / ratio);
				minY = (minY + distanceY / 2) - corrLenght / 2;
				maxY = (maxY - distanceY / 2) + corrLenght / 2;
			}
			return new ReferencedEnvelope(minY, maxY, minX, maxX, coordRefSystem);
		}
	}
}
