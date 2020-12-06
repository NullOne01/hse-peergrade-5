using Peergrade5.Presenter.Fractals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peergrade5.ViewModel
{
    public partial class FormFractal : Form
    {
        // This is the offscreen drawing buffer.
        private Bitmap canvas;
        public FractalBase fractalBase;

        private int mouseHoldStartX = 0;
        private int mouseHoldStartY = 0;
        private int mouseHoldMoveTempX = 0;
        private int mouseHoldMoveTempY = 0;
        private int mouseHoldPrevTransX = 0;
        private int mouseHoldPrevTransY = 0;

        public FormFractal() {
            InitializeComponent();
            MouseWheel += FormFractal_MouseWheel;
            MouseUp += FormFractal_MouseUp;
            MouseDown += FormFractal_MouseDown;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            Size = new Size(screenWidth / 2, screenHeight / 2);
            MinimumSize = new Size(screenWidth / 2, screenHeight / 2);
            MaximumSize = new Size(screenWidth, screenHeight);
        }

        public FormFractal(FractalBase fractalBase) : this() {
            this.fractalBase = fractalBase;
            ResizeCanvas();
        }

        /// <summary>
        ///     Resizes the offscreen bitmap to match the current size of the window, 
        ///     it preserves what is currently in the bitmap.
        /// </summary>
        private void ResizeCanvas() {
            Bitmap tmp = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
            using (Graphics g = Graphics.FromImage(tmp)) {
                g.Clear(Color.White);
                if (canvas != null) {
                    g.DrawImage(canvas, 0, 0);
                    canvas.Dispose();
                }
            }

            canvas = tmp;
        }

        /// <summary>
        ///     Called when settings in main menu are changed.
        /// </summary>
        /// <param name="fractalOptions"></param>
        public void PassFractalOptions(FractalOptions fractalOptions) {
            fractalBase.FractalOptions = fractalOptions;
            if (!fractalBase.IsIterationNumLessEqualMax(fractalOptions.iterationNumber)) {
                MessageBox.Show($"Для какого-то фрактала превышено максимальное количество итераций.{Environment.NewLine}" +
                    $"Оно будет снижено до максимального количества.");
            }

            ClearCanvas();
            fractalBase.control = this;
            fractalBase.Calculate();
            Refresh();
        }

        private void FormFractal_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(canvas, 0, 0);
        }

        private void FormFractal_Resize(object sender, EventArgs e) {
            ResizeCanvas();
            ClearCanvas();
            Refresh();
        }

        private void FormFractal_MouseWheel(object sender, MouseEventArgs e) {
            //fractalBase.fractalOptionsLocal.penWidth += (float) e.Delta / 100;
            fractalBase.fractalOptionsLocal.ScaleNum += (float) e.Delta / 500;
            ClearCanvas();
            Refresh();
        }

        private void timerUpdate_Tick(object sender, EventArgs e) {
            fractalBase.control = this;

            labelLoading.Visible = fractalBase.IsLoading();
            buttonSave.Visible = !fractalBase.IsLoading();

            using (Graphics g = Graphics.FromImage(canvas))
                fractalBase.Draw(g);
            Refresh();
        }

        private void FormFractal_Shown(object sender, EventArgs e) {
            ResizeCanvas();
        }

        private void ClearCanvas() {
            using (Graphics g = Graphics.FromImage(canvas))
                g.Clear(Color.White);
            if (fractalBase != null)
                fractalBase.graphicWrapper.ResetOrder();
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            // Do nothing to stop flickering.
        }

        private void FormFractal_MouseUp(object sender, MouseEventArgs e) {
            timerMouseHold.Enabled = false;
        }

        private void FormFractal_MouseDown(object sender, MouseEventArgs e) {
            mouseHoldStartX = Cursor.Position.X;
            mouseHoldStartY = Cursor.Position.Y;
            mouseHoldMoveTempX = mouseHoldStartX;
            mouseHoldMoveTempY = mouseHoldStartY;
            mouseHoldPrevTransX = fractalBase.fractalOptionsLocal.TransformX;
            mouseHoldPrevTransY = fractalBase.fractalOptionsLocal.TransformY;
            timerMouseHold.Enabled = true;
        }

        private void timerMouseHold_Tick(object sender, EventArgs e) {
            // If the cursor was moved, then we repaint this shit.
            if (Cursor.Position.X != mouseHoldMoveTempX || Cursor.Position.Y != mouseHoldMoveTempY) {
                mouseHoldMoveTempX = Cursor.Position.X;
                mouseHoldMoveTempY = Cursor.Position.Y;

                fractalBase.fractalOptionsLocal.TransformX =
                    mouseHoldPrevTransX + (Cursor.Position.X - mouseHoldStartX);
                fractalBase.fractalOptionsLocal.TransformY =
                    mouseHoldPrevTransY + (Cursor.Position.Y - mouseHoldStartY);
                
                ClearCanvas();
                Refresh();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                canvas.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }
    }
}
