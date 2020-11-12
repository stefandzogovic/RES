using Client;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Client_Test
{
    public class ConsoleWrapper_Test : ConsoleWrapper
    {
        ConsoleWrapper cw = new ConsoleWrapper();
        public override ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo('R', ConsoleKey.R, false, false, false);
        }


        [Test]
        [TestCase("naziv")]
        public void ConsoleWrapper_Write_IsNotNull(string naziv)
        {
            cw.Write(naziv);
            Assert.IsNotNull(cw);
        }

        [Test]
        [TestCase("naziv")]
        public void ConsoleWrapper_WriteLine_IsNotNull(string naziv)
        {
            cw.WriteLine(naziv);
            Assert.IsNotNull(cw);
        }

        [Test]
        [TestCase('R')]
        public void ConsoleWrapper_ReadKey_Test(char r)
        {

            Assert.AreEqual(r, ReadKey().KeyChar);
        }


    }
}
