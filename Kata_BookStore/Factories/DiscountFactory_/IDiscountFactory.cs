using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Factories.DiscountFactory_
{
    public interface IDiscountStrategy
    {
        double ApplyDiscount(List<Book> bookList);
    }
}
