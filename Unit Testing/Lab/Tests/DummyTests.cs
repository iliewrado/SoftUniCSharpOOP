using NUnit.Framework;
using System;

namespace Tests
{
    public class DummyTests
    {
        private const int attack = 1;
        private const int durability = 2;
        private const int health = 3;
        private const int exexperience = 2;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(health, exexperience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            dummy.TakeAttack(1);

            Assert.IsTrue(dummy.Health == 2);
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            dummy.TakeAttack(3);
            Exception ex = Assert
                .Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            dummy.TakeAttack(3);
            Assert.IsTrue(dummy.GiveExperience() == 2);
        }
        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With
                .Message.EqualTo("Target is not dead."));
        }
    }
}
