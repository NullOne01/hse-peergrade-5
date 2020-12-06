using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Peergrade5.Presenter.Fractals
{
    public class FractalOptions
    {
        public Color startColor = Color.FromArgb(255, 255, 255);
        public Color endColor = Color.FromArgb(255, 255, 255);
        public int iterationNumber = 5;
        public int baseLength = 200;

        // Tree.
        public double angleLeft = Math.PI / 3;
        public double angleRight = Math.PI / 4;
        public double lengthMult = (double)2 / 3;

        // Sierpinski.
        public Color backColor = Color.FromArgb(0, 0, 255);

        // Cantor.
        public int interval = 50;
    }
}
