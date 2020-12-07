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

        // All these shit to make calculations async.
        protected Task asyncTask;
        protected CancellationTokenSource cancelSource;
        protected CancellationToken cancelToken;

        public virtual int MaxIterationNum { get => 15; set { } }
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

        public bool IsIterationNumLessEqualMax(int iterationNum) => iterationNum <= MaxIterationNum;

        public bool IsLoading() {
            return asyncTask == null ||
                asyncTask.Status.Equals(TaskStatus.Running) ||
                graphicWrapper.IsEmpty();
        }

        /// <summary>
        ///     Draw figures per tick.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics) {
            if (IsLoading())
                return;

            // Some random num to make this shit not stuck.
            // We draw 10 figures per tick.
            graphicWrapper.DrawFiguresNextNum(graphics, 10);
        }

        /// <summary>
        ///     Base method to calculate figures. 
        ///     In these fractals it starts async task.
        /// </summary>
        public abstract void Calculate();
    }
}
