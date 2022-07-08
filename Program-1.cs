using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePart_1
{
    class Program
    {
        static void Main(string[] args)
        {                      
            Weapons sword = new Weapons("sword", 10, 0, 1);
            Character player = new Character("player", GameObject.GetX(0), GameObject.GetY(0), 50, 1, sword.name, sword.Damage);
            Console.WriteLine($"His weapon is {sword.name} with stats: damage {sword.Damage} exp {sword.Exp}. level {sword.Level}");
            Console.WriteLine($"Your enemies are:");
            for (int i = 0; i < Game.ListLenght(); i++)
            {
                Console.WriteLine($"{Game.GetName(i)} {Game.GetX(i)} {Game.GetY(i)}, level {Game.GetLevel(i)}");
            }                

        begin:
            ConsoleKeyInfo keyPushed;
            var flag = true; 
            while (flag)
             {
                    Console.WriteLine($"You are at {player.X} {player.Y}. Where to go?");
                    keyPushed = Console.ReadKey();

                    player.Move(keyPushed);
                              
                for (int i = 0; i < Game.ListLenght(); i++)
                {
                    if (player.X == Game.GetX(i) && player.Y == Game.GetY(i))
                    {
                        Console.WriteLine("Objects are on the same position. FIGHT !!!");
                        flag = false;
                        break;                                              
                                                
                    }
                    else
                    {
                        Console.WriteLine($"{Game.GetName(i)} {Game.GetX(i)} {Game.GetY(i)}, level {Game.GetLevel(i)}");
                        continue;                        
                    }                 
               }                
                
             } 
                for (int i = 0; i < Game.ListLenght(); i++)
            {
                if (player.X == Game.GetX(i) && player.Y == Game.GetY(i))
                {
                    Weapons axe = new Weapons("axe", 5, 0, 1);
                    Character enemy = new Character(Game.GetName(i), Game.GetX(i), Game.GetY(i), Game.GetHealth(i), Game.GetLevel(i), axe.name, axe.Damage + Game.GetAttack(i));
                    while (player.Health > 0 && enemy.Health > 0)
                    {
                        Console.WriteLine($"HERO {player.Health} ENEMY {enemy.Health}");
                        Console.WriteLine("press f to hit");
                        string command = Console.ReadLine();
                        player.Fight(command, enemy.attack);
                        enemy.Fight(command, player.attack);
                    }
                    enemy = null;
                    if (player.Health > 0)
                    {
                        Console.WriteLine($"Hero's health: {player.Health} | You win");
                        player.LevelUp();
                        player.Regeneration();
                        sword += axe;                        
                        player.attack = sword.Damage;
                        Console.WriteLine($"Object {player.Name}: newHealth {player.Health}. newlevel {player.Level}");
                        Console.WriteLine($"you've picked the defeated enemy's {axe.name} up .... You can use it to upgrade your {sword.name} ...");
                        Console.ReadKey();
                        Console.WriteLine($"your {player.weapon} was upgraded. new stats: damage {sword.Damage}. exp {sword.Exp} level {sword.Level}");
                    }
                    else
                    {
                        Console.WriteLine($"Hero's health: {player.Health} | You lost");
                        return;
                    }
                    Game.DeleteListItem(i);
                    Console.ReadKey();
                    while (Game.ListLenght() > 0)
                    {
                        goto begin;
                    }
                   
                }
            }

            Console.WriteLine($"game over | You win");

        }
    }
}
