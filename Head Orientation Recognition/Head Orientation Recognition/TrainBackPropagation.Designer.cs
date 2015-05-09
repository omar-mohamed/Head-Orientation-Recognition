namespace Head_Orientation_Recognition
{
    partial class TrainBackPropagation
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
            this.textBoxAccuracy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNum_Iteraions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLayers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonPart = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAccuracy
            // 
            this.textBoxAccuracy.Location = new System.Drawing.Point(265, 266);
            this.textBoxAccuracy.Name = "textBoxAccuracy";
            this.textBoxAccuracy.ReadOnly = true;
            this.textBoxAccuracy.Size = new System.Drawing.Size(74, 20);
            this.textBoxAccuracy.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Accuracy";
            // 
            // textBoxEta
            // 
            this.textBoxEta.Location = new System.Drawing.Point(179, 99);
            this.textBoxEta.Name = "textBoxEta";
            this.textBoxEta.Size = new System.Drawing.Size(74, 20);
            this.textBoxEta.TabIndex = 25;
            this.textBoxEta.Text = "0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "learning rate";
            // 
            // textBoxNum_Iteraions
            // 
            this.textBoxNum_Iteraions.Location = new System.Drawing.Point(179, 64);
            this.textBoxNum_Iteraions.Name = "textBoxNum_Iteraions";
            this.textBoxNum_Iteraions.Size = new System.Drawing.Size(74, 20);
            this.textBoxNum_Iteraions.TabIndex = 23;
            this.textBoxNum_Iteraions.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Number of iterations";
            // 
            // textBoxLayers
            // 
            this.textBoxLayers.Location = new System.Drawing.Point(179, 27);
            this.textBoxLayers.Name = "textBoxLayers";
            this.textBoxLayers.Size = new System.Drawing.Size(331, 20);
            this.textBoxLayers.TabIndex = 21;
            this.textBoxLayers.Text = "4 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Hidden layers";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrain.ForeColor = System.Drawing.Color.Maroon;
            this.buttonTrain.Location = new System.Drawing.Point(225, 184);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(150, 60);
            this.buttonTrain.TabIndex = 19;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPart);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(319, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 76);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dataset size";
            // 
            // radioButtonPart
            // 
            this.radioButtonPart.AutoSize = true;
            this.radioButtonPart.Checked = true;
            this.radioButtonPart.Location = new System.Drawing.Point(6, 42);
            this.radioButtonPart.Name = "radioButtonPart";
            this.radioButtonPart.Size = new System.Drawing.Size(208, 17);
            this.radioButtonPart.TabIndex = 1;
            this.radioButtonPart.TabStop = true;
            this.radioButtonPart.Text = "Small part of the Data set (240 image)";
            this.radioButtonPart.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(171, 17);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All the Data set (12000 image)";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // TrainBackPropagation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxAccuracy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNum_Iteraions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTrain);
            this.Name = "TrainBackPropagation";
            this.Text = "TrainBackPropagation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAccuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNum_Iteraions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPart;
        private System.Windows.Forms.RadioButton radioButtonAll;
    }
}