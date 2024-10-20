namespace Qr_Code
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
			components = new System.ComponentModel.Container();
			comboBox1 = new ComboBox();
			textBox1 = new TextBox();
			pictureBox1 = new PictureBox();
			button1 = new Button();
			button2 = new Button();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(133, 12);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(509, 28);
			comboBox1.TabIndex = 0;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(66, 57);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(663, 27);
			textBox1.TabIndex = 1;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(66, 90);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(663, 338);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// button1
			// 
			button1.Location = new Point(505, 434);
			button1.Name = "button1";
			button1.Size = new Size(93, 38);
			button1.TabIndex = 3;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(635, 434);
			button2.Name = "button2";
			button2.Size = new Size(94, 38);
			button2.TabIndex = 4;
			button2.Text = "button2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// timer1
			// 
			timer1.Tick += timer1_Tick;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(796, 488);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(pictureBox1);
			Controls.Add(textBox1);
			Controls.Add(comboBox1);
			Name = "Form1";
			Text = "Form1";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox comboBox1;
		private TextBox textBox1;
		private PictureBox pictureBox1;
		private Button button1;
		private Button button2;
		private System.Windows.Forms.Timer timer1;
	}
}
