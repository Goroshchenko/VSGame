using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_2
{
	public abstract class Character : IFriend
	{
		protected string name;
		protected int level;
		protected int attack;
		private Position position;
		protected int health;
		public string weapon;
		protected ConsoleColor color;
		public Character(string name, int level, int attack, Position position, int health, string weapon, ConsoleColor color)			
		{
			this.name = name;
			this.level = level;
			this.attack = attack;
			this.position = position;			
			this.health = health;
			this.weapon = weapon;
			this.color = color;
			Console.WriteLine($"Object {this.name} was created at {this.position.X} {this.position.Y}. Health {this.health}. level {this.level}. attack {this.attack}");
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
		public Position Position
		{
			get
			{
				return this.position;
			}

		}
		public int Health
		{
			get
			{
				return this.health;
			}

		}		
		public ConsoleColor Color
		{
			get
			{
				return this.color;
			}
		}
		public virtual void Fight(string command, int attack)	{	}
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
		public virtual bool isFriend()
		{
			return false;
		}
		public void Heal(IFriend name)
		{
			if (name.isFriend())
			{
				name.Talk(this);
				this.health += 10;
			}

		}

	}
}

