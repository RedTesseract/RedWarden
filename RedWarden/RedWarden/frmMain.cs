using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedWarden
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
            globalVars.LoginStatus = false;  
            globalVars.LoginIme = "nije prijavljen";
            lblIme.Text = globalVars.LoginIme; //postavljanje korisničkog imena nakon logina u gornji desni ugao
            btnEncOn.Enabled = false;
            btnDecOn.Enabled = false;
            btnGroup.Enabled = false;
            this.BackColor = Color.Azure;
            btnOdjavi.Enabled = false;
        }

        //otvaranje forme za login
        private void btnPrijava_Click(object sender, EventArgs e)
        {
                frmLogin login = new frmLogin(this);
                login.MdiParent = this;
                login.Show();
                login.Location = new Point(375, 50);
                login.Size = new Size(350, 380);
           
           
        }

        //otvaranje stranice za registraciju u web browseru
        private void btnReg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.redtesseract.sexy/redwarden/registracija.php");
        }

        //otvaranje trezora
        private void btnTrezor_Click(object sender, EventArgs e)
        {
            frmSef sef = new frmSef();
            sef.MdiParent = this;
            sef.Show();
            sef.Location = new Point(360, 50);
            sef.Size = new Size(380, 380);
        }

        //oflajn enkripcija
        private void btnEnc_Click(object sender, EventArgs e)
        {
            globalVars.TipRada = 1; //oflajn enkripcija
            OtvoriRad();
        }

        //oflajn dekripcija
        private void btnDec_Click(object sender, EventArgs e)
        {
            globalVars.TipRada = 2; //oflajn dekripcija
            OtvoriRad();
        }

        //onlajn enkripcija
        private void btnEncOn_Click(object sender, EventArgs e)
        {
            if (globalVars.LoginStatus)
            {
                globalVars.TipRada = 3; //onlajn enkripcija
                OtvoriRad();
            }
            else
            {
                MessageBox.Show("Morate se prijaviti kako biste koristili Online enkripciju");
            }
        }

        //oflajn dekripcija
        private void btnDecOn_Click(object sender, EventArgs e)
        {
            if (globalVars.LoginStatus)
            {
                globalVars.TipRada = 4; //oflajn dekripcija
                OtvoriRad();
            }
            else
            {
                MessageBox.Show("Morate se prijaviti kako biste koristili Online dekripciju");
            }
        }

        //pristup grupnim datotekama/projektima
        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (globalVars.LoginStatus)
            {
                frmGroup grupa = new frmGroup();
                grupa.MdiParent = this;
                grupa.Show();
                grupa.Location = new Point(370, 60);
                grupa.Size = new Size(370, 350);
            }
            else
            {
                MessageBox.Show("Morate se prijaviti kako biste pristupili Grupnim projektima");
            }
        }

        public void PostaviKorisnickoIme()
        {
            lblIme.Text = globalVars.LoginIme;
        }

        private void btnOdjavi_Click(object sender, EventArgs e)
        {
            globalVars.LoginStatus = false;
            globalVars.LoginIme = null;
            lblIme.Text = "Nije prijavljen";
            btnPrijava.Enabled = true;
            btnEncOn.Enabled = false;
            btnDecOn.Enabled = false;
            btnGroup.Enabled = false;
            btnReg.Enabled = true;
            btnOdjavi.Enabled = false;
        }
        private void OtvoriRad()
        {
            frmRad rad = new frmRad();
            rad.MdiParent = this;
            rad.Show();
            rad.Location = new Point(380, 60);
            rad.Size = new Size(350, 350);
            rad.Show();
        }
    }
}
