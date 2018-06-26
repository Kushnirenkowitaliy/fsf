using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LineTriangle
{
    /// <summary>
    /// Struct, contain perimetr and area of treangle
    /// </summary>
    public struct TreangleDat
    {
        public float Perimetr;
        public float Area;
        public TreangleDat(float P, float A)
        {
            Perimetr = P;
            Area = A;
        }
    }
    /// <summary>
    /// Main class, computing treangle data
    /// </summary>
    public static class TreangleOperations
    {
        //Points of treiangle
        public static PointF A;
        public static PointF B;
        public static PointF C;
        //Treangle sides lenght
        private static float AB;
        private static float BC;
        private static float CA;

        /// <summary>
        /// Find intersection point of two lines
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="c1"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static PointF FindPoint(float a1, float b1, float c1, float a2, float b2, float c2)
        {
            if ((a1 / a2) == (b1 / b2))
            { throw new Exception("Lines never intersect"); }
            PointF A = new PointF();
            float x, y, a0 = a1, c0 = c1, a = a2 , b = b2, c = c2;
            if (a1 == 0 && b2 == 0)
            {
                y = -c1 / b1;
                x = -c2 / a2;
            }
            else if (a2 == 0 && b1 == 0)
            {
                y = -c2 / b2;
                x = -c1 / b1;
            }
            else
            {
                if (a1 == 0)
                {
                    y = -c1 / b1;
                    x = (-c2 - b2 * y) / a2;
                }
                else if (b1 == 0)
                {
                    x = -c1 / a1;
                    y = (-a2 * x - c2) / b2;
                }
                else if (a2 == 0)
                {
                    y = -c2 / b2;
                    x = (-c1 - b1 * y) / a1;
                }
                else if (b2 == 0)
                {
                    x = -c2 / a2;
                    y = (-a1 * x - c1) / b1;
                }
                else
                {
                    c1 /= b1;
                    c2 /= b2;
                    a1 /= b1;
                    a2 /= b2;
                    x = (c2 - c1) / (a1 - a2);
                    y = (-a0 * x - c0) / b1;
                }
            }
            A.X = x;
            A.Y = y;
            return A;
        }
        /// <summary>
        /// Count sides lenght of ABC treangle
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static float SideLen(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.Y - B.Y)*(A.Y - B.Y) + (A.X - B.X)*(A.X - B.X));
        }
        /// <summary>
        /// Count treangle data (perimetr and area)
        /// </summary>
        /// <param name="aLine"></param>
        /// <param name="bLine"></param>
        /// <param name="cLine"></param>
        /// <returns></returns>
        public static TreangleDat TriangleDataCount(float[] aLine, float[] bLine, float[] cLine)
        {
            ABCFind(aLine, bLine, cLine);
            //Compute side lenghts
            AB = SideLen(A, B);
            BC = SideLen(B, C);
            CA = SideLen(C, A);
            //compute perimetr
            float p = AB + BC + CA;
            return new TreangleDat(p, TriangleArea(p/2));
        }
        /// <summary>
        /// Compute treangle area
        /// </summary>
        /// <param name="P">perimetr</param>
        /// <returns></returns>
        public static float TriangleArea(float P)
        {
            //Gerone formula
            return (float)Math.Sqrt(P * (P - AB)*(P - BC)*(P - CA));
        }
        /// <summary>
        /// Find all poins of three line intersection
        /// </summary>
        /// <param name="aLine"></param>
        /// <param name="bLine"></param>
        /// <param name="cLine"></param>
        private static void ABCFind(float[] aLine, float[] bLine, float[] cLine)
        {
            //Find points between each line
            A = FindPoint(aLine[0], aLine[1], aLine[2], bLine[0], bLine[1], bLine[2]);
            B = FindPoint(cLine[0], cLine[1], cLine[2], bLine[0], bLine[1], bLine[2]);
            C = FindPoint(aLine[0], aLine[1], aLine[2], cLine[0], cLine[1], cLine[2]);
        }
    }
}
