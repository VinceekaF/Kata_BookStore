using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_BookStore.Repository
{
    public class CartRepository : ICartRepository
    {
        public List<Book> cartList;
        public double totalPrice { get; set; }

        public CartRepository()
        {
            cartList = new List<Book>();
        }


        public void AddBook(Book book)
        {
            cartList.Add(book);
        }

        public double TotalPrice()
        {
            return cartList.Select(_ => _.Price).Sum();
        }
    }
}
