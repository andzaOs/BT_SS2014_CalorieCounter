using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;

namespace DBConnection
{
    // DAO - Data Access Object

    public class DAO
    {
        private MySqlConnection dataConnection = new MySqlConnection();

        public DAO(string server, string dbname, string username, string password)
        {
            dataConnection.ConnectionString = "Server=" + server + ";Database=" + dbname + ";Uid=" + username + ";Pwd=" + password + ";Charset=utf8;";
        }

        ~DAO()
        {
            dataConnection.Close();
        }

        public bool AzurirajKorisnika(Korisnik k)
        {
            try
            {
               
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
              
               
                string datumRodjenja = Convert.ToString(k.DatumRodjenja.Year) + "-" + Convert.ToString(k.DatumRodjenja.Month) + "-" + Convert.ToString(k.DatumRodjenja.Day);
                string datumPostizanjaCilja = Convert.ToString(k.DatumPostizanjaCilja.Year) + "-" + Convert.ToString(k.DatumPostizanjaCilja.Month) + "-" + Convert.ToString(k.DatumPostizanjaCilja.Day);
                
                MySqlCommand korisnik = new MySqlCommand("Update korisnik set ime=@ime, prezime=@prezime, datumRodjenja=@datumRodjenja, spol=@spol, visina=@visina, pocetnaTezina=@pocetnaTezina, nivoAktivnosti=@nivoAktivnosti, cilj=@cilj, zeljenaTezina=@zeljenaTezina, datumPostizanjaCilja=@datumPostizanjaCilja  where idPrijava= '" + k.Prijava + "'", dataConnection);
                
                korisnik.Parameters.AddWithValue("@ime", (Object)k.Ime);
                korisnik.Parameters.AddWithValue("@prezime", (Object)k.Prezime);
                korisnik.Parameters.AddWithValue("@datumRodjenja", (Object)datumRodjenja);
                korisnik.Parameters.AddWithValue("@spol", (Object)k.Spol);
                korisnik.Parameters.AddWithValue("@visina", (Object)k.Visina);
                korisnik.Parameters.AddWithValue("@pocetnaTezina", (Object)k.PocetnaTezina);
                korisnik.Parameters.AddWithValue("@nivoAktivnosti", (Object)k.NivoAktivnosti);
                korisnik.Parameters.AddWithValue("@cilj", (Object)k.Cilj);
                korisnik.Parameters.AddWithValue("@zeljenaTezina", (Object)k.ZeljenaTezina);
                korisnik.Parameters.AddWithValue("@datumPostizanjaCilja", (Object)datumPostizanjaCilja);
        

                korisnik.ExecuteNonQuery();
                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće ažurirati korisnika u bazi.");
            }
        }

        public bool AzurirajSifruKorisnika(string sifra, int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                MemoryStream m = new MemoryStream();
                MySqlCommand prijava = new MySqlCommand("Update prijava set lozinka=@lozinka  where idPrijava= '" + idPrijava + "'", dataConnection);

                prijava.Parameters.AddWithValue("@lozinka", (Object)sifra);
            
                prijava.ExecuteNonQuery();
                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće promijeniti šifru u bazi.");
            }
        }

        public bool DodajDnevnikTezine(DnevnikTezine d, int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                MemoryStream m = new MemoryStream();
                string datum = Convert.ToString(d.Datum.Year) + "-" + Convert.ToString(d.Datum.Month) + "-" + Convert.ToString(d.Datum.Day);
                MySqlCommand dnevnikTezine = new MySqlCommand("Insert into dnevniktezine(datum, trenutnaTezina, ruke, prsa, butine, listovi, pozadina, stomak, bmi, bmr, tdee, potrebnaKolicinaTecnosti, idKorisnik) "+ "values(@datum, @trenutnaTezina, @ruke, @prsa, butine=@butine, @listovi, @pozadina, @stomak, @bmi, @bmr, @tdee, @potrebnaKolicinaTecnosti, @idKorisnik);", dataConnection);
                dnevnikTezine.Parameters.AddWithValue("@datum", (Object)datum);
                dnevnikTezine.Parameters.AddWithValue("@trenutnaTezina", (Object)d.TrenutnaTezina);
                dnevnikTezine.Parameters.AddWithValue("@ruke", (Object)d.Ruke);
                dnevnikTezine.Parameters.AddWithValue("@prsa", (Object)d.Prsa);
                dnevnikTezine.Parameters.AddWithValue("@butine", (Object)d.Butine);
                dnevnikTezine.Parameters.AddWithValue("@listovi", (Object)d.Listovi);
                dnevnikTezine.Parameters.AddWithValue("@pozadina", (Object)d.Pozadina);
                dnevnikTezine.Parameters.AddWithValue("@stomak", (Object)d.Stomak);
                dnevnikTezine.Parameters.AddWithValue("@bmi", (Object)d.Bmi);
                dnevnikTezine.Parameters.AddWithValue("@bmr", (Object)d.Bmr);
                dnevnikTezine.Parameters.AddWithValue("@tdee", (Object)d.Tdee);
                dnevnikTezine.Parameters.AddWithValue("@potrebnaKolicinaTecnosti", (Object)d.PotrebnaKolicinaTecnosti);
                dnevnikTezine.Parameters.AddWithValue("@idKorisnik", (Object)idKorisnik);

                dnevnikTezine.ExecuteNonQuery();
                dataConnection.Close();
                return true;

            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće dodati aktivnost u bazu.");
            }
        }
        public bool DodajNamirnicu(Namirnica n)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                //Compose query using sql parameters
                var sqlCommand = "Insert into namirnica(naziv, kalorije, masti, zasiceneMasti, holesterol, proteini, natrijum, ugljikohidrati, vlakna, secer, kalcijum, tip) "
                  + "values(@naziv, @kalorije, @masti, @zasiceneMasti, @holesterol, @proteini, @natrijum, @ugljikohidrati, @vlakna, @secer, @kalcijum, @tip);";

                //Create mysql command and pass sql query
                using (var command = new MySqlCommand(sqlCommand, dataConnection))
                {
                    command.Parameters.AddWithValue("@naziv", (Object)n.Naziv);
                    command.Parameters.AddWithValue("@kalorije", (Object)n.Kalorije);
                    command.Parameters.AddWithValue("@masti", (Object)n.Masti);
                    command.Parameters.AddWithValue("@zasiceneMasti", (Object)n.ZasiceneMasti);
                    command.Parameters.AddWithValue("@holesterol", (Object)n.Holesterol);
                    command.Parameters.AddWithValue("@proteini", (Object)n.Proteini);
                    command.Parameters.AddWithValue("@natrijum", (Object)n.Natrijum);
                    command.Parameters.AddWithValue("@ugljikohidrati", (Object)n.Ugljikohidrati);
                    command.Parameters.AddWithValue("@vlakna", (Object)n.Vlakna);
                    command.Parameters.AddWithValue("@secer", (Object)n.Secer);
                    command.Parameters.AddWithValue("@kalcijum", (Object)n.Kalcijum);
                    command.Parameters.AddWithValue("@tip", (Object)n.Tip);
                    command.ExecuteNonQuery();
                }
                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće dodati namirnicu u bazu.");
            }
        }

        public bool DodajAktivnost(Aktivnost a)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand aktivnost = new MySqlCommand("Insert into aktivnost(naziv, utroseneKalorije) " + "values(@naziv, @utroseneKalorije);", dataConnection);
                aktivnost.Parameters.AddWithValue("@naziv", (Object)a.Naziv);
                aktivnost.Parameters.AddWithValue("@utroseneKalorije", (Object)a.UtrosakKalorija);
                aktivnost.ExecuteNonQuery();
                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće dodati aktivnost u bazu.");
            }
        }

        public int DodajTrening(Trening t)
        {
            try
            {
                List<Aktivnost> aktivnosti = new List<Aktivnost>();
                aktivnosti = t.Aktivnosti;
                long lastid = 0;

                for (int j = 0; j < aktivnosti.Count; j++)
                {
                    int minutazaAktivnosti = t.MinutazaAktivnosti.ElementAt(j);
                    Aktivnost a = t.Aktivnosti.ElementAt(j);
                    int idAktivnost = VratiAktivnostID(a.Naziv);
                    if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                    var sqlCommand = "Insert into trening(nazivTreninga, minutazaAktivnosti, idAktivnost) " + "values(@nazivTreninga, @minutazaAktivnosti, @idAktivnost);";
                    //Create mysql command and pass sql query
                    using (var trening = new MySqlCommand(sqlCommand, dataConnection))
                    {
                        trening.Parameters.AddWithValue("@nazivTreninga", (Object)t.NazivTreninga);
                        trening.Parameters.AddWithValue("@minutazaAktivnosti", (Object)minutazaAktivnosti);
                        trening.Parameters.AddWithValue("@idAktivnost", (Object)idAktivnost);
                        trening.ExecuteNonQuery();
                        lastid = trening.LastInsertedId;
                    }

                    dataConnection.Close();
                }

                return Convert.ToInt32(lastid);
            }

            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DodajJelo(Jelo je)
        {
            try
            {
                List<Namirnica> namirnice = new List<Namirnica>();
                namirnice = je.Namirnice;
                long lastid = 0;

                for (int j = 0; j < namirnice.Count; j++ )
                {
                    double kolicinaNamirnice = je.KolicineNamirnica.ElementAt(j);
                    Namirnica n = je.Namirnice.ElementAt(j);
                    int idNamirnica = VratiIDNamirnice(n.Naziv);
                    if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                    var sqlCommand = "Insert into jelo(nazivJela, kolicinaNamirnice, idNamirnica) " + "values(@nazivJela, @kolicinaNamirnice, @idNamirnica);";

                    //Create mysql command and pass sql query
                    using (var jelo = new MySqlCommand(sqlCommand, dataConnection))
                    {
                        jelo.Parameters.AddWithValue("@nazivJela", (Object)je.NazivJela);
                        jelo.Parameters.AddWithValue("@kolicinaNamirnice", (Object)kolicinaNamirnice);
                        jelo.Parameters.AddWithValue("@idNamirnica", (Object)idNamirnica);
                        jelo.ExecuteNonQuery();
                        lastid = jelo.LastInsertedId;
                    }
               
                    dataConnection.Close();
                }

                return Convert.ToInt32(lastid);
            }

            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DodajDnevnikPica(DnevnikPica d, int idKorisnik)
        {
            try
            {
                    string datum = Convert.ToString(d.Datum.Year) + "-" + Convert.ToString(d.Datum.Month) + "-" + Convert.ToString(d.Datum.Day);

                    if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                    MySqlCommand dnevnikPicaB = new MySqlCommand("Insert into dnevnikpica(datum, kolicinaPica, idPice, idKorisnik) " + "values(@datum, @kolicinaPica, @idPice, @idKorisnik);", dataConnection);
                    dnevnikPicaB.Parameters.AddWithValue("@datum", (Object)datum);
                    dnevnikPicaB.Parameters.AddWithValue("@kolicinaPica", (Object)d.KolicinaPica);
                    dnevnikPicaB.Parameters.AddWithValue("@idPice", (Object)d.Pice.Id);
                    dnevnikPicaB.Parameters.AddWithValue("@idKorisnik", (Object)idKorisnik);
                    dnevnikPicaB.ExecuteNonQuery();
                    dataConnection.Close();
                    return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće dodati aktivnost u bazu.");
            }
        }

        public bool DodajDnevnikIshrane(DnevnikIshrane d, int idKorisnik)
        {
            try
            {
                    if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                    string datum1 = Convert.ToString(d.Datum.Year) + "-" + Convert.ToString(d.Datum.Month) + "-" + Convert.ToString(d.Datum.Day);
                    var sqlCommand = "Insert into dnevnikishrane(datum, nazivObroka, idJelo, idKorisnik) " + "values(@datum, @nazivObroka, @idJelo, @idKorisnik);";

                    //Create mysql command and pass sql query
                    using (var dnevnikIshraneB = new MySqlCommand(sqlCommand, dataConnection))
                    {
                        dnevnikIshraneB.Parameters.AddWithValue("@datum", (Object)d.Datum);
                        dnevnikIshraneB.Parameters.AddWithValue("@nazivObroka", (Object)d.NazivObroka);
                        dnevnikIshraneB.Parameters.AddWithValue("@idJelo", (Object)d.Jelo.IdJelo);
                        dnevnikIshraneB.Parameters.AddWithValue("@idKorisnik", (Object)idKorisnik);
                        dnevnikIshraneB.ExecuteNonQuery();
                    }
                    dataConnection.Close();
                    return true;
            }

            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }


        public bool DodajDnevnikAktivnosti(DnevnikAktivnosti d, int idKorisnik)
        {
            try
            {
                string datum = Convert.ToString(d.Datum.Year) + "-" + Convert.ToString(d.Datum.Month) + "-" + Convert.ToString(d.Datum.Day);
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dnevnikAktivnostiB = new MySqlCommand("Insert into dnevnikaktivnosti(datum, idTrening, idKorisnik) " + "values(@datum, @idTrening, @idKorisnik);", dataConnection);
                dnevnikAktivnostiB.Parameters.AddWithValue("@datum", (Object)datum);
                dnevnikAktivnostiB.Parameters.AddWithValue("@idTrening", (Object)d.Trening.Id);
                dnevnikAktivnostiB.Parameters.AddWithValue("@idKorisnik", (Object)idKorisnik);
                dnevnikAktivnostiB.ExecuteNonQuery();
                dataConnection.Close();
                return true;
            }

            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Namirnica> PretraziNamirnice(string imeNamirnice)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<Namirnica> namirnice = new List<Namirnica>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE naziv LIKE '%" + imeNamirnice + "%' AND tip = '" + "namirnica" + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Namirnica n = new Namirnica(dataReader.GetString(1), dataReader.GetInt16(2), dataReader.GetDouble(3), dataReader.GetDouble(4), dataReader.GetDouble(5), dataReader.GetDouble(6), dataReader.GetDouble(7), dataReader.GetDouble(8), dataReader.GetDouble(9), dataReader.GetDouble(10), dataReader.GetDouble(11), dataReader.GetString(12));
                    namirnice.Add(n);
                }
                dataReader.Close();
                dataConnection.Close();
                return namirnice;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public List<Namirnica> VratiSveNamirnice()
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<Namirnica> namirnice = new List<Namirnica>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica;";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Namirnica n = new Namirnica(dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDouble(3), dataReader.GetDouble(4), dataReader.GetDouble(5), dataReader.GetDouble(6), dataReader.GetDouble(7), dataReader.GetDouble(8), dataReader.GetDouble(9), dataReader.GetDouble(10), dataReader.GetDouble(11), dataReader.GetString(12));
                    namirnice.Add(n);
                }
                dataReader.Close();
                dataConnection.Close();
                return namirnice;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public List<Aktivnost> VratiSveAktivnosti()
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<Aktivnost> aktivnosti = new List<Aktivnost>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM aktivnost;";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Aktivnost a = new Aktivnost(dataReader.GetString(1), dataReader.GetInt32(2));
                    aktivnosti.Add(a);
                }
                dataReader.Close();
                dataConnection.Close();
                return aktivnosti;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Namirnica PretraziNamirnicePoID(int idNamirnice)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE idNamirnica = '" + idNamirnice + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                Namirnica n = new Namirnica();
                while (dataReader.Read())
                {
                    n.Naziv = dataReader.GetString(1);
                    n.Kalorije = dataReader.GetInt16(2);
                    n.Masti = dataReader.GetDouble(3);
                    n.ZasiceneMasti = dataReader.GetDouble(4);
                    n.Holesterol = dataReader.GetDouble(5);
                    n.Proteini = dataReader.GetDouble(6);
                    n.Natrijum = dataReader.GetDouble(7);
                    n.Ugljikohidrati = dataReader.GetDouble(8);
                    n.Vlakna = dataReader.GetDouble(9);
                    n.Secer = dataReader.GetDouble(10);
                    n.Kalcijum = dataReader.GetDouble(11);
                    n.Tip = dataReader.GetString(12);
                }
                dataReader.Close();
                dataConnection.Close();
                return n;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Aktivnost PretraziAktivnostiPoID(int idAktivnost)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM aktivnost WHERE idAktivnost = '" + idAktivnost + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                Aktivnost a = new Aktivnost();
                while (dataReader.Read())
                {
                   a.Naziv = Convert.ToString(dataReader["naziv"]);
                   a.UtrosakKalorija = Convert.ToInt16(dataReader["utroseneKalorije"]);
                }
                dataReader.Close();
                dataConnection.Close();
                return a;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Jelo PretraziJela(string imeJela)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * from jelo j where j.nazivJela = '" + imeJela + "';";
                List<Namirnica> sastojciJela = new List<Namirnica>();
                List<double> kolicineSastojaka = new List<double>();
                Jelo jelo = new Jelo();
                int idJelo=0;
                List<int> idSastojaka = new List<int>();

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    idJelo = Convert.ToInt16(dataReader["idJelo"]);
                    kolicineSastojaka.Add(Convert.ToDouble(dataReader["kolicinaNamirnice"]));
                    idSastojaka.Add(Convert.ToInt32(dataReader["idNamirnica"]));
                }
                dataReader.Close();
                dataConnection.Close();
                jelo.KolicineNamirnica = kolicineSastojaka;
                foreach (int id in idSastojaka)
                {
                    sastojciJela.Add(PretraziNamirnicePoID(id));
                }
                jelo.Namirnice = sastojciJela;
                jelo.IdJelo = idJelo;
                return jelo;
                
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Trening PretraziTreninge(string imeTreninga)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * from trening t where t.nazivTreninga = '" + imeTreninga + "';";
                List<Aktivnost> aktivnosti = new List<Aktivnost>();
                List<int> minutazaAktivnosti = new List<int>();
                Trening trening = new Trening();
                int idTrening = 0;
                List<int> idAktivnosti = new List<int>();

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    idTrening = Convert.ToInt16(dataReader["idTrening"]);
                    minutazaAktivnosti.Add(Convert.ToInt16(dataReader["minutazaAktivnosti"]));
                    idAktivnosti.Add(Convert.ToInt16(dataReader["idAktivnost"]));
                }
                dataReader.Close();
                dataConnection.Close();
                trening.MinutazaAktivnosti = minutazaAktivnosti;
                foreach(int id in idAktivnosti)
                {
                    aktivnosti.Add(PretraziAktivnostiPoID(id));
                }
                trening.Aktivnosti = aktivnosti;
                trening.Id = idTrening;
                return trening;

            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public List<Namirnica> PretraziPica(string imePica)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<Namirnica> namirnice = new List<Namirnica>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE naziv LIKE '%" + imePica + "%' AND tip = '" + "piće" + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Namirnica n = new Namirnica(dataReader.GetString(1), dataReader.GetInt16(2), dataReader.GetDouble(3), dataReader.GetDouble(4), dataReader.GetDouble(5), dataReader.GetDouble(6), dataReader.GetDouble(7), dataReader.GetDouble(8), dataReader.GetDouble(9), dataReader.GetDouble(10), dataReader.GetDouble(11), dataReader.GetString(12));
                    namirnice.Add(n);
                }
                dataReader.Close();
                dataConnection.Close();
                return namirnice;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public List<Aktivnost> PretraziAktivnosti(string imeAktivnosti)
        {

            try
            {
                List<Aktivnost> aktivnosti = new List<Aktivnost>();

                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM aktivnost WHERE naziv LIKE '%" + imeAktivnosti + "%';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Aktivnost a = new Aktivnost(dataReader.GetString(1), dataReader.GetInt16(2));
                    aktivnosti.Add(a);
                }
                dataReader.Close();
                dataConnection.Close();
                return aktivnosti;
            }
            catch (MySqlException)
            {
                throw new Exception("Nije moguće izvršiti aktivnost.");
            }

        }
        public Jelo VratiJeloPoDatumu(DateTime datum)
        {

            try
            {
                string datum1 = Convert.ToString(datum.Year) + "-" + Convert.ToString(datum.Month) + "-" + Convert.ToString(datum.Day);
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * from jelo j, dnevnikishrane d WHERE j.idJelo = d.idJelo AND d.datum LIKE '%" + datum1 + "%';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                Jelo j = new Jelo();
                while (dataReader.Read())
                {
                    j.KolicineNamirnica[0] = Convert.ToDouble(dataReader["kolicinaNamirnice"]);
                    j.Namirnice[0] = PretraziNamirnicePoID(Convert.ToInt16(dataReader["idNamirnica"]));
                }
                dataReader.Close();
                dataConnection.Close();
                return j;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double UkupanUnosKalorijaPice(DateTime datum)
        {

            try
            {
                double ukupanUnosKalorija = 0;
                string datum1 = Convert.ToString(datum.Year) + "-" + Convert.ToString(datum.Month) + "-" + Convert.ToString(datum.Day);
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT d.kolicinaPica AS kp, n.kalorije AS k from namirnica n, dnevnikpica d where d.idPice = n.idNamirnica AND d.datum LIKE '%" + datum1 + "%';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    ukupanUnosKalorija += Convert.ToDouble(dataReader.GetDouble(0)) * Convert.ToDouble(dataReader.GetInt32(1))/100;
                }
                dataReader.Close();
                dataConnection.Close();
                return ukupanUnosKalorija;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Trening VratiTreningPoDatumu(DateTime datum)
        {

            try
            {
                string datum1 = Convert.ToString(datum.Year) + "-" + Convert.ToString(datum.Month) + "-" + Convert.ToString(datum.Day);
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * from trening t, dnevnikaktivnosti d where t.idTrening = d.idTrening AND d.datum = '" + datum1 + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                Trening t = new Trening();
                while (dataReader.Read())
                {
                    t.MinutazaAktivnosti[0] = Convert.ToInt16(dataReader["minutazaAktivnosti"]);
                    t.Aktivnosti[0]=PretraziAktivnostiPoID(Convert.ToInt16(dataReader["idAktivnost"]));
                }
                dataReader.Close();
                dataConnection.Close();
                return t;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message + "nlanla");
            }
        }

        public List<DnevnikTezine> PretraziDnevnikeTezine()
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<DnevnikTezine> dnevniciTezine = new List<DnevnikTezine>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;

                dataCommand.CommandText = "SELECT * FROM dnevniktezine;";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                string nazivKolone1 = "datum", nazivKolone2 = "trenutnaTezina";
                int brojKolone1, brojKolone2;
                while (dataReader.Read())
                {
                    brojKolone1 = dataReader.GetOrdinal(nazivKolone1);
                    brojKolone2 = dataReader.GetOrdinal(nazivKolone2);
                    DnevnikTezine d = new DnevnikTezine(dataReader.GetString(brojKolone1), dataReader.GetDouble(brojKolone2));
                    dnevniciTezine.Add(d);
                }
                dataReader.Close();
                dataConnection.Close();
                return dnevniciTezine;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiIDNamirnice(string nazivNamirnice)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idNamirnica FROM namirnica WHERE naziv = '" + nazivNamirnice + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }


        public string VratiNazivNamirnicePoID(int id)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "naziv";
                dataCommand.CommandText = "SELECT n.Naziv FROM namirnica n WHERE n.idNamirnica = '" + id + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                string naziv = "";
                while (dataReader.Read())
                {
                    int brojKolone = dataReader.GetOrdinal(nazivKolone);
                    naziv = dataReader.GetString(brojKolone);
                }
                dataReader.Close();
                dataConnection.Close();
                return naziv;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public string VratiNazivPica(int idPice)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "naziv";
                dataCommand.CommandText = "SELECT naziv FROM namirnica  WHERE idNamirnica = '" + idPice + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojKolone = dataReader.GetOrdinal(nazivKolone);
                string naziv = dataReader.GetString(brojKolone);
                dataReader.Close();
                dataConnection.Close();
                return naziv;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public string VratiNazivAktivnosti(int idAktivnost)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "naziv";
                dataCommand.CommandText = "SELECT naziv FROM aktivnost  WHERE idAktivnost = '" + idAktivnost + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojKolone = dataReader.GetOrdinal(nazivKolone);
                string naziv = dataReader.GetString(brojKolone);
                dataReader.Close();
                dataConnection.Close();
                return naziv;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiKalorijeNamirnicePoJelu(string nazivJela)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "kalorije";
                dataCommand.CommandText = "SELECT kalorije FROM namirnica n, jelo j WHERE n.idNamirnica=j.idNamirnica AND j.nazivJela = '" + nazivJela + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojKolone = dataReader.GetOrdinal(nazivKolone);
                int kalorije = dataReader.GetInt16(brojKolone);
                dataReader.Close();
                dataConnection.Close();
                return kalorije;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiKalorijePicaPoID(int idPica)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "kalorije";
                dataCommand.CommandText = "SELECT kalorije FROM namirnica WHERE idNamirnica = '" + idPica + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojKolone = dataReader.GetOrdinal(nazivKolone);
                int kalorije = dataReader.GetInt16(brojKolone);
                dataReader.Close();
                dataConnection.Close();
                return kalorije;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiUtroseneKalorijePoID(int idAktivnost)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                string nazivKolone = "utroseneKalorije";
                dataCommand.CommandText = "SELECT utroseneKalorije FROM aktivnost WHERE idAktivnost = '" + idAktivnost + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojKolone = dataReader.GetOrdinal(nazivKolone);
                int utroseneKalorije = dataReader.GetInt16(brojKolone);
                dataReader.Close();
                dataConnection.Close();
                return utroseneKalorije;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiJeloID(string nazivJela)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idJelo FROM jelo WHERE nazivJela='" + nazivJela + "' ;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }


        }

        public bool PostojiTrening(string nazivTreninga)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT count(*) FROM  trening  WHERE nazivTreninga = '" + nazivTreninga + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int broj = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                if (broj > 0) return true;
                else return false;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiAktivnostID(String naziv)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idAktivnost FROM aktivnost WHERE naziv = '" + naziv + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public int VratiKorisnikID(Korisnik k)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idKorisnik FROM korisnik WHERE ime = '" + k.Ime + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiIme(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT ime FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string ime = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return ime;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiKorisnickoIme(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT korisnickoIme FROM prijava WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string ime = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return ime;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiLozinku(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT lozinka FROM prijava WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string lozinka = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return lozinka;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiPrezime(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT prezime FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string prezime = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return prezime;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiDatumRodjenja(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT datumRodjenja FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string datumRodjenja = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return datumRodjenja;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiSpol(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT spol FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string spol = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return spol;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiVisinu(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT visina FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double visina = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return visina;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiPocetnuTezinu(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT pocetnaTezina FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double tezina = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return tezina;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiAktivnost(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT nivoAktivnosti FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string aktivnost = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return aktivnost;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiCilj(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT cilj FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string cilj = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return cilj;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiZeljenuTezinu(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT zeljenaTezina FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double zeljenaTezina = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return zeljenaTezina;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public string VratiDatumOstvarenjaCilja(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT datumPostizanjaCilja FROM korisnik WHERE idPrijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                string datumOstvarenjaCilja = dataReader.GetString(0);
                dataReader.Close();
                dataConnection.Close();
                return datumOstvarenjaCilja;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiBMI(int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT bmi FROM dnevniktezine WHERE idKorisnik = '" + idKorisnik + "' ORDER BY idDnevnikTezina DESC LIMIT 1;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double bmi = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return bmi;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiBMR(int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT bmr FROM dnevniktezine WHERE idKorisnik = '" + idKorisnik + "' ORDER BY idDnevnikTezina DESC LIMIT 1;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double bmr = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return bmr;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiTDEE(int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT tdee FROM dnevniktezine WHERE idKorisnik = '" + idKorisnik + "' ORDER BY idDnevnikTezina DESC LIMIT 1;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double tdee = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return tdee;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiTrenutnuTezinu(int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT trenutnaTezina FROM dnevniktezine WHERE idKorisnik = '" + idKorisnik + "' ORDER BY idDnevnikTezina DESC LIMIT 1;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double trenutnaTezina = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return trenutnaTezina;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiPotrebnaKolicinaTecnosti(int idKorisnik)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT potrebnaKolicinaTecnosti FROM dnevniktezine WHERE idKorisnik = '" + idKorisnik + "' ORDER BY idDnevnikTezina DESC LIMIT 1;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                double potrebnaKolicinaTecnosti = dataReader.GetDouble(0);
                dataReader.Close();
                dataConnection.Close();
                return potrebnaKolicinaTecnosti;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiPrijavaID(string sifra, string korisnickoIme)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idPrijava FROM prijava WHERE korisnickoIme = '" + korisnickoIme + "' AND lozinka = '" + sifra + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiIDKorisnik(int idPrijava)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT idKorisnik FROM korisnik WHERE idprijava = '" + idPrijava + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return id;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiRedoveDnevnikTezina()
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT COUNT(*) FROM dnevniktezine;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojRedova = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return brojRedova;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiRedoveJela()
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT COUNT(*) FROM jelo;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojRedova = dataReader.GetInt32(0);
                dataReader.Close(); 
                dataConnection.Close();
                return brojRedova;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiRedoveTreninga()
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT COUNT(*) FROM trening;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int brojRedova = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                return brojRedova;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

    }      

}
