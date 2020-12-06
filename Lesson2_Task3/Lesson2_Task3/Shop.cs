using System;
using System.Collections.Generic;

namespace Lesson2_Task3
{
    public interface IProduct
    {
        string Name { get; }
        int Price { get; }
        bool IsDeliveriable { get; }
    }

    public class Product : IProduct
    {
        public string Name { get; }
        public int Price { get; set; }
        public bool IsDeliveriable { get; }

        public Product(string name, int price, bool deliveryIsPossible)
        {
            Name = name;
            Price = price;
            IsDeliveriable = deliveryIsPossible;
        }

        public DiscountedProduct Discount(int percent)
        {
            DiscountedProduct discountedProduct = new DiscountedProduct(this, percent);         
            return discountedProduct;
        }
    }


    public class DiscountedProduct : IProduct
    {
        public Product MainProduct { get; }
        public int DiscountPercent { get; }
        public bool IsDeliveriable => false;

        public string Name => $"{MainProduct.Name} (Со скидкой {DiscountPercent}%)";

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
