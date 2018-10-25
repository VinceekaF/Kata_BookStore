using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_BookStore.Models
{
    public class Cart : ICart
    {
        public List<Book> cartList;
        public double totalPrice { get; set; }
        public Cart()
        {
            cartList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            cartList.Add(book);
        }

        public double TotalPrice(List<Book> currentCart)
        {
            return currentCart.Select(_ => _.Price).Sum();
        }
    }
}
