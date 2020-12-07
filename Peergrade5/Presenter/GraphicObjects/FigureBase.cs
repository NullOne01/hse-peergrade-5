using Peergrade5.Presenter.MathObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.GraphicObjects
{
    /// <summary>
    ///     Base class for figures that can be drawn.
    /// </summary>
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

        /// <summary>
        ///     The method to draw this figure. Coordinates are changed using matrix.
        /// </summary>
        /// <param name="graphics"> Graphics to draw on. </param>
        /// <param name="matrix"> Matrix to change coordinates. </param>
        public abstract void Draw(Graphics graphics, Matrix matrix);
    }
}
