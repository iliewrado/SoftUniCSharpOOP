using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitCar car;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            car = new UnitCar("Fiat", 50, 1500);
            driver = new UnitDriver("Pesho", car);
        }

        [Test]
        public void TestAddWithInvalidDriver()
        {
            driver = null;
            Assert.Throws<InvalidOperationException>
                (() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddThrowExceptionSameDriver()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>
                (() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void CountTest()
        {
            raceEntry.AddDriver(driver);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void AddCorrectDriver()
        {
            Assert.AreEqual(raceEntry.AddDriver(driver),
                "Driver Pesho added in race.");
        } 

        [Test]
        public void HorsePowerThrowExceptionNotEnoughtRacers()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>
                (() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            raceEntry.AddDriver(driver);
            UnitCar unitCar = new UnitCar("500", 50, 1500);
            UnitDriver unitDriver = new UnitDriver("Gosho", unitCar);
            raceEntry.AddDriver(unitDriver);
            Assert.AreEqual(raceEntry.CalculateAverageHorsePower(), 50);
        }
    }
}