namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        public RobotManager RobotManager { get; set; }

        [SetUp]
        public void SetUp()
        {
            RobotManager = new RobotManager(2);
        }

        [Test]
        public void CtorTest()
        {
            Assert.IsNotNull(RobotManager);
            Assert.AreEqual(RobotManager.Capacity, 2);
            Assert.AreEqual(RobotManager.Count, 0);
        }

        [Test]
        public void InvalidCapacityTest()
        {
            Assert.Throws<ArgumentException>
                (() => RobotManager = new RobotManager(-2));
        }

        [Test]
        public void AddRobotCorrect()
        {
            RobotManager.Add(new Robot("R2D2", 10));
            Assert.AreEqual(RobotManager.Count, 1);
        }

        [Test]
        public void IncorrectRoborNameTest()
        {
            RobotManager.Add(new Robot("R2D2", 10));
            Assert.Throws<InvalidOperationException>
                (() => RobotManager.Add(new Robot("R2D2", 20)));
        }

        [Test]
        public void NotEnoughtCapacity()
        {
            RobotManager.Add(new Robot("R2D2", 10));
            RobotManager.Add(new Robot("C3PO", 20));
            Assert.Throws<InvalidOperationException>
                (() => RobotManager.Add(new Robot("I`mRobot", 30)));
        }

        [Test]
        public void CorrectRemoveRobotTest()
        {
            RobotManager.Add(new Robot("R2D2", 10));
            RobotManager.Remove("R2D2");
            Assert.AreEqual(RobotManager.Count, 0);
        }

        [Test]
        public void NoSuchRobot()
        {
            RobotManager.Add(new Robot("R2D2", 10));
            Assert.Throws<InvalidOperationException>
                (() => RobotManager.Remove("C3PO"));
        }

        [Test]
        public void DoWork()
        {
            Robot r2d2 = new Robot("R2D2", 10);
            RobotManager.Add(r2d2);
            RobotManager.Work("R2D2", "Calculate", 5);
            Assert.AreEqual(r2d2.Battery, 5);
        }

        [Test]
        public void NotEnoughBatteryForWork()
        {
            Robot r2d2 = new Robot("R2D2", 10);
            RobotManager.Add(r2d2);
            Assert.Throws<InvalidOperationException>
            (() => RobotManager.Work("R2D2", "Calculate", 20));
        }

        [Test]
        public void NoRobotToWork()
        {
            Robot r2d2 = new Robot("R2D2", 10);
            RobotManager.Add(r2d2);
            Assert.Throws<InvalidOperationException>
            (() => RobotManager.Work("C3PO", "Calculate", 20));
        }

        [Test]
        public void ChargeRobot()
        {
            Robot r2d2 = new Robot("R2D2", 100);
            RobotManager.Add(r2d2);
            RobotManager.Work("R2D2", "Calculate", 20);
            RobotManager.Charge("R2D2");
            Assert.AreEqual(r2d2.Battery, 100);
        }

        [Test]
        public void NoRobotToCharge()
        {
            Robot r2d2 = new Robot("R2D2", 10);
            RobotManager.Add(r2d2);
            Assert.Throws<InvalidOperationException>
                (() => RobotManager.Charge("C3PO"));
        }
    }
}
