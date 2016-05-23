namespace RedWarden
{
    partial class frmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.lbGroup = new System.Windows.Forms.ListBox();
            this.cbOdabir = new System.Windows.Forms.ComboBox();
            this.lblGPOdabir = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbGroup
            // 
            this.lbGroup.FormattingEnabled = true;
            this.lbGroup.Location = new System.Drawing.Point(14, 36);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.ScrollAlwaysVisible = true;
            this.lbGroup.Size = new System.Drawing.Size(303, 134);
            this.lbGroup.TabIndex = 0;
            this.lbGroup.SelectedIndexChanged += new System.EventHandler(this.lbGroup_SelectedIndexChanged);
            // 
            // cbOdabir
            // 
            this.cbOdabir.FormattingEnabled = true;
            this.cbOdabir.Location = new System.Drawing.Point(14, 207);
            this.cbOdabir.Name = "cbOdabir";
            this.cbOdabir.Size = new System.Drawing.Size(140, 21);
            this.cbOdabir.TabIndex = 1;
            this.cbOdabir.SelectedIndexChanged += new System.EventHandler(this.cbOdabir_SelectedIndexChanged);
            // 
            // lblGPOdabir
            // 
            this.lblGPOdabir.AutoSize = true;
            this.lblGPOdabir.Location = new System.Drawing.Point(15, 188);
            this.lblGPOdabir.Name = "lblGPOdabir";
            this.lblGPOdabir.Size = new System.Drawing.Size(148, 13);
            this.lblGPOdabir.TabIndex = 2;
            this.lblGPOdabir.Text = "Odaberite grupni projekt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datoteke grupnog projekta:";
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Location = new System.Drawing.Point(201, 205);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(87, 23);
            this.btnUcitaj.TabIndex = 4;
            this.btnUcitaj.Text = "Učitaj";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(331, 262);
            this.Controls.Add(this.btnUcitaj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGPOdabir);
            this.Controls.Add(this.cbOdabir);
            this.Controls.Add(this.lbGroup);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGroup";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGroup;
        private System.Windows.Forms.ComboBox cbOdabir;
        private System.Windows.Forms.Label lblGPOdabir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUcitaj;
    }
}