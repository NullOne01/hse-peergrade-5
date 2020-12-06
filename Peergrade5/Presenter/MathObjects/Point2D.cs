using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    public class Point2D
    {
        public double x;
        public double y;

        public Point2D(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public static Point2D operator -(Point2D a) {
            return new Point2D(-a.x, -a.y);
        }
        public static Point2D operator +(Point2D a, Point2D b) {
            return new Point2D(a.x + b.x, a.y + b.y);
        }
        public static Point2D operator -(Point2D a, Point2D b) {
            return a + (-b);
        }
        public static Point2D operator *(Point2D a, double num) {
            return new Point2D(a.x * num, a.y * num);
        }


        public static Point2D GetPolarPoint(double length, double angleRad) {
            double x = Math.Cos(angleRad) * length;
            double y = Math.Sin(angleRad) * length;
            return new Point2D(x, y);
        }

        public Matrix GetVerticalHomogenMatrix() {
            return new Matrix(new double[,] { { x }, { y }, { 1 } });
        }


        public Point2D RotateCoords(double angleRad) {
            return MatrixTemplates.GetRotateMatrix(angleRad) * GetVerticalHomogenMatrix();
        }

        public Point2D RotateRevertCoords(double angleRad) {
 
            return MatrixTemplates.GetInvRotateMatrix(angleRad) * GetVerticalHomogenMatrix();
        }

        public static implicit operator Point(Point2D a) {
            return new Point((int)Math.Round(a.x), (int)Math.Round(a.y));
        }

        public static implicit operator Vector2D(Point2D a) {
            return new Vector2D(a.x, a.y);
        }

        public override string ToString() {
            return $"X: {x} Y: {y}";
        }

        public RecursivePoint2D ToRecursivePoint2D() {
            return new RecursivePoint2D(x, y);
        }
    }
}
