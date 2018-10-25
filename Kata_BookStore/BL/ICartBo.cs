using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.BL
{
    public interface  ICartBo
    {
        double TotalPrice(List<Book> currentCart);
    }
}
