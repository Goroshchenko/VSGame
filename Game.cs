using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePart_2
{
    class Game
    {
        static void Main(string[] args)
        {                      
            Weapons sword = new Weapons("Sword", 1, 10, 0);
            Weapons axe = new Weapons("Axe", 1, 5, 0);
            Weapons hammer = new Weapons("Hammer", 1, 10, 0);
            Weapons fireball = new Weapons("Fireball", 1, 15, 0);
            Weapons arch = new Weapons("Arch", 1, 10, 0);
            Man player = new Man("PLAYER", 1, sword.Attack, GameObject.GetX(0), GameObject.GetY(0), 50, sword.Name);
            Console.WriteLine($"His weapon is {sword.Name} with stats: damage {sword.Attack} exp {sword.Exp}. level {sword.Level}");
            Console.WriteLine($"Your enemies are:");
            Ork trus = new Ork("TRUS", 0, axe.Attack, GameObject.GetX(1), GameObject.GetY(1), 30, axe.Name);
            Elve LogoVAZ = new Elve("LogoVAZ", 1, arch.Attack, GameObject.GetX(2), GameObject.GetY(2), 50, arch.Name);
            Dwarf balbes = new Dwarf("BALBES", 2, hammer.Attack, GameObject.GetX(3), GameObject.GetY(3), 60, hammer.Name);
            Wizard byvalyi = new Wizard("BYVALYI", 3, fireball.Attack, GameObject.GetX(4), GameObject.GetY(4), 100, fireball.Name);
            List<Character> listofchar = new List<Character>();
            listofchar.Add(player);
            listofchar.Add(trus);
            listofchar.Add(LogoVAZ);
            listofchar.Add(balbes);
            listofchar.Add(byvalyi);

            List<Weapons> listofweapons = new List<Weapons>();
            listofweapons.Add(sword);
            listofweapons.Add(axe);
            listofweapons.Add(arch);
            listofweapons.Add(hammer);
            listofweapons.Add(fireball);

        begin:
            ConsoleKeyInfo keyPushed;
            var flag = true;
            int number = 1;
            while (flag)
             {
                    Console.WriteLine($"You are at {player.X} {player.Y}. Where to go?");
                    keyPushed = Console.ReadKey();

                    player.Move(keyPushed);
                number = 1;         
                for (int i = 1; i < listofchar.Count; i++)
                {
                    if (player.X == listofchar[i].X && player.Y == listofchar[i].Y)
                    {
                        Console.WriteLine("Objects are on the same position!!!");
                        flag = false;                                           
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{listofchar[i].Name} {listofchar[i].X} {listofchar[i].Y}, level {listofchar[i].Level}");
                        number++;
                        continue;                        
                    }                 
               }                
                
             }
            Character enemy = listofchar[number];
            int newHealth = player.Health;
            player.Heal(enemy);
            if (newHealth != player.Health)
            {                
                Console.WriteLine($"Your new health: {player.Health}");
                Console.ReadKey();
                goto begin;
            }
                Weapons enemyWeapon = listofweapons[number];            
            while (player.Health > 0 && enemy.Health > 0)
                    {
                        Console.WriteLine($"HERO {player.Health} ENEMY {enemy.Health}");
                        Console.WriteLine("press f to hit");
                        string command = Console.ReadLine();
                        player.Fight(command, enemy.Attack);
                        enemy.Fight(command, player.Attack);
                    }                    
                    if (player.Health > 0)
                    {
                        Console.WriteLine($"Hero's health: {player.Health} | You win");
                        player.LevelUp();
                        player.Regeneration();
                        sword += enemyWeapon;                        
                        player.plusAttack(sword.Attack);
                        Console.WriteLine($"Object {player.Name}: newHealth {player.Health}. newlevel {player.Level}");
                        Console.WriteLine($"you've picked the defeated enemy's {enemyWeapon.Name} up .... You can use it to upgrade your {player.weapon} ...");
                        Console.ReadKey();
                        Console.WriteLine($"your {player.weapon} was upgraded. new stats: damage {sword.Attack}. exp {sword.Exp} level {sword.Level}");
                    }
                    else
                    {
                        Console.WriteLine($"Hero's health: {player.Health} | You lost");
                        return;
                    }
                    enemy = null;
                    listofchar.Remove(listofchar[number]);
                    listofweapons.Remove(listofweapons[number]);
                    Console.ReadKey();
                    while (listofchar.Count > 2)
                    {                        
                        goto begin;
                    }                
                          
            Console.WriteLine($"game over | You win");

        }
    }
}
