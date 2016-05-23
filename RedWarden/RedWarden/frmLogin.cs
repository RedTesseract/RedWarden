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
    //forma za login

    public partial class frmLogin : Form
    {
        // varijabla u koju će biti spremljena referenca na objekt glavne forme
        private readonly frmMain frmMain;

        /// <summary>   sta znaci ///?
        /// Konstruktor login forme
        /// </summary>
        /// <param name="frmMain">referenca na glavnu formu</param>
        public frmLogin(frmMain frmMain)
        {
            // spremanje proslijeđene reference na glavnu formu u varijablu frmMain (gore navedenu)
            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.redtesseract.sexy/redwarden/registracija.php");
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            //šalje na server uneseno korisničko ime i lozinku. PHP skripta provjerava valjanost
            string Data = Web.GetPost("http://redtesseract.sexy/redwarden/prijava_app.php", "UserName", tbIme.Text, "Password", tbLozinka.Text);
            
            if (Data == "Valja")
            {
                //u slučaju uspješne prijave, loginStatus se postavlja na 1 te se pamti korisničko ime
                MessageBox.Show("Prijava uspješna");
                globalVars.LoginStatus = true;
                globalVars.LoginIme = tbIme.Text;
                frmMain.PostaviKorisnickoIme();
                frmMain.btnEncOn.Enabled = true;
                frmMain.btnDecOn.Enabled = true;
                frmMain.btnGroup.Enabled = true;
                frmMain.btnTrezor.Enabled = true;
                frmMain.btnPrijava.Enabled = false;
                frmMain.btnReg.Enabled = false;
                frmMain.btnOdjavi.Enabled = true;
                this.Close();
                
            }
            else if (Data == "Greska")
            {
                MessageBox.Show("Greška prilikom prijave");
            }
        }
    }
}
