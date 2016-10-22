using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class DnevnikPica
    {
        private DateTime datum;
        private double kolicinaPica;
        private Namirnica pice;

        public DnevnikPica(DateTime datum, double kolicinaPica, Namirnica pice)
        {
            this.datum = datum;
            this.kolicinaPica = kolicinaPica;
            this.pice = pice;
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public double KolicinaPica
        {
            get { return kolicinaPica; }
            set { kolicinaPica = value; }
        }

        public Namirnica Pice
        {
            get { return pice; }
            set { pice = value; }
        }
    }
}
