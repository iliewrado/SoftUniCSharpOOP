using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const string name = "Shishman";
        private const int damage = 100;
        private const int hp = 100;

        public Warrior testWarrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorWorkCorrect()
        {
            Warrior testWarrior = new Warrior(name, damage, hp);
            Assert.AreEqual(testWarrior.Name, name);
            Assert.AreEqual(testWarrior.Damage, damage);
            Assert.AreEqual(testWarrior.HP, hp);
        }

        [Test]
        public void InvalidNameTest()
        {
            Assert.Throws<ArgumentException>(() => 
            testWarrior = new Warrior(string.Empty, damage, hp));
        }

        [Test]
        public void WhiteSpaceNameTest()
        {
            Assert.Throws<ArgumentException>(() =>
            testWarrior = new Warrior("  ", damage, hp));
        }

        [Test]
        public void InvalidDamageTest()
        {
            Assert.Throws<ArgumentException>(() =>
            testWarrior = new Warrior(name, 0, hp));
        }

        [Test]
        public void NegativeDamageTest()
        {
            Assert.Throws<ArgumentException>(() =>
            testWarrior = new Warrior(name, -1, hp));
        }

        [Test]
        public void InvalidHPtest()
        {
            Assert.Throws<ArgumentException>(() =>
            testWarrior = new Warrior(name, damage, -1));
        }

        [Test]
        public void AttackWithLowerHP()
        {
            Warrior warrior = new Warrior("Pesho", damage, hp);
            testWarrior = new Warrior(name, damage, 20);
            Assert.Throws<InvalidOperationException>
                (() => testWarrior.Attack(warrior));
        }

        [Test]
        public void AttackHeroWithLowerHP()
        {
            testWarrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Pesho", damage, 20);
            Assert.Throws<InvalidOperationException>
                (() => testWarrior.Attack(warrior));
        }

        [Test]
        public void AttackStrongerHero()
        {
            testWarrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Pesho", 1000, hp);
            Assert.Throws<InvalidOperationException>
                (() => testWarrior.Attack(warrior));
        }

        [Test]
        public void AttackerHpTest()
        {
            testWarrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Pesho", 90, 90);
            testWarrior.Attack(warrior);
            Assert.AreEqual(testWarrior.HP, 10);
        }

        [Test]
        public void AttackeDHpTest()
        {
            testWarrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Pesho", 90, 90);
            testWarrior.Attack(warrior);
            Assert.AreEqual(warrior.HP, 0);
        }

        [Test]
        public void AttackedPositiveHpTest()
        {
            testWarrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Pesho", 90, 110);
            testWarrior.Attack(warrior);
            Assert.AreEqual(warrior.HP, 10);
        }
    }
}