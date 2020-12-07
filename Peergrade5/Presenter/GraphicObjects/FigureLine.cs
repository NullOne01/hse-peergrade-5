using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.GraphicObjects
{
    class FigureLine : FigureBase
    {
        public Point2D point1;
        public Point2D point2;

        public FigureLine(Pen pen, Point2D point1, Point2D point2) : base(pen) {
            this.point1 = point1;
            this.point2 = point2;
        }

        public override void Draw(Graphics graphics, Matrix matrix) {
            Point p1 = (Point2D)(matrix * point1.GetVerticalHomogenMatrix());
            Point p2 = (Point2D)(matrix * point2.GetVerticalHomogenMatrix());

            System.Diagnostics.Debug.WriteLine($"Draw line: {p1} -> {p2}");
            graphics.DrawLine(pen, p1, p2);
        }
    }
}
