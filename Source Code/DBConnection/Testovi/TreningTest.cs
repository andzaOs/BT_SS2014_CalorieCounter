using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConnection;

namespace DBConnection.Testovi
{
    [TestClass]
    public class TreningTest
    {
         Trening t;
        [TestInitialize]
        public void Postavi()
        {
            List<int> minutazaAktivnosti = new List<int>();
            Aktivnost a1 = new Aktivnost();
            a1.Naziv = "Trčanje";
            a1.UtrosakKalorija = 345;
            minutazaAktivnosti.Add(60);
            List<Aktivnost> aktivnosti = new List<Aktivnost>();
            aktivnosti.Add(a1);
            Aktivnost a2 = new Aktivnost();
            a2.Naziv = "Rolanje";
            a2.UtrosakKalorija = 250;
            minutazaAktivnosti.Add(60);
            aktivnosti.Add(a2);
            t = new Trening("Trening 1", minutazaAktivnosti, aktivnosti);
        }
        [TestCleanup]
        public void Obrisi()
        {
            t = null;
        }
        [TestMethod]
        public void NazivTest()
        {
            Assert.AreEqual("Trening 1", t.NazivTreninga);
        }
        [TestMethod]
        public void AktivnostiTest()
        {
            Assert.AreEqual(2, t.Aktivnosti.Count);
            Assert.AreEqual("Trčanje", t.Aktivnosti[0].Naziv);
            Assert.AreEqual("Rolanje", t.Aktivnosti[1].Naziv);
        }
        [TestMethod]
        public void VrijednostMinutazeTest()
        {
            Assert.AreEqual(60, t.MinutazaAktivnosti[0]);
            Assert.AreEqual(60, t.MinutazaAktivnosti[1]);
        }
        [TestMethod]
        public void UtrosakKalorijaPoTreninguTest()
        {
            Assert.AreEqual(595, t.GetUtrošakKaorijaPoTreningu());
        }
    }
}
