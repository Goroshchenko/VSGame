using System;
using System.Collections.Generic;
using System.Text;

namespace GamePart_1
{
    class Weapons
    {
        public string name;
        private int damage;
        private int exp;
        private int level;
        public Weapons(string name, int damage, int exp, int level)
        {
            this.name = name;
            this.damage = damage;
            this.exp = exp;
            this.level = level;            
        }
        public int Damage
        {
            get
            {
                return this.damage;
            }
        }
        public int Exp
        {
            get
            {
                return this.exp;
            }
        }
        public int Level
        {
            get
            {
                return this.level;
            }
        }
        public static explicit operator int(Weapons axe)
        {
            return (axe.Damage + axe.Level + axe.Exp)*2;
        }
        public static int Power(Weapons weapon)
        {
            int power = (int)weapon;
            return(power);
        }
       
        public static Weapons operator +(Weapons sword, Weapons axe)
        {
            new Weapons(sword.name, sword.damage + axe.damage, sword.exp + Power(axe), sword.level);
            if (sword.exp + Power(axe) >= 20)
            {
                sword.level += 1;
                sword.exp = 0;
                sword.damage += 10;
                return new Weapons(sword.name, sword.damage, sword.exp, sword.level);
            }
            else
            {
                return new Weapons(sword.name, sword.damage + axe.damage, sword.exp + Power(axe), sword.level);
            }
        }

    }
}
