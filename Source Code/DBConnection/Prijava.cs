using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Prijava
    {
        private string korisnickoIme;
        private string lozinka;

        public Prijava(string korisnickoIme, string lozinka)
        {
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
        }
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }

        public string Sifra
        {
            get { return lozinka; }
            set { lozinka = value; }
        }

    }
}
