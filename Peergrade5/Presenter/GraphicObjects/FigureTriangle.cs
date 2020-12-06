using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.GraphicObjects
{
    class FigureTriangle : FigureBase
    {
        private Point2D point1;
        private Point2D point2;
        private Point2D point3;

        public FigureTriangle(Pen pen, Triangle triangle) : base(pen) {
            point1 = triangle.point1;
            point2 = triangle.point2;
            point3 = triangle.point3;
        }

        public override void Draw(Graphics graphics, Matrix matrix) {
            Point p1 = (Point2D)(matrix * point1.GetVerticalHomogenMatrix());
            Point p2 = (Point2D)(matrix * point2.GetVerticalHomogenMatrix());
            Point p3 = (Point2D)(matrix * point3.GetVerticalHomogenMatrix());

            // Draw triangle to screen.
            System.Diagnostics.Debug.WriteLine($"Draw triangle: {p1} -> {p2} -> {p3}");
            graphics.DrawLine(pen, p1, p2);
            graphics.DrawLine(pen, p2, p3);
            graphics.DrawLine(pen, p3, p1);
        }
    }
}
