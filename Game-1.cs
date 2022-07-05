using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_1
{
	class Game
	{

		public int xx { get; set; }
		public int yy { get; set; }
		public string nm { get; set; }
		public int hlth { get; set; }
		public int lvl { get; set; }

		public static List<Game> listofcharacters = new List<Game>
			{
				new Game {nm = "trus", xx = GameObject.GetX(1), yy = GameObject.GetY(1), hlth = 20, lvl = 0 },
				new Game {nm = "balbes", xx = GameObject.GetX(2), yy = GameObject.GetY(2), hlth = 30, lvl = 1},
				new Game {nm = "byvalyi", xx = GameObject.GetX(3), yy = GameObject.GetY(3), hlth = 50, lvl = 2},
			};
	
		public static string GetName(int i)
		{
			return (listofcharacters.ElementAt(i).nm);
		}
		public static int GetX(int i)
		{
			var X = listofcharacters.ElementAt(i).xx;
			return (X);
		}
		public static int GetY(int i)
		{
			var Y = listofcharacters.ElementAt(i).yy;
			return (Y);
		}
		public static int GetHealth(int i)
		{
			return (listofcharacters.ElementAt(i).hlth);
		}
		public static int GetLevel(int i)
		{
			return (listofcharacters.ElementAt(i).lvl);
		}
		public static void DeleteListItem(int i)
		{
			listofcharacters.RemoveAt(i);
		}
		public static int ListLenght()
		{
			return (listofcharacters.Count());
		}





	}
}
