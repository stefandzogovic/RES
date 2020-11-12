﻿using Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Client_Test
{
    [TestFixture]
    public class Clientt_Test
    {
        [Test]
        public void Clientt_IsNotNull()
        {
            string naziv = "naz";
            Clientt c = new Clientt(naziv);
            Assert.IsNotNull(c.Naziv_klijenta);
        }

        [Test]
        public void Clientt_IsNotNullConst()
        {
            Clientt c = new Clientt();
            Assert.IsNotNull(c);
        }

        [Test]
        public void ClientFactory_IsNotNull()
        {
            ClientFactory cf = new ClientFactory();
            Clientt c = new Clientt("naziv");
            Assert.IsNotNull(cf.ClientCreateNew("naz"));
        }
    }
}
