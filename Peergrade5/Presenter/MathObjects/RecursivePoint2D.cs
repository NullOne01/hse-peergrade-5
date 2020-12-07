using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    /// <summary>
    ///     Class of Point2D but connected with some other Point2D.
    /// </summary>
    public class RecursivePoint2D : Point2D
    {
        public RecursivePoint2D prevPoint;

        public RecursivePoint2D(double x, double y) : base(x, y) {}

        // Maybe I can use operators of the derived class. :/
        public static RecursivePoint2D operator -(RecursivePoint2D a) {
            return new RecursivePoint2D(-a.x, -a.y);
        }
        public static RecursivePoint2D operator +(RecursivePoint2D a, RecursivePoint2D b) {
            return new RecursivePoint2D(a.x + b.x, a.y + b.y);
        }
        public static RecursivePoint2D operator -(RecursivePoint2D a, RecursivePoint2D b) {
            return a + (-b);
        }
        public static RecursivePoint2D operator *(RecursivePoint2D a, double num) {
            return new RecursivePoint2D(a.x * num, a.y * num);
        }
    }
}
