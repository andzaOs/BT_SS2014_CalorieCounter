using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnection
{
    public class Jelo
    {
        private int idJelo=0;
        private String nazivJela;
        private List<double> kolicineNamirnica = new List<double>();
        private List<Namirnica> namirnice = new List<Namirnica>();
        private static double kalorijePoJelu = 0;

        public Jelo(){}
        public Jelo(string nazivJela, List<double> kolicineNamirnica, List<Namirnica> namirnice)
        {
            this.nazivJela = nazivJela;
            this.kolicineNamirnica.AddRange(kolicineNamirnica);
            this.namirnice.AddRange(namirnice);
        }
        public String NazivJela
        {
            get { return nazivJela; }
            set { nazivJela = value; }
        }
        public List<double> KolicineNamirnica
        {
            get { return kolicineNamirnica; }
            set { kolicineNamirnica = value; }
        }
        public List<Namirnica> Namirnice
        {
            get { return namirnice; }
            set { namirnice = value; }
        }


        public int IdJelo
        {
            get { return idJelo; }
            set { idJelo = value; }
        }

        public double GetKalorijePoJelu()
        {
            for(int i=0; i<namirnice.Count; i++)
                kalorijePoJelu+=namirnice[i].Kalorije*kolicineNamirnica[i]/100;
            return kalorijePoJelu;
        }
    }
}
