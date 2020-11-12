using Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Client_Test
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void Item_TestConst()
        {
            Item i = new Item();
            Assert.NotNull(i);
        }

        [Test]
        [TestCase("Naziv1", 123, false, 32)]
        [TestCase("Naziv2", 444444, true, 325)]
        [TestCase("Naziv3", 123, true, 450)]
        public void ItemDobriParametri(string naz, int kol, bool akt, int raz)
        {
            Item i = new Item(naz, kol, akt, raz);
            Assert.AreEqual(i.Naziv, naz);
            Assert.AreEqual(i.Kolicina, kol);
            Assert.AreEqual(i.Aktiviran, akt);
            Assert.AreEqual(i.Razorna_moc, raz);
        }

        [Test]
        [TestCase("", 123, false, 32)]
        [TestCase("Naziv2", 444444, true, -325)]
        [TestCase("Naziv3", -123, true, 450)]
        [TestCase("Naziv3", 0, true, 0)]
        public void ItemLosiParametri(string naz, int kol, bool akt, int raz)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Item i = new Item(naz, kol, akt, raz);
            }
            );
        }

        [Test]
        [TestCase(null, 123, false, 32)]
        public void NazivNull(string naz, int kol, bool akt, int raz)
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Item i = new Item(naz, kol, akt, raz);
            }
            );
        }

    }
}
