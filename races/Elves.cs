using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_2
{
	class Elve : Character, IFriend
	{
		public Elve(string name, int level, int attack, Position position, int health, string weapon, ConsoleColor color)
		: base(name, level, attack, position, health, weapon, color) { }
		public override void Fight(string command, int attack)
		{
			switch (command)
			{				
				case "f":
					Console.WriteLine($"Vo imya lesa!!!");
					Console.WriteLine($"{this.name} attacks with {this.weapon}");
					this.health -= attack;
					break;
				case "stop":
					this.health = 0;
					break;
			}
		}
		public override bool isFriend()
		{
			return true;
		}
	}
}
