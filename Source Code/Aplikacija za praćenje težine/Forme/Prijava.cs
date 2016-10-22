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
    public partial class Prijava : Form
    {
        public int id;
        public Prijava()
        {
            InitializeComponent();
            id = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection.Prijava p = new DBConnection.Prijava(korisnickoIme.Text, lozinka.Text);
            
            try
            {
                
                DAO dao = new DAO("localhost", "zavrsnirad", "root", "");
                id = dao.VratiPrijavaID(p.Sifra, p.KorisnickoIme);

                if (id == 0)
                {
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                    toolStripStatusLabel1.Text = "Neovlašten pristup.";
                }

                else
                {
                    Menu m = new Menu();
                    m.Show();
                    this.Hide();
                }
               
            }
            catch (Exception em)
            {
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                toolStripStatusLabel1.Text = em.Message;
            }

        }

    
       

      
    }  
}
