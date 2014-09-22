namespace Percolatie
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartAnimatie = new System.Windows.Forms.Button();
            this.panelAnimatie = new System.Windows.Forms.Panel();
            this.numericUpDownAantalRijen = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelPercolatie = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.buttonStopAnimatie = new System.Windows.Forms.Button();
            this.timerAnimatie = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAantalRijen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aantal rijen";
            // 
            // buttonStartAnimatie
            // 
            this.buttonStartAnimatie.Location = new System.Drawing.Point(50, 140);
            this.buttonStartAnimatie.Name = "buttonStartAnimatie";
            this.buttonStartAnimatie.Size = new System.Drawing.Size(120, 23);
            this.buttonStartAnimatie.TabIndex = 1;
            this.buttonStartAnimatie.Text = "Start animatie";
            this.buttonStartAnimatie.UseVisualStyleBackColor = true;
            this.buttonStartAnimatie.Click += new System.EventHandler(this.buttonStartAnimatie_Click);
            // 
            // panelAnimatie
            // 
            this.panelAnimatie.Location = new System.Drawing.Point(50, 220);
            this.panelAnimatie.Name = "panelAnimatie";
            this.panelAnimatie.Size = new System.Drawing.Size(400, 400);
            this.panelAnimatie.TabIndex = 3;
            // 
            // numericUpDownAantalRijen
            // 
            this.numericUpDownAantalRijen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAantalRijen.Location = new System.Drawing.Point(110, 50);
            this.numericUpDownAantalRijen.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAantalRijen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAantalRijen.Name = "numericUpDownAantalRijen";
            this.numericUpDownAantalRijen.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownAantalRijen.TabIndex = 7;
            this.numericUpDownAantalRijen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAantalRijen.ValueChanged += new System.EventHandler(this.numericUpDownAantalRijen_ValueChanged);
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Location = new System.Drawing.Point(110, 80);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownInterval.TabIndex = 6;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelPercolatie
            // 
            this.labelPercolatie.AutoSize = true;
            this.labelPercolatie.Location = new System.Drawing.Point(107, 200);
            this.labelPercolatie.Name = "labelPercolatie";
            this.labelPercolatie.Size = new System.Drawing.Size(0, 13);
            this.labelPercolatie.TabIndex = 5;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(47, 200);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(33, 13);
            this.labelN.TabIndex = 4;
            this.labelN.Text = "N = 0";
            // 
            // buttonStopAnimatie
            // 
            this.buttonStopAnimatie.Location = new System.Drawing.Point(330, 140);
            this.buttonStopAnimatie.Name = "buttonStopAnimatie";
            this.buttonStopAnimatie.Size = new System.Drawing.Size(120, 23);
            this.buttonStopAnimatie.TabIndex = 3;
            this.buttonStopAnimatie.Text = "Stop animatie";
            this.buttonStopAnimatie.UseVisualStyleBackColor = true;
            this.buttonStopAnimatie.Click += new System.EventHandler(this.buttonStopAnimatie_Click);
            // 
            // timerAnimatie
            // 
            this.timerAnimatie.Tick += new System.EventHandler(this.timerAnimatie_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Interval";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 670);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownAantalRijen);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.labelPercolatie);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.buttonStopAnimatie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStartAnimatie);
            this.Controls.Add(this.panelAnimatie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Percolatie";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAantalRijen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartAnimatie;
        private System.Windows.Forms.Panel panelAnimatie;
        private System.Windows.Forms.Timer timerAnimatie;
        private System.Windows.Forms.Button buttonStopAnimatie;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelPercolatie;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownAantalRijen;
        private System.Windows.Forms.Label label2;
    }
}

