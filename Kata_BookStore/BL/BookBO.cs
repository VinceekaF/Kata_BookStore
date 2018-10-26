using Kata_BookStore.Models;
using Kata_BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.BL
{
    public class BookBO : IBookBo
    {
        private readonly IBookRepository _repo;

        public BookBO(IBookRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }
    }
}
