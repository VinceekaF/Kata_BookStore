using Kata_BookStore.BL;
using Kata_BookStore.Models;
using Kata_BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Tests
{
    public class CartShould
    {
        private static IBookRepository _repo = new InMemoryBookRepository();
        private IEnumerable<Book> list = _repo.GetAllBooks();
        private static ICartRepository _myCart = new CartRepository();
        private CartBO bo = new CartBO(_myCart);

        [Fact]
        public void AddtheBookIWant()
        {
            Book _book = list.ElementAt(2);
            
            _myCart.AddBook(_book);

            Assert.Contains(list.ElementAt(2).Id, _myCart.GetCurrentCartList().Select(b=>b.Id));
        }


        [Fact]
        public void ShowMeTheTotalPrice()
        {

            foreach(var book in list)
            {
                _myCart.AddBook(book);
            }

            double totalPrice = bo.TotalPrice();
        }

    }
}
