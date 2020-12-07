
namespace Peergrade5.ViewModel
{
    partial class FormStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonFractal1 = new System.Windows.Forms.Button();
            this.colorDialogStart = new System.Windows.Forms.ColorDialog();
            this.panelStartColor = new System.Windows.Forms.Panel();
            this.buttonStartColor = new System.Windows.Forms.Button();
            this.buttonEndColor = new System.Windows.Forms.Button();
            this.panelEndColor = new System.Windows.Forms.Panel();
            this.labelFractal1 = new System.Windows.Forms.Label();
            this.labelFractal2 = new System.Windows.Forms.Label();
            this.buttonFractal2 = new System.Windows.Forms.Button();
            this.labelIteration = new System.Windows.Forms.Label();
            this.trackBarIteration = new System.Windows.Forms.TrackBar();
            this.labelIterationTrackBar1 = new System.Windows.Forms.Label();
            this.labelIterationTrackBar3 = new System.Windows.Forms.Label();
            this.labelIterationTrackBar4 = new System.Windows.Forms.Label();
            this.labelIterationTrackBar5 = new System.Windows.Forms.Label();
            this.labelBaseLength = new System.Windows.Forms.Label();
            this.textBoxBaseLength = new System.Windows.Forms.TextBox();
            this.labelFractal3 = new System.Windows.Forms.Label();
            this.buttonFractal3 = new System.Windows.Forms.Button();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.panelBackgroundColor = new System.Windows.Forms.Panel();
            this.labelFractal4 = new System.Windows.Forms.Label();
            this.buttonFractal4 = new System.Windows.Forms.Button();
            this.labelFractal5 = new System.Windows.Forms.Label();
            this.buttonFractal5 = new System.Windows.Forms.Button();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.textBoxTree1 = new System.Windows.Forms.TextBox();
            this.labelTree1 = new System.Windows.Forms.Label();
            this.textBoxTree2 = new System.Windows.Forms.TextBox();
            this.labelTree2 = new System.Windows.Forms.Label();
            this.textBoxTree3 = new System.Windows.Forms.TextBox();
            this.labelTree3 = new System.Windows.Forms.Label();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIteration)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFractal1
            // 
            this.buttonFractal1.Location = new System.Drawing.Point(42, 56);
            this.buttonFractal1.Name = "buttonFractal1";
            this.buttonFractal1.Size = new System.Drawing.Size(75, 23);
            this.buttonFractal1.TabIndex = 0;
            this.buttonFractal1.Text = "Показать";
            this.buttonFractal1.UseVisualStyleBackColor = true;
            this.buttonFractal1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelStartColor
            // 
            this.panelStartColor.BackColor = System.Drawing.Color.White;
            this.panelStartColor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panelStartColor.Location = new System.Drawing.Point(70, 361);
            this.panelStartColor.Name = "panelStartColor";
            this.panelStartColor.Size = new System.Drawing.Size(87, 86);
            this.panelStartColor.TabIndex = 1;
            // 
            // buttonStartColor
            // 
            this.buttonStartColor.Location = new System.Drawing.Point(55, 316);
            this.buttonStartColor.Name = "buttonStartColor";
            this.buttonStartColor.Size = new System.Drawing.Size(119, 39);
            this.buttonStartColor.TabIndex = 2;
            this.buttonStartColor.Text = "Выбрать начальный цвет";
            this.buttonStartColor.UseVisualStyleBackColor = true;
            this.buttonStartColor.Click += new System.EventHandler(this.buttonStartColor_Click);
            // 
            // buttonEndColor
            // 
            this.buttonEndColor.Location = new System.Drawing.Point(216, 316);
            this.buttonEndColor.Name = "buttonEndColor";
            this.buttonEndColor.Size = new System.Drawing.Size(119, 39);
            this.buttonEndColor.TabIndex = 4;
            this.buttonEndColor.Text = "Выбрать конечный цвет";
            this.buttonEndColor.UseVisualStyleBackColor = true;
            this.buttonEndColor.Click += new System.EventHandler(this.buttonEndColor_Click);
            // 
            // panelEndColor
            // 
            this.panelEndColor.BackColor = System.Drawing.Color.White;
            this.panelEndColor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panelEndColor.Location = new System.Drawing.Point(231, 361);
            this.panelEndColor.Name = "panelEndColor";
            this.panelEndColor.Size = new System.Drawing.Size(87, 86);
            this.panelEndColor.TabIndex = 3;
            // 
            // labelFractal1
            // 
            this.labelFractal1.AutoSize = true;
            this.labelFractal1.Location = new System.Drawing.Point(22, 38);
            this.labelFractal1.Name = "labelFractal1";
            this.labelFractal1.Size = new System.Drawing.Size(120, 15);
            this.labelFractal1.TabIndex = 5;
            this.labelFractal1.Text = "Фрактальное дерево";
            // 
            // labelFractal2
            // 
            this.labelFractal2.AutoSize = true;
            this.labelFractal2.Location = new System.Drawing.Point(188, 38);
            this.labelFractal2.Name = "labelFractal2";
            this.labelFractal2.Size = new System.Drawing.Size(75, 15);
            this.labelFractal2.TabIndex = 7;
            this.labelFractal2.Text = "Кривая Коха";
            // 
            // buttonFractal2
            // 
            this.buttonFractal2.Location = new System.Drawing.Point(188, 56);
            this.buttonFractal2.Name = "buttonFractal2";
            this.buttonFractal2.Size = new System.Drawing.Size(75, 23);
            this.buttonFractal2.TabIndex = 6;
            this.buttonFractal2.Text = "Показать";
            this.buttonFractal2.UseVisualStyleBackColor = true;
            this.buttonFractal2.Click += new System.EventHandler(this.buttonFractal2_Click);
            // 
            // labelIteration
            // 
            this.labelIteration.AutoSize = true;
            this.labelIteration.Location = new System.Drawing.Point(277, 469);
            this.labelIteration.Name = "labelIteration";
            this.labelIteration.Size = new System.Drawing.Size(127, 15);
            this.labelIteration.TabIndex = 9;
            this.labelIteration.Text = "Количество итераций";
            this.labelIteration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarIteration
            // 
            this.trackBarIteration.LargeChange = 1;
            this.trackBarIteration.Location = new System.Drawing.Point(54, 502);
            this.trackBarIteration.Maximum = 15;
            this.trackBarIteration.Minimum = 1;
            this.trackBarIteration.Name = "trackBarIteration";
            this.trackBarIteration.Size = new System.Drawing.Size(608, 45);
            this.trackBarIteration.TabIndex = 10;
            this.trackBarIteration.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarIteration.Value = 5;
            this.trackBarIteration.ValueChanged += new System.EventHandler(this.trackBarIteration_ValueChanged);
            // 
            // labelIterationTrackBar1
            // 
            this.labelIterationTrackBar1.AutoSize = true;
            this.labelIterationTrackBar1.Location = new System.Drawing.Point(61, 532);
            this.labelIterationTrackBar1.Name = "labelIterationTrackBar1";
            this.labelIterationTrackBar1.Size = new System.Drawing.Size(13, 15);
            this.labelIterationTrackBar1.TabIndex = 12;
            this.labelIterationTrackBar1.Text = "1";
            // 
            // labelIterationTrackBar3
            // 
            this.labelIterationTrackBar3.AutoSize = true;
            this.labelIterationTrackBar3.Location = new System.Drawing.Point(228, 534);
            this.labelIterationTrackBar3.Name = "labelIterationTrackBar3";
            this.labelIterationTrackBar3.Size = new System.Drawing.Size(13, 15);
            this.labelIterationTrackBar3.TabIndex = 14;
            this.labelIterationTrackBar3.Text = "5";
            // 
            // labelIterationTrackBar4
            // 
            this.labelIterationTrackBar4.AutoSize = true;
            this.labelIterationTrackBar4.Location = new System.Drawing.Point(432, 536);
            this.labelIterationTrackBar4.Name = "labelIterationTrackBar4";
            this.labelIterationTrackBar4.Size = new System.Drawing.Size(19, 15);
            this.labelIterationTrackBar4.TabIndex = 15;
            this.labelIterationTrackBar4.Text = "10";
            // 
            // labelIterationTrackBar5
            // 
            this.labelIterationTrackBar5.AutoSize = true;
            this.labelIterationTrackBar5.Location = new System.Drawing.Point(639, 534);
            this.labelIterationTrackBar5.Name = "labelIterationTrackBar5";
            this.labelIterationTrackBar5.Size = new System.Drawing.Size(19, 15);
            this.labelIterationTrackBar5.TabIndex = 16;
            this.labelIterationTrackBar5.Text = "15";
            // 
            // labelBaseLength
            // 
            this.labelBaseLength.AutoSize = true;
            this.labelBaseLength.Location = new System.Drawing.Point(369, 340);
            this.labelBaseLength.Name = "labelBaseLength";
            this.labelBaseLength.Size = new System.Drawing.Size(106, 15);
            this.labelBaseLength.TabIndex = 17;
            this.labelBaseLength.Text = "Начальная длина:";
            // 
            // textBoxBaseLength
            // 
            this.textBoxBaseLength.Location = new System.Drawing.Point(375, 358);
            this.textBoxBaseLength.Name = "textBoxBaseLength";
            this.textBoxBaseLength.Size = new System.Drawing.Size(100, 23);
            this.textBoxBaseLength.TabIndex = 18;
            this.textBoxBaseLength.Text = "100";
            this.textBoxBaseLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTree1_KeyDown);
            // 
            // labelFractal3
            // 
            this.labelFractal3.AutoSize = true;
            this.labelFractal3.Location = new System.Drawing.Point(312, 38);
            this.labelFractal3.Name = "labelFractal3";
            this.labelFractal3.Size = new System.Drawing.Size(116, 15);
            this.labelFractal3.TabIndex = 20;
            this.labelFractal3.Text = "Ковёр Серпинского";
            // 
            // buttonFractal3
            // 
            this.buttonFractal3.Location = new System.Drawing.Point(327, 56);
            this.buttonFractal3.Name = "buttonFractal3";
            this.buttonFractal3.Size = new System.Drawing.Size(75, 23);
            this.buttonFractal3.TabIndex = 19;
            this.buttonFractal3.Text = "Показать";
            this.buttonFractal3.UseVisualStyleBackColor = true;
            this.buttonFractal3.Click += new System.EventHandler(this.buttonFractal3_Click);
            // 
            // buttonBackgroundColor
            // 
            this.buttonBackgroundColor.Location = new System.Drawing.Point(309, 85);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(119, 39);
            this.buttonBackgroundColor.TabIndex = 6;
            this.buttonBackgroundColor.Text = "Выбрать цвет фона";
            this.buttonBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            // 
            // panelBackgroundColor
            // 
            this.panelBackgroundColor.BackColor = System.Drawing.Color.White;
            this.panelBackgroundColor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panelBackgroundColor.Location = new System.Drawing.Point(327, 130);
            this.panelBackgroundColor.Name = "panelBackgroundColor";
            this.panelBackgroundColor.Size = new System.Drawing.Size(87, 86);
            this.panelBackgroundColor.TabIndex = 5;
            // 
            // labelFractal4
            // 
            this.labelFractal4.AutoSize = true;
            this.labelFractal4.Location = new System.Drawing.Point(452, 38);
            this.labelFractal4.Name = "labelFractal4";
            this.labelFractal4.Size = new System.Drawing.Size(153, 15);
            this.labelFractal4.TabIndex = 22;
            this.labelFractal4.Text = "Треугольник Серпинского";
            // 
            // buttonFractal4
            // 
            this.buttonFractal4.Location = new System.Drawing.Point(496, 56);
            this.buttonFractal4.Name = "buttonFractal4";
            this.buttonFractal4.Size = new System.Drawing.Size(75, 23);
            this.buttonFractal4.TabIndex = 21;
            this.buttonFractal4.Text = "Показать";
            this.buttonFractal4.UseVisualStyleBackColor = true;
            this.buttonFractal4.Click += new System.EventHandler(this.buttonFractal4_Click);
            // 
            // labelFractal5
            // 
            this.labelFractal5.AutoSize = true;
            this.labelFractal5.Location = new System.Drawing.Point(652, 38);
            this.labelFractal5.Name = "labelFractal5";
            this.labelFractal5.Size = new System.Drawing.Size(119, 15);
            this.labelFractal5.TabIndex = 24;
            this.labelFractal5.Text = "Множество Кантора";
            // 
            // buttonFractal5
            // 
            this.buttonFractal5.Location = new System.Drawing.Point(667, 56);
            this.buttonFractal5.Name = "buttonFractal5";
            this.buttonFractal5.Size = new System.Drawing.Size(89, 23);
            this.buttonFractal5.TabIndex = 23;
            this.buttonFractal5.Text = "Показать";
            this.buttonFractal5.UseVisualStyleBackColor = true;
            this.buttonFractal5.Click += new System.EventHandler(this.buttonFractal5_Click);
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(668, 116);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(100, 23);
            this.textBoxInterval.TabIndex = 26;
            this.textBoxInterval.Text = "100";
            this.textBoxInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTree1_KeyDown);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(683, 98);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(63, 15);
            this.labelInterval.TabIndex = 25;
            this.labelInterval.Text = "Интервал:";
            // 
            // textBoxTree1
            // 
            this.textBoxTree1.Location = new System.Drawing.Point(29, 115);
            this.textBoxTree1.Name = "textBoxTree1";
            this.textBoxTree1.Size = new System.Drawing.Size(100, 23);
            this.textBoxTree1.TabIndex = 28;
            this.textBoxTree1.Text = "100";
            this.textBoxTree1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTree1_KeyDown);
            // 
            // labelTree1
            // 
            this.labelTree1.AutoSize = true;
            this.labelTree1.Location = new System.Drawing.Point(12, 98);
            this.labelTree1.Name = "labelTree1";
            this.labelTree1.Size = new System.Drawing.Size(137, 15);
            this.labelTree1.TabIndex = 27;
            this.labelTree1.Text = "Левый угол (радианы)):";
            // 
            // textBoxTree2
            // 
            this.textBoxTree2.Location = new System.Drawing.Point(29, 170);
            this.textBoxTree2.Name = "textBoxTree2";
            this.textBoxTree2.Size = new System.Drawing.Size(100, 23);
            this.textBoxTree2.TabIndex = 30;
            this.textBoxTree2.Text = "100";
            this.textBoxTree2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTree1_KeyDown);
            // 
            // labelTree2
            // 
            this.labelTree2.AutoSize = true;
            this.labelTree2.Location = new System.Drawing.Point(12, 152);
            this.labelTree2.Name = "labelTree2";
            this.labelTree2.Size = new System.Drawing.Size(141, 15);
            this.labelTree2.TabIndex = 29;
            this.labelTree2.Text = "Правый угол (радианы):";
            // 
            // textBoxTree3
            // 
            this.textBoxTree3.Location = new System.Drawing.Point(29, 219);
            this.textBoxTree3.Name = "textBoxTree3";
            this.textBoxTree3.Size = new System.Drawing.Size(100, 23);
            this.textBoxTree3.TabIndex = 32;
            this.textBoxTree3.Text = "100";
            this.textBoxTree3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTree1_KeyDown);
            // 
            // labelTree3
            // 
            this.labelTree3.AutoSize = true;
            this.labelTree3.Location = new System.Drawing.Point(22, 201);
            this.labelTree3.Name = "labelTree3";
            this.labelTree3.Size = new System.Drawing.Size(114, 15);
            this.labelTree3.TabIndex = 31;
            this.labelTree3.Text = "Множитель длины:";
            // 
            // labelInfo1
            // 
            this.labelInfo1.AutoSize = true;
            this.labelInfo1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInfo1.Location = new System.Drawing.Point(334, 275);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(164, 20);
            this.labelInfo1.TabIndex = 33;
            this.labelInfo1.Text = "ОБЩИЕ НАСТРОЙКИ";
            // 
            // labelInfo2
            // 
            this.labelInfo2.AutoSize = true;
            this.labelInfo2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfo2.Location = new System.Drawing.Point(545, 316);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(312, 120);
            this.labelInfo2.TabIndex = 34;
            this.labelInfo2.Text = "Оцени этот великий интерфейс))\r\nКороче, инструкция:\r\n1) В окошках с фракталами мо" +
    "жно \r\nкрутить колёсиком, чтобы менять масштаб.\r\n2) В окошках с фракталами можно\r" +
    "\nзажимать ЛКМ и двигать фрактал.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "ИНДИВИДУАЛЬНЫЕ НАСТРОЙКИ И ВЫЗОВ ФРАКТАЛОВ\r\n";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 552);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelInfo2);
            this.Controls.Add(this.labelInfo1);
            this.Controls.Add(this.textBoxTree3);
            this.Controls.Add(this.labelTree3);
            this.Controls.Add(this.textBoxTree2);
            this.Controls.Add(this.labelTree2);
            this.Controls.Add(this.textBoxTree1);
            this.Controls.Add(this.labelTree1);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelFractal5);
            this.Controls.Add(this.buttonFractal5);
            this.Controls.Add(this.labelFractal4);
            this.Controls.Add(this.buttonFractal4);
            this.Controls.Add(this.buttonBackgroundColor);
            this.Controls.Add(this.panelBackgroundColor);
            this.Controls.Add(this.labelFractal3);
            this.Controls.Add(this.buttonFractal3);
            this.Controls.Add(this.textBoxBaseLength);
            this.Controls.Add(this.labelBaseLength);
            this.Controls.Add(this.labelIterationTrackBar5);
            this.Controls.Add(this.labelIterationTrackBar4);
            this.Controls.Add(this.labelIterationTrackBar3);
            this.Controls.Add(this.labelIterationTrackBar1);
            this.Controls.Add(this.trackBarIteration);
            this.Controls.Add(this.labelIteration);
            this.Controls.Add(this.labelFractal2);
            this.Controls.Add(this.buttonFractal2);
            this.Controls.Add(this.labelFractal1);
            this.Controls.Add(this.buttonEndColor);
            this.Controls.Add(this.panelEndColor);
            this.Controls.Add(this.buttonStartColor);
            this.Controls.Add(this.panelStartColor);
            this.Controls.Add(this.buttonFractal1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStart";
            this.Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIteration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFractal1;
        private System.Windows.Forms.ColorDialog colorDialogStart;
        private System.Windows.Forms.Panel panelStartColor;
        private System.Windows.Forms.Button buttonStartColor;
        private System.Windows.Forms.Button buttonEndColor;
        private System.Windows.Forms.Panel panelEndColor;
        private System.Windows.Forms.Label labelFractal1;
        private System.Windows.Forms.Label labelFractal2;
        private System.Windows.Forms.Button buttonFractal2;
        private System.Windows.Forms.Label labelIteration;
        private System.Windows.Forms.TrackBar trackBarIteration;
        private System.Windows.Forms.Label labelIterationTrackBar1;
        private System.Windows.Forms.Label labelIterationTrackBar3;
        private System.Windows.Forms.Label labelIterationTrackBar4;
        private System.Windows.Forms.Label labelIterationTrackBar5;
        private System.Windows.Forms.Label labelBaseLength;
        private System.Windows.Forms.TextBox textBoxBaseLength;
        private System.Windows.Forms.Label labelFractal3;
        private System.Windows.Forms.Button buttonFractal3;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Panel panelBackgroundColor;
        private System.Windows.Forms.Label labelFractal4;
        private System.Windows.Forms.Button buttonFractal4;
        private System.Windows.Forms.Label labelFractal5;
        private System.Windows.Forms.Button buttonFractal5;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.TextBox textBoxTree1;
        private System.Windows.Forms.Label labelTree1;
        private System.Windows.Forms.TextBox textBoxTree2;
        private System.Windows.Forms.Label labelTree2;
        private System.Windows.Forms.TextBox textBoxTree3;
        private System.Windows.Forms.Label labelTree3;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.Label label1;
    }
}

