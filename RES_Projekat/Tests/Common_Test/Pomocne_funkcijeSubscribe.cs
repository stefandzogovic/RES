using Client;
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
    public class Pomocne_funkcijeSubscribe_Test
    {
        private static Pomocne_funkcijeSubscribe pfs;
        private static MyTupleFactory mtf;
        private static QueueFactory qf;

        [SetUp]
        public void setup()
        {
            pfs = new Pomocne_funkcijeSubscribe(mtf, qf);
            mtf = new MyTupleFactory();
            qf = new QueueFactory();
        }

        [Test]
        public void Pomocne_funkcijeSubscribe_Test1()
        {
            Assert.IsNotNull(pfs);
        }

        [Test]
        public void Enqueue_TestTrue()
        {
            Queue q = new Queue();

            string str = "a";
            Assert.IsTrue(pfs.Enqueue(q, str));
        }

        [Test]
        public void Enqueue_TestFalse()
        {
            Queue q = new Queue();
            q.Enqueue("str");
            string str = "a";
            Assert.IsFalse(pfs.Enqueue(q, str));
        }



        [Test]
        public void Dequeue_TestTrue()
        {
            Queue q = new Queue();
            q.Enqueue("str");
            Queue q1 = new Queue();
            q1.Enqueue("str");

            Assert.AreEqual(pfs.Dequeue(q), q1.Dequeue());
        }

        [Test]
        public void Dequeue_TestFalse()
        {
            Queue q = new Queue();
            Queue q1 = new Queue();

            Assert.AreEqual(pfs.Dequeue(q), "Queue is empty");
        }

        /* [Test]
         public void Izaberi_Test()
         {
             MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> t = new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>();
             MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> t2 = new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>();

             Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
             Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict2 = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();


             dict.Add("str", t);
             dict2.Add("str", t2);
             Assert.AreEqual(JsonConvert.SerializeObject(pfs.Izaberi(dict, "loby", k1)),JsonConvert.SerializeObject(t2));
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
     */
    }
}