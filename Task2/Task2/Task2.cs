using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Bag
    {
        public List<Item> Items { get; private set; }
        public int MaxWeidth { get; private set; }

        public void AddItem(string name, int count)
        {
            int currentWeidth = Items.Sum(item => item.Count);
            Item targetItem = Items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
                throw new InvalidOperationException();

            if (currentWeidth + count > MaxWeidth)
                throw new InvalidOperationException();

            targetItem.Count += count;
        }

        public Item GetItem(string name)
        {
            return Items.Find(item => item.Name == name);
        }

    }

    class Item
    {
        public int Count { get; set; }
        public string Name { get; set; }
    }

}
