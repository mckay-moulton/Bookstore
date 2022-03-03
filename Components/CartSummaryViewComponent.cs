using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Bookstores books;
        public CartSummaryViewComponent(Bookstores cartService)
        {
            books = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(books);
        }
    }
}
