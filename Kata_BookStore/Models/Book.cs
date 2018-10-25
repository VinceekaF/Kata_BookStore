using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
