using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LineTriangle;
using System.Drawing;


namespace UnitTestLineTreangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLineIntersectpoint()
        {
            PointF result = TreangleOperations.FindPoint(2, -1, -3, -3, -1, 2);
            PointF expected = new PointF(1, -1);
            Assert.AreEqual(result,expected);
        }

        [TestMethod]
        public void TestLineLen()
        {
            float result = TreangleOperations.SideLen(new PointF(1,1),  new PointF(5,4));
            float expected = 5;
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void TestArea()
        {
            float[] aLine = new float[] { 0, 1, 5};
            float[] bLine = new float[] { 1, 0, 10};
            float[] cLine = new float[] { 1, 2, 0};
            TreangleDat result = TreangleOperations.TriangleDataCount(aLine, bLine, cLine);
            float expected = 100;
            Assert.AreEqual(result.Area, expected);
        }
        [TestMethod]
        public void TestPerimetr()
        {
            float[] aLine = new float[] { 0, 1, 5};
            float[] bLine = new float[] { 1, 0, 10};
            float[] cLine = new float[] { 1, 2, 0 };
            TreangleDat result = TreangleOperations.TriangleDataCount(aLine, bLine, cLine);
            int expected = 52;
            Assert.AreEqual((int)result.Perimetr, expected);
        }
    }
}
