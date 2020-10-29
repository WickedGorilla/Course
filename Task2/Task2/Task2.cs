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

            if (currentWeidth + count > MaxWeidth) return;

            Item targetItem = Items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
            {
                targetItem = new Item(name, count);
                Items.Add(targetItem);
            }
            else 
            {
                Items.Remove(targetItem);
                Item updateItem = new Item(name, count + targetItem.Count);
                Items.Add(updateItem);
            }

        }

        public Item GetItem(string name)
        {
            return Items.Find(item => item.Name == name);
        }

    }

    class Item
    {
        public int Count { get; }
        public string Name { get; private set; }

        public Item(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }

}
