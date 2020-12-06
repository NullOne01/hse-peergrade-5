using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.GraphicObjects
{
    class FigureRectangle : FigureBase
    {
        private Point2D point1;
        private Point2D point2;

        public FigureRectangle(Brush brush, RectangleF rectangle) : base(brush) {
            point1 = new Point2D(rectangle.X, rectangle.Y);
            point2 = new Point2D(rectangle.Right, rectangle.Bottom);
        }

        public override void Draw(Graphics graphics, Matrix matrix) {
            Point p1 = (Point2D)(matrix * point1.GetVerticalHomogenMatrix());
            Point p2 = (Point2D)(matrix * point2.GetVerticalHomogenMatrix());
            Rectangle rect = new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);

            // Draw rectangle to screen.
            System.Diagnostics.Debug.WriteLine($"Draw rectangle: {p1} -> {p2}");
            graphics.FillRectangle(brush, rect);
        }
    }
}
