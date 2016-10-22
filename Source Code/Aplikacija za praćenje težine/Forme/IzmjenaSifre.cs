using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnection;

namespace AplikacijaZaPracenjeTezine.Forme
{
    public partial class IzmjenaSifre : Form
    {
        public IzmjenaSifre()
        {
            InitializeComponent();
        }

        private void spremi_Click(object sender, EventArgs e)
        {
            if (sifra1.Text == sifra2.Text)
            {
                try
                {
                    int idPrijava = 1;
                    DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                    string novaSifra;
                    novaSifra = sifra1.Text;
                    dao.AzurirajSifruKorisnika(novaSifra, idPrijava);
                    errorProvider1.Clear();
                    toolStripStatusLabel1.Text = "Šifra je uspješno promijenjena.";
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                }
                catch (Exception izuzetak)
                {
                    toolStripStatusLabel1.Text = Convert.ToString(izuzetak);
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
            }

            else
            {
                toolStripStatusLabel1.Text = "Šifre se ne podudaraju!";
                errorProvider1.SetError(sifra2, "Šifre se ne podudaraju!");
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
