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

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;
            var x = new ProjectViewModel
            { 
                Books = repo.Books
                .OrderBy(p => p.BookID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Books.Count(),
                    ProjectPerPage = pageSize,
                    CurrentPage = pageNum
                }
        };

            return View(x);
        }

    }
}
