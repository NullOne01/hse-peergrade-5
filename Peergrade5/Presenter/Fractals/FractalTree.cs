using Peergrade5.Presenter.GraphicObjects;
using Peergrade5.Presenter.MathObjects;
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
    class FractalTree : FractalBase
    {
        public override int MaxIterationNum 
            { get => 15; set { } }

        public FractalTree(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillPoints(RecursivePoint2D pointFrom) {
            // Replaced recursion on two loops. I don't trust recursions :)
            List<FigureBase> listFigures = new List<FigureBase>();

            Queue<RecursivePoint2D> pointsToContinue = new Queue<RecursivePoint2D>();
            pointsToContinue.Enqueue(pointFrom);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                Queue<RecursivePoint2D> pointsNextGeneration = new Queue<RecursivePoint2D>();

                while (pointsToContinue.Count > 0) {
                    RecursivePoint2D point = pointsToContinue.Dequeue();
                    RecursivePoint2D prevPoint = point.prevPoint;

                    // Use max to prevent division on zero.
                    Pen linePen = new Pen(
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1)),
                         (float)fractalOptionsLocal.penWidth);
                    listFigures.Add(new FigureLine(linePen, prevPoint, point));

                    pointsNextGeneration.Enqueue(CreateNextPoint(point, FractalOptions.angleRight, true));
                    pointsNextGeneration.Enqueue(CreateNextPoint(point, FractalOptions.angleLeft, false));
                    
                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;
                pointsToContinue = new Queue<RecursivePoint2D>(pointsNextGeneration);
            }

            if (cancelToken.IsCancellationRequested) {
                // Another thread decided to cancel.
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            graphicWrapper.SetListFigures(listFigures);
        }

        private RecursivePoint2D CreateNextPoint(RecursivePoint2D point, double angle, bool isRight) {
            RecursivePoint2D prevPoint = point.prevPoint;
            Vector2D lastVec = new Vector2D(point, prevPoint);

            // Local point in it's own system of coordinates.
            Point2D localPoint = Point2D.GetPolarPoint(lastVec.GetLength() * FractalOptions.lengthMult, Math.PI / 2 - angle);
            double angleLastVec = lastVec.GetAngleBetweenX() - Math.PI / 2;

            // If vector looks down, then we should have 180 - angle.
            if (lastVec.y <= 0) {
                angleLastVec = Math.PI - angleLastVec;
            }

            // We rotate system coordinates of local point.
            Point2D rotatedLocalPoint;
            if (isRight) {
                rotatedLocalPoint = localPoint.RotateRevertCoords(angleLastVec);
            } else {
                rotatedLocalPoint = localPoint.RotateCoords(angleLastVec);
                rotatedLocalPoint.x *= -1;
            }

            // The UI system coordinates has Y inverted.
            rotatedLocalPoint.y *= -1;

            RecursivePoint2D resultPoint = (point + rotatedLocalPoint).ToRecursivePoint2D();
            resultPoint.prevPoint = point;

            return resultPoint;
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
            RecursivePoint2D startFractralPoint = new RecursivePoint2D(control.Width / 2, control.Height);
            RecursivePoint2D startSecondFractalPoint = startFractralPoint - new RecursivePoint2D(0, FractalOptions.baseLength);
            startSecondFractalPoint.prevPoint = startFractralPoint;

            try {
                // Calculating figures to make UI thread available all time.
                asyncTask = new Task(() => FillPoints(startSecondFractalPoint), cancelToken);
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
