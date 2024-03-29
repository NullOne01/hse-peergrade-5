﻿using Peergrade5.Presenter.GraphicObjects;
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
    class FractalSierpinski : FractalBase
    {
        public override int MaxIterationNum { get => 5; set { } }

        public FractalSierpinski(FractalOptions fractalOptions) : base(fractalOptions) {

        }

        private void FillRectangles(RectangleF rectFrom) {
            List<FigureBase> listFigures = new List<FigureBase>();

            // Filling background rectangle.
            SolidBrush backFillBrush = new SolidBrush(FractalOptions.backColor);
            listFigures.Add(new FigureRectangle(backFillBrush, rectFrom));

            Queue<RectangleF> rectsToContinue = new Queue<RectangleF>();
            rectsToContinue.Enqueue(rectFrom);

            for (int i = 0; i < FractalOptions.iterationNumber; i++) {
                Queue<RectangleF> rectsNextGeneration = new Queue<RectangleF>();

                while (rectsToContinue.Count > 0) {
                    RectangleF rect = rectsToContinue.Dequeue();

                    // Use max to prevent division on zero.
                    SolidBrush fillBrush = new SolidBrush(
                        MathUtilities.LerpColor(FractalOptions.startColor, FractalOptions.endColor,
                        (double)i / Math.Max(FractalOptions.iterationNumber - 1, 1)));

                    listFigures.Add(new FigureRectangle(fillBrush, GetMiddleRect(rect)));
                    CreateNextRectangles(rect, rectsNextGeneration);

                    if (cancelToken.IsCancellationRequested)
                        break;
                }

                if (!cancelToken.IsCancellationRequested)
                    System.Diagnostics.Debug.WriteLine($"Generation calculated!");
                else
                    break;
                rectsToContinue = new Queue<RectangleF>(rectsNextGeneration);
            }

            if (cancelToken.IsCancellationRequested) {
                // Another thread decided to cancel.
                System.Diagnostics.Debug.WriteLine("Task canceled");
                return;
            }

            graphicWrapper.SetListFigures(listFigures);
        }

        private void CreateNextRectangles(RectangleF rect, Queue<RectangleF> queue) {
            float sideLittleLength = rect.Width / 3;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    // Skip center.
                    if (i == 1 && j == 1)
                        continue;

                    RectangleF newRect =
                        new RectangleF(rect.X + sideLittleLength * j,
                        rect.Y + sideLittleLength * i,
                        sideLittleLength, sideLittleLength);
                    queue.Enqueue(newRect);
                }
            }
        }

        /// <summary>
        ///     Get the middle rectangle out of divided 9 rectangles.
        /// </summary>
        /// <param name="rect"> Rectangle that should be divided. </param>
        /// <returns> The middle rectangle. </returns>
        private RectangleF GetMiddleRect(RectangleF rect) {
            float sideLittleLength = rect.Width / 3;
            return new RectangleF(rect.X + sideLittleLength,
                        rect.Y + sideLittleLength,
                        sideLittleLength, sideLittleLength);
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

            // Start rect.
            RectangleF startFractralRect = 
                new RectangleF(control.Width / 2 - FractalOptions.baseLength / 2,
                control.Height / 2 - FractalOptions.baseLength / 2,
                FractalOptions.baseLength,
                FractalOptions.baseLength);

            try {
                // Calculating figures to make UI thread available all time.
                asyncTask = new Task(() => FillRectangles(startFractralRect), cancelToken);
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

