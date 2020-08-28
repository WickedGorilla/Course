using System;

namespace Task1
{
    class Task1
    {
        public static void Main(string[] args)
        {
            Object[] objects = new Object[]
            {

                new Object(5, 5, true),
                new Object(10, 10, true),
                new Object(15, 15, true)
            };

            Random random = new Random();

            while (true)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    for (int j = 0; i < objects.Length; j++)
                    {
                        if (j >= i) continue;
                        CheckReached(objects[i], objects[j]);
                    }
                }

                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].Move(random.Next(-1, 1), random.Next(-1, 1));
                    objects[i].Normalize();

                    if (objects[i].IsAlive)
                    {
                        int output = i + 1;
                        Render(objects[i], output.ToString());
                    }
                }
            }
        }

        public static void Render(Object obj, string output)
        {
            Console.SetCursorPosition(obj.X, obj.Y);
            Console.Write(output);
        }

        public static void CheckReached(Object object1, Object object2)
        {
            if (object1.X == object2.X && object1.Y == object2.Y)
            {
                object1.IsAlive = false;
                object2.IsAlive = false;
            }
        }

    }

    class Object
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; set; }

        public Object(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }

        public void Move(int xForce, int yForce)
        {
            X += xForce;
            Y += yForce;
        }

        public void Normalize()
        {
            if (X < 0) X = 0;
            if (Y < 0) Y = 0;
        }
    }

}


