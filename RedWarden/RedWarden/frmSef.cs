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
    //forma za trezor
    public partial class frmSef : Form
    {
        //kad se ude, ako je korisnik prijavljen treba promijeniti u gornjem desnom kutu korisnik je prijavljen
        private string direktorij;
        private string provjera;
        private string provjera2;
        private string citaj;
        private int provjera_otvaranja;
        private string lozinka;
        private bool provjeraZatvaranja;

        public frmSef()
        {
            InitializeComponent();

            provjeraZatvaranja = false;
            //dohvaća putanju trenutačnog direktorija aplikacije
            direktorij = Directory.GetCurrentDirectory();
            //provjerava da li postoji već fajl za trezor. Ako ne postoji, kreira novi. Ako postoji, traži lozinku za pristup.
            provjera = direktorij + @"\trezor_r";
            provjera2 = provjera.Replace("_r", "");
            this.BackColor = Color.Azure;
        }

        private void frmSef_Load(object sender, EventArgs e)
        {
            provjera_otvaranja = 0;
            if (File.Exists(provjera))
            {
                
                //poziva formu za lozinku te dekriptira fajl za trezor s tom lozinkom
                frmLozinka dialog = new frmLozinka();
                dialog.ShowDialog(this); 

                if (dialog.PrenesiLozinku == null)
                {
                    MessageBox.Show("Odustao");
                    provjeraZatvaranja = true;
                    this.Close();
                }
                else
                {
                    lozinka = dialog.PrenesiLozinku;
                    SharpAESCrypt.SharpAESCrypt.Decrypt(lozinka, "trezor_r", "trezor.txt"); //dekriptira fajl za trezor te ga sprema kao trezor.txt
                    provjera_otvaranja = 1;
                    File.Delete(provjera); 

                    ProcitajSadrzajDekriptiraneDatoteke();
                }
                //DekriptirajTrezor();
            }
            else //u slučaju da ne postoji fajl za trezor
            {
                using (StreamWriter sw = File.CreateText(provjera2)) //kreira fajl
                {
                    sw.WriteLine("Trezor");
                }
    
                
                //traži lozinku
                frmLozinka dialog = new frmLozinka();
                dialog.ShowDialog(this);

                if (dialog.PrenesiLozinku == null)
                {
                    MessageBox.Show("Odustao");
                    provjeraZatvaranja = true;
                    this.Close();
                }
                else //enkriptira novostvoreni fajl za trezor s unesenom lozinkom, te ga odmah otvara
                {
                    lozinka = dialog.PrenesiLozinku;
                    SharpAESCrypt.SharpAESCrypt.Encrypt(lozinka, "trezor", "trezor_r");
                    File.Delete(provjera2);

                    SharpAESCrypt.SharpAESCrypt.Decrypt(lozinka, "trezor_r", "trezor.txt");
                    provjera_otvaranja = 1;
                    File.Delete(provjera);

                    ProcitajSadrzajDekriptiraneDatoteke();
                }
                 
                //DekriptirajTrezor();
            }
        }

        private void ProcitajSadrzajDekriptiraneDatoteke()
        {
         
              citaj = provjera2 + ".txt";
                using (StreamReader file = new StreamReader(citaj)) // otvara datoteku za citanje (stream)
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        lbLista.Items.Add(line); //dodaje sve zapise iz fajla u listbox
                    }
                }
        }

       /* private void DekriptirajTrezor()
        {
            //poziva formu za lozinku te dekriptira fajl za trezor s tom lozinkom
            frmLozinka dialog = new frmLozinka();
            dialog.ShowDialog(this); //zast se proslijedei formi ova forma?

            if (dialog.PrenesiLozinku == null)
            {
                MessageBox.Show("Odustao");
                provjeraZatvaranja = true;
                this.Close();
            }
            else
            {
                lozinka = dialog.PrenesiLozinku;
                SharpAESCrypt.SharpAESCrypt.Decrypt(lozinka, "trezor_r", "trezor.txt"); //dekriptira fajl za trezor te ga sprema kao trezor.txt
                File.Delete(provjera); //briše enkriptirani fajl za trezor (trezor_r) //why?

                ProcitajSadrzajDekriptiraneDatoteke();
            }
        }*/

        private void frmSef_FormClosing(object sender, FormClosingEventArgs e) //enkriptira otvoreni fajl za trezor prilikom zatvaranja ove forme
        {
            if (!provjeraZatvaranja) //provjera u slučaju da je korisnik odustao od unosa lozinke, inače se pobaga program
            {
                SharpAESCrypt.SharpAESCrypt.Encrypt(lozinka, "trezor.txt", "trezor_r");
                if(provjera_otvaranja == 1) File.Delete(citaj); //briše dekriptirani fajl za trezor kako se ne bi moglo pristupiti, ostaje samo enkriptirani
                if (provjera_otvaranja == 0)
                {
                    File.Delete(provjera);
                    File.Delete(provjera2+".txt");
                    MessageBox.Show("Došlo je do korupcije podataka. Vaš trezor je obrisan.");
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //dodavanje novog zapisa, dodaje ga u listbox i fajl za trezor
            if (provjera_otvaranja == 0) this.Close();

            string naziv = tbNaziv.Text;
            string lozinka = tbLozinka.Text;
            string opis = tbOpis.Text;
            string upis = naziv + " | " + lozinka + " | " + opis;

            lbLista.Items.Add(upis);


            if (provjera_otvaranja == 1)
            {
                using (StreamWriter sw = File.AppendText(citaj))  //javlja gresku kad se upisuje lozinka
                {
                    sw.WriteLine(upis);
                }
            }
        }
    }
}
