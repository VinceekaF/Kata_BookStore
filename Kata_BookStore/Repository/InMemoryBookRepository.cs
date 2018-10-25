using Kata_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Repository
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book{
                        Id = Guid.NewGuid(),
                        Title = "1. Harry Potter à l'école des sorciers",
                        Price = 8.00d
                    },
            new Book{
                        Id = Guid.NewGuid(),
                        Title = "2. Harry Potter et la chambre des secrets",
                        Price = 8.00d
                    },
            new Book{
                        Id = Guid.NewGuid(),
                        Title = "3. Harry Potter et le prisonnier d'Azkaban",
                        Price = 8.00d
                    },
            new Book{
                        Id = Guid.NewGuid(),
                        Title = "4. Harry Potter et la coupe de feu",
                        Price = 8.00d
                    },
            new Book{
                        Id = Guid.NewGuid(),
                        Title = "5. Harry Potter et le prince de sang-mêlé",
                        Price = 8.00d
                    }
        };

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
