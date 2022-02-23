using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class IndexModel : PageModel
    {
        //since we don't use the controller here, we are mimicking it and creating an instance
        private IBookstoreRepository repo { get; set; }

        public IndexModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public void OnGet(Basket b)
        {
             basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookID) //bringing in our project ID from our button form
        {
            Bookstores p = repo.Books.FirstOrDefault(x => x.BookID == bookID);
            //add item to our basket, in the way we defined it with our Basket parameters
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);
            
            return RedirectToPage(basket);
        }

    }
}