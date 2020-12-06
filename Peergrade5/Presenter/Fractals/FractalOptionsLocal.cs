using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.Fractals
{
    public class FractalOptionsLocal
    {
        private const double minScaleNum = 0.5;
        private const double maxScaleNum = 5;
        private const int maxAbsTransform = 100000;

        public double penWidth = 3;
        private double scaleNum = 1;
        private int transformX = 0;
        private int transformY = 0;

        public double ScaleNum {
            get => scaleNum;
            set {
                scaleNum = Math.Min(maxScaleNum, Math.Max(minScaleNum, value));
            }
        }

        public int TransformX {
            get => transformX;
            set {
                transformX = Math.Min(maxAbsTransform, Math.Max(-maxAbsTransform, value));
            }
        }
        public int TransformY {
            get => transformY;
            set {
                transformY = Math.Min(maxAbsTransform, Math.Max(-maxAbsTransform, value));
            }
        }

        public Matrix GetDimenMatrix() {
            return MatrixTemplates.GetTransformMatrix(TransformX, TransformY) 
                * MatrixTemplates.GetScaleMatrix(ScaleNum, ScaleNum);
        }
    }
}
