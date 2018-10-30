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
        readonly InMemoryBookRepository _repo;
        readonly CartRepository _myCart;
        readonly IEnumerable<Book> list;
        readonly CartBO bo;

        public CartShould()
        {
            _repo = new InMemoryBookRepository();
            _myCart = new CartRepository();
            bo = new CartBO(_myCart);
            list = _repo.GetAllBooks();
        }
       

        [Fact]
        public void AddtheBookIWant()
        {
            Book _book = list.ElementAt(2);
            
            bo.AddBook(_book);

            Assert.Contains(list.ElementAt(2).Id, _myCart.GetCurrentCartList().Select(b=>b.Id));
        }



        [Theory]
        [InlineData(100.4)]
        public void ShowMeTheTotalPrice(double expected)
        {
            foreach(var book in fakeList)
            {
                bo.AddBook(book);
            }
            double totalPrice = bo.GetTotalPrice();

            Assert.Equal(expected, totalPrice);
        }


        [Fact]
        public void getTheCurrentListOfCustomer()
        {
            var listOfBooksInCart = bo.GetCurrentCartList();

            Assert.Equal(_myCart.GetCurrentCartList(), listOfBooksInCart);
        }

        private List<Book> fakeList = new List<Book>()
        {
            new Book{
                        Id = new Guid("d33afcc5-7064-435b-b1b8-e30b531b7fc7"),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("d33afcc5-7064-435b-b1b8-e30b531b7fc7"),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("d33afcc5-7064-435b-b1b8-e30b531b7fc7"),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("d33afcc5-7064-435b-b1b8-e30b531b7fc7"),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("d33afcc5-7064-435b-b1b8-e30b531b7fc7"),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("003b65a5-e678-4e82-838f-651ffdd7a992"),
                        Title = "2. Harry Potter et la chambre des secrets",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("003b65a5-e678-4e82-838f-651ffdd7a992"),
                        Title = "2. Harry Potter et la chambre des secrets",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("003b65a5-e678-4e82-838f-651ffdd7a992"),
                        Title = "2. Harry Potter et la chambre des secrets",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("8ee3028b-2ee3-4c98-94c8-a862e46da972"),
                        Title = "3. Harry Potter et le prisonnier d'Azkaban",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("8ee3028b-2ee3-4c98-94c8-a862e46da972"),
                        Title = "3. Harry Potter et le prisonnier d'Azkaban",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("8ee3028b-2ee3-4c98-94c8-a862e46da972"),
                        Title = "3. Harry Potter et le prisonnier d'Azkaban",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("8ee3028b-2ee3-4c98-94c8-a862e46da972"),
                        Title = "3. Harry Potter et le prisonnier d'Azkaban",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("f1046973-5b6b-46f9-beb6-e5d78ec313a2"),
                        Title = "4. Harry Potter et la coupe de feu",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("a326cd90-1b15-426d-928e-b8b05e64717b"),
                        Title = "5. Harry Potter et le prince de sang-mêlé",
                        Price = 8.00d
                    },
            new Book{
                        Id = new Guid("a326cd90-1b15-426d-928e-b8b05e64717b"),
                        Title = "5. Harry Potter et le prince de sang-mêlé",
                        Price = 8.00d
                    }
        };
        
    }
}
