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
using Tests.Client_Test.Client_Test;

namespace Tests.Client_Test.Metode_Test
{
    [TestFixture]
    public class SubscribeTest
    {
        private static ClientFactory cf;
        private static Serverr server;
        private static Konzola konzola;
        private static Metode m;
        private static MyTupleFactory mytuplefactory;
        private static QueueFactory queueFactory;
        private static Pomocne_funkcijeSubscribe pfs;
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
            pfs = new Pomocne_funkcijeSubscribe(mytuplefactory, queueFactory);

        }

        [Test]
        public void SubscribeGood()
        {
            client = new Clientt("Klijent");
            client.Model = new Model(1);
            client.Trenutan_lobby = new MyTuple<MyTuple<string, System.Collections.Queue>, MyTuple<string, System.Collections.Queue>>();
            client.Naziv_trenutnog_lobbyja = "lobby";
            server.lista_klijentskih_redova.Add("lobby", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("lobbyA", queueFactory), mytuplefactory.CreateNewMyTuple("lobbyB", queueFactory)));
            server.lista_klijentskih_redova.Add("32", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("32A", queueFactory), mytuplefactory.CreateNewMyTuple("32B", queueFactory)));
            Clientt client1 = new Clientt("Klijent");
            client1.Model = new Model(1);
            client1.Trenutan_lobby = server.lista_klijentskih_redova["32"];
            client1.Naziv_trenutnog_lobbyja = "32";

            
            Assert.AreEqual(JsonConvert.SerializeObject(client1), JsonConvert.SerializeObject(m.Subscribe(pfs, client.Naziv_trenutnog_lobbyja, client.Id, client.Model, client.Naziv_klijenta, false)));
        }


        [Test]
        public void SubscribeNull()
        {
            client = new Clientt("Klijent");
            client.Model = new Model(1);
            client.Trenutan_lobby = new MyTuple<MyTuple<string, System.Collections.Queue>, MyTuple<string, System.Collections.Queue>>();
            client.Naziv_trenutnog_lobbyja = "lobby";

         

            Assert.IsNull(m.Subscribe(pfs, client.Naziv_trenutnog_lobbyja, client.Id, client.Model, client.Naziv_klijenta, false));
        }
        /*
        [Test]
        public void TestAddToModelClients()
        {
            client = new Clientt("Klijent");
            client.Model = new Model(1);
            client.Trenutan_lobby = new MyTuple<MyTuple<string, System.Collections.Queue>, MyTuple<string, System.Collections.Queue>>();
            client.Naziv_trenutnog_lobbyja = "lobby";
            server.lista_klijentskih_redova.Add("lobby", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("lobbyA", queueFactory), mytuplefactory.CreateNewMyTuple("lobbyB", queueFactory)));
            server.lista_klijentskih_redova.Add("32", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("32A", queueFactory), mytuplefactory.CreateNewMyTuple("32B", queueFactory)));

            Clientt client2 = new Clientt("Klijentela");
            client2.Model = new Model(1);
            client2.Trenutan_lobby = server.lista_klijentskih_redova["32"];
            client2.Naziv_trenutnog_lobbyja = "32";

            server.klijenti.Add(client.Naziv_klijenta, client);
            server.klijenti.Add(client2.Naziv_klijenta, client2);

            Assert.Contains(client2, m.Subscribe(pfs, client.Naziv_trenutnog_lobbyja, client.Id, client.Model, client.Naziv_klijenta, false).Model.Clients);

        }

        [Test]
        public void TestResubScribe()
        {
            server.lista_klijentskih_redova.Add("lobby", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("lobbyA", queueFactory), mytuplefactory.CreateNewMyTuple("lobbyB", queueFactory)));
            server.lista_klijentskih_redova.Add("32", mytuplefactory.CreateNewMyTuple1(mytuplefactory.CreateNewMyTuple("32A", queueFactory), mytuplefactory.CreateNewMyTuple("32B", queueFactory)));

            client = new Clientt("Klijent");
            client.Model = new Model(1);
            client.Trenutan_lobby = server.lista_klijentskih_redova["lobby"];
            client.Naziv_trenutnog_lobbyja = "lobby";

            Clientt client2 = new Clientt("Klijentela");
            client2.Model = new Model(1);
            client2.Trenutan_lobby = server.lista_klijentskih_redova["lobby"];
            client2.Naziv_trenutnog_lobbyja = "lobby";

            server.klijenti.Add(client.Naziv_klijenta, client);
            server.klijenti.Add(client2.Naziv_klijenta, client2);



            Assert.IsFalse(m.Subscribe(pfs, client.Naziv_trenutnog_lobbyja, client.Id, client.Model, client.Naziv_klijenta, true).Model.Clients.Contains(client2));

        }
        */
    }

    public class Konzola : ConsoleWrapper
    {


        public override void WriteLine(string message)
        {
        }

        public override string ReadLine()
        {
            return "32";
        }
    }
}
