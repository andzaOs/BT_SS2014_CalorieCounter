using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AplikacijaZaPracenjeTezine
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void dnevnikAktivnostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DnevnikPica d = new DnevnikPica();
            d.Show();

        }

        private void dnevnikIshraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DnevnikIshrane d = new DnevnikIshrane();
            d.Show();
            
        }

        private void težinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DnevnikAktivnosti d = new DnevnikAktivnosti();
            d.Show();
        }

        private void grafPraćenjaTežineToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Graf g = new Graf();
            g.Show();
        }

        private void izvještajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graf g = new Graf();
            g.Show();
        }


        private void korisničkiPodaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KorisnickiPodaci k = new KorisnickiPodaci();
            k.Show();
        }

        private void proliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfilKorisnika p = new ProfilKorisnika();
            p.Show();
        }

        private void evidentirajTežinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DnevnikTezine t = new DnevnikTezine();
            t.Show();
        }

        private void oNamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void promijeniŠifruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplikacijaZaPracenjeTezine.Forme.IzmjenaSifre i = new AplikacijaZaPracenjeTezine.Forme.IzmjenaSifre();
            i.Show();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void korisničkoUpustvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\AnelaO\Dropbox\Public\Aplikacija za praćenje težine\Aplikacija za praćenje težine\Resources\KorisnickoUpustvo.pdf");
        }
        

    }
}
