using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; }
        public double BaseHealth { get; }
        public double AbilityPoints { get; }
        public Bag Bag { get; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double restPoints = this.Armor - hitPoints;
            this.Armor -= hitPoints;

            if (this.Armor == 0)
            {
                this.Health += restPoints;
            }

            if (this.Health == 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
            if (this.health == 0)
            {
                IsAlive = false;
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}