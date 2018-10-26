using Kata_BookStore.Models;
using Kata_BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_BookStore.BL
{
    public class CartBO : ICartBo
    {
        private ICartRepository _repoCart;

        public CartBO(ICartRepository repoCart)
        {
            _repoCart = repoCart;
        }

        public void AddBook(Book book)
        {
            _repoCart.AddBook(book);
        }

        public double TotalPrice()
        {
            return _repoCart.TotalPrice();
        }
    }
}
