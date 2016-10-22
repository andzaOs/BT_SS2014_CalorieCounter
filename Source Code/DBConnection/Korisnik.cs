using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Korisnik
    {
        private int id;
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private int starost;
        private string spol;
        private double visina;
        private double pocetnaTezina;
        private string nivoAktivnosti;
        private string cilj;
        private double zeljenaTezina;
        private DateTime datumPostizanjaCilja;
        private string korisnickoIme;
        private string lozinka;
        private Prijava prijava;

        public Korisnik() { }
        public Korisnik(string ime, string prezime, DateTime datumRodjenja, string spol, double visina, double pocetnaTezina, string nivoAktivnosti, string cilj, double zeljenaTezina, DateTime datumPostizanjaCilja)
            
	    {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.spol = spol;
            this.visina = visina;
            this.pocetnaTezina = pocetnaTezina;
            this.nivoAktivnosti = nivoAktivnosti;
            this.cilj = cilj;
            this.zeljenaTezina = zeljenaTezina;
            this.datumPostizanjaCilja = datumPostizanjaCilja;
	    }


        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public string Spol
        {
            get { return spol; }
            set { spol = value; }
        }

        public double Visina
        {
            get { return visina; }
            set { visina = value; }
        }

        public double PocetnaTezina
        {
            get { return pocetnaTezina; }
            set { pocetnaTezina = value; }
        }
        
        public string NivoAktivnosti
        {
            get { return nivoAktivnosti; }
            set { nivoAktivnosti = value; }
        }

        public string Cilj
        {
            get { return cilj; }
            set { cilj = value; }
        }

        public double ZeljenaTezina
        {
            get { return zeljenaTezina; }
            set { zeljenaTezina = value; }
        }

        public DateTime DatumPostizanjaCilja
        {
            get { return datumPostizanjaCilja; }
            set { datumPostizanjaCilja = value; }
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

        public int GetStarost(DateTime now)
        {
            return (now - datumRodjenja).Days / 365;
        }
        public int Starost
        {
            get { return starost; }
            set { starost = value; }
        }
        public Prijava Prijava
        {
            get { return prijava; }
            set { prijava = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
