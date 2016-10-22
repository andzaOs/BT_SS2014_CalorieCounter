using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Namirnica
    {
        private int id;
        private string naziv;
        private int kalorije;
        private double masti;
        private double zasiceneMasti;
        private double holesterol;
        private double proteini;
        private double natrijum;
        private double ugljikohidrati;
        private double vlakna;
        private double secer;
        private double kalcijum;
        private string tip;

        public Namirnica() { }
        public Namirnica(string naziv, int kalorije, double masti, double zasiceneMasti, double holesterol, double proteini, double natrijum, double ugljikohidrati, double vlakna, double secer, double kalcijum, string tip)
        {
            this.naziv = naziv;
            this.kalorije = kalorije;
            this.masti = masti;
            this.zasiceneMasti = zasiceneMasti;
            this.holesterol = holesterol;
            this.proteini = proteini;
            this.natrijum = natrijum;
            this.ugljikohidrati = ugljikohidrati;
            this.vlakna = vlakna;
            this.secer = secer;
            this.kalcijum = kalcijum;
            this.tip = tip;

        }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public int Kalorije
        {
            get { return kalorije; }
            set { kalorije = value; }
        }

        public double Masti
        {
            get { return masti; }
            set { masti = value; }
        }

        public double ZasiceneMasti
        {
            get { return zasiceneMasti; }
            set { zasiceneMasti = value; }
        }

        public double Holesterol
        {
            get { return holesterol; }
            set { holesterol = value; }
        }

        public double Proteini
        {
            get { return proteini; }
            set { proteini = value; }
        }

        public double Natrijum
        {
            get { return natrijum; }
            set { natrijum = value; }
        }

        public double Ugljikohidrati
        {
            get { return ugljikohidrati; }
            set { ugljikohidrati = value; }
        }

        public double Vlakna
        {
            get { return vlakna; }
            set { vlakna = value; }
        }

        public double Secer
        {
            get { return secer; }
            set { secer = value; }
        }

        public double Kalcijum
        {
            get { return kalcijum; }
            set { kalcijum = value; }
        }

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
