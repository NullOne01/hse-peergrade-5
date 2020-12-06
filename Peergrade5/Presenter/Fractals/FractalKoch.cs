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
    class FractalKoch : FractalBase
    {
        public override int MaxIterationNum { get => 5; set { } }

        private Task asyncTask;
        private CancellationTokenSource cancelSource;
        private CancellationToken cancelToken;

        public FractalKoch(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillPoints(RecursivePoint2D pointFrom) {
            pointFrom.lineColor = FractalOptions.startColor;
            pointFrom.prevPoint.lineColor = FractalOptions.startColor;

            List<RecursivePoint2D> points = new List<RecursivePoint2D>();
            points.Add(pointFrom);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                int pointsCount = points.Count;
                for (int j = 0; j < pointsCount; j++) {
                    RecursivePoint2D point = points[j];
                    RecursivePoint2D prevPoint = point.prevPoint;

                    // Use max to prevent division on zero.
                    Color newColor =
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1));

                    //listFigures.Add(new FigureLine(linePen, prevPoint, point));

                    //System.Diagnostics.Debug.WriteLine($"I'm gay who added 2 points.");
                    CreateNextThreePoints(point, points, newColor);

                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;
            }

            if (cancelToken.IsCancellationRequested) {
                // another thread decided to cancel
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            List<FigureBase> listFigures = new List<FigureBase>();

            RecursivePoint2D currentPoint = pointFrom;
            while (currentPoint != null) {
                Pen linePen = new Pen(currentPoint.lineColor,
                         (float)fractalOptionsLocal.penWidth);
                if (currentPoint.prevPoint != null)
                    listFigures.Add(new FigureLine(linePen, currentPoint, currentPoint.prevPoint));
                currentPoint = currentPoint.prevPoint;
            }

            graphicWrapper.SetListFigures(listFigures);
        }

        private void CreateNextThreePoints(RecursivePoint2D point, List<RecursivePoint2D> list, Color color) {
            RecursivePoint2D prevPoint = point.prevPoint;
            Vector2D lastVec = new Vector2D(prevPoint, point);

            double angleLastVec = Math.PI / 2 - lastVec.GetAngleBetweenX();
            RecursivePoint2D middlePoint = ((Point2D)(prevPoint + (lastVec / 2))).ToRecursivePoint2D();

            double a = lastVec.GetLength() / 3;
            double h = a * Math.Pow(3, 1.0/3) / 2;

            if (lastVec.y <= 0) {
                middlePoint.x -= h * Math.Cos(angleLastVec);
                middlePoint.y -= h * Math.Sin(angleLastVec);
            } else {
                middlePoint.x += h * Math.Cos(angleLastVec);
                middlePoint.y -= h * Math.Sin(angleLastVec);
            }

            // Adding 2 points to make triangle.
            RecursivePoint2D pointA = ((Point2D)(prevPoint + (lastVec / 3))).ToRecursivePoint2D();
            pointA.prevPoint = prevPoint;
            middlePoint.prevPoint = pointA;
            RecursivePoint2D pointB = ((Point2D)(prevPoint + (2 * lastVec / 3))).ToRecursivePoint2D();
            pointB.prevPoint = middlePoint;
            point.prevPoint = pointB;

            pointA.lineColor = pointA.prevPoint.lineColor;
            middlePoint.lineColor = color;
            pointB.lineColor = color;

            list.Add(pointA);
            list.Add(middlePoint);
            list.Add(pointB);
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
           RecursivePoint2D startFractralPoint = 
                new RecursivePoint2D(control.Width / 2 - FractalOptions.baseLength / 2, control.Height / 2);

            RecursivePoint2D startSecondFractalPoint = 
                startFractralPoint + new RecursivePoint2D(FractalOptions.baseLength, 0);

            startSecondFractalPoint.prevPoint = startFractralPoint;

            try {
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
