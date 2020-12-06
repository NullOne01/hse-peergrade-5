using Peergrade5.Presenter.Fractals;
using Peergrade5.Presenter.GraphicObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.Utilities
{
    public class GraphicWrapper
    {
        private FractalOptionsLocal fractalOptionsLocal;

        private List<FigureBase> orderToDraw = new List<FigureBase>();
        private int indexToPrint = 0;

        public GraphicWrapper(FractalOptionsLocal fractalOptionsLocal) {
            this.fractalOptionsLocal = fractalOptionsLocal;
        }

        public void DrawFiguresNextNum(Graphics graphics, int num) {
            if (indexToPrint >= orderToDraw.Count)
                return;
            System.Diagnostics.Debug.WriteLine($"Draw {num} figures called");
            for (int i = indexToPrint; i < Math.Min(indexToPrint + num, orderToDraw.Count); i++) {
                // Rectangales don't have pen. They have brush.
                if (orderToDraw[i].pen != null)
                    orderToDraw[i].pen.Width = (float)fractalOptionsLocal.penWidth;
                orderToDraw[i].Draw(graphics, fractalOptionsLocal.GetDimenMatrix());
            }

            indexToPrint = Math.Min(indexToPrint + num, orderToDraw.Count);
        }

        public void SetListFigures(List<FigureBase> figureBases) {
            orderToDraw = figureBases;
        }

        public void ResetOrder() {
            indexToPrint = 0;
        }

        public void FullClear() {
            orderToDraw = new List<FigureBase>();
            ResetOrder();
        }

        public bool IsEmpty() {
            return orderToDraw.Count == 0;
        }
    }
}
