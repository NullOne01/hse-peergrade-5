using Peergrade5.Presenter.GraphicObjects;
using Peergrade5.Presenter.MathObjects;
using Peergrade5.Presenter.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Peergrade5.Presenter.Fractals
{
    class FractalCantor : FractalBase
    {
        public override int MaxIterationNum { get => 20; set { } }

        private Task asyncTask;
        private CancellationTokenSource cancelSource;
        private CancellationToken cancelToken;

        public FractalCantor(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillPoints(Tuple<Point2D, Point2D> startLine) {
            List<FigureBase> listFigures = new List<FigureBase>();

            Queue<Tuple<Point2D, Point2D>> linesToContinue = new Queue<Tuple<Point2D, Point2D>>();
            linesToContinue.Enqueue(startLine);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                Queue<Tuple<Point2D, Point2D>> linesNextGeneration = new Queue<Tuple<Point2D, Point2D>>();

                while (linesToContinue.Count > 0) {
                    Tuple<Point2D, Point2D> line = linesToContinue.Dequeue();
  
                    // Use max to prevent division on zero.
                    Pen linePen = new Pen(
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1)),
                         (float)fractalOptionsLocal.penWidth);
                    listFigures.Add(new FigureLine(linePen, line.Item1, line.Item2));

                    CreateNextLines(line, linesNextGeneration);

                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;

                linesToContinue = new Queue<Tuple<Point2D, Point2D>>(linesNextGeneration);
            }

            if (cancelToken.IsCancellationRequested) {
                // another thread decided to cancel
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            graphicWrapper.SetListFigures(listFigures);
        }

        private void CreateNextLines(Tuple<Point2D, Point2D> line, Queue<Tuple<Point2D, Point2D>> queue) {
            Vector2D lineVec = new Vector2D(line.Item1, line.Item2);
            double lineLengthDiv = lineVec.GetLength() / 3;
            double newY = line.Item1.y + FractalOptions.interval;

            Point2D leftPoint = new Point2D(line.Item1.x, newY);
            Point2D leftMiddle = new Point2D(line.Item1.x + lineLengthDiv, newY);
            Point2D rightMiddle = new Point2D(line.Item2.x - lineLengthDiv, newY);
            Point2D rightPoint = new Point2D(line.Item2.x, newY);

            queue.Enqueue(new Tuple<Point2D, Point2D>(leftPoint, leftMiddle));
            queue.Enqueue(new Tuple<Point2D, Point2D>(rightMiddle, rightPoint));
        }

        private async void BuildAsync() {
            // Preventing 2 same calculations at the same time.
            if (cancelSource != null) {
                cancelSource.Cancel();
                graphicWrapper.FullClear();
            }

            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;

            // Start line.
            Point2D leftPoint = new Point2D(control.Width / 2 - FractalOptions.baseLength / 2, control.Height / 2);
            Point2D rightPoint = new Point2D(control.Width / 2 + FractalOptions.baseLength / 2, control.Height / 2);

            try {
                asyncTask = new Task(() => FillPoints(new Tuple<Point2D, Point2D>(leftPoint, rightPoint)), cancelToken);
                asyncTask.Start();
                await asyncTask;
                System.Diagnostics.Debug.WriteLine($"Figures calculated!");
            }
            catch (TaskCanceledException) {
                System.Diagnostics.Debug.WriteLine($"Task canceled!");
            }
            catch (OperationCanceledException) {
                System.Diagnostics.Debug.WriteLine($"Task canceled with operation exception!");
            }
        }

        public override void Draw(Graphics graphics) {
            if (IsLoading())
                return;

            // Some random num to make this shit not stuck.
            // We draw 10 figures per tick.
            graphicWrapper.DrawFiguresNextNum(graphics, 10);
        }

        public override void Calculate() {
            BuildAsync();
        }

        public override bool IsLoading() {
            return asyncTask == null ||
                asyncTask.Status.Equals(TaskStatus.Running) ||
                graphicWrapper.IsEmpty();
        }
    }
}
