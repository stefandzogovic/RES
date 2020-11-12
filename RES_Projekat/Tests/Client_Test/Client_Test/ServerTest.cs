using Client;
using Common;
using Newtonsoft.Json;
using NUnit.Framework;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Client_Test
{
    [TestFixture]
    public class ServerTest
    {
        private static Serverr s;
        private static Clientt c;
        private static ClientFactory cf;
        private static Konzola1 k;

        [SetUp]
        public void setup()
        {
            c = new Clientt();
            cf = new ClientFactory();
            s = new Serverr(cf, null);
            k = new Konzola1();
        }

        [Test]
        public void IzaberiClienta_Test()
        {
            Clientt klijent = new Clientt("str");
            s.klijenti.Add(klijent.Naziv_klijenta, klijent);
            Assert.AreEqual(s.IzaberiClienta(k, klijent), klijent);
        }

        [Test]
        public void IzaberiClienta_Test1()
        {
            Clientt klijent = new Clientt("drugacije");
            s.klijenti.Add(klijent.Naziv_klijenta, klijent);
            Assert.AreEqual(s.IzaberiClienta(k, klijent), klijent);
        }

        [Test]
        public void KreirajKlijenta_Test()
        {
            Clientt c = new Clientt();
            c = s.Kreiraj_klijenta(k);
            Clientt c1 = new Clientt("str");
            c1.Model = new Model(1);
            c1.ModelId = c1.Model.Id;
            Assert.AreEqual(JsonConvert.SerializeObject(c), JsonConvert.SerializeObject(c1));
        }

        [Test]
        public void IscitajIzBazeNaPocetku()
        {

        }

    }

    public class Konzola1 : ConsoleWrapper
    {

        public override string ReadLine()
        {
            return "str";
        }

        public override void WriteLine(string message)
        {
        }
    }
}
