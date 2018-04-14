namespace SalesmanTravellingProblem
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cities = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ants = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(873, 629);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.form1_paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(975, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Намалювати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(975, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Розрахувати";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cities
            // 
            this.cities.Location = new System.Drawing.Point(975, 326);
            this.cities.Name = "cities";
            this.cities.Size = new System.Drawing.Size(132, 26);
            this.cities.TabIndex = 3;
            this.cities.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(975, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "К-сть міст";
            // 
            // ants
            // 
            this.ants.Location = new System.Drawing.Point(975, 405);
            this.ants.Name = "ants";
            this.ants.Size = new System.Drawing.Size(132, 26);
            this.ants.TabIndex = 5;
            this.ants.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(979, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "К-сть мурах";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 690);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ants);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cities);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ants;
        private System.Windows.Forms.Label label2;
    }
}

