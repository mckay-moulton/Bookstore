using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {

        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }
        public DbSet<Bookstore> Books { get; set; }

    }
}
