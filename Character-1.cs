using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_1
{
    class Character
    {
		private string name;
		private int health;
		private int x;
		private int y;
		private int level;
		public string weapon;
		public int attack;		

		public Character(string name, int x, int y, int health, int level, string weapon, int attack)
		{
			this.name = name;
			this.x = x;
			this.y = y;
			this.health = health;
			this.level = level;
			this.weapon = weapon;
			this.attack = attack;
			Console.WriteLine($"Object {this.name} was created at {this.x} {this.y}. Health {this.health}. level {this.level}. attack {this.attack}");
		}

		public int Health
		{
			get
			{
				return this.health;
			}
			
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
		
		public void Fight(string command, int attack)
        {
			switch (command)
            {
				case "f":
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
			this.health += 15*this.level; 			
		}	

	}
}
