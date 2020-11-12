using Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture()]
    public class ClientFactoryTest
    {
        [Test]
        [TestCase()]
        public void ClientCreateNewTest()
        {
            var clientFactory = new ClientFactory();

            var client = clientFactory.ClientCreateNew("pera");

            Assert.That(client.Naziv_klijenta, Is.EqualTo("pera"));
        }
    }
}
