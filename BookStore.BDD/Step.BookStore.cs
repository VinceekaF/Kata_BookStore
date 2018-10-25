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
        IBookRepository _bookRepo = new InMemoryBookRepository();
        Cart _cart = new Cart();

        public static IEnumerable<Book> Output
        {
            get => ScenarioContext.Current.Get<List<Book>>(nameof(Output));
            set => ScenarioContext.Current.Set(value, nameof(Output));
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


        [Given(@"I have a book (.*):")]
        public void GivenIHaveABook(string title)
        {
            _book = new Book();
            _book.Title = title;
        }

        [When(@"I add it")]
        public void WhenIAddIt()
        {
            _cart.AddBook(_book);
            Output = _cart.cartList; ;
        }

        [Then(@"in my cart I must see the book (.*)")]
        public void ThenInMyCartIMustSeeTheBook(string title)
        {
            Assert.IsTrue(Output.Any(x => x.Title == title));
        }
    }
}
