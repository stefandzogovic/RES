using Client;
using Common;
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
    public class MetodeTest
    {
        private static ClientFactory cf;
        private static Serverr server;
        private static Konzola konzola;
        private static Metode m;
        private static MyTupleFactory mytuplefactory;
        private static QueueFactory queueFactory;
        private static Pomocne_funkcijeCreate pfc;
        private static Clientt client;

        [SetUp]
        public void TestSetup()
        {
            cf = new ClientFactory();
            server = new Serverr(cf, null);
            konzola = new Konzola();
            m = new Metode(server, konzola);
            mytuplefactory = new MyTupleFactory();
            queueFactory = new QueueFactory();
            pfc = new Pomocne_funkcijeCreate(mytuplefactory, queueFactory);
            client = new Clientt("Klijent");
        }


        [Test]
        public void TestCreateReturnTrue()
        {
            Assert.IsTrue(m.Create(pfc, client));
            
        }

        [Test]
        public void TestCreateReturnFalse()
        {
            server.lista_klijentskih_redova.Add("Str", new MyTuple<MyTuple<string, System.Collections.Queue>, MyTuple<string, System.Collections.Queue>>());
            Assert.IsFalse(m.Create(pfc, client));
        }

        [Test]
        public void TestCreateNazivTrenutnog()
        {
            Clientt c = new Clientt("Klijent");
            c.Model = new Model();
            c.Naziv_trenutnog_lobbyja = "Str";
            Clientt c1 = new Clientt("Klijentela");
            c.Naziv_trenutnog_lobbyja = "Str";
            c1.Model = new Model();
            c.Model.Clients.Add(c1);
            c1.Model.Clients.Add(c);
            server.klijenti.Add(c.Naziv_klijenta, c);
            server.klijenti.Add(c1.Naziv_klijenta, c);
            Assert.IsTrue(m.Create(pfc, c));
        }

        [TearDown]
        public void TearDown()
        {
            cf = null;
            server = null;
            konzola = null;
            m = null;
            mytuplefactory = null;
            queueFactory = null;
            pfc = null;
            client = null;
        }



    }

    public class Konzola : ConsoleWrapper
    {


        public override void WriteLine(string message)
        {
        }

        public override string ReadLine()
        {
            return "Str";
        }
    }
}
