using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoCalculator_Refactoring
{
	[TestClass]
	public class GeoCalculatorTest
	{

		[TestMethod]
		public void testCalculateBoundingBox_TestWithPointOutSideBerlin_MaxBoundingBox()
		{
			var berichtList = new List<Point>();
			berichtList.Add(GeoTools.createPoint(12.34, 23.34));
			berichtList.Add(GeoTools.createPoint(15.45, 22.34));
			berichtList.Add(GeoTools.createPoint(25.58, 35.11));

			ReferencedEnvelope actual = GeoCalculator.createBoundingBoxWithMarginFrom(berichtList, ReferencedEnvelope.CoordinateReferenceSystem.Epsg48);


			Assert.AreEqual(12.970889112363615, actual.MinX);
			Assert.AreEqual(13.810921568663067, actual.MaxX);
			Assert.AreEqual(52.300519325409908, actual.MinY);
			Assert.AreEqual(52.695356603341857, actual.MaxY);
		}

		[TestMethod]
		public void testCalculateBoundingBox_TestWithPointInsideBerlin_StringWithMinXMaXMinYMaxY()
		{
			var berichtList = new List<Point>();
			berichtList.Add(GeoTools.createPoint(13.3977622551083, 52.5239502108693));
			berichtList.Add(GeoTools.createPoint(13.3937622551083, 52.5229502108693));

			ReferencedEnvelope actual = GeoCalculator.createBoundingBoxWithMarginFrom(berichtList, ReferencedEnvelope.CoordinateReferenceSystem.Epsg48);

			Assert.AreEqual(13.3924122551083, actual.MinX);
			Assert.AreEqual(13.399112255108301, actual.MaxX);
			Assert.AreEqual(52.521411629965023, actual.MinY);
			Assert.AreEqual(52.525488791773576, actual.MaxY);
		}

		[TestMethod]
		public void testCalculateBoundingBox_TestWithMultiplePointsInsideBerlin_WithMinXMaXMinYMaxY()
		{
			var berichtList = new List<Point>();
			berichtList.Add(GeoTools.createPoint(13.388557434082, 52.527501340212));
			berichtList.Add(GeoTools.createPoint(13.3906173706055, 52.5258303413169));
			berichtList.Add(GeoTools.createPoint(13.3680009841919, 52.5524125681897));

			ReferencedEnvelope actual = GeoCalculator.createBoundingBoxWithMarginFrom(berichtList, ReferencedEnvelope.CoordinateReferenceSystem.Epsg48);

			Assert.IsTrue(13.356816184125995 > actual.MinX);
			Assert.IsTrue(13.401802170671404 < actual.MaxX);
			Assert.IsTrue(52.525433757270974 > actual.MinY);
			Assert.IsTrue(52.552809152235625 < actual.MaxY);

			Assert.AreEqual(13.354932002563347, actual.MinX);
			Assert.AreEqual(13.403686352234052, actual.MaxX);
			Assert.AreEqual(52.524287173225062, actual.MinY);
			Assert.AreEqual(52.553955736281537, actual.MaxY);
		}

		[TestMethod]
		public void testCalculateBoundingBox_TestWithMultiplePointsInsideBerlin2_MinXMaXMinYMaxY()
		{
			var berichtList = new List<Point>();
			berichtList.Add(GeoTools.createPoint(13.388557434082, 52.527501340212));
			berichtList.Add(GeoTools.createPoint(13.3680009841919, 52.5524125681897));
			berichtList.Add(GeoTools.createPoint(13.3906173706055, 52.5258303413169));
			berichtList.Add(GeoTools.createPoint(13.3977622551083, 52.5289502108693));

			ReferencedEnvelope actual = GeoCalculator.createBoundingBoxWithMarginFrom(berichtList, ReferencedEnvelope.CoordinateReferenceSystem.Epsg48);

			Assert.IsTrue(13.3680009841919 > actual.MinX);
			Assert.IsTrue(13.3977622551083 < actual.MaxX);
			Assert.IsTrue(52.5258303413169 > actual.MinY);
			Assert.IsTrue(52.5524125681897 < actual.MaxY);
		}
	}
}
