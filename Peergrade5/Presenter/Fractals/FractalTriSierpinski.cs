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
    class FractalTriSierpinski : FractalBase
    {
        public override int MaxIterationNum { get => 10; set { } }

        public FractalTriSierpinski(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillTriangles(Triangle triangleFrom) {
            List<FigureBase> listFigures = new List<FigureBase>();

            Queue<Triangle> trisToContinue = new Queue<Triangle>();
            trisToContinue.Enqueue(triangleFrom);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                Queue<Triangle> trisNextGeneration = new Queue<Triangle>();

                while (trisToContinue.Count > 0) {
                    Triangle triangle = trisToContinue.Dequeue();

                    // Use max to prevent division on zero.
                    Pen linePen = new Pen(
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1)),
                         (float)fractalOptionsLocal.penWidth);

                    listFigures.Add(new FigureTriangle(linePen, triangle));
                    CreateNextTriangles(triangle, trisNextGeneration);

                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;
                trisToContinue = new Queue<Triangle>(trisNextGeneration);
            }

            if (cancelToken.IsCancellationRequested) {
                // Another thread decided to cancel.
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            // We draw this shit in reverse order to illustrate colors properly.
            listFigures.Reverse();
            graphicWrapper.SetListFigures(listFigures);
        }

        private void CreateNextTriangles(Triangle triangle, Queue<Triangle> queue) {
            Triangle triangle1 = new Triangle(triangle.point1, 
                triangle.GetMiddlePoint1(), 
                triangle.GetMiddlePoint3());
            Triangle triangle2 = new Triangle(triangle.point2,
                triangle.GetMiddlePoint1(),
                triangle.GetMiddlePoint2());
            Triangle triangle3 = new Triangle(triangle.point3,
                triangle.GetMiddlePoint2(),
                triangle.GetMiddlePoint3());

            queue.Enqueue(triangle1);
            queue.Enqueue(triangle2);
            queue.Enqueue(triangle3);
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

            // Start triangle.
            Triangle startFractralTriangle =
                new Triangle(new Point2D(control.Width / 2, control.Height / 2),
                FractalOptions.baseLength);

            try {
                // Calculating figures to make UI thread available all time.
                asyncTask = new Task(() => FillTriangles(startFractralTriangle), cancelToken);
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
