namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present Present;
        private Bag Bag;
        [SetUp]
        [Test]
        public void CtorTest()
        {
            Bag = new Bag();
            Assert.IsNotNull(Bag);
            Present = new Present("Happy", 100);
        }

        [Test]
        public void CreateinvalidPresent()
        {
            Present present = null;
            Assert.Throws<ArgumentNullException>
                (() => Bag.Create(present));
        }

        [Test]
        public void InvalidAddSamePresent()
        {
            Bag.Create(Present);
            Assert.Throws<InvalidOperationException>
                (() => Bag.Create(Present));
        }

        [Test]
        public void CreatePresent()
        {
            Bag.Create(Present);
            
        }

        [Test]
        public void RemoveTest()
        {
            Bag.Create(Present);
            Assert.AreEqual(Bag.Remove(Present), true);
        }

        [Test]
        public void GetPresentByName()
        {
            Bag.Create(Present);
            Assert.AreEqual(Bag.GetPresent("Happy"), Present);
        }

        [Test]
        public void LowMagicPresentTest()
        {
            Present present = new Present("Magic", 90);
            Bag.Create(present);
            Bag.Create(Present);
            Assert.AreEqual(Bag.GetPresentWithLeastMagic(), present);
        }

        [Test]
        public void GetAllColection()
        {
            Bag backPack = new Bag();
            backPack.Create(Present);
            Present present = new Present("Magic", 90);
            Bag.Create(Present);
            Bag.Create(present);
            backPack.Create(present);
            Assert.AreEqual(Bag.GetPresents(), backPack.GetPresents());
        }
    }
}
