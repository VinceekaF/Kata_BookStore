using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.BL
{
    public interface  ICartBo
    {
        void AddBook(Book book);
        double TotalPrice();
        List<Book> GetCurrentCartList();
        double GetTotalPrice();
    }
}
