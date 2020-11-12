using Client;
using Client.Pomocne_funkcijeUpdate;
using Common;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Metode_Test
{
    [TestFixture]
    public class UpdateTest
    {
        private static Pomocne_funkcijeUpdate pfu;
        private static MyTupleFactory mtf = new MyTupleFactory();
        private static QueueFactory qf = new QueueFactory();
        private static Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict;
        private static Konzola1 konzola;
        private static Konzola2 konzola2;
        private static List<Item> lista;


        [SetUp]
        public void setup()
        {
            konzola = new Konzola1();
            konzola2 = new Konzola2();
            lista = new List<Item>();
            pfu = new Pomocne_funkcijeUpdate();
            mtf = new MyTupleFactory();
            qf = new QueueFactory();
            dict = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
        }

        [Test]
        [TestCase("string")]
        public void Enqueue_Test_False(string str)
        {
            Queue q = new Queue();
            q.Enqueue(str);
            Assert.IsFalse(pfu.Enqueue(q, str));
        }

        [Test]
        [TestCase("string")]
        public void Enqueue_Test_True(string str)
        {
            Queue q = new Queue();
            Assert.IsTrue(pfu.Enqueue(q, str));
        }

        [Test]
        public void TestAddItemAktiviranTrue()
        {
            Item item = new Item("12", 12, true, 12);

            Assert.AreEqual(JsonConvert.SerializeObject( item), JsonConvert.SerializeObject( pfu.DodajItem(konzola)));
        }

        [Test]
        public void TestAddItemAktiviranFalse()
        {
            Item item = new Item("12", 12, false, 12);

            Assert.AreEqual(JsonConvert.SerializeObject(item), JsonConvert.SerializeObject(pfu.DodajItem(konzola2)));
        }

        [Test]
        public void TestIzmeniItemNull()
        {
            Item item = new Item("12", 12, true, 12);

            lista.Add(new Item("Dzoga", 21, false, 24));
            lista.Add(new Item("12", 128, true, 890));

            Assert.AreNotEqual(item, lista[1]);
            lista[1] = pfu.IzmeniItem(lista, konzola);

            Assert.IsNull(lista[1]);


        }




    }

    public class Konzola1 : ConsoleWrapper
    {


        public override void WriteLine(string message)
        {
        }

        public override string ReadLine()
        {
            return "12";
        }

        public override ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo('Y', ConsoleKey.Y, false, false, false);
        }
    }

    public class Konzola2 : ConsoleWrapper
    {


        public override void WriteLine(string message)
        {
        }

        public override string ReadLine()
        {
            return "12";
        }

        public override ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo('N', ConsoleKey.N, false, false, false);
        }
    }
}
