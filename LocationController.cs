using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_2
{
    class LocationController
    {
		public static void Move(ConsoleKeyInfo KeyPushed)
		{
			Direction d = Direction.None;
			switch (KeyPushed.Key)
			{
				case ConsoleKey.RightArrow:
					d = Direction.Right;
					break;
				case ConsoleKey.LeftArrow:
					d = Direction.Left;
					break;
				case ConsoleKey.UpArrow:
					d = Direction.Up;
					break;
				case ConsoleKey.DownArrow:
					d = Direction.Down;
					break;
				case ConsoleKey.A:
					Character obj = null;

					int dY = 0;
					int dX = 0;
                    switch (Game.player.Position.direction)
                    {
                        case Direction.Up:
                            dY = -1;
                            break;

                        case Direction.Down:
                            dY = 1;
                            break;

                        case Direction.Left:
                            dX = -1;
                            break;

                        case Direction.Right:
                            dX = 1;
                            break;
                    }

                    int tempX = Game.player.Position.X + dX;
                    int tempY = Game.player.Position.Y + dY;

                    obj = Game.player.Position.GetCollision(Game.objects, tempX, tempY);

                    if (obj != null)
                    {
                        Character enemy = obj;
                        int number = Game.objects.IndexOf(obj);
                        Weapons enemyWeapon = Game.weapons[number];
                        int newHealth = Game.player.Health;
                        Game.player.Heal(enemy);
                        if (newHealth != Game.player.Health)
                        {
                            Console.WriteLine($"Your new health: {Game.player.Health}");
                            Console.ReadKey();
                            goto point;
                        }                        
                        while (Game.player.Health > 0 && enemy.Health > 0)
                        {
                            Console.WriteLine($"HERO {Game.player.Health} ENEMY {enemy.Health}");
                            Console.WriteLine("press f to hit");
                            string command = Console.ReadLine();
                            Game.player.Fight(command, enemy.Attack);
                            enemy.Fight(command,Game.player.Attack);
                        }
                        if (Game.player.Health > 0)
                        {
                            Console.WriteLine($"Hero's health: {Game.player.Health} | You win");
                            Game.player.LevelUp();
                            Game.player.Regeneration();
                            Game.weapons[0] += enemyWeapon;
                            Game.player.plusAttack(Game.weapons[0].Attack);
                            Console.WriteLine($"Object {Game.player.Name}: newHealth {Game.player.Health}. newlevel {Game.player.Level}");
                            Console.WriteLine($"you've picked the defeated enemy's {enemyWeapon.Name} up .... You can use it to upgrade your {Game.player.weapon} ...");
                            Console.ReadKey();
                            Console.WriteLine($"your {Game.player.weapon} was upgraded. new stats: damage {Game.weapons[0].Attack}. exp {Game.weapons[0].Exp} level {Game.weapons[0].Level}");
                        }
                        else
                        {
                            Console.WriteLine($"Hero's health: {Game.player.Health} | You lost");
                            Console.Beep();
                            return;
                        }
                        enemy = null;
                        Game.objects.Remove(Game.objects[number]);
                        Game.weapons.Remove(Game.weapons[number]);
                        Console.ReadKey();
                        while (Game.objects.Count > 2)
                        {
                            goto point;
                        }
                    }
                    break;

                case ConsoleKey.Escape:
                    Console.SetCursorPosition(0, Game.Height + 1);
                    Console.WriteLine("Are you sure you want to exit? (y/n)");

                    KeyPushed = Console.ReadKey();

                    Console.WriteLine("\nGood Bye!");
                    if (KeyPushed.Key == ConsoleKey.Y)
                    {
                        Game.Play = false;
                    }
                    break;                
            }
            point:
            if (d != Direction.None)
            {
                Game.player.Position.Move(d);
            }
        }
		
	}
}
