using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Common_Test
{
    [TestFixture]
    public class MyTuple_Test
    {
        private MyTuple<string, string> tuple;

        [Test]
        [TestCase("Sombe1","Sombe2")]
        [TestCase(null,"Dzogovic2")]
        [TestCase(null,null)]
        public void MyTuple_Test_AreEquealTrue(string s1,string s2)
        {
            tuple = new MyTuple<string, string>(s1, s2);
            Assert.AreEqual(s1, tuple.Item1);
            Assert.AreEqual(s2, tuple.Item2);
        }
        
    }
}
