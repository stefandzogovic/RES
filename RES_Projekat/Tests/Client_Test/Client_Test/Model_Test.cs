using Client;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Client_Test.Client_Test
{
    [TestFixture]
    public class Model_Test
    {
        private static Model position1;
        private static Model model2;
        int id = 0;

        [SetUp]
        public void setup()
        {
            position1 = new Model();
            model2 = new Model(id);
        }

        [Test]
        [TestCase(2)]
        public void Model_Test_NotNull(int id)
        {
            position1.Id = id;
            Assert.NotNull(position1);
        }

        [Test]
        public void Model_Test_NotNull2()
        {
            Assert.NotNull(position1);
        }

        [Test]
        [TestCase(2)]
        public void Model_Test_NotNullConst(int id)
        {
            model2.Id = id;
            Assert.AreEqual(model2.Id, id);
        }

        [Test]
        [TestCase(1)]
        public void ModelFactory_Test(int id)
        {
            ModelFactory mf = new ModelFactory();
            Model m = new Model(id);
            Assert.AreEqual(JsonConvert.SerializeObject(mf.CreateNewModel(id)), JsonConvert.SerializeObject(m));
        }
    }
}
