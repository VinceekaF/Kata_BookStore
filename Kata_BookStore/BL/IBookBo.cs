using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.BL
{
    public interface IBookBo
    {
        IEnumerable<Book> GetAllBooks();
    }
}
