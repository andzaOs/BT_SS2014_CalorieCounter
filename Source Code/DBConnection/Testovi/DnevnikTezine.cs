using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConnection;

namespace DBConnection.Testovi
{
    [TestClass]
    public class DnevnikTezineTest
    {
        DnevnikTezine dt;

        [TestInitialize]
        public void Postavi()
        {
            DateTime datumRodjenja = new DateTime();
            datumRodjenja.AddDays(29);
            datumRodjenja.AddMonths(12);
            datumRodjenja.AddYears(1990);
            DateTime datumPostizanjaCilja = new DateTime();
            datumPostizanjaCilja.AddDays(10);
            datumPostizanjaCilja.AddMonths(9);
            datumPostizanjaCilja.AddYears(2014);
            Korisnik k = new Korisnik("Anela", "Osmanovic", datumRodjenja, "žensko", 159, 58, "lagana", "", 47, datumPostizanjaCilja);
            DateTime trenutniDatum = DateTime.Today;
            dt = new DnevnikTezine();
            dt.Datum = trenutniDatum;
            dt.SetBmi(k.Visina, k.PocetnaTezina);
            dt.SetBmr(k.Spol, k.PocetnaTezina, k.Visina, k.Starost);
            dt.SetTdee(k.NivoAktivnosti);
            dt.SetPotrebnaKolicinaTecnosti(k.PocetnaTezina);
            dt.TrenutnaTezina = k.PocetnaTezina;
        }
        [TestCleanup]
        public void Obrisi()
        {
            dt = null;
        }
        [TestMethod]
        public void BmiTest()
        {
            Assert.AreEqual(22.94, dt.Bmi);
        }
        [TestMethod]
        public void BmrTest()
        {
            Assert.AreEqual(1498, dt.Bmr);
        }
        [TestMethod]
        public void TdeeTest()
        {
            Assert.AreEqual(2059.75, dt.Tdee);
        }
        [TestMethod]
        public void PotrebnaKolicinaTecnosti()
        {
            Assert.AreEqual(0.87, dt.PotrebnaKolicinaTecnosti);
        }
    }
}
