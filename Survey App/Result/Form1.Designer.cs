namespace Result
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbA = new System.Windows.Forms.ListBox();
            this.lbM = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adult\'s average fondness about programing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minor\'s average fondness about programing";
            // 
            // lbA
            // 
            this.lbA.BackColor = System.Drawing.Color.LightBlue;
            this.lbA.FormattingEnabled = true;
            this.lbA.ItemHeight = 15;
            this.lbA.Location = new System.Drawing.Point(388, 94);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(136, 244);
            this.lbA.TabIndex = 4;
            // 
            // lbM
            // 
            this.lbM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbM.FormattingEnabled = true;
            this.lbM.ItemHeight = 15;
            this.lbM.Location = new System.Drawing.Point(93, 94);
            this.lbM.Name = "lbM";
            this.lbM.Size = new System.Drawing.Size(135, 244);
            this.lbM.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(637, 396);
            this.Controls.Add(this.lbM);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Result";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private ListBox lbA;
        private ListBox lbM;
    }
}