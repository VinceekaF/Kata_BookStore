using Kata_BookStore.BL;
using Kata_BookStore.Models;
using Kata_BookStore.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookStore.BDD
{
    [Binding]
    public sealed class Step
    {
        InMemoryBookRepository _bookRepo;
        CartRepository _cartRepo;
        CartBO _cartBo;
        List<Book> _books;


        public Step()
        {
            _bookRepo = new InMemoryBookRepository();
            _cartRepo = new CartRepository();
            _cartBo = new CartBO(_cartRepo);
            _books = _bookRepo.GetAllBooks().ToList();
        }

        public static IEnumerable<Book> Output
        {
            get => ScenarioContext.Current.Get<List<Book>>(nameof(Output));
            set => ScenarioContext.Current.Set(value, nameof(Output));
        }
        public static double OutputPrice
        {
            get => ScenarioContext.Current.Get<double>(nameof(OutputPrice));
            set => ScenarioContext.Current.Set(value, nameof(OutputPrice));
        }

        public Book _book
        {
            get => ScenarioContext.Current.Get<Book>(nameof(_book));
            set => ScenarioContext.Current.Set(value, nameof(_book));
        }

        [When(@"I open the web site")]
        public void WhenIOpenTheWebSite()
        {
            Output = _bookRepo.GetAllBooks();
        }

        [Then(@"The page must show me the correct books (.*)")]
        public void ThenThePageMustShowMeTheCorrectBooks(int number)
        {
            Assert.AreEqual(number,Output.Count());
        }


        [When(@"I add a book by its (.*)")]
        public void WhenIAddABook(string title)
        {
            _book = _books.First(b => b.Title == title);
            _cartRepo.AddBook(_book);
            Output = _cartRepo.GetCurrentCartList();
        }

        [Then(@"in my cart I must see the book")]
        public void ThenInMyCartIMustSeeTheBook()
        {
            Assert.IsTrue(Output.Contains(_book));
        }


        [When(@"I add (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAdd(int book1, int book2, int book3, int book4, int book5)
        {
            AddEachBooks(_books, book1, book2, book3, book4, book5);
            OutputPrice = _cartBo.GetTotalPrice();
        }

        private void AddEachBooks(List<Book> _books, int book1, int book2, int book3, int book4, int book5)
        {
            for (int i = 0; i < book1; i++)
            {
                _cartRepo.AddBook(_books[0]);
            }
            for (int i = 0; i < book2; i++)
            {
                _cartRepo.AddBook(_books[1]);
            }
            for (int i = 0; i < book3; i++)
            {
                _cartRepo.AddBook(_books[2]);
            }
            for (int i = 0; i < book4; i++)
            {
                _cartRepo.AddBook(_books[3]);
            }
            for (int i = 0; i < book5; i++)
            {
                _cartRepo.AddBook(_books[4]);
            }


        }


        [Then(@"I have to see the total (.*) with discount applied")]
        public void ThenIHaveToSeeTheTotalWithDiscountApplied(double price)
        {
            Assert.AreEqual(price, OutputPrice);
        }

    }
}
