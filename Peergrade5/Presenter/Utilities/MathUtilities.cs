using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.Utilities
{
    public static class MathUtilities
    {
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

        public static int LerpStartEnd(int start, int end, double t) {
            if (start <= end) {
                return (int)(start + (end - start) * t);
            } else {
                return (int)(start - (start - end) * t);
            }
        }

        public static int LerpMinMax(int a, int b, double t) {
            int max = Math.Max(a, b);
            int min = Math.Min(a, b);
            return (int)(min + (max - min) * t);
        }
    }
}
