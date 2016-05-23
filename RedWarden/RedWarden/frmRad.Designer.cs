namespace RedWarden
{
    partial class frmRad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRad));
            this.listFileData = new System.Windows.Forms.ListBox();
            this.btnOdabirDat = new System.Windows.Forms.Button();
            this.btnEnc = new System.Windows.Forms.Button();
            this.labelPodaci = new System.Windows.Forms.Label();
            this.pbarEnc = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // listFileData
            // 
            this.listFileData.FormattingEnabled = true;
            this.listFileData.Location = new System.Drawing.Point(15, 55);
            this.listFileData.Name = "listFileData";
            this.listFileData.Size = new System.Drawing.Size(291, 95);
            this.listFileData.TabIndex = 0;
            // 
            // btnOdabirDat
            // 
            this.btnOdabirDat.Location = new System.Drawing.Point(15, 227);
            this.btnOdabirDat.Name = "btnOdabirDat";
            this.btnOdabirDat.Size = new System.Drawing.Size(128, 23);
            this.btnOdabirDat.TabIndex = 1;
            this.btnOdabirDat.Text = "Odaberi datoteku";
            this.btnOdabirDat.UseVisualStyleBackColor = true;
            this.btnOdabirDat.Click += new System.EventHandler(this.btnOdabirDat_Click);
            // 
            // btnEnc
            // 
            this.btnEnc.Location = new System.Drawing.Point(195, 227);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(87, 23);
            this.btnEnc.TabIndex = 2;
            this.btnEnc.Text = "Enkriptiraj";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // labelPodaci
            // 
            this.labelPodaci.AutoSize = true;
            this.labelPodaci.Location = new System.Drawing.Point(12, 18);
            this.labelPodaci.Name = "labelPodaci";
            this.labelPodaci.Size = new System.Drawing.Size(111, 13);
            this.labelPodaci.TabIndex = 4;
            this.labelPodaci.Text = "Podaci o datoteci:";
            // 
            // pbarEnc
            // 
            this.pbarEnc.BackColor = System.Drawing.SystemColors.Control;
            this.pbarEnc.Location = new System.Drawing.Point(15, 176);
            this.pbarEnc.Name = "pbarEnc";
            this.pbarEnc.Size = new System.Drawing.Size(291, 23);
            this.pbarEnc.Step = 20;
            this.pbarEnc.TabIndex = 5;
            // 
            // frmRad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(310, 280);
            this.Controls.Add(this.pbarEnc);
            this.Controls.Add(this.labelPodaci);
            this.Controls.Add(this.btnEnc);
            this.Controls.Add(this.btnOdabirDat);
            this.Controls.Add(this.listFileData);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmRad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enkriptiraj";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRad_FormClosing);
            this.Load += new System.EventHandler(this.frmRad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFileData;
        private System.Windows.Forms.Button btnOdabirDat;
        private System.Windows.Forms.Button btnEnc;
        private System.Windows.Forms.Label labelPodaci;
        private System.Windows.Forms.ProgressBar pbarEnc;
    }
}