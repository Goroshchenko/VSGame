using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_2
{
    class Weapons
    {
        private string name;
        private int level;
        private int attack;
        private int exp;
        
        public Weapons(string name, int level, int attack, int exp)
            
        {
            this.name = name;
            this.level = level;
            this.attack = attack;
            this.exp = exp;                       
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
        public int Attack
        {
            get
            {
                return this.attack;
            }

        }
        public int Exp
        {
            get
            {
                return this.exp;
            }
        }        
        public static explicit operator int(Weapons enemyWeapon)
        {
            return (enemyWeapon.attack + enemyWeapon.level + enemyWeapon.Exp)*2;
        }
        public static int Power(Weapons enemyWeapon)
        {
            int power = (int)enemyWeapon;
            return(power);
        }
       
        public static Weapons operator +(Weapons sword, Weapons enemyWeapon)
        {
            new Weapons(sword.name, sword.level, sword.attack + enemyWeapon.attack, sword.exp + Power(enemyWeapon));
            if (sword.exp + Power(enemyWeapon) >= 20)
            {
                sword.level += 1;
                sword.exp = 0;
                sword.attack += 10;
                return new Weapons(sword.name, sword.level, sword.attack, sword.exp);
            }
            else
            {
                return new Weapons(sword.name, sword.level, sword.attack + enemyWeapon.attack, sword.exp + Power(enemyWeapon));
            }
        }
    }
}
