using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_2
{
	public class Character
	{
		protected string name;
		protected int level;
		protected int attack;
		protected int x;
		protected int y;
		protected int health;
		public string weapon;
		public Character(string name, int level, int attack, int x, int y, int health, string weapon)			
		{
			this.name = name;
			this.level = level;
			this.attack = attack;
			this.x = x;
			this.y = y;
			this.health = health;
			this.weapon = weapon;

			Console.WriteLine($"Object {this.name} was created at {this.x} {this.y}. Health {this.health}. level {this.level}. attack {this.attack}");
		}
		public string Name
		{
			get
			{
				return this.name;
			}

		}
		public int Level
		{
			get
			{
				return this.level;
			}

		}
		public int Attack
		{
			get
			{
				return this.attack;
			}

		}
		public int Health
		{
			get
			{
				return this.health;
			}

		}
		public int X
		{
			get
			{
				return this.x;
			}
		}
		public int Y
		{
			get
			{
				return this.y;
			}
		}

		public void Move(ConsoleKeyInfo KeyPushed)
		{
			switch (KeyPushed.Key)
			{
				case ConsoleKey.RightArrow:
					this.x++;
					break;
				case ConsoleKey.LeftArrow:
					this.x--;
					break;
				case ConsoleKey.UpArrow:
					this.y++;
					break;
				case ConsoleKey.DownArrow:
					this.y--;
					break;
			}
		}

		public virtual void Fight(string command, int attack)
		{
			switch (command)
			{
				case "f":
					Console.WriteLine($"{this.name} attacks with {this.weapon}");
					this.health -= attack;
					break;
				case "stop":
					this.health = 0;
					break;
			}
		}
		public void LevelUp()
		{
			this.level++;

		}
		public void Regeneration()
		{
			this.health += 15 * this.level;
		}
		public void plusAttack(int parameter)
		{
			this.attack = parameter;
		}
	}
}

