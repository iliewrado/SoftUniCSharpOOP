using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characterParty;
		private Stack<Item> itemPool;
		public WarController()
		{
			characterParty = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

            switch (characterType)
            {
				case "Warrior":
					characterParty.Add(new Warrior(name));
					break;
				case "Priest":
					characterParty.Add(new Priest(name));
					break;
                default:
					throw new ArgumentException
						(string.Format(ExceptionMessages
						.InvalidCharacterType, characterType));
			}

			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

            switch (itemName)
            {
				case "FirePotion":
					itemPool.Push(new FirePotion());
					break;
				case "HealthPotion":
					itemPool.Push(new HealthPotion());
					break;
                default:
					throw new ArgumentException
						(string.Format(ExceptionMessages
						.InvalidItem, itemName));
            }

            return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			int index = -1;
			index = characterParty.FindIndex(x => x.Name == characterName);

            if (index < 0)
            {
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException
					(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = itemPool.Pop();
			characterParty[index].Bag.AddItem(item);

			return string.Format(SuccessMessages.PickUpItem, characterName,item.GetType().Name);
		}

		public string UseItem(string[] args)
		{

			string characterName = args[0];
			string itemName = args[1];

			Character character = characterParty
				.FirstOrDefault(x => x.Name == characterName);
            
			if (character == null)
            {
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, characterName));
            }
			
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages
				.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder getStats = new StringBuilder();
            
			foreach (var hero in characterParty
				.OrderByDescending(x=> x.IsAlive)
				.OrderByDescending(x=> x.Health))
            {
				getStats.AppendLine(string.Format(SuccessMessages
					.CharacterStats, hero.Name, hero.Health, hero.BaseHealth,
					hero.Armor, hero.BaseArmor, hero.IsAlive));
            }

			return getStats.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
            if (!characterParty.Exists(x => x.Name == attackerName))
            {
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, attackerName));
            }
			if (!characterParty.Exists(x => x.Name == receiverName))
			{
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, receiverName));
			}

			IAttacker character = characterParty
				.FirstOrDefault(x => x.Name == attackerName) as IAttacker;
            if (character == null)
            {
				throw new ArgumentException
					(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

			Warrior attacker = character as Warrior;
			Character receiver = characterParty
				.FirstOrDefault(x => x.Name == receiverName);
			attacker.Attack(receiver);

			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine(string.Format(SuccessMessages.AttackCharacter,
				attacker.Name, receiver.Name, attacker.AbilityPoints,
				receiver.Name, receiver.Health, receiver.BaseHealth,
				receiver.Armor, receiver.BaseArmor));
            
			if (receiver.IsAlive == false)
            {
				stringBuilder.AppendLine(string.Format(SuccessMessages
					.AttackKillsCharacter, receiver.Name));
            }
			
			return stringBuilder.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			if (!characterParty.Exists(x => x.Name == healerName))
			{
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, healerName));
			}
			if (!characterParty.Exists(x => x.Name == healingReceiverName))
			{
				throw new ArgumentException
					(string.Format(ExceptionMessages
					.CharacterNotInParty, healingReceiverName));
			}

			IHealer character = characterParty
				.FirstOrDefault(x => x.Name == healerName) as IHealer;
			if (character == null)
			{
				throw new ArgumentException
					(string.Format(ExceptionMessages.AttackFail, healerName));
			}

			Priest healer = character as Priest;
			Character receiver = characterParty
				.FirstOrDefault(x => x.Name == healingReceiverName);
			healer.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter
				, healer.Name, receiver.Name, healer.AbilityPoints,
				receiver.Name, receiver.Health);
		}
	}
}
