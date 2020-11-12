using Client;
using Client.Pomocne_funkcijeUpdate;
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
    public class Meni_Test
    {
        private static Meni meni;
        private static Pomocne_funkcijeUpdate pfu;
        private static Pomocne_funkcijeCreate pfc;
        private static Pomocne_funkcijeSubscribe pfs;
        private static MyTupleFactory mtf;
        private static QueueFactory qf;
        private static ClientFactory cf;
        private static Serverr srv;


        [SetUp]
        public void setup()
        {
            mtf = new MyTupleFactory();
            qf = new QueueFactory();
            pfc = new Pomocne_funkcijeCreate(mtf, qf);
            pfs = new Pomocne_funkcijeSubscribe(mtf, qf);
            pfu = new Pomocne_funkcijeUpdate();
            meni = new Meni(pfc, pfs, pfu);
            cf = new ClientFactory();
            srv = new Serverr(cf, null);
        }

        [Test]
        public void Meni_Test1()
        {
            Assert.IsNotNull(meni);
        }

        /*[Test]
        public void Register_Test()
        {
            Clientt c = new Clientt();
            Metode m = new Metode(srv,k);
            Assert.AreNotEqual(c, meni.Register(c, k, m));
                
        }
        */

    }


}
