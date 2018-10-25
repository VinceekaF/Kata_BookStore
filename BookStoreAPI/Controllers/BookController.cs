using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kata_BookStore.BL;
using Kata_BookStore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookBo _bo;

        public BookController(IBookBo bo)
        {
            _bo = bo;
        }

        [HttpGet("[action]")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bo.GetAllBooks();
        }
    }
}
