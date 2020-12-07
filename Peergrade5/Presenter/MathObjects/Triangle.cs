using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    /// <summary>
    ///     Just triangle. Three points, nothing else.
    /// </summary>
    class Triangle
    {
        public Point2D point1;
        public Point2D point2;
        public Point2D point3;

        public Triangle(Point2D point1, Point2D point2, Point2D point3) {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        /// <summary>
        ///     Create equilateral triangle with center in <paramref name="pointCenter"/> and with choosen side length.
        ///     Uses triangle radius formule.
        /// </summary>
        /// <param name="pointCenter"></param>
        /// <param name="length"></param>
        public Triangle(Point2D pointCenter, double length) {
            double radius = GetRadius(length);
            point1 = new Point2D(pointCenter.x - length / 2, pointCenter.y + radius / 2);
            point2 = new Point2D(pointCenter.x + length / 2, pointCenter.y + radius / 2);
            point3 = new Point2D(pointCenter.x, pointCenter.y - radius);
        }

        /// <summary>
        ///     Get middle point between A and B.
        /// </summary>
        /// <returns> Middle point between A and B. </returns>
        public Point2D GetMiddlePoint1() => point1 + (Point2D)(new Vector2D(point1, point2) / 2);
        /// <summary>
        ///     Get middle point between B and C.
        /// </summary>
        /// <returns> Middle point between B and C. </returns>
        public Point2D GetMiddlePoint2() => point3 + (Point2D)(new Vector2D(point3, point2) / 2);
        /// <summary>
        ///     Get middle point between A and C.
        /// </summary>
        /// <returns> Middle point between A and C. </returns>
        public Point2D GetMiddlePoint3() => point1 + (Point2D)(new Vector2D(point1, point3) / 2);

        /// <summary>
        ///     Find length of side of equilateral triangle.
        /// </summary>
        /// <returns></returns>
        public double GetLength() => new Vector2D(point1, point2).GetLength();
        /// <summary>
        ///     Find radius of equilateral triangle.
        /// </summary>
        /// <returns></returns>
        public double GetRadius() => GetLength() / (Math.Pow(3, 1.0/2));
        public double GetRadius(double length) => length / (Math.Pow(3, 1.0/2));
    }
}
