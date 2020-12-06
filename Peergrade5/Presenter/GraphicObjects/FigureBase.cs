using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.GraphicObjects
{
    public abstract class FigureBase
    {
        public Pen pen;
        public Brush brush;

        protected FigureBase(Pen pen) {
            this.pen = pen;
        }
        protected FigureBase(Brush brush) {
            this.brush = brush;
        }

        public abstract void Draw(Graphics graphics, Matrix matrix);
    }
}
