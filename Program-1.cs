using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePart_1
{
    class Program
    {
        static void Main(string[] args)
        {                      
            Character player = new Character("player", GameObject.GetX(0), GameObject.GetY(0), 50, 1);

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
                        Console.WriteLine($"{Game.GetName(i)} {Game.GetX(i)} {Game.GetY(i)}");
                        continue;                        
                    }                 
               }                
                
             } 
                for (int i = 0; i < Game.ListLenght(); i++)
            {
                if (player.X == Game.GetX(i) && player.Y == Game.GetY(i))
                {
                    Character enemy = new Character(Game.GetName(i), Game.GetX(i), Game.GetY(i), Game.GetHealth(i), Game.GetLevel(i));
                    while (player.Health > 0 && enemy.Health > 0)
                    {
                        Console.WriteLine($"HERO {player.Health} ENEMY {enemy.Health}");
                        Console.WriteLine("press f to hit");
                        string command = Console.ReadLine();
                        player.Fight(command);
                        enemy.Fight(command);
                    }
                    enemy = null;
                    if (player.Health > 0)
                    {
                        Console.WriteLine($"Hero's health: {player.Health} | You win");
                        player.LevelUp();
                        player.Regeneration();
                        Console.WriteLine($"Object {player.Name} was modified at {player.X} {player.Y}. newHealth {player.Health}. newlevel {player.Level}");

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
                
            



            


               
            


        }
    }
}
