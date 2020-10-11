using System;

namespace Lesson2_Task1
{
    abstract class Character
    {
        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {            
            Health -= CalculatedDamage(damage); ;

            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

        public abstract int CalculatedDamage(int damage);

    }

    class Wombat : Character
    {
        public int Armor { get; private set; }

        public override int CalculatedDamage(int damage)
        {
           return damage - Armor;
        }
    }

    class Human : Character
    {
        public int Agility { get; private set; }

        public override int CalculatedDamage(int damage)
        {
            return damage / Agility;
        }
    }
}
