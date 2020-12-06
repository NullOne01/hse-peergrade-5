using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    public class Vector2D
    {
        public double x;
        public double y;

        public Vector2D(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Vector2D(Point2D a, Point2D b) {
            x = b.x - a.x;
            y = b.y - a.y;
        }

        public static Vector2D operator -(Vector2D vec) {
            return new Vector2D(-vec.x , -vec.y);
        }

        public static Vector2D operator -(Vector2D vec1, Vector2D vec2) {
            return vec1 + (-vec2);
        }

        public static Vector2D operator +(Vector2D vec1, Vector2D vec2) {
            return new Vector2D(vec1.x + vec2.x, vec1.y + vec2.y);
        }

        public static Vector2D operator /(Vector2D vec, double num) {
            return new Vector2D(vec.x / num, vec.y / num);
        }

        public static Vector2D operator *(Vector2D vec, double num) {
            return new Vector2D(vec.x * num, vec.y * num);
        }
        public static Vector2D operator *(double num, Vector2D vec) {
            return new Vector2D(vec.x * num, vec.y * num);
        }

        public static implicit operator Point2D(Vector2D vec) {
            return new Point2D(vec.x, vec.y);
        }

        public double GetLength() {
            return Math.Sqrt(x * x + y * y);
        }

        public double GetAngleBetweenVec(Vector2D vec2) {
            return Math.Acos((x * vec2.x + y * vec2.y) /
                              (GetLength() * vec2.GetLength()));
        }

        public double GetAngleBetweenX() {
            return GetAngleBetweenVec(new Vector2D(1, 0));
        }
    }
}
