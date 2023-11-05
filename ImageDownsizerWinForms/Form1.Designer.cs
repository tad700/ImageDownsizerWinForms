namespace ImageDownsizerWinForms
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
            browseButton = new Button();
            label1 = new Label();
            txtPath = new TextBox();
            txtPercent = new TextBox();
            label2 = new Label();
            downSizeButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Location = new Point(34, 72);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(106, 23);
            browseButton.TabIndex = 0;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 25);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "Select Image";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(34, 43);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(404, 23);
            txtPath.TabIndex = 2;
            // 
            // txtPercent
            // 
            txtPercent.Location = new Point(34, 130);
            txtPercent.Name = "txtPercent";
            txtPercent.Size = new Size(100, 23);
            txtPercent.TabIndex = 3;
            txtPercent.TextChanged += txtPercent_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 133);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 4;
            label2.Text = "%";
            // 
            // downSizeButton
            // 
            downSizeButton.Location = new Point(33, 159);
            downSizeButton.Name = "downSizeButton";
            downSizeButton.Size = new Size(75, 23);
            downSizeButton.TabIndex = 5;
            downSizeButton.Text = "Downsize";
            downSizeButton.UseVisualStyleBackColor = true;
            downSizeButton.Click += downSizeButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(163, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(625, 355);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(downSizeButton);
            Controls.Add(label2);
            Controls.Add(txtPercent);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Controls.Add(browseButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button browseButton;
        private Label label1;
        private TextBox txtPath;
        private TextBox txtPercent;
        private Label label2;
        private Button downSizeButton;
        private PictureBox pictureBox1;
    }
}