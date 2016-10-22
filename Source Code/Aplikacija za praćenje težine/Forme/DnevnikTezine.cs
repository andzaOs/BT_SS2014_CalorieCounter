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
    public partial class DnevnikTezine : Form
    {
        public DnevnikTezine()
        {
            InitializeComponent();
        }

       

        private void spremi_Click(object sender, EventArgs e)
        {
            try
            {

                int idPrijava = 1, idDnevnikTezine;

                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");

                Korisnik k = new Korisnik();
                k.Id = dao.VratiIDKorisnik(idPrijava);
                idDnevnikTezine = dao.VratiRedoveDnevnikTezina();
                k.Visina = dao.VratiVisinu(idPrijava);
                k.PocetnaTezina = Convert.ToDouble(trenutnaTezina.Value);
                k.NivoAktivnosti = dao.VratiAktivnost(idPrijava);
                k.Spol = dao.VratiSpol(idPrijava);
                k.Starost = (Convert.ToDateTime(datum.Value) - Convert.ToDateTime(dao.VratiDatumRodjenja(idPrijava))).Days / 365;

                DBConnection.DnevnikTezine d = new DBConnection.DnevnikTezine();
                
                d.Datum = Convert.ToDateTime(datum.Value);
                d.TrenutnaTezina = k.PocetnaTezina;
                d.Ruke = Convert.ToDouble(ruke.Value);
                d.Prsa = Convert.ToDouble(prsa.Value);
                d.Butine = Convert.ToDouble(butine.Value);
                d.Listovi = Convert.ToDouble(listovi.Value);
                d.Pozadina = Convert.ToDouble(pozadina.Value);
                d.Stomak = Convert.ToDouble(stomak.Value);
                d.SetBmi(k.Visina, k.PocetnaTezina);
                d.SetBmr(k.Spol, k.PocetnaTezina, k.Visina, k.Starost);
                d.SetTdee(k.NivoAktivnosti);
                d.SetPotrebnaKolicinaTecnosti(k.PocetnaTezina);
                dao.DodajDnevnikTezine(d, k.Id);

                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "Promjene su uspješno sačuvane.";
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void izadji_Click_1(object sender, EventArgs e)
        {
            Close();
        }


    }
}
