using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {

        //new stuff here down _______________________________________________________________________________________________________________________

        //private BookstoreContext context { get; set; } this was what we had before with the bag/list
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        //create index page view, which will include some sql-like filtering
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 5;
            var x = new ProjectViewModel
            { 
                Books = repo.Books
                // allow filtering by category (off to left side of page)
                .Where(p => p.Category == category || category == null)
                .OrderBy(p => p.BookID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                // if null, return total number of books for home view
                    TotalNumProjects =
                    (category == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == category).Count()),
                        ProjectPerPage = pageSize,
                        CurrentPage = pageNum
                }
        };

            return View(x);
        }

    }
}
