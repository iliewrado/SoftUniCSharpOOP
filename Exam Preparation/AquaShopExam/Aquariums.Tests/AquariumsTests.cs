namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;


        [SetUp]
        [Test]
        public void CorrectCtorTest()
        {
            aquarium = new Aquarium("Aqua", 2);
            Assert.IsNotNull(aquarium);
            Assert.AreEqual(aquarium.Name, "Aqua");
            Assert.AreEqual(aquarium.Capacity, 2);
        }

        [Test]
        public void IncorrectName()
        {
            Assert.Throws<ArgumentNullException>
                (() => aquarium = new Aquarium(string.Empty, 2));
        }

        [Test]
        public void incorrectCapacity()
        {
            Assert.Throws<ArgumentException>
                (() => aquarium = new Aquarium("NoAqua", -1));
        }

        [Test]
        public void CorrectCountAndAddTest()
        {
            aquarium.Add(new Fish("Nemo"));
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void FullAQuariumTest()
        {
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Pesho"));
            Assert.Throws<InvalidOperationException>
                (() => aquarium.Add(new Fish("Gosho")));
        }

        [Test]
        public void CorrectFishRemove()
        {
            aquarium.Add(new Fish("Nemo"));
            aquarium.RemoveFish("Nemo");
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void IncorrectFishNameToRemove()
        {
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>
                (() => aquarium.RemoveFish("Nino"));
        }

        [Test]
        public void CorrectSellFishTest()
        {
            Fish nemo = new Fish("Nemo");
            aquarium.Add(nemo);
            Assert.AreEqual(aquarium.SellFish("Nemo"), nemo);
        }

        [Test]
        public void IncorrectFishNameToSell()
        {
            Fish nemo = new Fish("Nemo");
            aquarium.Add(nemo);
            Assert.Throws<InvalidOperationException>
                (() => aquarium.SellFish("Nino"));
        }

        [Test]
        public void ReportTest()
        {
            aquarium.Add(new Fish("Nemo"));
            Assert.AreEqual(aquarium.Report(), "Fish available at Aqua: Nemo");
        }
    }
}
