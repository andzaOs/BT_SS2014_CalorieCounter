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
    public partial class DnevnikAktivnosti : Form
    {
        private List<Aktivnost> aktivnosti;
        private Trening trening;
        private List<int> minutazaAktivnosti;
        private List<Aktivnost> aktivnostiUTreningu;
        private int idPrijava, idKorisnik;

        public DnevnikAktivnosti()
        {
            InitializeComponent();
            aktivnosti = new List<Aktivnost>();
            trening = new Trening();
            minutazaAktivnosti = new List<int>();
            aktivnostiUTreningu = new List<Aktivnost>();
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

        private void izadji_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pretraziAktivnosti_Click(object sender, EventArgs e)
        {
            try
            {
                listViewAktivnosti.Items.Clear();
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

                // Prvo provjerimo da li je korisnik unio naziv aktivnosti

                if (nazivPostojeceAktivnosti.Text.Length < 1)
                {
                    toolStripStatusLabel1.Text = "Unesite naziv aktivnosti";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                
                // Zatim na osnovu unesenog naziva pretražujemo bazu 

                else 
                {
                    ListViewItem temp = new ListViewItem();

                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    aktivnosti = dao.PretraziAktivnosti(nazivPostojeceAktivnosti.Text);

                // Ukoliko aktivnost nije pronađena obavještamo korisnika o istom

                    if (aktivnosti.Capacity == 0)
                    {
                        toolStripStatusLabel1.Text = "Aktivnost nije pronađena";
                        toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        // Ispisujemo pronađeni rezultat u listi aktivnosti

                        foreach (Aktivnost a in aktivnosti)
                        {
                            temp = listViewAktivnosti.Items.Add(a.Naziv);
                            temp.SubItems.Add(a.UtrosakKalorija.ToString());
                        }
                    }
                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void pretraziTreninge_Click(object sender, EventArgs e)
        {
            try
            {
                listViewAktivnostiUTreningu.Items.Clear();
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

                // Prvo provjerimo da li je korisnik unio naziv treninga

                if (nazivPostojecegTreninga.Text.Length < 1)
                {
                    toolStripStatusLabel1.Text = "Unesite naziv treninga";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

                // Zatim na osnovu unesenog naziva pretražujemo bazu 

                else if (nazivPostojecegTreninga.Text.Length < 50)
                {
                    ListViewItem temp = new ListViewItem();

                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    trening = dao.PretraziTreninge(nazivPostojecegTreninga.Text);

                    // Ukoliko trening nije pronađen obavještamo korisnika o istom

                    if (trening.MinutazaAktivnosti.Count == 0)
                    {
                        toolStripStatusLabel1.Text = "Trening nije pronađen";
                        toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    }

                    // Ispisujemo pronađeni rezultat u listi 
                    int i = 0;
                    foreach(Aktivnost a in trening.Aktivnosti)
                    {
                        
                        temp = listViewAktivnostiUTreningu.Items.Add(dao.VratiNazivAktivnosti(dao.VratiAktivnostID(a.Naziv)));
                        temp.SubItems.Add(trening.MinutazaAktivnosti[i].ToString());
                        i++;
                    }

                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void dodajPostojeciTrening_Click(object sender, EventArgs e)
        {
            try
            {
                listViewAktivnostiUTreningu.Items.Clear();
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                DBConnection.DnevnikAktivnosti dnevnikAktivnosti = new DBConnection.DnevnikAktivnosti(Convert.ToDateTime(datum.Value), trening);
                
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void dodajPostojecuAktivnost_Click(object sender, EventArgs e)
        {
            try
            {
                if (minutazaPostojeceAktivnosti.Value < 1)
                {
                    toolStripStatusLabel1.Text = "Morate unijenti minutazu aktivnosti.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    int idAktivnosti;
                    for (int i = 0; i < listViewAktivnosti.Items.Count; i++)
                    {
                        if (listViewAktivnosti.Items[i].Selected == true)
                        {
                            DAO dao = new DAO("localhost", "zavrsnirad", "root", "");

                            foreach (Aktivnost a in aktivnosti)
                            {
                                if (a.Naziv == listViewAktivnosti.Items[i].Text)
                                {
                                    idAktivnosti = dao.VratiAktivnostID(aktivnosti[i].Naziv);
                                    Aktivnost aktivnost = new Aktivnost();
                                    aktivnost = dao.PretraziAktivnostiPoID(idAktivnosti);
                                    List<int> minutazaAktivnosti = new List<int>();
                                    minutazaAktivnosti.Add(Convert.ToInt16(minutazaPostojeceAktivnosti.Value));
                                    Trening t = dao.PretraziTreninge(aktivnost.Naziv);
                                    t.MinutazaAktivnosti = minutazaAktivnosti;
                                    DBConnection.DnevnikAktivnosti dnevnikAktivnosti = new DBConnection.DnevnikAktivnosti(Convert.ToDateTime(datum.Value), trening);
                                    dao.DodajDnevnikAktivnosti(dnevnikAktivnosti, idKorisnik);
                                }
                            }
                        }
                    }
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Aktivnost je dodana";
                }
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PregledStanja p = new PregledStanja();
            p.Show();
        }

        private void tabControlTrening_Selected(object sender, TabControlEventArgs e)
        {
            nazivAktivnostiUTreningu.AutoCompleteMode = AutoCompleteMode.Suggest;
            nazivAktivnostiUTreningu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                List<Aktivnost> aktivnostiUTreningu = dao.VratiSveAktivnosti();
                foreach (Aktivnost a in aktivnostiUTreningu) col.Add(a.Naziv);
                nazivAktivnostiUTreningu.AutoCompleteCustomSource = col;
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void dodajNovuAktivnost_Click(object sender, EventArgs e)
        {
            try
            {
                if (nazivNoveAktivnosti.Text.Length < 1 || utrosakKalorijaPoMin.Value < 1 || minutazaNoveAktivnosti.Value < 1)
                {
                    toolStripStatusLabel1.Text = "Popunite sva polja.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else if (nazivNoveAktivnosti.Text.Length < 50 && utrosakKalorijaPoMin.Value > 1 && minutazaNoveAktivnosti.Value > 1)
                {
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    Aktivnost aktivnost = new Aktivnost(nazivNoveAktivnosti.Text, Convert.ToInt16(utrosakKalorijaPoMin.Value));
                    dao.DodajAktivnost(aktivnost);
                    List<Aktivnost> aktivnosti = new List<Aktivnost>();
                    aktivnosti.Add(aktivnost);
                    List<int> minutazaAktivnosti = new List<int>();
                    minutazaAktivnosti.Add(Convert.ToInt16(minutazaNoveAktivnosti.Value));
                    Trening trening = new Trening(aktivnost.Naziv, minutazaAktivnosti, aktivnosti);
                    trening.Id = dao.DodajTrening(trening);
                    DBConnection.DnevnikAktivnosti dnevnikAktivnosti = new DBConnection.DnevnikAktivnosti(Convert.ToDateTime(datum.Value), trening);
                    dao.DodajDnevnikAktivnosti(dnevnikAktivnosti, 1);

                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Aktivnost je dodana";
                }
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void dodajAktivnostUTrening_Click(object sender, EventArgs e)
        {
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                minutazaAktivnosti.Add(Convert.ToInt16(minutazaAtivnostiZaTrening.Value));
                int idAktivnosti = dao.VratiAktivnostID(nazivAktivnostiUTreningu.Text);
                Aktivnost aktivnost = new Aktivnost();
                aktivnost = dao.PretraziAktivnostiPoID(idAktivnosti);
                aktivnostiUTreningu.Add(aktivnost);
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "Aktivnost je dodana";
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void spremiTrening_Click(object sender, EventArgs e)
        {
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                Trening trening = new Trening(nazivNovogTreninga.Text, minutazaAktivnosti, aktivnostiUTreningu);
                trening.Id = dao.DodajTrening(trening);
                DBConnection.DnevnikAktivnosti dnevnikAktivnosti = new DBConnection.DnevnikAktivnosti(Convert.ToDateTime(datum.Value), trening);
                dao.DodajDnevnikAktivnosti(dnevnikAktivnosti, idKorisnik);
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "Trening je dodan";
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void tabControlAktivnost_SelectedIndexChanged(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

            if (tabControlAktivnost.SelectedIndex == 0)
            {
                nazivPostojeceAktivnosti.Text = "";
                listViewAktivnosti.Items.Clear();
                minutazaPostojeceAktivnosti.Value = 0;
            }
            else
            {
                nazivNoveAktivnosti.Text = "";
                utrosakKalorijaPoMin.Value = 0;
                minutazaNoveAktivnosti.Value = 0;
            }
        }

        private void tabControlTrening_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

            if (tabControlTrening.SelectedIndex == 0)
            {
                nazivPostojecegTreninga.Text = "";
                listViewAktivnostiUTreningu.Items.Clear();
            }
            else
            {
                nazivNovogTreninga.Text = "";
                nazivAktivnostiUTreningu.Text = "";
                minutazaAtivnostiZaTrening.Value = 0;
            }

        }
        }
    }

