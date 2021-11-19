using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 10, 20 };

        [SetUp]
        public void Setup()
        {
            database = new Database(initialData);
        }

        [Test]
        public void CtorThrowsExeption()
        {
            Assert.Throws<InvalidOperationException>(() => database =
            new Database( 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 ));
        }

        [Test]
        public void CountTest()
        {
            Assert.That(database.Count, Is.EqualTo(initialData.Length));
        }
        [Test]
        public void AddingElement()
        {
            database.Add(30);
            Assert.AreEqual(database.Count, initialData.Length + 1);
        }
        [Test]
        public void ThrowsExeptionWhenAddingElement()
        {
            for (int i = database.Count; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.That(() => database.Add(30), Throws.InvalidOperationException);
        }
        [Test]
        public void ProperRemove()
        {

            database.Remove();
            Assert.AreEqual(database.Count, initialData.Length - 1);
        }
        [Test]
        public void ExeptionWhenRemoveTest()
        {
            for (int i = database.Count; i > 0; i--)
            {
                database.Remove();
            }
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void FletchTest()
        {
            int[] result = database.Fetch();
            Assert.AreEqual(result, initialData);
        }
    }
}