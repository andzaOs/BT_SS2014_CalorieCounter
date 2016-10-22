using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class DnevnikIshrane
    {
        private DateTime datum;
        private String nazivObroka;
        private Jelo jelo;

         public DnevnikIshrane(DateTime datum, string nazivObroka, Jelo jelo)
        {
            this.datum = datum;
            this.nazivObroka = nazivObroka;
            this.jelo = jelo;
        }
        
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public String NazivObroka
        {
            get { return nazivObroka; }
            set { nazivObroka = value; }
        }
        public Jelo Jelo
        {
            get { return jelo; }
            set { jelo = value; }
        }

    }
}
