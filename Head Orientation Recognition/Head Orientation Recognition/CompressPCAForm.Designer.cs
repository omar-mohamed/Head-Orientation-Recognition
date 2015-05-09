namespace Head_Orientation_Recognition
{
    partial class CompressPCAForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonClassify = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputNumText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLearningRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.ForeColor = System.Drawing.Color.DimGray;
            this.buttonBrowse.Location = new System.Drawing.Point(141, 24);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(131, 37);
            this.buttonBrowse.TabIndex = 21;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Path";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Enabled = false;
            this.textBoxPath.Location = new System.Drawing.Point(68, 81);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(300, 20);
            this.textBoxPath.TabIndex = 24;
            // 
            // buttonClassify
            // 
            this.buttonClassify.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassify.ForeColor = System.Drawing.Color.Maroon;
            this.buttonClassify.Location = new System.Drawing.Point(131, 212);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(150, 60);
            this.buttonClassify.TabIndex = 26;
            this.buttonClassify.Text = "Compress";
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.buttonClassify_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Output number of features";
            // 
            // outputNumText
            // 
            this.outputNumText.Location = new System.Drawing.Point(161, 134);
            this.outputNumText.Name = "outputNumText";
            this.outputNumText.Size = new System.Drawing.Size(96, 20);
            this.outputNumText.TabIndex = 27;
            this.outputNumText.Text = "256";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Learning Rate";
            // 
            // textBoxLearningRate
            // 
            this.textBoxLearningRate.Location = new System.Drawing.Point(161, 171);
            this.textBoxLearningRate.Name = "textBoxLearningRate";
            this.textBoxLearningRate.Size = new System.Drawing.Size(96, 20);
            this.textBoxLearningRate.TabIndex = 29;
            this.textBoxLearningRate.Text = "0.00001";
            // 
            // CompressPCAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 297);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLearningRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputNumText);
            this.Controls.Add(this.buttonClassify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "CompressPCAForm";
            this.Text = "CompressPCAForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputNumText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLearningRate;
    }
}