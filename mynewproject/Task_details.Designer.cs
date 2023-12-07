namespace mynewproject
{
    partial class Task_details
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
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox6 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            textBox5 = new TextBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            label11 = new Label();
            richTextBox1 = new RichTextBox();
            comboBox3 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(311, 23);
            label1.Name = "label1";
            label1.Size = new Size(147, 31);
            label1.TabIndex = 0;
            label1.Text = "Task Details";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.Location = new Point(118, 367);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(80, 133);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 4;
            label3.Text = "Project ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(80, 75);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 5;
            label4.Text = "Task Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(78, 207);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 6;
            label5.Text = "Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(453, 116);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 7;
            label6.Text = "Priority";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.Location = new Point(450, 172);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 8;
            label7.Text = "Deadline";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.Location = new Point(453, 214);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 9;
            label8.Text = "Progress (int)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.Location = new Point(453, 259);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 10;
            label9.Text = "Status";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label10.Location = new Point(453, 307);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 11;
            label10.Text = "Comment";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(211, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(211, 68);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 13;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(569, 307);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(569, 165);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 27);
            dateTimePicker1.TabIndex = 17;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "New", "Revert", "Approved" });
            comboBox2.Location = new Point(569, 259);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 18;
            comboBox2.Text = "New";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(569, 215);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 19;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Normal", "Regular", "Urgent", "Most Urgent" });
            comboBox1.Location = new Point(569, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 20;
            comboBox1.Text = "Normal";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(337, 367);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 21;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button3.Location = new Point(551, 367);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 22;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label11.Location = new Point(450, 68);
            label11.Name = "label11";
            label11.Size = new Size(98, 20);
            label11.TabIndex = 23;
            label11.Text = "Employee ID";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(211, 207);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(220, 120);
            richTextBox1.TabIndex = 25;
            richTextBox1.Text = "";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(569, 60);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 26;
            comboBox3.Text = "Select";
            // 
            // Task_details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox3);
            Controls.Add(richTextBox1);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox6);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Task_details";
            Text = "Task_details";
            Load += Task_details_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private Button button2;
        private Button button3;
        private Label label11;
        private RichTextBox richTextBox1;
        private ComboBox comboBox3;
    }
}