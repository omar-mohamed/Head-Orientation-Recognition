namespace Head_Orientation_Recognition
{
    partial class ClassifyInput
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonClassify = new System.Windows.Forms.Button();
            this.textBoxClassification = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(34, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.ForeColor = System.Drawing.Color.DimGray;
            this.buttonBrowse.Location = new System.Drawing.Point(34, 33);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(131, 37);
            this.buttonBrowse.TabIndex = 20;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonClassify
            // 
            this.buttonClassify.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassify.ForeColor = System.Drawing.Color.Maroon;
            this.buttonClassify.Location = new System.Drawing.Point(404, 92);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(150, 60);
            this.buttonClassify.TabIndex = 21;
            this.buttonClassify.Text = "Classify";
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.buttonClassify_Click);
            // 
            // textBoxClassification
            // 
            this.textBoxClassification.Enabled = false;
            this.textBoxClassification.Location = new System.Drawing.Point(429, 204);
            this.textBoxClassification.Name = "textBoxClassification";
            this.textBoxClassification.ReadOnly = true;
            this.textBoxClassification.Size = new System.Drawing.Size(96, 20);
            this.textBoxClassification.TabIndex = 22;
            this.textBoxClassification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Prediction";
            // 
            // ClassifyInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxClassification);
            this.Controls.Add(this.buttonClassify);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ClassifyInput";
            this.Text = "ClassifyInput";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.TextBox textBoxClassification;
        private System.Windows.Forms.Label label1;
    }
}