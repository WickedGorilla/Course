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
                    for (int j = 0; j != i; j++)
                    {
                        bool isAlive = CheckIsAlive(objects[i], objects[j]);

                        objects[i].Move(random.Next(-1, 1), random.Next(-1, 1));

                        if (isAlive)
                        {
                            int output = i + 1;
                            Render(objects[i], output.ToString());
                        }
                    }
                }

            }
        }

        public static void Render(Object obj, string output)
        {
            Console.SetCursorPosition(obj.X, obj.Y);
            Console.Write(output);
        }

        public static bool CheckIsAlive(Object object1, Object object2)
        {
            if (object1.X == object2.X && object1.Y == object2.Y)
                return false;
            else
                return true;
        }

    }

    class Object
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Object(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int xVelocity, int yVelocity)
        {
            X += xVelocity;
            Y += yVelocity;

            if (X < 0) xVelocity = 0;
            if (Y < 0) yVelocity = 0;
        }

    }

}
