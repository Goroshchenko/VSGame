using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_2
{
    static class GraphicsController
    {
        public static string TopLine = "";
        public static string MidLine = "";

        public static void Draw(List<Character> objects)
        {
            Console.Clear();

            DrawBorder();

            foreach (Character obj in objects)
            {
                if (obj.Health > 0)
                {
                    Draw(obj);
                }
            }

            Console.SetCursorPosition(0, Game.Height + 1);
        }

        public static void Draw(Character obj)
        {
            Console.SetCursorPosition(obj.Position.X - obj.Position.WidthHalf, obj.Position.Y - obj.Position.HeightHalf);
            Console.ForegroundColor = obj.Color;

            string width = "";

            char symbol = ' ';

            switch (obj.Position.direction)
            {
                case Direction.Up:
                    symbol = '↑';
                    break;

                case Direction.Down:
                    symbol = '↓';
                    break;

                case Direction.Left:
                    symbol = '←';
                    break;

                case Direction.Right:
                    symbol = '→';
                    break;
            }

            for (int i = 0; i < obj.Position.Width; i++)
            {

                width += symbol;
            }

            for (int i = 0; i < obj.Position.Height; i++)
            {
                Console.SetCursorPosition(obj.Position.X - obj.Position.WidthHalf, obj.Position.Y - obj.Position.HeightHalf + i);
                Console.Write(width);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.White;

            InitLines();

            for (int i = 0; i < Game.Height; i++)
            {
                if (i == 0 || i == Game.Height - 1)
                {
                    Console.WriteLine(TopLine);
                }
                else
                {
                    Console.WriteLine(MidLine);
                }
            }

            Console.WriteLine(Game.player.Health);
        }

        private static void InitLines()
        {
            if (TopLine == "")
            {
                for (int i = 0; i < Game.Width; i++)
                {
                    if (i == 0 || i == Game.Width - 1)
                    {
                        TopLine += "+";
                        MidLine += "|";
                    }
                    else
                    {
                        TopLine += "=";
                        MidLine += " ";
                    }
                }
            }
        }
    }
}

