using System;
using System.Collections.Generic;

namespace Lesson2_Task3
{
    class Shop
    {
        static void Main(string[] args)
        {

        }
    }

    public interface IProduct
    {
        string Name { get; }
        int Price { get; }
        bool DeliveryIsPossible { get; }
    }

    public class Product : IProduct
    {
        public string Name { get; }
        public int Price { get; private set; }
        public bool DeliveryIsPossible { get; }

        public Product(string name, int price, bool deliveryIsPossible)
        {
            Name = name;
            Price = price;
            DeliveryIsPossible = deliveryIsPossible;
        }

        public void EditPrice(int newPrice)
        {
            Price = newPrice;
        }

        public DiscountedProduct GetDiscountedProduct(int percent)
        {
            DiscountedProduct discountedProduct = new DiscountedProduct(this, percent);         
            return discountedProduct;
        }
    }


    public class DiscountedProduct : IProduct
    {
        public Product MainProduct { get; }
        public int DiscountPercent { get; }
        public bool DeliveryIsPossible => false;

        public string Name
        {
            get
            { 
                return $"{MainProduct.Name} (Со скидкой {DiscountPercent}%)";
            }
        }

        public int Price
        {
            get
            {
                int price = MainProduct.Price;
                return price - (price / 100 * DiscountPercent);
            }
        }

        public DiscountedProduct(Product mainProduct, int discountPercent)
        {
            MainProduct = mainProduct;
            DiscountPercent = discountPercent;
        }

    }

}
