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
    public partial class frmRad : Form
    {
        private string putanja1;
        private string putanja2;
        private int provjera = 0;
        private string ime_dat;
        private string spremanje;
        private string direktorij;
        private string provjeraR;
        private string provjera2;
        private string ekstenzija;
        private string korisnik_id;
        private long velicina;
        private DateTime datum;

        public frmRad()
        {
            InitializeComponent();
            if (globalVars.TipRada == 1 || globalVars.TipRada == 3)
            {
                btnEnc.Text = "Enkriptiraj";
                this.Text = "Enkriptiraj";
            }
            if (globalVars.TipRada == 2 || globalVars.TipRada == 4)
            {
                btnEnc.Text = "Dekriptiraj";
                this.Text = "Dekriptiraj";
            }
            btnEnc.Enabled = false;
            this.BackColor = Color.Azure;
           
        }

        private void frmRad_Load(object sender, EventArgs e)
        {
            if (globalVars.TipRada == 3 || globalVars.TipRada == 4)
            {
                direktorij = Directory.GetCurrentDirectory();

                provjeraR = direktorij + @"\repozitorij_r";
                provjera2 = provjeraR.Replace("_r", "");

                korisnik_id = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "korisnik", "id", "idkorisnik", "uvjet", "korisnicko_ime", "vrijednost", globalVars.LoginIme);

                if (!File.Exists(provjeraR))
                {
                    using (StreamWriter sw = File.CreateText(provjera2))
                    {
                        sw.WriteLine("Lokalni repozitorij enkripcija");
                        sw.WriteLine("-------------------------");
                    }

                    string repozitorij = KeyGenerator.GetUniqueKey(15, 1);
                    SharpAESCrypt.SharpAESCrypt.Encrypt(repozitorij, "repozitorij", "repozitorij_r");
                    File.Delete(provjera2);

                    string DataRep = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "korisnik", "id", "repozitorij", "unos", repozitorij, "uvjet", "idkorisnik", "vrijednost", korisnik_id);
                }
            }
        }

        private void btnOdabirDat_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                putanja1 = openFileDialog1.FileName;
                //pbarEnc.PerformStep();
                ime_dat = System.IO.Path.GetFileName(putanja1);
                putanja2 = Directory.GetCurrentDirectory() + @"\" + ime_dat;
                if (globalVars.TipRada == 1) //dodati za tip rada 3
                {
                    if (putanja2 != null) File.Delete(putanja2);
                }
                //pbarEnc.PerformStep();
                if (putanja1 != putanja2) File.Copy(putanja1, putanja2);
                spremanje = System.IO.Path.GetFileName(putanja1);
                provjera = 1;
                //pbarEnc.PerformStep();

                //ispis u listbox listFileData
                FileInfo info = new FileInfo(ime_dat);
                velicina = info.Length;
                datum = File.GetCreationTime(ime_dat);
                ekstenzija = Path.GetExtension(putanja2);
                //pbarEnc.PerformStep();
                listFileData.Items.Add("Ime: " + ime_dat);
                listFileData.Items.Add("Veličina: " + velicina + " bajtova");
                listFileData.Items.Add("Tip: " + ekstenzija);
                listFileData.Items.Add("Datum kreiranja: " + datum);
                btnEnc.Enabled = true;
                //pbarEnc.PerformStep();
            }
        }

        private void btnEnc_Click(object sender, EventArgs e)
        {
            if (provjera == 0)
            {
                MessageBox.Show("Datoteka nije odabrana");
            }
            else
            {
                
                //slozi da odabere file kud da spremi enkriptiranu
                string lozinka;

                if (globalVars.TipRada == 1 || globalVars.TipRada == 2)
                {
                    frmLozinka dialog = new frmLozinka();
                    dialog.ShowDialog(this);

                    if (dialog.PrenesiLozinku == null)
                    {
                        MessageBox.Show("Odustao");
                    }
                    else
                    {
                        lozinka = dialog.PrenesiLozinku;

                        if (globalVars.TipRada == 1)
                        {
                            pbarEnc.PerformStep();
                            spremanje += "_enc";
                            listFileData.Items.Add("Lozinka: " + lozinka);
                            pbarEnc.PerformStep();
                            SharpAESCrypt.SharpAESCrypt.Encrypt(lozinka, ime_dat, spremanje);
                            pbarEnc.PerformStep();
                            listFileData.Items.Add("Enkripcija uspješna");
                            listFileData.Items.Add("Datoteka je spremljena u direktoriju s aplikacijom");
                            pbarEnc.PerformStep();
                            File.Delete(putanja2);
                            pbarEnc.PerformStep();
                        }

                        if (globalVars.TipRada == 2)
                        {
                            pbarEnc.PerformStep();
                            string spremanje2 = ime_dat.Replace("_enc", "");
                            pbarEnc.PerformStep();
                            SharpAESCrypt.SharpAESCrypt.Decrypt(lozinka, ime_dat, spremanje2);
                            pbarEnc.PerformStep();
                            listFileData.Items.Add("Dekripcija uspješna");
                            pbarEnc.PerformStep();
                            listFileData.Items.Add("Datoteka je spremljena u direktoriju s aplikacijom");
                            pbarEnc.PerformStep();
                        }
                    }
                }
                if (globalVars.TipRada == 3 || globalVars.TipRada == 4)
                {

                    string prim_par_a, prim_par_b;

                    if (globalVars.TipRada == 3)
                    {
                        lozinka = KeyGenerator.GetUniqueKey(10, 1);
                        prim_par_a = KeyGenerator.GetUniqueKey(1, 2);
                        pbarEnc.PerformStep();
                        prim_par_b = KeyGenerator.GetUniqueKey(1, 2);

                        spremanje += "_enc";
                        pbarEnc.PerformStep();
                        SharpAESCrypt.SharpAESCrypt.Encrypt(lozinka, ime_dat, spremanje);
                        listFileData.Items.Add("Enkripcija uspješna");
                        pbarEnc.PerformStep();
                        listFileData.Items.Add("Datoteka je spremljena u direktoriju s aplikacijom");
                        File.Delete(putanja2);

                        string dohvat1 = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "enkripcije", "id", "idenkripcije");
                        int temp_dohvat = int.Parse(dohvat1) + 1;
                        string id_enc = temp_dohvat.ToString();
                        string dohvat2 = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "korisnik", "id", "repozitorij", "uvjet", "idkorisnik", "vrijednost", korisnik_id);
                        string repozitorij_temp = dohvat2, repozitorij = "";
                        pbarEnc.PerformStep();
                        foreach (char c in repozitorij_temp.ToCharArray(0, 15))
                        {
                            repozitorij += c;
                        }

                        string DataID = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "idenkripcije", "unos", id_enc);
                        string DataLozinka = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "lozinka", "unos", lozinka, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataA = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "prim_param_a", "unos", prim_par_a, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataB = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "prim_param_b", "unos", prim_par_b, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataNaziv = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "naziv_datoteke", "unos", ime_dat, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataVelicina = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "velicina", "unos", velicina.ToString(), "uvjet", "idenkripcije", "vrijednost", id_enc);

                        string post_datum = datum.Year.ToString() + "-" + datum.Month.ToString() + "-" + datum.Day.ToString() + " " + datum.Hour.ToString() + ":" + datum.Minute.ToString() + ":" + datum.Second.ToString();
                        string DataDatum = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "datum", "unos", post_datum, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataTip = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "tip", "unos", ekstenzija, "uvjet", "idenkripcije", "vrijednost", id_enc);
                        string DataKorisnik = Web.GetPost("http://redtesseract.sexy/redwarden/post_app.php", "tablica", "enkripcije", "id", "korisnik_idkorisnik", "unos", korisnik_id, "uvjet", "idenkripcije", "vrijednost", id_enc);

                        SharpAESCrypt.SharpAESCrypt.Decrypt(repozitorij, "repozitorij_r", "repozitorij");
                        File.Delete(provjeraR);

                        using (StreamWriter sw = File.AppendText(provjera2))
                        {
                            sw.WriteLine("idenkripcije: " + id_enc);
                            sw.WriteLine("naziv_datoteke: " + ime_dat);
                            sw.WriteLine("korisnik_idkorisnik: " + korisnik_id);
                            sw.WriteLine("prim_param_a: " + prim_par_a);
                            sw.WriteLine("prim_param_b: " + prim_par_b);
                            sw.WriteLine("lozinka: " + lozinka);
                            sw.WriteLine("velicina: " + velicina.ToString());
                            sw.WriteLine("datum: " + post_datum);
                            sw.WriteLine("tip: " + ekstenzija);
                            sw.WriteLine("-------------------------");
                        }

                        SharpAESCrypt.SharpAESCrypt.Encrypt(repozitorij, "repozitorij", "repozitorij_r");
                        pbarEnc.PerformStep();
                        File.Delete(provjera2);
                    }

                    if (globalVars.TipRada == 4)
                    {
                        frmLozinka dialog = new frmLozinka();
                        dialog.ShowDialog(this);

                        if (dialog.PrenesiLozinku == null)
                        {
                            MessageBox.Show("Odustao");
                        }
                        else
                        {
                            
                            string dohvat2 = Web.GetPost("http://redtesseract.sexy/redwarden/dohvati_app.php", "tablica", "korisnik", "id", "repozitorij", "uvjet", "idkorisnik", "vrijednost", korisnik_id);
                            string repozitorij_temp = dohvat2, repozitorij = "";
                            pbarEnc.PerformStep();
                            foreach (char c in repozitorij_temp.ToCharArray(0, 15))
                            {
                                repozitorij += c;
                            }
                            pbarEnc.PerformStep();
                            SharpAESCrypt.SharpAESCrypt.Decrypt(repozitorij, "repozitorij_r", "repozitorij");
                            File.Delete(provjeraR);

                            string line, sprem_lozinka = "", sprem_a = "", sprem_b = "";
                            int prebroj = 0, flag = 0;
                            pbarEnc.PerformStep();
                            string ime_replace = ime_dat.Replace("_enc", "");
                            string provjera_imena = "naziv_datoteke: " + ime_replace;
                            using (System.IO.StreamReader file = new System.IO.StreamReader(provjera2))
                            {
                                while ((line = file.ReadLine()) != null)
                                {
                                    if (line.Contains(provjera_imena))
                                    {
                                        flag = 1;
                                    }
                                    if (flag == 1) prebroj++;
                                    if (prebroj == 3)
                                    {
                                        sprem_a = line;
                                        sprem_a = sprem_a.Replace("prim_param_a: ", "");
                                    }
                                    if (prebroj == 4)
                                    {
                                        sprem_b = line;
                                        sprem_b = sprem_b.Replace("prim_param_b: ", "");
                                    }
                                    if (prebroj == 5)
                                    {
                                        sprem_lozinka = line;
                                        sprem_lozinka = sprem_lozinka.Replace("lozinka: ", "");
                                    }
                                }
                            }

                            string lozinka_enc = dialog.PrenesiLozinku;
                            pbarEnc.PerformStep();
                            DateTime datum_cest = DateTime.Now;
                            TimeZoneInfo cestZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                            datum_cest = TimeZoneInfo.ConvertTime(datum_cest, TimeZoneInfo.Local, cestZone);

                            int sat = datum_cest.Hour + 1;
                            int dan = datum_cest.Day;

                            string temp_lozinka = "";

                            foreach (char c in lozinka_enc)
                            {
                                int temp_br, temp_a, temp_b;

                                temp_br = (int)c;

                                temp_a = int.Parse(sprem_a);
                                temp_b = int.Parse(sprem_b);

                                int temp_enc = temp_br - temp_a - temp_b - sat - dan;

                                if (temp_br > 47 && temp_br < 58)
                                {
                                    while (temp_enc < 48) temp_enc += 10;
                                }

                                if (temp_br > 64 && temp_br < 91)
                                {
                                    while (temp_enc < 65) temp_enc += 26;
                                }

                                if (temp_br > 96 && temp_br < 123)
                                {
                                    while (temp_enc < 97) temp_enc += 26;
                                }

                                temp_lozinka += (char)temp_enc;
                            }
                            string reversed_lozinka = "";
                            foreach (char c in temp_lozinka.ToCharArray(0, 10))
                            {
                                reversed_lozinka += c;
                            }

                            if (reversed_lozinka == sprem_lozinka)
                            {
                                string spremanje2 = ime_dat.Replace("_enc", "");
                                SharpAESCrypt.SharpAESCrypt.Decrypt(reversed_lozinka, ime_dat, spremanje2);
                                listFileData.Items.Add("Dekripcija uspješna");
                                listFileData.Items.Add("Datoteka je spremljena u direktoriju s aplikacijom");
                                SharpAESCrypt.SharpAESCrypt.Encrypt(repozitorij, "repozitorij", "repozitorij_r");
                                File.Delete(provjera2);
                            }
                            pbarEnc.PerformStep();
                        }
                    }
                }
            }
        }

        private void frmRad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (putanja2 != null)
            {
                if (globalVars.TipRada == 1) File.Delete(putanja2);
            }
            globalVars.TipRada = 0;
        }
    }
}
