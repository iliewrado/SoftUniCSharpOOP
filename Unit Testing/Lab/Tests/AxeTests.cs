using NUnit.Framework;

namespace Tests
{
    public class AxeTests
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
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(1, axe.DurabilityPoints, 
                "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}