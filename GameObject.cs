using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GamePart_1
{
    class GameObject
    {
        private int x;
        private int y;
		public static List<GameObject> coordinates = new List<GameObject>
			{
			new GameObject {x = 10, y = 10},
			new GameObject {x = 11, y = 11},
			new GameObject {x = 9, y = 9},
			new GameObject {x = 12, y = 8},
			};

		public static int GetX(int i)
		{
			return (coordinates.ElementAt(i).X);
		}
		public static int GetY(int i)
		{
			return (coordinates.ElementAt(i).Y);
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
	}
}
