namespace Guess_The_Word_Windows_Forms_MOO_ICT
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
            label1 = new Label();
            lblWord = new Label();
            textBox1 = new TextBox();
            lblInfo = new Label();
            lblGussed = new Label();
            RandomButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F);
            label1.Location = new Point(240, 19);
            label1.Name = "label1";
            label1.Size = new Size(274, 47);
            label1.TabIndex = 0;
            label1.Text = "Guess The Word";
            // 
            // lblWord
            // 
            lblWord.Font = new Font("Segoe UI", 21.75F);
            lblWord.ForeColor = Color.White;
            lblWord.Location = new Point(240, 118);
            lblWord.Name = "lblWord";
            lblWord.Size = new Size(274, 52);
            lblWord.TabIndex = 1;
            lblWord.Text = "label2";
            lblWord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 21.75F);
            textBox1.Location = new Point(259, 204);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 46);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.KeyPress += KeyIsPressed;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 18F);
            lblInfo.ForeColor = Color.FromArgb(192, 255, 255);
            lblInfo.Location = new Point(240, 280);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(274, 52);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Words: 0 of 0";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGussed
            // 
            lblGussed.Font = new Font("Segoe UI", 18F);
            lblGussed.ForeColor = Color.FromArgb(255, 255, 192);
            lblGussed.Location = new Point(520, 203);
            lblGussed.Name = "lblGussed";
            lblGussed.Size = new Size(274, 47);
            lblGussed.TabIndex = 1;
            lblGussed.Text = "Guessed: 0 times";
            lblGussed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RandomButton
            // 
            RandomButton.Location = new Point(340, 335);
            RandomButton.Name = "RandomButton";
            RandomButton.Size = new Size(75, 23);
            RandomButton.TabIndex = 3;
            RandomButton.Text = "Radomizar";
            RandomButton.UseVisualStyleBackColor = true;
            RandomButton.Click += RandomButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(RandomButton);
            Controls.Add(textBox1);
            Controls.Add(lblGussed);
            Controls.Add(lblInfo);
            Controls.Add(lblWord);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(192, 192, 255);
            Name = "Form1";
            Text = "Guess The Word Game MOO ICT";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lblWord;
        private TextBox textBox1;
        private Label lblInfo;
        private Label lblGussed;
        private Button RandomButton;
    }
}