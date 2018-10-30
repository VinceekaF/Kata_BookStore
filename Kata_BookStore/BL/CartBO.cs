using Kata_BookStore.Factories.DiscountFactory_;
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

        public List<Book> GetCurrentCartList()
        {
            return _repoCart.GetCurrentCartList();
        }

        public double TotalPrice()
        {
            return _repoCart.TotalPrice();
        }

        public double GetTotalPrice()
        {
            var list = GetCurrentCartList();
            List<Guid> listOfBooksId = list.Select(a => a.Id).Distinct().ToList();
            Dictionary<Guid,int> numberOfBooksById = new Dictionary<Guid, int>();
            foreach(var id in listOfBooksId)
            {
                numberOfBooksById.Add(id,list.Where(b => b.Id == id).Count());
            }

            return ApplyDiscountsAndGetTotalPrice(numberOfBooksById,list);
        }

        private IDiscountStrategy GetTheDiscountStrategy(int numberOfDifferentBook)
        {
            switch (numberOfDifferentBook)
            {
                case 2:
                    return DiscountStrategy.Discount5();
                case 3:
                    return DiscountStrategy.Discount10();
                case 4:
                    return DiscountStrategy.Discount20();
                case 5:
                    return DiscountStrategy.Discount25();
                default:
                    return DiscountStrategy.Discount0();
            }
        }

        private double ApplyDiscountsAndGetTotalPrice(Dictionary<Guid, int> numberOfBooksById, List<Book> list)
        {
            double totalPrice = 0;
            int countOfDifferentBooks = 0;
            do
            {
                countOfDifferentBooks = numberOfBooksById.Where(_ => _.Value != 0).Count();
                IDiscountStrategy _strategy = GetTheDiscountStrategy(countOfDifferentBooks);
                List<Book> bookList = new List<Book>();
                numberOfBooksById.Where(_ => _.Value != 0)
                    .ToList()
                    .ForEach(_ => bookList.Add(
                        list.First(b => b.Id == _.Key
                        )));
                totalPrice += _strategy.ApplyDiscount(bookList);
                numberOfBooksById.Where(_ => _.Value != 0)
                    .ToList()
                    .ForEach(_ => numberOfBooksById[_.Key] -= 1);
            }
            while (countOfDifferentBooks != 0);

            return totalPrice;
        }

    }
}
