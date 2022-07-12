using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePart_2
{
    public static class Game
    {
        public static bool Play = true;
        public static List<Character> objects = new List<Character>();
        public static List<Weapons> weapons = new List<Weapons>();
        public static Character player;
        public const int Width = 100; 
        public const int Height = 25;        

        public static void Main()
        {
            InitGame();
            Update();

        }
        public static void InitGame()
        {
            Weapons sword = new Weapons("weapons[0]", 1, 10, 0);
            Weapons axe = new Weapons("Axe", 1, 5, 0);
            Weapons hammer = new Weapons("Hammer", 1, 10, 0);
            Weapons fireball = new Weapons("Fireball", 1, 15, 0);
            Weapons arch = new Weapons("Arch", 1, 10, 0);
            Game.player = new Man("PLAYER", 1, sword.Attack, new Position(5, 10, 2, 2), 50, sword.Name, ConsoleColor.White);
            Console.WriteLine($"His weapon is {sword.Name} with stats: damage {sword.Attack} exp {sword.Exp}. level {sword.Level}");
            Console.WriteLine($"Your enemies are:");
            Ork trus = new Ork("TRUS", 0, axe.Attack, new Position(20, 5, 2, 2), 30, axe.Name, ConsoleColor.Red);
            Elve LogoVAZ = new Elve("LogoVAZ", 1, arch.Attack, new Position(30, 20, 2, 2), 50, arch.Name, ConsoleColor.Green);
            Dwarf balbes = new Dwarf("BALBES", 2, hammer.Attack, new Position(70, 20, 2, 2), 60, hammer.Name, ConsoleColor.Blue);
            Wizard byvalyi = new Wizard("BYVALYI", 3, fireball.Attack, new Position(90, 15, 2, 2), 100, fireball.Name, ConsoleColor.Yellow);
            
            objects.Add(player);
            objects.Add(trus);
            objects.Add(LogoVAZ);
            objects.Add(balbes);
            objects.Add(byvalyi);

            weapons.Add(sword);
            weapons.Add(axe);
            weapons.Add(arch);
            weapons.Add(hammer);
            weapons.Add(fireball);
        }
       
        static void Update()
        {           
            ConsoleKeyInfo keyPushed;

            while (Game.Play)
            {                            
                        GraphicsController.Draw(Game.objects);

                        keyPushed = Console.ReadKey();

                        LocationController.Move(keyPushed); 
                                   
            }
            Console.WriteLine($"game over | You win");
        }
        
    }
}

