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
    public partial class DnevnikPica : Form
    {
        private List<Namirnica> pica;
     
        public DnevnikPica()
        {
            InitializeComponent();
            pica = new List<Namirnica>();
        }

        private void dodajNovoPice_Click(object sender, EventArgs e)
        {
            try
            {
                //Provjera da li su uneseni obavezi podaci
                if (kolicina.Value < 1 || kalorije.Value < 1 || nazivNovogPica.Text.Length < 1)
                {
                    //Ukoliko količina, kalorije ili naziv pića nisu uneseni ispisuje se poruka o grešci
                    toolStripStatusLabel1.Text = "Niste unijeli sva obavezna polja.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

                else if (nazivNovogPica.Text.Length >1 && kolicina.Value>0 && kalorije.Value>0)
                {
                    //Ukoliko su unesena obavezna polja kreira se klasa za komunikaciju s bazom
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    //Na osnovu unesenih podataka kreira se piće
                    Namirnica pice = new Namirnica(nazivNovogPica.Text, Convert.ToInt16(kalorije.Value), Convert.ToDouble(masti.Value), Convert.ToDouble(zasiceneMasti.Value), Convert.ToDouble(holesterol.Value), Convert.ToDouble(proteini.Value), Convert.ToDouble(natrijum.Value), Convert.ToDouble(ugljikohidrati.Value), Convert.ToDouble(vlakna.Value), Convert.ToDouble(secer.Value), Convert.ToDouble(kalcijum.Value), "piće");
                    //Poziva se funkcija koja dodaje piće u bazu podataka
                    dao.DodajNamirnicu(pice);
                    pice.Id = dao.VratiIDNamirnice(pice.Naziv);
                    //Kreira se dnevnik pića
                    DBConnection.DnevnikPica dnevnikPica = new DBConnection.DnevnikPica(Convert.ToDateTime(datum.Value), Convert.ToDouble(kolicina.Value), pice);
                    //Poziva se funkcija koja kreira dnevnik pica u bazi
                    dao.DodajDnevnikPica(dnevnikPica, 1);
                    //Korisnik se obavještava o uspješnosti operacije
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Piće je dodano";
                }
            }
            catch (Exception izuzetak)
            {
                //U slučaju problema u radu s bazom korisnik se obavještava o tome
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void izadji_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pretraziPica_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "";
                listViewPica.Items.Clear();
                kolicinaPostojecegPica.Value = 0;

                // Prvo provjerimo da li je korisnik unio naziv pića

                if (nazivPostojecegPica.Text.Length < 1)
                {
                    toolStripStatusLabel1.Text = "Niste unijeli sva potrebna polja.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                
                // Zatim na osnovu unesenog naziva pretražujemo bazu 

                else if (nazivPostojecegPica.Text.Length < 50)
                {
                    ListViewItem temp = new ListViewItem();

                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    pica = dao.PretraziPica(nazivPostojecegPica.Text);

                // Ukoliko piće nije pronađeno obavještamo korisnika o istom

                    if (pica.Capacity == 0)
                    {
                        toolStripStatusLabel1.Text = "Piće nije pronađeno";
                        toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    }

                // Ispisujemo pronađeni rezultat u listi pića

                    foreach (Namirnica n in pica)
                    {
                        temp = listViewPica.Items.Add(n.Naziv);
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

        private void dodajPostojecePice_Click(object sender, EventArgs e)
        {
            try
            {
                if (kolicinaPostojecegPica.Value < 1)
                {
                    toolStripStatusLabel1.Text = "Morate unijenti količinu pića.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    for (int i = 0; i < listViewPica.Items.Count; i++)
                    {
                        if (listViewPica.Items[i].Selected == true)
                        {
                            foreach (Namirnica n in pica)
                                if (n.Naziv == listViewPica.Items[i].Text)
                                {
                                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                                    n.Id = dao.VratiIDNamirnice(pica[i].Naziv);
                                    DBConnection.DnevnikPica dnevnikPica = new DBConnection.DnevnikPica(Convert.ToDateTime(datum.Value), Convert.ToDouble(kolicinaPostojecegPica.Value), n);
                                    dao.DodajDnevnikPica(dnevnikPica, 1);
                                }
                        }
                    }

                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    toolStripStatusLabel1.Text = "Piće je dodano";
                }
            }

            catch (Exception izuzetak)
            {
                toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void nazivNovogPica_TextChanged(object sender, EventArgs e)
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
            kolicina.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PregledStanja p = new PregledStanja();
            p.Show();
        }

        private void tabControlDnevnikPica_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            toolStripStatusLabel1.Text = "";

            if (tabControlDnevnikPica.SelectedIndex == 0)
            {
                nazivPostojecegPica.Text = "";
                listViewPica.Items.Clear();
                kolicinaPostojecegPica.Value = 0;
            }
            else
            {
                nazivNovogPica.Text = "";
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
                kolicina.Value = 0;
            }
        }



    }
}
