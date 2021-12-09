using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private List<Warrior> warriors;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warriors = new List<Warrior>()
            {
                new Warrior("Petar", 100, 100),
                new Warrior("George", 200, 200),
                new Warrior("Teodor", 300, 300)
            };
        }

        [Test]
        public void TestConstructorWorksCorrect()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void VerifyWarriorCollection()
        {
            warriors = new List<Warrior>();
            warriors.Add(new Warrior("Petar", 100, 100));
            warriors.Add(new Warrior("George", 200, 200));
            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void CountTest()
        {
            Warrior pesho = new Warrior("Petar", 10, 10);
            arena.Enroll(pesho);
            Assert.AreEqual(arena.Count, 1);
        }

        [Test]
        public void EnrollWorkCorrect()
        {
            foreach (var warrior in warriors)
            {
                arena.Enroll(warrior);
            }

            Assert.AreEqual(arena.Warriors, warriors);
        }

        [Test]
        public void EnrollSHoudThrowExeptionForSameNameWarrior()
        {
            foreach (var warrior in warriors)
            {
                arena.Enroll(warrior);
            }
            Warrior pesho = new Warrior("Petar", 10, 10);
            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(pesho));
        }

        [Test]
        public void ThrowsExeprionIfAttackerNameIsEmty()
        {
            string attacker = string.Empty;
            string defender = "Petar";
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight(attacker, defender));
        }

        [Test]
        public void ThrowsExeprionIfDefendrNameIsEmpty()
        {
            string attacker = "Teodor";
            string defender = string.Empty;
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight(attacker, defender));
        }

        [Test]
        public void CorrectFightTest()
        {
            foreach (var warrior in warriors)
            {
                arena.Enroll(warrior);
            }
            Warrior attacker = arena.Warriors
                .First(x => x.Name == "Teodor");
            Warrior defender = arena.Warriors
                .First(x => x.Name == "George");

            long expectedHP = defender.HP - attacker.Damage;
            if (expectedHP < 0)
            {
                expectedHP = 0;
            }
            arena.Fight("Teodor", "George");
            var actualHP = defender.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }
    }
}
