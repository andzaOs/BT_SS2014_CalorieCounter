using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Aktivnost
    {
        private string naziv;
        private int utroseneKalorije;

        public Aktivnost() { }
        public Aktivnost(string naziv, int utroseneKalorije)
        {
            this.naziv = naziv;
            this.UtrosakKalorija = utroseneKalorije;
        }
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public int UtrosakKalorija
        {
            get { return utroseneKalorije; }
            set { utroseneKalorije = value; }
        }
    }
}
