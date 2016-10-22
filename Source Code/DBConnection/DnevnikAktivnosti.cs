using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class DnevnikAktivnosti
    {
        private DateTime datum;
        private Trening trening;

        public DnevnikAktivnosti(DateTime datum, Trening trening)
        {
            this.datum = datum;
            this.trening = trening;
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public Trening Trening
        {
            get { return trening; }
            set { trening = value; }
        }
        
    }
}
