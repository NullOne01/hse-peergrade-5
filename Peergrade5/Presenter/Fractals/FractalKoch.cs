using Peergrade5.Presenter.GraphicObjects;
using Peergrade5.Presenter.MathObjects;
using Peergrade5.Presenter.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Peergrade5.Presenter.Fractals
{
    class FractalKoch : FractalBase
    {
        public override int MaxIterationNum { get => 5; set { } }

        public FractalKoch(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillLines(FigureLine lineFrom) {
            Queue<FigureLine> linesToContinue = new Queue<FigureLine>();
            linesToContinue.Enqueue(lineFrom);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                Queue<FigureLine> linesNextGeneration = new Queue<FigureLine>();

                while (linesToContinue.Count > 0) {
                    FigureLine line = linesToContinue.Dequeue();

                    // Use max to prevent division on zero.
                    Pen linePen = new Pen(
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1)),
                         (float)fractalOptionsLocal.penWidth);
                    CreateNextLines(line, linesNextGeneration, linePen);

                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;

                linesToContinue = new Queue<FigureLine>(linesNextGeneration);
            }

            if (cancelToken.IsCancellationRequested) {
                // Another thread decided to cancel.
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            graphicWrapper.SetListFigures(linesToContinue.Cast<FigureBase>().ToList());
        }

        private void CreateNextLines(FigureLine prevLine, Queue<FigureLine> queue, Pen newPen) {
            Vector2D lastVec = new Vector2D(prevLine.point1, prevLine.point2);

            double angleLastVec = Math.PI / 2 - lastVec.GetAngleBetweenX();
            Point2D middlePoint = (Vector2D)prevLine.point1 + (lastVec / 2);

            double a = lastVec.GetLength() / 3;
            double h = a * Math.Pow(3, 1.0 / 3) / 2;

            if (lastVec.y <= 0) {
                middlePoint.x -= h * Math.Cos(angleLastVec);
            } else {
                middlePoint.x += h * Math.Cos(angleLastVec);
            }

            middlePoint.y -= h * Math.Sin(angleLastVec);

            // Adding 2 points to make triangle.
            Point2D pointA = (Vector2D)prevLine.point1 + (lastVec / 3);
            Point2D pointB = (Vector2D)prevLine.point1 + (2 * lastVec / 3);

            queue.Enqueue(new FigureLine(newPen, pointA, middlePoint));
            queue.Enqueue(new FigureLine(newPen, middlePoint, pointB));
            queue.Enqueue(new FigureLine(prevLine.pen, prevLine.point1, pointA));
            queue.Enqueue(new FigureLine(prevLine.pen, pointB, prevLine.point2));
        }

        private async void BuildAsync() {
            // Preventing 2 same calculations at the same time.
            if (cancelSource != null) {
                cancelSource.Cancel();
                graphicWrapper.FullClear();
            }

            // These token are needed to stop async thread (task here).
            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;

            // Start line.
            Point2D startFractralPoint =
                 new RecursivePoint2D(control.Width / 2 - FractalOptions.baseLength / 2, control.Height / 2);
            Point2D startSecondFractalPoint =
                startFractralPoint + new RecursivePoint2D(FractalOptions.baseLength, 0);

            Pen linePen = new Pen(FractalOptions.startColor,
                         (float)fractalOptionsLocal.penWidth);
            FigureLine startLine = new FigureLine(linePen, startFractralPoint, startSecondFractalPoint);

            try {
                // Calculating figures to make UI thread available all time.
                asyncTask = new Task(() => FillLines(startLine), cancelToken);
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

        public override void Calculate() {
            BuildAsync();
        }
    }
}
