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
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartBo _bo;

        public CartController(ICartBo bo)
        {
            _bo = bo;
        }
        
        [HttpPut("[action]")]
        public void AddBookToCart([FromBody]Book book)
        {
            _bo.AddBook(book);
        }

        [HttpGet("[action]")]
        public List<Book> GetListOfBooksInCart()
        {
            return _bo.GetCurrentCartList();
        }

        [HttpGet("[action]")]
        public double GetTotalPrice()
        {
            return Math.Round(_bo.GetTotalPrice(),2);
        }
    }
}
