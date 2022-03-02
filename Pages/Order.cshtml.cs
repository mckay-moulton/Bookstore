using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class IndexModel : PageModel
    {
        //since we don't use the controller here, we are mimicking it and creating an instance
        private IBookstoreRepository repo { get; set; }

        public IndexModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(Basket b)
        {
            ReturnUrl = ReturnUrl ?? "/";
        }

        public IActionResult OnPost(int bookID, string returnUrl) //bringing in our project ID from our button form
        {
            Bookstores p = repo.Books.FirstOrDefault(x => x.BookID == bookID);
            //add item to our basket, in the way we defined it with our Basket parameters
            basket.AddItem(p, 1);
            
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        //recieve variables to collect what we are going to delete in method
        public IActionResult OnPostRemove(int bookID, string returnUrl)
        {
            var items = basket.Items;
            basket.RemoveItem(basket.Items.First(x => x.Bookstores.BookID == bookID).Bookstores);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }

    }
}