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

		public Character(string name, int x, int y, int health, int level)
		{
			this.name = name;
			this.x = x;
			this.y = y;
			this.health = health;
			this.level = level;
			Console.WriteLine($"Object {this.name} was created at {this.x} {this.y}. Health {this.health}. level {this.level}");
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
		
		public void Fight(string strikes)
        {
			switch (strikes)
            {
				case "f":
					this.health -= 10;
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
			this.health += 30; 			
		}

		
	}
}
