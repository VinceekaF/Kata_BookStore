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

        public Step()
        {
            _bookRepo = new InMemoryBookRepository();
            _cartRepo = new CartRepository();
            _cartBo = new CartBO(_cartRepo);
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

        public static Book _book
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

        [Given(@"I added different (.*) in my cart")]
        public void GivenIAddedInMyCart(int numberOfDifferentBooks)
        {
            List<Book> _books = _bookRepo.GetAllBooks().ToList();
            
            for (int i = 0; i< numberOfDifferentBooks; i++)
            {
                _cartRepo.AddBook(_books[i]);
            }
        }


        [When(@"I open my cart")]
        public void WhenIOpenMyCart()
        {
            OutputPrice = _cartBo.GetTotalPrice();
        }

        [Then(@"I have to see the total (.*)")]
        public void ThenIHaveToSeeTheTotal(double totalPrice)
        {
            Assert.AreEqual(totalPrice, OutputPrice);
        }


        [Given(@"I have a book (.*):")]
        public void GivenIHaveABook(string title)
        {
            _book = new Book();
            _book.Title = title;
        }

        [When(@"I add it")]
        public void WhenIAddIt()
        {
            _cartRepo.AddBook(_book);
            Output = _cartRepo.GetCurrentCartList(); ;
        }

        [Then(@"in my cart I must see the book (.*)")]
        public void ThenInMyCartIMustSeeTheBook(string title)
        {
            Assert.IsTrue(Output.Any(x => x.Title == title));
        }
    }
}
