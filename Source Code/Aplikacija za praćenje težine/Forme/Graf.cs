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
    public partial class Graf : Form
    {
        private List<DBConnection.DnevnikTezine> dnevniciTezine;
        
        private int idPrijava, idKorisnik;

        public Graf()
        {
            InitializeComponent();
            dnevniciTezine = new List<DBConnection.DnevnikTezine>();
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                idPrijava = 1;
                idKorisnik = dao.VratiIDKorisnik(idPrijava);
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void Izvjestaji_Load(object sender, EventArgs e)
        {
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                dnevniciTezine = dao.PretraziDnevnikeTezine();
             
                foreach (DBConnection.DnevnikTezine d in dnevniciTezine)
                {
                     this.chart1.Series["Težina"].Points.AddXY(d.Datum, d.TrenutnaTezina);
                }

            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}
