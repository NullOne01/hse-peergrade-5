using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    /// <summary>
    ///     Different types of homogeneous matrices. 
    ///     Homogeneous matrices are used to be able to transform, scale, rotate coordinates.
    /// </summary>
    public class MatrixTemplates
    {
        /// <summary>
        /// Get rotate homogeneous matrix.
        /// </summary>
        /// <param name="angleRad"> Angle in radians. </param>
        /// <returns> Rotate matrix. </returns>
        public static Matrix GetRotateMatrix(double angleRad) {
            return new Matrix(new double[,]
            {
                { Math.Cos(angleRad), -Math.Sin(angleRad), 0 },
                { Math.Sin(angleRad), Math.Cos(angleRad), 0 },
                { 0, 0, 1 }
            });
        }

        /// <summary>
        ///     Get transposed rotate homogeneous matrix.
        /// </summary>
        /// <param name="angleRad"> Angle in radians. </param>
        /// <returns> Transposed rotate matrix. </returns>
        public static Matrix GetInvRotateMatrix(double angleRad) {
            return new Matrix(new double[,]
            {
                { Math.Cos(angleRad), Math.Sin(angleRad), 0 },
                { -Math.Sin(angleRad), Math.Cos(angleRad), 0 },
                { 0, 0, 1 }
            });
        }

        /// <summary>
        ///     Get scale homogeneous matrix.
        /// </summary>
        /// <param name="scaleX"> Scale of x coordinates. </param>
        /// <param name="scaleY"> Scale of y coordinates. </param>
        /// <returns> Scale matrix. </returns>
        public static Matrix GetScaleMatrix(double scaleX, double scaleY) {
            return new Matrix(new double[,]
            {
                { scaleX, 0, 0 },
                { 0, scaleY, 0 },
                { 0, 0, 1 }
            });
        }

        /// <summary>
        /// <inheritdoc cref="GetScaleMatrix(double, double)"/> Here scaleX = 1, scaleY = -1.
        /// </summary>
        /// <returns> Scale matrix. </returns>
        public static Matrix GetInvertYMatrix() {
            return GetScaleMatrix(1, -1);
        }

        /// <summary>
        ///     Get transform homogeneous matrix. Ables to move coordinates.
        /// </summary>
        /// <param name="transformX"> Units to move x coordinates on. </param>
        /// <param name="transformY"> Units to move y coordinates on. </param>
        /// <returns> Transform matrix. </returns>
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
