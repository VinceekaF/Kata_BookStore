using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_BookStore.BL
{
    public class CartBO
    {
        private IEnumerable<Book> _currentCart;

        public CartBO(IEnumerable<Book> currentCart)
        {
            _currentCart = currentCart;
        }
        public double TotalPrice(List<Book> currentCart)
        {
            return currentCart.Select(_ => _.Price).Sum();
        }
    }
}
