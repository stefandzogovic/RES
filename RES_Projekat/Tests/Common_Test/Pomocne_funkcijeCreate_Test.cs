using Common;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Common_Test
{
    [TestFixture]
    public class Pomocne_funkcijeCreate_Test
    {
        private static Pomocne_funkcijeCreate pf;
        private static MyTupleFactory mtf = new MyTupleFactory();
        private static QueueFactory qf = new QueueFactory();
        private static Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict;

        [SetUp]
        public void setup()
        {
            mtf = new MyTupleFactory();
            qf = new QueueFactory();
            dict = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
        }

        [Test]
        public void Pomocne_funkcijeCreate_Test_IsNotNull()
        {
            pf = new Pomocne_funkcijeCreate(mtf, qf);
            Assert.IsNotNull(pf);
        }

        [Test]
        public void Jedinstvenost_Test_True()
        {
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            dict.Add("kljuc", new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>());
            Assert.IsTrue(pfc.Jedinstvenost("kljuc", dict));
        }

        [Test]
        [TestCase("")]
        public void Jedinstvenost_Test_EmptyString(string str)
        {
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict1 = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
            Assert.Throws<ArgumentException>(() =>
            {
                pfc.Jedinstvenost(str, dict1);
            });
        }

        [Test]
        [TestCase(null)]
        public void Jedinstvenost_Test_NullString(string str)
        {
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict1 = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
            Assert.Throws<ArgumentNullException>(() =>
            {
                pfc.Jedinstvenost(str, dict1);

            });
        }

        [Test]

        public void Jedinstvenost_Test_False()
        {
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            dict.Add("kljuc", new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>());
            Assert.IsFalse(pfc.Jedinstvenost("k", dict));

        }

        [Test]
        [TestCase("naziv")]
        public void CreateClientQueues_Test(string str)
        {
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> tu = new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>();
            tu = pfc.CreateClientQueues(str);

            MyTuple<string, Queue> tupleA = mtf.CreateNewMyTuple(str + "A", qf);
            MyTuple<string, Queue> tupleB = mtf.CreateNewMyTuple(str + "B", qf);
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> tuple = mtf.CreateNewMyTuple1(tupleA, tupleB);


            Assert.AreEqual(JsonConvert.SerializeObject(tu), JsonConvert.SerializeObject(tuple));

        }

        [Test]
        [TestCase("Client:Dzoga  sent: Create Queue (naz)")]
        public void CreateServerQueuePair_Test(string q)
        {
            Queue red = new Queue();
            red.Enqueue(q);
            Queue red2 = new Queue();
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Client_server_queues = pfc.CreateServerQueuePair(red, red2);
            Assert.AreEqual(JsonConvert.SerializeObject(Client_server_queues), JsonConvert.SerializeObject(pfc.CreateClientQueues("Servernaz")));
        }

        [Test]
        [TestCase("string")]
        public void Enqueue_Test_False(string str)
        {
            Queue q = new Queue();
            q.Enqueue(str);
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            Assert.IsFalse(pfc.Enqueue(q, str));
        }

        [Test]
        [TestCase("string")]
        public void Enqueue_Test_True(string str)
        {
            Queue q = new Queue();
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            Assert.IsTrue(pfc.Enqueue(q, str));
        }

        [Test]
        public void Dequeue_Test_String()
        {
            string str = "str";
            Queue q = new Queue();
            q.Enqueue(str);
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            var s = pfc.Dequeue(q);
            Assert.AreEqual(s.GetType(), str.GetType());
            Assert.AreEqual(s, str);
        }

        [Test]
        public void Dequeue_Test_Tuple()
        {
            Tuple<string, string> t = new Tuple<string, string>("naz1", "naz");
            Queue q = new Queue();
            q.Enqueue(t);
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            var s = pfc.Dequeue(q);
            Assert.AreEqual(s.GetType(), t.GetType());
            Assert.AreEqual(s, t);
        }

        [Test]
        public void Dequeue_Test_EmptyQueue()
        {
            Queue q = new Queue();
            Pomocne_funkcijeCreate pfc = new Pomocne_funkcijeCreate(mtf, qf);
            var s = pfc.Dequeue(q);
            Assert.AreEqual(s, "Queue is empty");
        }
    }
}
