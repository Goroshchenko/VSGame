using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_2
{
    public interface IFriend
    {
        public virtual bool isFriend()
		{
			return false;
		}        
        public void Talk(Character name)
        {
            Console.WriteLine($"Hello, Player! My name is {name.Name}. We are friends. Let me heal you");            
        } 
        
    }
}
