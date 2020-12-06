using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    /// <summary>
    ///     Different types of homogeneous matrices.
    /// </summary>
    public class MatrixTemplates
    {
        public static Matrix GetRotateMatrix(double angleRad) {
            return new Matrix(new double[,]
            {
                { Math.Cos(angleRad), -Math.Sin(angleRad), 0 },
                { Math.Sin(angleRad), Math.Cos(angleRad), 0 },
                { 0, 0, 1 }
            });
        }

        public static Matrix GetInvRotateMatrix(double angleRad) {
            return new Matrix(new double[,]
            {
                { Math.Cos(angleRad), Math.Sin(angleRad), 0 },
                { -Math.Sin(angleRad), Math.Cos(angleRad), 0 },
                { 0, 0, 1 }
            });
        }

        public static Matrix GetScaleMatrix(double scaleX, double scaleY) {
            return new Matrix(new double[,]
            {
                { scaleX, 0, 0 },
                { 0, scaleY, 0 },
                { 0, 0, 1 }
            });
        }

        public static Matrix GetInvertYMatrix() {
            return GetScaleMatrix(1, -1);
        }

        public static Matrix GetTransformMatrix(double transformX, double transformY) {
            return new Matrix(new double[,]
            {
                { 1, 0, transformX },
                { 0, 1, transformY },
                { 0, 0, 1 }
            });
        }
    }
}
