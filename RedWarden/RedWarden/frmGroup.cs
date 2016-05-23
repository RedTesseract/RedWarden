using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RedWarden
{
    public partial class frmGroup : Form
    {
        public frmGroup()
        {
            InitializeComponent();
            this.BackColor = Color.Azure;
        }

        private string korisnik_id;

        //odmah nakon pristupa ovoj formi dohvaćaju se sve grupne datoteke od korisnika

        private void frmGroup_Load(object sender, EventArgs e)
        {
            //dohvaća korisnikov id sa servera preko korisničkog imena spremljenog u aplikaciji nakon logina
            string dohvatiKorisnika = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "korisnik", "id", "idkorisnik", "uvjet", "korisnicko_ime", "vrijednost", globalVars.LoginIme);
            korisnik_id = dohvatiKorisnika;

            //prebrojava korisnikove grupne datoteke i dohvaća njihove id-eve
            string countProjekata = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_group.php", "tablica", "pripadnici_projekta", "id", "count(grupni_projekti_idgrupni_projekti)", "uvjet", "korisnik_idkorisnik", "vrijednost", korisnik_id);

            char prebroj = countProjekata[0];
            int counter = prebroj - '0';
            countProjekata = countProjekata.Remove(0, 2);

            char[] delimiterChars = { ' ', '\t' };
            string[] idevi = countProjekata.Split(delimiterChars);

            foreach (string s in idevi)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    //dohvaća podatke o grupnim datotekama sa servera preko id-eva i stavlja ih u combobox
                    string dohvatiNaziv = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "grupni_projekti", "id", "grupni_projektiNaziv", "uvjet", "idgrupni_projekti", "vrijednost", s);
                    cbOdabir.Items.Add(dohvatiNaziv);
                }
            }
        }

        private void lbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbOdabir_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            //odabrani projekt u comboboxu stavlja u listbox
            string temp = cbOdabir.SelectedItem.ToString();

            lbGroup.Items.Add("Naziv: " + temp);
            lbGroup.Items.Add("Datum: " + temp);
            lbGroup.Items.Add("Veličina: " + temp);
            lbGroup.Items.Add("Tip: " + temp);
            lbGroup.Items.Add("------------------");
        }
    }
}
