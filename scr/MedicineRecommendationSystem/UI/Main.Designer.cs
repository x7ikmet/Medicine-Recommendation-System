namespace MedicineRecommendationSystem
{
    partial class Main
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
            button1 = new Button();
            BtnDoctor = new Button();
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(415, 242);
            button1.Name = "button1";
            button1.Size = new Size(207, 203);
            button1.TabIndex = 0;
            button1.Text = "Eczaci";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BtnDoctor
            // 
            BtnDoctor.FlatStyle = FlatStyle.Flat;
            BtnDoctor.Font = new Font("Segoe UI", 15F);
            BtnDoctor.Location = new Point(708, 242);
            BtnDoctor.Name = "BtnDoctor";
            BtnDoctor.Size = new Size(209, 203);
            BtnDoctor.TabIndex = 1;
            BtnDoctor.Text = "Doctor";
            BtnDoctor.UseVisualStyleBackColor = true;
            BtnDoctor.Click += BtnDoctor_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1325, 34);
            panel1.TabIndex = 2;
            panel1.MouseDoubleClick += panel1_MouseDoubleClick;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(1243, 0);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(40, 34);
            button4.TabIndex = 4;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Dock = DockStyle.Right;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F);
            button3.ForeColor = Color.Red;
            button3.Location = new Point(1285, 0);
            button3.Name = "button3";
            button3.Size = new Size(40, 34);
            button3.TabIndex = 3;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(BtnDoctor);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(1325, 722);
            panel2.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 756);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Main";
            Text = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button BtnDoctor;
        private Panel panel1;
        private Button button4;
        private Button button3;
        private Panel panel2;
    }
}
