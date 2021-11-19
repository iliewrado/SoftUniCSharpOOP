using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        Person pesho = new Person(123, "Pesho");
        Person gosho = new Person(456, "Gosho");
        Person tosho = new Person(789, "Todor");
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            Person[] people = new Person[] { pesho, gosho };
            database = new ExtendedDatabase(people);
        }

        [Test]
        public void CountTest()
        {
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void CtorThrowsExeptionAddTooManyPeople()
        {
            Person[] manyPeople = new Person[18];
            for (int i = 0; i < 18; i++)
            {
                manyPeople[i] = new Person(i, $"Gosh{i}");
            }
            
            Assert.That(() => database = new 
            ExtendedDatabase(manyPeople),
                Throws.ArgumentException);
        }

        [Test]
        public void AddPropperPerson()
        {
            database.Add(tosho);
            Assert.AreEqual(database.Count, 3);
        }

        [Test]
        public void AddTrowsExeptionDataIsFull()
        {
            Person[] manyPeople = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                manyPeople[i] = new Person(i, $"Pesh{i}");
            }
            
            database = new ExtendedDatabase(manyPeople);

            Assert.That(() => database.Add(tosho), Throws.InvalidOperationException);
        }

        [Test]
        public void AddThrowsExeptionExistingPerson()
        {
            Person gosho1 = new Person(789, "Gosho");

            Assert.That(() => database.Add(gosho1), Throws.InvalidOperationException);
        }
        
        [Test]
        public void AddThrowsExeptionExistingId()
        {
            Person tosho = new Person(123, "Todor");
            Assert.That(() => database.Add(tosho), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovingPerson()
        {
            database.Remove();
            Assert.AreEqual(database.Count, 1);
        }

        [Test]
        public void ThrowsExseptinBaseIsEmpty()
        {
            database.Remove();
            database.Remove();
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void FindsPersonByName()
        {
            Assert.AreEqual(database.FindByUsername("Gosho"), gosho);
        }

        [Test]
        public void ThrowsExeptionNullEmpryName()
        {
            Assert.That(() => database.FindByUsername(string.Empty),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExeptionNoSuchName()
        {
            Assert.That(() => database.FindByUsername("Tosho"), 
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindsUserByID()
        {
            Assert.AreEqual(database.FindById(123), pesho);
        }

        [Test]
        public void ThorowsExeptionInvalidID()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-3));
        }

        [Test]
        public void ThrowsExeptionNoSuchID()
        {
            Assert.That(() => database.FindById(8910), Throws.InvalidOperationException);
        }
    }
}