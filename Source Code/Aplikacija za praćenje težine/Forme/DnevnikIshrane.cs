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
    public partial class DnevnikIshrane : Form
    {
        private List<Namirnica> namirnice;
        private List<Namirnica> sastojciJela;
        private List<double> kolicineSastojaka;
        private Jelo jelo;
        private int idPrijava, idKorisnik;

        public DnevnikIshrane()
        {
            InitializeComponent();
            namirnice = new List<Namirnica>();
            sastojciJela = new List<Namirnica>();
            kolicineSastojaka = new List<double>();
            jelo = new Jelo();
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


        private void dodajNovuNamirnicu_Click(object sender, EventArgs e)
        {
            try
            {
                if (unosNazivNamirnice.Text.Length < 1 || kalorije.Value<1 || kolicinaNoveNamirnice.Value<1)
                {
                    toolStripStatusLabel1.Text = "Niste unijeli obavezna polja.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

                else if (unosNazivNamirnice.Text.Length < 100 && kalorije.Value>0 && kolicinaNoveNamirnice.Value>0)
                {
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");

                    Namirnica n = new Namirnica(unosNazivNamirnice.Text, Convert.ToInt32(kalorije.Value), Convert.ToDouble(masti.Value), Convert.ToDouble(zasiceneMasti.Value), Convert.ToDouble(holesterol.Value), Convert.ToDouble(proteini.Value), Convert.ToDouble(natrijum.Value), Convert.ToDouble(ugljikohidrati.Value), Convert.ToDouble(vlakna.Value), Convert.ToDouble(secer.Value), Convert.ToDouble(kalcijum.Value), "namirnica");
                    dao.DodajNamirnicu(n);
                    List<double> kolicineNamirnica = new List<double>();
                    kolicineNamirnica.Add(Convert.ToDouble(kolicinaNoveNamirnice.Value));
                    List<Namirnica> namirniceUJelu = new List<Namirnica>();
                    namirniceUJelu.Add(n);

                    Console.WriteLine(kolicineNamirnica.Count+" "+namirniceUJelu.Count);
                    Jelo jelo = new Jelo(n.Naziv, kolicineNamirnica, namirniceUJelu);
                    Console.WriteLine(jelo.Namirnice.Count + " " + jelo.KolicineNamirnica.Count);
                    jelo.IdJelo=dao.DodajJelo(jelo);


                    string nazivObroka;
                    if (dorucak.Checked) nazivObroka = "doručak";
                    else if (rucak.Checked) nazivObroka = "ručak";
                    else if (vecera.Checked) nazivObroka = "večera";
                    else if (uzina.Checked) nazivObroka = "užina";
                    else nazivObroka = "";

                    DBConnection.DnevnikIshrane dnevnikIshrane = new  DBConnection.DnevnikIshrane(Convert.ToDateTime(datum.Value), nazivObroka, jelo);
                    dao.DodajDnevnikIshrane(dnevnikIshrane, idKorisnik);
                    toolStripStatusLabel1.Text = "Namirnica je evidentirana.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

                }
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

        private void pretraziNamirnice_Click(object sender, EventArgs e)
        {
            try
            {
                listViewNamirnice.Items.Clear();
                toolStripStatusLabel1.Text = "";
                kolicinaPostojeceNamirnice.Value = 0;

                // Prvo provjerimo da li je korisnik unio naziv namirnice

                if (pretragaNazivNamirnice.Text.Length < 1)
                {
                    toolStripStatusLabel1.Text = "Unesite naziv namirnice";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

                // Zatim na osnovu unesenog naziva pretražujemo bazu 

                else if (pretragaNazivNamirnice.Text.Length < 100)
                {
                    ListViewItem temp = new ListViewItem();

                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    namirnice = dao.PretraziNamirnice(pretragaNazivNamirnice.Text);

                    // Ukoliko namirnica nije pronađeno obavještamo korisnika o istom

                    if (namirnice.Capacity == 0)
                    {
                        toolStripStatusLabel1.Text = "Namirnica nije pronađena";
                        toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    }

                    // Ispisujemo pronađeni rezultat u listi namirnica

                    foreach (Namirnica n in namirnice)
                    {
                        temp = listViewNamirnice.Items.Add(n.Naziv);
                        temp.SubItems.Add(n.Kalorije.ToString());
                        temp.SubItems.Add(n.Masti.ToString());
                        temp.SubItems.Add(n.ZasiceneMasti.ToString());
                        temp.SubItems.Add(n.Holesterol.ToString());
                        temp.SubItems.Add(n.Proteini.ToString());
                        temp.SubItems.Add(n.Natrijum.ToString());
                        temp.SubItems.Add(n.Ugljikohidrati.ToString());
                        temp.SubItems.Add(n.Vlakna.ToString());
                        temp.SubItems.Add(n.Secer.ToString());
                        temp.SubItems.Add(n.Kalcijum.ToString());
                    }

                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void dodajPostojecuNamirnicu_Click(object sender, EventArgs e)
        {
            try
            {
                int idNamirnice;
                if (kolicinaPostojeceNamirnice.Value < 1)
                {
                    toolStripStatusLabel1.Text = "Morate unijenti količinu namirnice.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    for (int i = 0; i < listViewNamirnice.Items.Count; i++)
                    {
                        if (listViewNamirnice.Items[i].Selected == true)
                        {
                            DAO dao = new DAO("localhost", "zavrsnirad", "root", "");

                            foreach (Namirnica n in namirnice)
                            {
                                if (n.Naziv == listViewNamirnice.Items[i].Text)
                                {

                                    string nazivObroka;
                                    if (dorucak.Checked) nazivObroka = "doručak";
                                    else if (rucak.Checked) nazivObroka = "ručak";
                                    else if (vecera.Checked) nazivObroka = "večera";
                                    else if (uzina.Checked) nazivObroka = "užina";
                                    else nazivObroka = "";
                                    idNamirnice = dao.VratiIDNamirnice(namirnice[i].Naziv);
                                    Namirnica namirnica = new Namirnica();
                                    namirnica = dao.PretraziNamirnicePoID(idNamirnice);
                                    List<double> kolicinaNamirnice = new List<double>();
                                    kolicinaNamirnice.Add(Convert.ToDouble(kolicinaPostojeceNamirnice.Value));
                                    Jelo jelo = dao.PretraziJela(n.Naziv);
                                    jelo.KolicineNamirnica = kolicinaNamirnice;
                                    DBConnection.DnevnikIshrane dnevnikIshrane = new DBConnection.DnevnikIshrane(Convert.ToDateTime(datum.Value), nazivObroka, jelo);
                                    dao.DodajDnevnikIshrane(dnevnikIshrane, idKorisnik);
                                }
                            }
                        }
                    }

                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Namirnica je evidentirana.";
                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void unosNazivNamirnice_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            toolStripStatusLabel1.Text = "";
            kalorije.Value = 0;
            proteini.Value = 0;
            masti.Value = 0;
            zasiceneMasti.Value = 0;
            holesterol.Value = 0;
            natrijum.Value = 0;
            secer.Value = 0;
            vlakna.Value = 0;
            ugljikohidrati.Value = 0;
            kalcijum.Value = 0;
            kolicinaNoveNamirnice.Value = 0;
        }

        private void tabControlDodajNamirnice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlDodajNamirnice.SelectedIndex == 0)
            {
                listViewNamirnice.Items.Clear();
                toolStripStatusLabel1.Text = "";
                kolicinaPostojeceNamirnice.Value = 0;
                pretragaNazivNamirnice.Text = "";
            }

            else if (tabControlDodajNamirnice.SelectedIndex == 1)
            {
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                kalorije.Value = 0;
                proteini.Value = 0;
                masti.Value = 0;
                zasiceneMasti.Value = 0;
                holesterol.Value = 0;
                natrijum.Value = 0;
                secer.Value = 0;
                vlakna.Value = 0;
                ugljikohidrati.Value = 0;
                kalcijum.Value = 0;
                kolicinaNoveNamirnice.Value = 0;
                unosNazivNamirnice.Text = "";
            }
        }

        private void tabControlDodajJela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlDodajJela.SelectedIndex == 0)
            {
                listViewNamirniceUJelu.Items.Clear();
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                pretragaNazivJela.Text = "";
            }

            else if (tabControlDodajJela.SelectedIndex == 1)
            {
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                nazivNovogJela.Text = "";
                sastojakJela.Text = "";
                kolicinaSastojkaJela.Value = 0;
                errorProvider1.Clear();
                sastojakJela.AutoCompleteMode = AutoCompleteMode.Suggest;
                sastojakJela.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                try
                {
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    List<Namirnica> sastojciJela = dao.VratiSveNamirnice();
                    foreach (Namirnica n in sastojciJela) col.Add(n.Naziv);
                    sastojakJela.AutoCompleteCustomSource = col;
                }
                catch (Exception izuzetak)
                {
                    toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                
            }
        }


        private void tabControlDnevnikIshrane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlDnevnikIshrane.SelectedIndex == 0)
            {
                listViewNamirnice.Items.Clear();
                toolStripStatusLabel1.Text = "";
                kolicinaPostojeceNamirnice.Value = 0;
                pretragaNazivNamirnice.Text = "";
            
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                kalorije.Value = 0;
                proteini.Value = 0;
                masti.Value = 0;
                zasiceneMasti.Value = 0;
                holesterol.Value = 0;
                natrijum.Value = 0;
                secer.Value = 0;
                vlakna.Value = 0;
                ugljikohidrati.Value = 0;
                kalcijum.Value = 0;
                kolicinaNoveNamirnice.Value = 0;
                unosNazivNamirnice.Text = "";
            }

            else if (tabControlDnevnikIshrane.SelectedIndex == 1)
            {
                listViewNamirniceUJelu.Items.Clear();
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                pretragaNazivJela.Text = "";

                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                toolStripStatusLabel1.Text = "";
                nazivNovogJela.Text = "";
                sastojakJela.Text = "";
                kolicinaSastojkaJela.Value = 0;
                errorProvider1.Clear();
            }
        }

        private void nazivNamirniceUJelu_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PregledStanja p = new PregledStanja();
            p.Show();
        }

        private void spremiSastojak_Click(object sender, EventArgs e)
        {
            try
            {
                if (nazivNovogJela.Text != "" && sastojakJela.Text != "" && kolicinaSastojkaJela.Value > 0)
                {
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    int idNamirnica = dao.VratiIDNamirnice(sastojakJela.Text);
                    Namirnica namirnica = dao.PretraziNamirnicePoID(idNamirnica);
                    sastojciJela.Add(namirnica);
                    kolicineSastojaka.Add(Convert.ToDouble(kolicinaSastojkaJela.Value));
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Sastojak je uspješno dodan.";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Morate unijeti sva polja.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void spremiJelo_Click(object sender, EventArgs e)
        {
            try
            {
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                if (kolicineSastojaka.Count == 0 || sastojciJela.Count == 0)
                {
                    toolStripStatusLabel1.Text = "Niste evidentirali sastojke jela.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                /*
                int postojiJelo=0;
                postojiJelo=dao.VratiJeloID(nazivNovogJela.Text);
                if(postojiJelo!=0)
                {
                    toolStripStatusLabel1.Text = "Jelo vec postoji u bazi podataka";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {*/
                    Console.WriteLine("Prošli");
                    Jelo jelo = new Jelo(nazivNovogJela.Text, kolicineSastojaka, sastojciJela);
                    jelo.IdJelo = dao.DodajJelo(jelo);
                    string nazivObroka;
                    if (dorucak.Checked) nazivObroka = "doručak";
                    else if (rucak.Checked) nazivObroka = "ručak";
                    else if (vecera.Checked) nazivObroka = "večera";
                    else if (uzina.Checked) nazivObroka = "užina";
                    else nazivObroka = "";
                    DBConnection.DnevnikIshrane dnevnikIshrane = new DBConnection.DnevnikIshrane(Convert.ToDateTime(datum.Value), nazivObroka, jelo);
                    dao.DodajDnevnikIshrane(dnevnikIshrane, idKorisnik);
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Jelo je uspješno evidentirano.";
                
            }
            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void pretraziNamirniceUJelu_Click(object sender, EventArgs e)
        {
            try
            {
                listViewNamirniceUJelu.Items.Clear();
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;

                // Prvo provjerimo da li je korisnik unio naziv jela

                if (pretragaNazivJela.Text.Length < 1)
                {
                    toolStripStatusLabel1.Text = "Unesite naziv jela.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

                // Zatim na osnovu unesenog naziva pretražujemo bazu 

                else if (pretragaNazivJela.Text.Length < 100)
                {
                    ListViewItem temp = new ListViewItem();

                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");

                    jelo = dao.PretraziJela(pretragaNazivJela.Text);
                    // Ukoliko jelo nije pronađeno obavještamo korisnika o istom

                    if (jelo.KolicineNamirnica.Count == 0)
                    {
                        toolStripStatusLabel1.Text = "Jelo nije pronađeno";
                        toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    }

                    // Ispisujemo pronađeni rezultat u listi jela
                    else
                    {
                        int i = 0;
                        foreach (Namirnica n in jelo.Namirnice)
                        {
                            temp = listViewNamirniceUJelu.Items.Add(dao.VratiNazivNamirnicePoID(dao.VratiIDNamirnice(n.Naziv)));
                            temp.SubItems.Add(jelo.KolicineNamirnica[i].ToString());
                            i++;
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

        private void dodajPostojeceJelo_Click(object sender, EventArgs e)
        {
            try
            {
              DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
              string nazivObroka;
              if (dorucak.Checked) nazivObroka = "doručak";
              else if (rucak.Checked) nazivObroka = "ručak";
              else if (vecera.Checked) nazivObroka = "večera";
              else if (uzina.Checked) nazivObroka = "užina";
              else nazivObroka = "";
              DBConnection.DnevnikIshrane dnevnikIshrane = new DBConnection.DnevnikIshrane(Convert.ToDateTime(datum.Value), nazivObroka, jelo);
              dao.DodajDnevnikIshrane(dnevnikIshrane, idKorisnik);
              toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
              toolStripStatusLabel1.Text = "Jelo je uspješno evidentirano.";   
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}
