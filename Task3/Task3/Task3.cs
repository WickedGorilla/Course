using System;

namespace Task3
{
    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    }

    class Attack
    {
        public void DoAttack()
        {
            //attack
        }
    }

    class Weapon
    {
        public int Damage { get; private set; }
        public float Cooldown { get; private set; }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    class Movement
    {
        public float Speed { get; private set; }
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }

        public void DoMove()
        {
            //Do move
        }
    }
}
