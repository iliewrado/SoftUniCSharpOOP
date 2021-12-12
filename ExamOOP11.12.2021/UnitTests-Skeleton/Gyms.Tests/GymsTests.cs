using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete;
        [SetUp]
        public void SetUp()
        {
            gym = new Gym("Fit", 3);
            athlete = new Athlete("Pesho");
        }

        [Test]
        public void InitialTest()
        {
            Assert.IsNotNull(gym);
            Assert.IsNotNull(athlete);
            Assert.AreEqual(gym.Capacity, 3);
        }

        [Test]
        public void CountTest()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(gym.Count, 1);
        }

        [Test]
        public void InvalidCapacity()
        {
            Assert.Throws<ArgumentException>
                (() => gym = new Gym("Fit", -3));
        }

        [Test]
        public void InvalidName()
        {
            Assert.Throws<ArgumentNullException>
                (() => gym = new Gym(null, 3));
        }

        [Test]
        public void GymSizeFullException()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>
                (() => gym.AddAthlete(athlete));
        }
        
        [Test]
        public void RemoveAthlete()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Pesho");
            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void RemoveThrowException()
        {
            Assert.Throws<InvalidOperationException>
                (() => gym.RemoveAthlete("Gosho"));
        }

        [Test]
        public void InjureAthleteTest()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(gym.InjureAthlete("Pesho"), athlete);
        }

        [Test]
        public void InvalidInjureAthleteTest()
        {
            Assert.Throws<InvalidOperationException>
                (() => gym.InjureAthlete("Pesho"));
        }

        [Test]
        public void ReportTest()
        {
            gym.AddAthlete(athlete);
            string expected = "Active athletes at Fit: Pesho";
            Assert.AreEqual(gym.Report(), expected);
        }
    }
}
