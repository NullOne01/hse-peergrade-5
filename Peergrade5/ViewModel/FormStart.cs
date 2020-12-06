using Peergrade5.Presenter.Fractals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peergrade5.ViewModel
{
    public partial class FormStart : Form
    {
        private FractalOptions fractalOptions = new FractalOptions();
        private List<FormFractal> formsFractal = new List<FormFractal>();

        public FormStart() {
            InitializeComponent();
            SetFractalOptionsGUI();

            textBoxTree1.LostFocus += textBoxTree1_LostFocus;
            textBoxTree2.LostFocus += textBoxTree2_LostFocus;
            textBoxTree3.LostFocus += textBoxTree3_LostFocus;
            textBoxBaseLength.LostFocus += textBoxBaseLength_LostFocus;
            textBoxInterval.LostFocus += textBoxInterval_LostFocus;
        }

        private void button1_Click(object sender, EventArgs e) {
            AddNewFractalForm(new FormFractal(new FractalTree(fractalOptions)));
        }

        private void buttonStartColor_Click(object sender, EventArgs e) {
            if (colorDialogStart.ShowDialog() == DialogResult.OK) {
                fractalOptions.startColor = colorDialogStart.Color;
                PassFractalOptions();
            }
        }

        private void buttonEndColor_Click(object sender, EventArgs e) {
            if (colorDialogStart.ShowDialog() == DialogResult.OK) {
                fractalOptions.endColor = colorDialogStart.Color;
                PassFractalOptions();
            }
        }

        private void AddNewFractalForm(FormFractal formFractal) {
            formsFractal.Add(formFractal);
            formFractal.Show();

            PassFractalOptions();
        }

        private void PassFractalOptions() {
            SetFractalOptionsGUI();

            foreach (var formFractal in formsFractal) {
                if (!formFractal.IsDisposed)
                    formFractal.PassFractalOptions(fractalOptions);
            }
        }

        private void buttonFractal2_Click(object sender, EventArgs e) {
            AddNewFractalForm(new FormFractal(new FractalKoch(fractalOptions)));
        }

        private void trackBarIteration_ValueChanged(object sender, EventArgs e) {
            fractalOptions.iterationNumber = trackBarIteration.Value;
            PassFractalOptions();
        }

        private void SetFractalOptionsGUI() {
            panelEndColor.BackColor = fractalOptions.endColor;
            panelStartColor.BackColor = fractalOptions.startColor;

            if (textBoxBaseLength.Text != "")
                textBoxBaseLength.Text = fractalOptions.baseLength.ToString();

            trackBarIteration.Value = fractalOptions.iterationNumber;
            panelBackgroundColor.BackColor = fractalOptions.backColor;

            if (textBoxInterval.Text != "")
                textBoxInterval.Text = fractalOptions.interval.ToString();

            if (textBoxTree1.Text != "")
                textBoxTree1.Text = fractalOptions.angleLeft.ToString();
            if (textBoxTree2.Text != "")
                textBoxTree2.Text = fractalOptions.angleRight.ToString();
            if (textBoxTree3.Text != "")
                textBoxTree3.Text = fractalOptions.lengthMult.ToString();
        }

        private void buttonFractal3_Click(object sender, EventArgs e) {
            AddNewFractalForm(new FormFractal(new FractalSierpinski(fractalOptions)));
        }

        private void buttonBackgroundColor_Click(object sender, EventArgs e) {
            if (colorDialogStart.ShowDialog() == DialogResult.OK) {
                fractalOptions.backColor = colorDialogStart.Color;
                PassFractalOptions();
            }
        }

        private void buttonFractal4_Click(object sender, EventArgs e) {
            AddNewFractalForm(new FormFractal(new FractalTriSierpinski(fractalOptions)));
        }

        private void buttonFractal5_Click(object sender, EventArgs e) {
            AddNewFractalForm(new FormFractal(new FractalCantor(fractalOptions)));
        }

        private bool EnterInt(TextBox textBox, out int resNum, int min, int max) {
            if (int.TryParse(textBox.Text, out resNum)) {
                if (resNum >= min && resNum <= max) {
                    return true;
                } else {
                    MessageBox.Show($"Введите число {min} <= n <= {max}");
                }
            } else {
                if (textBox.Text != "")
                    MessageBox.Show("Введите целое число");
            }

            return false;
        }

        private bool EnterDouble(TextBox textBox, out double resNum, double min, double max) {
            if (double.TryParse(textBox.Text, out resNum)) {
                if (resNum >= min && resNum <= max) {
                    return true;
                } else {
                    MessageBox.Show($"Введите число {min} <= n <= {max}");
                }
            } else {
                if (textBox.Text != "")
                    MessageBox.Show("Введите вещественное число");
            }

            return false;
        }

        private void textBoxTree1_LostFocus(object sender, EventArgs e) {
            if (EnterDouble(textBoxTree1, out double angle, -3.14, 3.14)) {
                fractalOptions.angleLeft = angle;
                PassFractalOptions();
            }

            SetFractalOptionsGUI();
        }

        private void textBoxTree2_LostFocus(object sender, EventArgs e) {
            if (EnterDouble(textBoxTree2, out double angle, -3.14, 3.14)) {
                fractalOptions.angleRight = angle;
                PassFractalOptions();
            }

            SetFractalOptionsGUI();
        }

        private void textBoxTree3_LostFocus(object sender, EventArgs e) {
            if (EnterDouble(textBoxTree3, out double mult, -1, 1)) {
                fractalOptions.lengthMult = mult;
                PassFractalOptions();
            }

            SetFractalOptionsGUI();
        }

        private void textBoxInterval_LostFocus(object sender, EventArgs e) {
            if (EnterInt(textBoxInterval, out int interval, -1000, 1000)) {
                fractalOptions.interval = interval;
                PassFractalOptions();
            }

            SetFractalOptionsGUI();
        }

        private void textBoxBaseLength_LostFocus(object sender, EventArgs e) {
            if (EnterInt(textBoxBaseLength, out int baseLength, 1, 1000)) {
                fractalOptions.baseLength = baseLength;
                PassFractalOptions();
            }

            SetFractalOptionsGUI();
        }

        // Methods below make enter text by pressing enter.
        private void textBoxTree1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.ActiveControl = null;
            }
        }
    }
}
