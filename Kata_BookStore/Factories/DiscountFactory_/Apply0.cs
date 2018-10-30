using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata_BookStore.Factories.DiscountFactory_
{
    public class Apply0 : IDiscountStrategy
    {
        public double ApplyDiscount(List<Book> bookList)
        {
            double totalPrice = 0;
            bookList.Select(b => b.Price).ToList().ForEach(_ => totalPrice += _);
            return totalPrice;
        }
    }
}