namespace Lab_5_RPP_andrew
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxSize = new ComboBox();
            buttonDraw = new Button();
            comboBoxColor = new ComboBox();
            SuspendLayout();
            // 
            // comboBoxSize
            // 
            comboBoxSize.FormattingEnabled = true;
            comboBoxSize.Items.AddRange(new object[] { "нормальный", "с масштабированием" });
            comboBoxSize.Location = new Point(25, 53);
            comboBoxSize.Name = "comboBoxSize";
            comboBoxSize.Size = new Size(151, 28);
            comboBoxSize.TabIndex = 0;
            // 
            // buttonDraw
            // 
            buttonDraw.Location = new Point(213, 56);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.RightToLeft = RightToLeft.Yes;
            buttonDraw.Size = new Size(158, 29);
            buttonDraw.TabIndex = 1;
            buttonDraw.Text = "перерисовать";
            buttonDraw.UseVisualStyleBackColor = true;
            buttonDraw.Click += buttonDraw_Click;
            // 
            // comboBoxColor
            // 
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Items.AddRange(new object[] { "зеленый", "красный", "синий" });
            comboBoxColor.Location = new Point(32, 109);
            comboBoxColor.Name = "comboBoxColor";
            comboBoxColor.Size = new Size(151, 28);
            comboBoxColor.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 611);
            Controls.Add(comboBoxColor);
            Controls.Add(buttonDraw);
            Controls.Add(comboBoxSize);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxSize;
        private Button buttonDraw;
        private ComboBox comboBoxColor;
    }
}
