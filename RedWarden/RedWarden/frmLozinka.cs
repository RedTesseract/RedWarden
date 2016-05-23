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
    //forma koja se koristi za unos lozinki, iskorištena na više mjesta (rad, sef, itd.)
    //unesena lozinka u ovoj formi se prenosi u formu iz koje je ova forma pozvana

    public partial class frmLozinka : Form
    {
        public frmLozinka() 
        {
            InitializeComponent();
        }

        public string PrenesiLozinku;

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            PrenesiLozinku = tbLozinka.Text; //prenosi unesenu lozinku
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PrenesiLozinku = null; //odustaje od unosa lozinke
            this.Close();
        }
    }
}
