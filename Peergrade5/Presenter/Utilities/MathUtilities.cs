using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.Utilities
{
    public static class MathUtilities
    {
        /// <summary>
        ///     Creates color linear gradient between start and end color. 
        ///     If t == 1 then returns end color.
        ///     If t == 0 then return start color.
        /// </summary>
        /// <param name="startColor"> Some start color. </param>
        /// <param name="endColor"> Some end color. </param>
        /// <param name="t"> Number in range [0, 1] </param>
        /// <returns> Linear gradient color. </returns>
        public static Color LerpColor(Color startColor, Color endColor, double t) {
            int resR = LerpStartEnd(startColor.R, endColor.R, t);
            int resG = LerpStartEnd(startColor.G, endColor.G, t);
            int resB = LerpStartEnd(startColor.B, endColor.B, t);

            // To prevent some random shit (it happens lol).
            resR = Math.Min(255, Math.Max(resR, 0));
            resG = Math.Min(255, Math.Max(resG, 0));
            resB = Math.Min(255, Math.Max(resB, 0));

            return Color.FromArgb(resR, resG, resB);
        }

        /// <summary>
        ///     Simple lerp between two numbers. From the first number to the second.
        /// </summary>
        /// <param name="start"> Start number. </param>
        /// <param name="end"> End number. </param>
        /// <param name="t"> Number in range [0, 1] </param>
        /// <returns> Lerped number. </returns>
        public static int LerpStartEnd(int start, int end, double t) {
            if (start <= end) {
                return (int)(start + (end - start) * t);
            } else {
                return (int)(start - (start - end) * t);
            }
        }

        /// <summary>
        ///     Simple lerp from min to max.
        /// </summary>
        /// <param name="a"> Some number. </param>
        /// <param name="b"> Some number. </param>
        /// <param name="t"> Number in range [0, 1] </param>
        /// <returns> Lerped number. </returns>
        public static int LerpMinMax(int a, int b, double t) {
            int max = Math.Max(a, b);
            int min = Math.Min(a, b);
            return (int)(min + (max - min) * t);
        }
    }
}
