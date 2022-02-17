using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectPerPage { get; set; }
        public int CurrentPage { get; set; }

        // create varaible that determines how many pages we should have, based on the total number of projects
        public int TotalPages => (int)Math.Ceiling((double)TotalNumProjects / ProjectPerPage);
    }
}
