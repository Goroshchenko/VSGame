using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_2
{	public class Man : Character
	{
		public Man(string name, int level, int attack, int x, int y, int health, string weapon)
		: base(name, level, attack, x, y, health, weapon) { }
		public override void Fight(string command, int attack)
		{
			switch (command)
			{			
				case "f":
					Console.WriteLine($"Za pobedu!!! sila V pravde!");
					Console.WriteLine($"{this.name} attacks with {this.weapon}");
					this.health -= attack;
					break;
				case "stop":
					this.health = 0;
					break;
			}
		}
	}	
}
