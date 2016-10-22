using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class DnevnikTezine
    {
        private DateTime datum;
        private double trenutnaTezina;
        private double ruke;
        private double prsa;
        private double butine;
        private double listovi;
        private double pozadina;
        private double stomak;
        private double bmi;
        private double bmr;
        private double tdee;
        private double potrebnaKolicinaTecnosti;

        public DnevnikTezine() { }

           public DnevnikTezine(DateTime datum, double trenutnaTezina, double ruke, double prsa, double butine, double listovi, double pozadina, double stomak, double bmi, double bmr, double tdee, double potrebnaKolicinaTecnosti)
        {
            this.datum = datum;
            this.trenutnaTezina = trenutnaTezina;
            this.ruke = ruke;
            this.prsa = prsa;
            this.butine = butine;
            this.listovi = listovi;
            this.pozadina = pozadina;
            this.stomak = stomak;
            this.bmi = bmi;
            this.bmr = bmr;
            this.tdee = tdee;
            this.potrebnaKolicinaTecnosti = potrebnaKolicinaTecnosti;
        }

           public DnevnikTezine(string datum, double trenutnaTezina)
           {
               this.trenutnaTezina = trenutnaTezina;
               this.datum = Convert.ToDateTime(datum);
           }


        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        
        public double TrenutnaTezina
        {
            get { return trenutnaTezina; }
            set { trenutnaTezina = value; }
        }

        public double Ruke
        {
            get { return ruke; }
            set { ruke = value; }
        }

        public double Prsa
        {
            get { return prsa; }
            set { prsa = value; }
        }

        public double Butine
        {
            get { return butine; }
            set { butine = value; }
        }

        public double Listovi
        {
            get { return listovi; }
            set { listovi = value; }
        }

        public double Pozadina
        {
            get { return pozadina; }
            set { pozadina = value; }
        }

        public double Stomak
        {
            get { return stomak; }
            set { stomak = value; }
        }

        public double SetBmi(double visina, double tezina)
        {
            this.bmi = Convert.ToDouble(string.Format("{0:F2}", tezina / (visina * visina / 10000)));
            return bmi;
        }

        public double Bmi
        {
            get { return bmi; }
        }

        public double SetBmr(string spol, double tezina, double visina, int starost)
        {
            if (spol == "žensko") this.bmr = 655 + (9.6 * tezina) + (1.8 * visina) - (4.7 * starost);
            else this.bmr = 66 + (13.7 * tezina) + (5 * visina) - (6.8 * starost);
            return this.bmr;
        }

        public double Bmr
        {
            get { return bmr; }
        }

        public double SetTdee(string nivoAktivnosti)
        {
            if (nivoAktivnosti == "lagana") this.tdee = this.bmr * 1.375;
            else if (nivoAktivnosti == "umjerena") this.tdee = this.bmr * 1.55;
            else if (nivoAktivnosti == "teška") this.tdee = this.bmr * 1.725;
            else this.tdee = this.bmr * 1.9;
            return this.tdee;
        }

        public double Tdee
        {
            get { return tdee; }
        }

        public double PotrebnaKolicinaTecnosti
        {
            get { return potrebnaKolicinaTecnosti; }
            set { potrebnaKolicinaTecnosti = value; }
        }

        public void SetPotrebnaKolicinaTecnosti(double tezina)
        {
            potrebnaKolicinaTecnosti = Convert.ToDouble(string.Format("{0:F2}", (tezina / 2) * 0.03));
        }

    }
}
