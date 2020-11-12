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
    public class Position_Test
    {
        private static Position position1;
        private static Position position2;
        double x = 1;
        double y = 2;
        double z = 3;

        [SetUp]
        public void setup()
        {
            position1 = new Position();
            position2 = new Position(x, y, z);
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void Model_Test_NotNull(double x1, double y1, double z1)
        {
            position2.X = x1;
            position2.Y = y1;
            position2.Z = z1;

            Assert.NotNull(position2);
        }

        [Test]
        public void Model_Test_NotNull2()
        {
            Assert.NotNull(position1);
        }
    }
}
