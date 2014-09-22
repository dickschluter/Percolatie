namespace Percolatie
{
    partial class PanelSimulaties
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRijen = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKolommen = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxParallel = new System.Windows.Forms.CheckBox();
            this.textBoxSimulatie = new System.Windows.Forms.TextBox();
            this.pictureBoxGrafiek = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMediaan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRijen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafiek)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rijen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kolommen";
            // 
            // numericUpDownRijen
            // 
            this.numericUpDownRijen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRijen.Location = new System.Drawing.Point(160, 50);
            this.numericUpDownRijen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRijen.Name = "numericUpDownRijen";
            this.numericUpDownRijen.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownRijen.TabIndex = 2;
            this.numericUpDownRijen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownKolommen
            // 
            this.numericUpDownKolommen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownKolommen.Location = new System.Drawing.Point(160, 80);
            this.numericUpDownKolommen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownKolommen.Name = "numericUpDownKolommen";
            this.numericUpDownKolommen.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownKolommen.TabIndex = 3;
            this.numericUpDownKolommen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(100, 140);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start simulatie";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(220, 140);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 23);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Stop simulatie";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxParallel
            // 
            this.checkBoxParallel.AutoSize = true;
            this.checkBoxParallel.Checked = true;
            this.checkBoxParallel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxParallel.Location = new System.Drawing.Point(100, 184);
            this.checkBoxParallel.Name = "checkBoxParallel";
            this.checkBoxParallel.Size = new System.Drawing.Size(60, 17);
            this.checkBoxParallel.TabIndex = 19;
            this.checkBoxParallel.Text = "Parallel";
            this.checkBoxParallel.UseVisualStyleBackColor = true;
            // 
            // textBoxSimulatie
            // 
            this.textBoxSimulatie.Location = new System.Drawing.Point(100, 220);
            this.textBoxSimulatie.Multiline = true;
            this.textBoxSimulatie.Name = "textBoxSimulatie";
            this.textBoxSimulatie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSimulatie.Size = new System.Drawing.Size(200, 250);
            this.textBoxSimulatie.TabIndex = 20;
            // 
            // pictureBoxGrafiek
            // 
            this.pictureBoxGrafiek.Location = new System.Drawing.Point(100, 522);
            this.pictureBoxGrafiek.Name = "pictureBoxGrafiek";
            this.pictureBoxGrafiek.Size = new System.Drawing.Size(200, 101);
            this.pictureBoxGrafiek.TabIndex = 21;
            this.pictureBoxGrafiek.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 566);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "0,50";
            // 
            // labelMediaan
            // 
            this.labelMediaan.AutoSize = true;
            this.labelMediaan.Location = new System.Drawing.Point(200, 626);
            this.labelMediaan.Name = "labelMediaan";
            this.labelMediaan.Size = new System.Drawing.Size(0, 13);
            this.labelMediaan.TabIndex = 23;
            // 
            // PanelSimulaties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelMediaan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxGrafiek);
            this.Controls.Add(this.textBoxSimulatie);
            this.Controls.Add(this.checkBoxParallel);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownKolommen);
            this.Controls.Add(this.numericUpDownRijen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PanelSimulaties";
            this.Size = new System.Drawing.Size(350, 670);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRijen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafiek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRijen;
        private System.Windows.Forms.NumericUpDown numericUpDownKolommen;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxParallel;
        private System.Windows.Forms.TextBox textBoxSimulatie;
        private System.Windows.Forms.PictureBox pictureBoxGrafiek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMediaan;
    }
}
