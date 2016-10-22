using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Trening
    {
        private int id = 0;
        private string nazivTreninga;
        private List<int> minutazaAktivnosti = new List<int>();
        private List<Aktivnost> aktivnosti = new List<Aktivnost>();
        private static double utrosakKalorijaPoTreningu = 0;

        public Trening() { }
        public Trening(string nazivTreninga, List<int> minutazaAktivnosti, List<Aktivnost> aktivnosti)
        {
            this.nazivTreninga = nazivTreninga;
            this.minutazaAktivnosti.AddRange(minutazaAktivnosti);
            this.aktivnosti.AddRange(aktivnosti);
        }

        public string NazivTreninga
        {
            get { return nazivTreninga; }
            set { nazivTreninga = value; }
        }

        public List<int> MinutazaAktivnosti
        {
            get { return minutazaAktivnosti; }
            set { minutazaAktivnosti = value; }
        }

        public List<Aktivnost> Aktivnosti
        {
            get { return aktivnosti; }
            set { aktivnosti = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public double GetUtrošakKaorijaPoTreningu()
        {
            for(int i=0; i<aktivnosti.Count; i++)
                utrosakKalorijaPoTreningu+=((aktivnosti[i].UtrosakKalorija*minutazaAktivnosti[i])/60);
            return utrosakKalorijaPoTreningu;
        }
    }
}
