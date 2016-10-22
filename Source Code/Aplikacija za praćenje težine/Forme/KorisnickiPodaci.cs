using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using DBConnection;
using System.Collections;
using System.Drawing.Text;



namespace AplikacijaZaPracenjeTezine
{
    public partial class KorisnickiPodaci : Form
    {
        Korisnik k;
        bool tezinaPromjenjena;

        public KorisnickiPodaci()
        {
            InitializeComponent();
            tezinaPromjenjena = false;
        }


        private void dodaj_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrijava = 1;
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                string spol, aktivnost, cilj;
                if (spolZensko.Checked) spol = "žensko";
                else spol = "muško";
                if (umjerenaAktivnost.Checked) aktivnost = "umjerena";
                else if (teskaAktivnost.Checked) aktivnost = "teška";
                else if (laganaAktivnost.Checked) aktivnost = "lagana";
                else aktivnost = "izuzetno teška";
                if (ciljOdrzati.Checked) cilj = "održati";
                else if (ciljSmrsati.Checked) cilj = "smršati";
                else cilj = "udebljati se";

                DBConnection.Prijava p = new DBConnection.Prijava(dao.VratiKorisnickoIme(idPrijava), dao.VratiLozinku(idPrijava));
                k = new Korisnik(ime.Text, prezime.Text, Convert.ToDateTime(datumRodjenja.Text), spol, Convert.ToDouble(visina.Value), Convert.ToDouble(tezina.Value), aktivnost, cilj, Convert.ToDouble(zeljenaTezina.Value), Convert.ToDateTime(datumOstvarenjaCilja.Text));
                k.Prijava = p;
                dao.AzurirajKorisnika(k);
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "Korisnik je ažuriran";

                if (dao.VratiRedoveDnevnikTezina() == 0 || tezinaPromjenjena == true)
                {
                    DateTime now = DateTime.Now;
                    double tezina1, visina1;
                    tezina1 = Convert.ToDouble(tezina.Value);
                    visina1 = Convert.ToDouble(visina.Value);

                    DBConnection.DnevnikTezine d = new DBConnection.DnevnikTezine();

                    d.SetBmi(visina1, tezina1);
                    d.SetBmr(spol, tezina1, visina1, k.GetStarost(now));
                    d.SetTdee(aktivnost);
                    double potrebnaKolicinaTecnosti = Convert.ToDouble(string.Format("{0:F2}", (tezina1 / 2) * 0.03));
                    d.PotrebnaKolicinaTecnosti = potrebnaKolicinaTecnosti;

                    dao.DodajDnevnikTezine(d, dao.VratiIDKorisnik(idPrijava));
                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void KorisnickiPodaci_Load(object sender, EventArgs e)
        {
            try
            {
                int idPrijava = 1;
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                ime.Text = dao.VratiIme(idPrijava);
                prezime.Text = dao.VratiPrezime(idPrijava);
                datumRodjenja.Value = Convert.ToDateTime(dao.VratiDatumRodjenja(idPrijava));
                if (dao.VratiSpol(idPrijava) == "žensko") spolZensko.Checked = true;
                else spolMusko.Checked = true;
                visina.Value = Convert.ToDecimal(dao.VratiVisinu(idPrijava));
                tezina.Value = Convert.ToDecimal(dao.VratiPocetnuTezinu(idPrijava));
                if (dao.VratiAktivnost(idPrijava) == "umjerena") umjerenaAktivnost.Checked = true;
                else if (dao.VratiAktivnost(idPrijava) == "lagana") laganaAktivnost.Checked = true;
                else if (dao.VratiAktivnost(idPrijava) == "teška") teskaAktivnost.Checked = true;
                else izuzetnoTeskaAktivnost.Checked = true;
                if (dao.VratiCilj(idPrijava) == "smršati") ciljSmrsati.Checked = true;
                else if (dao.VratiCilj(idPrijava) == "održati") ciljOdrzati.Checked = true;
                else ciljUdebljatiSe.Checked = true;
                zeljenaTezina.Value = Convert.ToDecimal(dao.VratiZeljenuTezinu(idPrijava));
                datumOstvarenjaCilja.Value = Convert.ToDateTime(dao.VratiDatumOstvarenjaCilja(idPrijava));
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void izadji_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tezina_ValueChanged(object sender, EventArgs e)
        {
            tezinaPromjenjena = true;
        }


    }
}
