using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Bag
    {
        private List<Item> Items { get; set; }
        public int MaxWeidth { get; private set; }

        public void AddItem(string name, int count)
        {
            int currentWeidth = Items.Sum(item => item.Count);

            if (currentWeidth + count > MaxWeidth)
                return;

            Item targetItem = Items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
            {
                targetItem = new Item(name, count);
                Items.Add(targetItem);
            }
            else           
                targetItem.Count += count;
        }

        public List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            foreach (var item in Items)
                items.Add(item);
           
            return items;
        }

    }

    class Item : IItem
    {
        public int Count { get; set; }
        public string Name { get; }

        public Item(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }

    interface IItem
    {
        int Count { get; }
        string Name { get; }
    }

}
