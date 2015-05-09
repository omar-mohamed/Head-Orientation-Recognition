namespace Head_Orientation_Recognition
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
            this.trainButtonBp = new System.Windows.Forms.Button();
            this.trainButtonRB = new System.Windows.Forms.Button();
            this.classifyInputButton = new System.Windows.Forms.Button();
            this.compressImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trainButtonBp
            // 
            this.trainButtonBp.BackColor = System.Drawing.Color.DarkGray;
            this.trainButtonBp.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButtonBp.ForeColor = System.Drawing.Color.Maroon;
            this.trainButtonBp.Location = new System.Drawing.Point(54, 57);
            this.trainButtonBp.Name = "trainButtonBp";
            this.trainButtonBp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trainButtonBp.Size = new System.Drawing.Size(194, 103);
            this.trainButtonBp.TabIndex = 2;
            this.trainButtonBp.Text = "Train dataset back propagation";
            this.trainButtonBp.UseVisualStyleBackColor = false;
            this.trainButtonBp.Click += new System.EventHandler(this.trainButtonBp_Click);
            // 
            // trainButtonRB
            // 
            this.trainButtonRB.BackColor = System.Drawing.Color.DarkGray;
            this.trainButtonRB.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButtonRB.ForeColor = System.Drawing.Color.Maroon;
            this.trainButtonRB.Location = new System.Drawing.Point(346, 57);
            this.trainButtonRB.Name = "trainButtonRB";
            this.trainButtonRB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trainButtonRB.Size = new System.Drawing.Size(194, 103);
            this.trainButtonRB.TabIndex = 3;
            this.trainButtonRB.Text = "Train dataset radial basis";
            this.trainButtonRB.UseVisualStyleBackColor = false;
            this.trainButtonRB.Click += new System.EventHandler(this.trainButtonRB_Click);
            // 
            // classifyInputButton
            // 
            this.classifyInputButton.BackColor = System.Drawing.Color.DarkGray;
            this.classifyInputButton.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classifyInputButton.ForeColor = System.Drawing.Color.Maroon;
            this.classifyInputButton.Location = new System.Drawing.Point(54, 207);
            this.classifyInputButton.Name = "classifyInputButton";
            this.classifyInputButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.classifyInputButton.Size = new System.Drawing.Size(194, 103);
            this.classifyInputButton.TabIndex = 4;
            this.classifyInputButton.Text = "Classify input";
            this.classifyInputButton.UseVisualStyleBackColor = false;
            this.classifyInputButton.Click += new System.EventHandler(this.classifyInputButton_Click);
            // 
            // compressImages
            // 
            this.compressImages.BackColor = System.Drawing.Color.DarkGray;
            this.compressImages.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compressImages.ForeColor = System.Drawing.Color.Maroon;
            this.compressImages.Location = new System.Drawing.Point(346, 207);
            this.compressImages.Name = "compressImages";
            this.compressImages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.compressImages.Size = new System.Drawing.Size(194, 103);
            this.compressImages.TabIndex = 5;
            this.compressImages.Text = "Compress Images PCA";
            this.compressImages.UseVisualStyleBackColor = false;
            this.compressImages.Click += new System.EventHandler(this.compressImages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 337);
            this.Controls.Add(this.compressImages);
            this.Controls.Add(this.classifyInputButton);
            this.Controls.Add(this.trainButtonRB);
            this.Controls.Add(this.trainButtonBp);
            this.Name = "Form1";
            this.Text = "Head orientation recognition";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button trainButtonBp;
        private System.Windows.Forms.Button trainButtonRB;
        private System.Windows.Forms.Button classifyInputButton;
        private System.Windows.Forms.Button compressImages;
    }
}

