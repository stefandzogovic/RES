using Common;
using Moq;
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
    public class MyTupleFactory_Test
    {
        private static MyTupleFactory mtf;
        private static MyTuple<string, Queue> mt ;
        private static QueueFactory qf;



        private static QueueFactory getObject1(string key)
        {
            if (key == "qf1")
                return qf;

            throw new ArgumentException("Unknown key");
        }


        private static MyTuple<string, Queue> getObject2(string key, string str)
        {
            if (key == "qf2")
                return new MyTuple<string, Queue>(str, new Queue());

            throw new ArgumentException("Unknown key");
        }

                private static MyTuple<string, Queue> getObject3(string key, string str)
        {
            if (key == "qf3")
                return new MyTuple<string, Queue>(str, new Queue());

            throw new ArgumentException("Unknown key");
        }

        [Test]
        [TestCase("String", "qf1")]
        public void CreateNewMyTuple_True(string str, string queueF)
        {
            mtf = new MyTupleFactory();
            mt = new MyTuple<string, Queue>("String", new Queue());
            QueueFactory qf = getObject1(queueF);
            MyTuple<string, Queue> sd = mtf.CreateNewMyTuple(str, qf);
            Assert.AreEqual(sd.Item1, mt.Item1);
            Assert.AreEqual(mt.Item2, sd.Item2);
        }

        [Test]
        [TestCase("String", "sd")]
        public void CreateNewMyTuple_BadKey(string str, string queueF)
        {
            mtf = new MyTupleFactory();
            mt = new MyTuple<string, Queue>("String", new Queue());
            qf = new QueueFactory();
            Assert.Throws<ArgumentException>(() => {
                QueueFactory qf = getObject1(queueF);
            });

        }

        [Test]
        [TestCase("qf2", "qf3", "String1", "String2")]
        public void CreateNewMyTuple_(string queueF1, string queueF2, string str1, string str2)
        {
            mtf = new MyTupleFactory();
            MyTuple<string, Queue> mt1 = new MyTuple<string, Queue>("String1", new Queue());
            MyTuple<string, Queue> mt2 = new MyTuple<string, Queue>("String2", new Queue());
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> sd = mtf.CreateNewMyTuple1(getObject2(queueF1, str1), getObject3(queueF2, str2));
            Assert.AreEqual(sd.Item1.Item1, mt1.Item1);
            Assert.AreEqual(sd.Item1.Item2, mt1.Item2);
            Assert.AreEqual(sd.Item2.Item1, mt2.Item1);
            Assert.AreEqual(sd.Item2.Item2, mt2.Item2);
        }

        [Test]
        public void CreateNewMyTuple_T()
        {
            Assert.Throws<ArgumentException>(() => {
                QueueFactory qf = getObject1("k");
            });
            Assert.Throws<ArgumentException>(() => {
                MyTuple<string, Queue> qf1 = getObject2("k","f");
            });
            Assert.Throws<ArgumentException>(() => {
                MyTuple<string, Queue> qf2 = getObject3("novo","staro");
            });
        }
    }
}
