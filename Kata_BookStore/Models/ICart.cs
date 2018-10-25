using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Models
{
    public interface ICart
    {
        void AddBook(Book book);
    }
}
