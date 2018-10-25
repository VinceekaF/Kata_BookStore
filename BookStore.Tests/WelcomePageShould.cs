
using System.Linq;

using Xunit;
using Kata_BookStore;
using Kata_BookStore.Repository;
using Kata_BookStore.BL;

namespace BookStore.Tests
{


    public class WelcomePageShould
    {
        private static IBookRepository _repo = new InMemoryBookRepository();
        private static IBookBo bo = new BookBO(_repo);

        [Fact]
        public void ShowTheListOfBooks()
        {
            var list = bo.GetAllBooks();

            Assert.Equal(5, list.Count());
        }

        
    }
}
