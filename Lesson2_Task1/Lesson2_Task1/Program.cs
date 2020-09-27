using System;

namespace Lesson2_Task1
{
    abstract class Character
    {
        public int Health { get; private set; }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

    }

    class Wombat : Character
    {
        public int Armor { get; private set; }

        public override void TakeDamage(int damage) 
        {
            int calculatedDamage = damage - Armor;
            base.TakeDamage(calculatedDamage);
        }
    }

    class Human : Character
    {
        public int Agility { get; private set; }

        public override void TakeDamage(int damage)
        {
            int calculatedDamage = damage / Agility;
            base.TakeDamage(calculatedDamage);
        }
    }
}
