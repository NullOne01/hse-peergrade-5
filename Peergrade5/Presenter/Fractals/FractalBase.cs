using Peergrade5.Presenter.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peergrade5.Presenter.Fractals
{
    public abstract class FractalBase
    {
        private FractalOptions fractalOptions;
        public GraphicWrapper graphicWrapper;
        public Control control;
        public FractalOptionsLocal fractalOptionsLocal = new FractalOptionsLocal();

        public virtual int MaxIterationNum { get => 20; set { } }
        public FractalOptions FractalOptions {
            get => fractalOptions;
            set {
                // Own copy method ¯\_(ツ)_/¯
                if (fractalOptions == null)
                    fractalOptions = new FractalOptions();

                fractalOptions.startColor = value.startColor;
                fractalOptions.endColor = value.endColor;
                fractalOptions.iterationNumber = Math.Min(value.iterationNumber, MaxIterationNum);
                fractalOptions.baseLength = value.baseLength;
                fractalOptions.backColor = value.backColor;
                fractalOptions.interval = value.interval;

                fractalOptions.angleLeft = value.angleLeft;
                fractalOptions.angleRight = value.angleRight;
                fractalOptions.lengthMult = value.lengthMult;
            }
        }

        protected FractalBase(FractalOptions fractalOptions) {
            this.FractalOptions = fractalOptions;
            graphicWrapper = new GraphicWrapper(fractalOptionsLocal);
        }

        public bool IsIterationNumLessEqualMax(int iterationNum) {
            return iterationNum <= MaxIterationNum;
        }

        public abstract bool IsLoading();
        public abstract void Draw(Graphics graphics);
        public abstract void Calculate();
    }
}
