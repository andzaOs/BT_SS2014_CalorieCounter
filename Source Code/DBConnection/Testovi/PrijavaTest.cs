using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConnection;

namespace DBConnection.Testovi
{
    [TestClass]
    public class PrijavaTest
    {
        Prijava p;
        [TestInitialize]
        public void Postavi()
        {
            p = new Prijava("anela", "anela");
        }
        [TestCleanup]
        public void Obrisi()
        {
            p = null;
        }
        [TestMethod]
        public void KorisnickoImeTest()
        {
            Assert.AreEqual("anela", p.KorisnickoIme);
        }
        [TestMethod]
        public void LozinkaTest()
        {
            Assert.AreEqual("anela", p.Sifra);
        }
    }
}
