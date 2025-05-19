namespace MedicineRecommendationSystem
{
    partial class FrmDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            listBox1 = new ListBox();
            comboBoxSymptoms = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            listView3 = new ListView();
            comboBoxDiseases = new ComboBox();
            button14 = new Button();
            button10 = new Button();
            label3 = new Label();
            button11 = new Button();
            comboBoxMedication = new ComboBox();
            listView1 = new ListView();
            button8 = new Button();
            button6 = new Button();
            label2 = new Label();
            button7 = new Button();
            button5 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 37);
            panel1.TabIndex = 0;
            panel1.MouseDoubleClick += panel1_MouseDoubleClick;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(1016, 0);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(40, 37);
            button4.TabIndex = 6;
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
            button3.Location = new Point(1058, 0);
            button3.Name = "button3";
            button3.Size = new Size(40, 37);
            button3.TabIndex = 5;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(19, 93);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(907, 124);
            listBox1.TabIndex = 1;
            // 
            // comboBoxSymptoms
            // 
            comboBoxSymptoms.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxSymptoms.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxSymptoms.FormattingEnabled = true;
            comboBoxSymptoms.Location = new Point(124, 44);
            comboBoxSymptoms.Name = "comboBoxSymptoms";
            comboBoxSymptoms.Size = new Size(260, 28);
            comboBoxSymptoms.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(19, 44);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 4;
            label1.Text = "Symptom:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(395, 44);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(83, 923);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(listView3);
            panel3.Controls.Add(comboBoxDiseases);
            panel3.Controls.Add(button14);
            panel3.Controls.Add(button10);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(button11);
            panel3.Controls.Add(comboBoxMedication);
            panel3.Controls.Add(listView1);
            panel3.Controls.Add(button8);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(listBox1);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(comboBoxSymptoms);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(83, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(1015, 923);
            panel3.TabIndex = 7;
            // 
            // listView3
            // 
            listView3.Location = new Point(19, 260);
            listView3.Name = "listView3";
            listView3.Size = new Size(907, 126);
            listView3.TabIndex = 26;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxDiseases
            // 
            comboBoxDiseases.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxDiseases.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxDiseases.FormattingEnabled = true;
            comboBoxDiseases.Location = new Point(124, 226);
            comboBoxDiseases.Name = "comboBoxDiseases";
            comboBoxDiseases.Size = new Size(260, 28);
            comboBoxDiseases.TabIndex = 25;
            // 
            // button14
            // 
            button14.Font = new Font("Segoe UI", 15F);
            button14.Location = new Point(19, 800);
            button14.Name = "button14";
            button14.Size = new Size(201, 43);
            button14.TabIndex = 23;
            button14.Text = "Reçete Oluştur";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 10F);
            button10.Location = new Point(495, 404);
            button10.Name = "button10";
            button10.Size = new Size(94, 29);
            button10.TabIndex = 18;
            button10.Text = "Sil";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(19, 404);
            label3.Name = "label3";
            label3.Size = new Size(45, 28);
            label3.TabIndex = 16;
            label3.Text = "İlaç:";
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 10F);
            button11.Location = new Point(395, 404);
            button11.Name = "button11";
            button11.Size = new Size(94, 29);
            button11.TabIndex = 17;
            button11.Text = "Ekle";
            button11.UseVisualStyleBackColor = true;
            // 
            // comboBoxMedication
            // 
            comboBoxMedication.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxMedication.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxMedication.FormattingEnabled = true;
            comboBoxMedication.Location = new Point(124, 404);
            comboBoxMedication.Name = "comboBoxMedication";
            comboBoxMedication.Size = new Size(260, 28);
            comboBoxMedication.TabIndex = 15;
            // 
            // listView1
            // 
            listView1.Location = new Point(19, 447);
            listView1.Name = "listView1";
            listView1.Size = new Size(907, 327);
            listView1.TabIndex = 14;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 10F);
            button8.Location = new Point(595, 222);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 13;
            button8.Text = "Analiz";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 10F);
            button6.Location = new Point(495, 222);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 12;
            button6.Text = "Sil";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(19, 222);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 10;
            label2.Text = "Hastalık:";
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 10F);
            button7.Location = new Point(395, 222);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 11;
            button7.Text = "Ekle";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 10F);
            button5.Location = new Point(495, 44);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 8;
            button5.Text = "Sil";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F);
            button2.Location = new Point(595, 44);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Analiz";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FrmDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 960);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmDoctor";
            Text = "FrmDoctor";
            Load += FrmDoctor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox listBox1;
        private ComboBox comboBoxSymptoms;
        private Label label1;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button8;
        private Button button6;
        private Label label2;
        private Button button7;
        private Button button5;
        private ListView listView1;
        private Button button10;
        private Label label3;
        private Button button11;
        private ComboBox comboBoxMedication;
        private Button button14;
        private ComboBox comboBoxDiseases;
        private ListView listView3;
    }
}