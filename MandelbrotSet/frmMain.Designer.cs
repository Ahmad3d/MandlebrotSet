namespace MandelbrotSet
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.picField = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.chkAutoPrecision = new System.Windows.Forms.CheckBox();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.trkPrecision = new System.Windows.Forms.TrackBar();
            this.lblIterations = new System.Windows.Forms.Label();
            this.trkIterations = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picField)).BeginInit();
            this.grpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // picField
            // 
            this.picField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picField.BackColor = System.Drawing.Color.White;
            this.picField.Location = new System.Drawing.Point(12, 12);
            this.picField.Name = "picField";
            this.picField.Size = new System.Drawing.Size(943, 756);
            this.picField.TabIndex = 0;
            this.picField.TabStop = false;
            this.picField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picField_MouseClick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1022, 745);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(1022, 300);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "&Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.chkAutoPrecision);
            this.grpParameters.Controls.Add(this.lblPrecision);
            this.grpParameters.Controls.Add(this.trkPrecision);
            this.grpParameters.Controls.Add(this.lblIterations);
            this.grpParameters.Controls.Add(this.trkIterations);
            this.grpParameters.Location = new System.Drawing.Point(962, 13);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(135, 281);
            this.grpParameters.TabIndex = 3;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Parameters";
            // 
            // chkAutoPrecision
            // 
            this.chkAutoPrecision.AutoSize = true;
            this.chkAutoPrecision.Checked = true;
            this.chkAutoPrecision.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoPrecision.Location = new System.Drawing.Point(9, 150);
            this.chkAutoPrecision.Name = "chkAutoPrecision";
            this.chkAutoPrecision.Size = new System.Drawing.Size(48, 17);
            this.chkAutoPrecision.TabIndex = 4;
            this.chkAutoPrecision.Text = "Auto";
            this.chkAutoPrecision.UseVisualStyleBackColor = true;
            this.chkAutoPrecision.CheckedChanged += new System.EventHandler(this.chkAutoPrecision_CheckedChanged);
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(6, 102);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(85, 13);
            this.lblPrecision.TabIndex = 3;
            this.lblPrecision.Text = "Image Precision:";
            // 
            // trkPrecision
            // 
            this.trkPrecision.LargeChange = 20;
            this.trkPrecision.Location = new System.Drawing.Point(6, 118);
            this.trkPrecision.Maximum = 100;
            this.trkPrecision.Minimum = 10;
            this.trkPrecision.Name = "trkPrecision";
            this.trkPrecision.Size = new System.Drawing.Size(123, 45);
            this.trkPrecision.SmallChange = 10;
            this.trkPrecision.TabIndex = 2;
            this.trkPrecision.TickFrequency = 10;
            this.trkPrecision.Value = 50;
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(6, 28);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(99, 13);
            this.lblIterations.TabIndex = 1;
            this.lblIterations.Text = "Algorithm Precision:";
            // 
            // trkIterations
            // 
            this.trkIterations.LargeChange = 100;
            this.trkIterations.Location = new System.Drawing.Point(6, 44);
            this.trkIterations.Maximum = 4000;
            this.trkIterations.Minimum = 50;
            this.trkIterations.Name = "trkIterations";
            this.trkIterations.Size = new System.Drawing.Size(123, 45);
            this.trkIterations.SmallChange = 50;
            this.trkIterations.TabIndex = 0;
            this.trkIterations.TickFrequency = 50;
            this.trkIterations.Value = 50;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 780);
            this.Controls.Add(this.grpParameters);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.picField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Mandelbrot Set";
            ((System.ComponentModel.ISupportInitialize)(this.picField)).EndInit();
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picField;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.TrackBar trkIterations;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.TrackBar trkPrecision;
        private System.Windows.Forms.CheckBox chkAutoPrecision;
    }
}

