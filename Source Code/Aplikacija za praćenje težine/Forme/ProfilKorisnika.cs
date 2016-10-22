using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnection;

namespace AplikacijaZaPracenjeTezine
{
    public partial class ProfilKorisnika : Form
    {
        public ProfilKorisnika()
        {
            InitializeComponent();
        }

        private void ProfilKorisnika_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "";
                int idPrijava = 1;
                DAO dao = new DAO("localhost", "zavrsnirad", "root", " ");
                int idKorisnik = dao.VratiIDKorisnik(idPrijava);
                label1.Text = Convert.ToString(dao.VratiBMI(idKorisnik));
                label2.Text = Convert.ToString(dao.VratiBMR(idKorisnik));
                label3.Text = Convert.ToString(dao.VratiTDEE(idKorisnik));
                label4.Text = Convert.ToString(dao.VratiPotrebnaKolicinaTecnosti(idKorisnik)) + " litara";
                label5.Text = Convert.ToString(dao.VratiZeljenuTezinu(idPrijava) + " kilograma");
                label6.Text = dao.VratiDatumOstvarenjaCilja(idPrijava);
                label7.Text = Convert.ToString(dao.VratiTrenutnuTezinu(idPrijava) + " kilograma");
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

      
    }
}
