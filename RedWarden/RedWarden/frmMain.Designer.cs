namespace RedWarden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnPrijava = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnTrezor = new System.Windows.Forms.Button();
            this.btnEnc = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.gbOff = new System.Windows.Forms.GroupBox();
            this.gbOn = new System.Windows.Forms.GroupBox();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnEncOn = new System.Windows.Forms.Button();
            this.btnDecOn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOdjavi = new System.Windows.Forms.Button();
            this.gbOff.SuspendLayout();
            this.gbOn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrijava
            // 
            resources.ApplyResources(this.btnPrijava, "btnPrijava");
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // btnReg
            // 
            resources.ApplyResources(this.btnReg, "btnReg");
            this.btnReg.Name = "btnReg";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnTrezor
            // 
            resources.ApplyResources(this.btnTrezor, "btnTrezor");
            this.btnTrezor.Name = "btnTrezor";
            this.btnTrezor.UseVisualStyleBackColor = true;
            this.btnTrezor.Click += new System.EventHandler(this.btnTrezor_Click);
            // 
            // btnEnc
            // 
            resources.ApplyResources(this.btnEnc, "btnEnc");
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // btnDec
            // 
            this.btnDec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnDec, "btnDec");
            this.btnDec.Name = "btnDec";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // lblIme
            // 
            resources.ApplyResources(this.lblIme, "lblIme");
            this.lblIme.Name = "lblIme";
            // 
            // lblKorisnik
            // 
            resources.ApplyResources(this.lblKorisnik, "lblKorisnik");
            this.lblKorisnik.Name = "lblKorisnik";
            // 
            // gbOff
            // 
            this.gbOff.Controls.Add(this.btnEnc);
            this.gbOff.Controls.Add(this.btnDec);
            resources.ApplyResources(this.gbOff, "gbOff");
            this.gbOff.Name = "gbOff";
            this.gbOff.TabStop = false;
            // 
            // gbOn
            // 
            this.gbOn.Controls.Add(this.btnGroup);
            this.gbOn.Controls.Add(this.btnEncOn);
            this.gbOn.Controls.Add(this.btnDecOn);
            resources.ApplyResources(this.gbOn, "gbOn");
            this.gbOn.Name = "gbOn";
            this.gbOn.TabStop = false;
            // 
            // btnGroup
            // 
            resources.ApplyResources(this.btnGroup, "btnGroup");
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnEncOn
            // 
            resources.ApplyResources(this.btnEncOn, "btnEncOn");
            this.btnEncOn.Name = "btnEncOn";
            this.btnEncOn.UseVisualStyleBackColor = true;
            this.btnEncOn.Click += new System.EventHandler(this.btnEncOn_Click);
            // 
            // btnDecOn
            // 
            resources.ApplyResources(this.btnDecOn, "btnDecOn");
            this.btnDecOn.Name = "btnDecOn";
            this.btnDecOn.UseVisualStyleBackColor = true;
            this.btnDecOn.Click += new System.EventHandler(this.btnDecOn_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnOdjavi
            // 
            resources.ApplyResources(this.btnOdjavi, "btnOdjavi");
            this.btnOdjavi.Name = "btnOdjavi";
            this.btnOdjavi.UseVisualStyleBackColor = true;
            this.btnOdjavi.Click += new System.EventHandler(this.btnOdjavi_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.btnOdjavi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbOn);
            this.Controls.Add(this.gbOff);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.btnTrezor);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnPrijava);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.gbOff.ResumeLayout(false);
            this.gbOn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnc;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.GroupBox gbOff;
        private System.Windows.Forms.GroupBox gbOn;
        public System.Windows.Forms.Button btnEncOn;
        public System.Windows.Forms.Button btnTrezor;
        public System.Windows.Forms.Button btnDecOn;
        public System.Windows.Forms.Button btnGroup;
        public System.Windows.Forms.Button btnPrijava;
        public System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnOdjavi;
    }
}

