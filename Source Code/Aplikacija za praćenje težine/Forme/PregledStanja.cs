using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBConnection;

namespace AplikacijaZaPracenjeTezine
{
    public partial class PregledStanja : Form
    {
        private List<Jelo> jela;
        private List<DBConnection.DnevnikPica> dnevniciPica;
        private List<Trening> treninzi;
        private int idPrijava, idKorisnik;

        public PregledStanja()
        {
            InitializeComponent();
            jela = new List<Jelo>();
            dnevniciPica = new List<DBConnection.DnevnikPica>();
            treninzi = new List<Trening>();
            
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                idPrijava = 1;
                idKorisnik = dao.VratiIDKorisnik(idPrijava);
            }
            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message);
            }
        }

        private void PregledStanja_Load(object sender, EventArgs e)
        {
            try
            {
          
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
            
                Jelo jelo = dao.PretraziJela(dao.VratiJeloPoDatumu(Convert.ToDateTime(datum.Value)).NazivJela);
                double ukupanUnosKalorijaNamirnica = jelo.GetKalorijePoJelu();
                double ukupanUnosKalorijaPice = dao.UkupanUnosKalorijaPice(Convert.ToDateTime(datum.Value));
                //Trening trening = dao.PretraziTreninge(dao.VratiTreningPoDatumu(Convert.ToDateTime(datum.Value)).NazivTreninga);
                //double ukupanUtrosakKalorija = trening.GetUtrošakKaorijaPoTreningu();
                double TDEE = dao.VratiTDEE(idKorisnik);
                //double deficit = TDEE - ukupanUnosKalorijaNamirnica + ukupanUnosKalorijaPice - ukupanUtrosakKalorija;

                ListViewItem temp = new ListViewItem();
                temp = listView1.Items.Add(Convert.ToString(TDEE));
                temp.SubItems.Add(Convert.ToString(ukupanUnosKalorijaNamirnica + ukupanUnosKalorijaPice));
                //temp.SubItems.Add(Convert.ToString(ukupanUtrosakKalorija));
                //temp.SubItems.Add(Convert.ToString(deficit));

                
            }

            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
