using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Repository
{
    public interface ICartRepository
    {
        void AddBook(Book book);
        double TotalPrice();
    }
}
