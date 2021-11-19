using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private const string make = "Fiat";

        private const string model = "Bravo";

        private const double fuelConsumption = 10.0;

        private const double fuelAmount = 20.0;

        private double fuelCapacity = 50.0;

        private Car testCar;

        [SetUp]
        public void Setup()
        {
            testCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CarExeptionInvalidModel()
        {
            Assert.Throws<ArgumentException>(() => testCar = 
            new Car(make, string.Empty, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarThrowsExeptionInvalidMake()
        {
            Assert.Throws<ArgumentException>(() => testCar =
            new Car(string.Empty, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarThrowsExeptionInvalidFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => testCar =
            new Car(make, model, 0, fuelCapacity));
        }

        [Test]
        public void CarThrowsExeptionInvalidFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => testCar =
            new Car(make, model, fuelConsumption, 0));
        }

        [Test]
        public void RefuelCorrect()
        {
            testCar.Refuel(fuelAmount);
            Assert.AreEqual(testCar.FuelAmount, fuelAmount);
        }

        [Test]
        public void CarThrowsExeptionInvalidFuelAmount()
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(0));
        }

        [Test]
        public void CarFillUp()
        {
            testCar.Refuel(60);
            Assert.AreEqual(testCar.FuelAmount, fuelCapacity);
        }

        [Test]
        public void CorrectDriving()
        {
            testCar.Refuel(fuelAmount);
            testCar.Drive(100);
            Assert.AreEqual(testCar.FuelAmount, 10);
        }

        [Test]
        public void CarThrowsExeptionNotEnoughFuel()
        {
            testCar.Refuel(fuelAmount);
            Assert.Throws<InvalidOperationException>(() =>
            testCar.Drive(500));
        }
    }
}