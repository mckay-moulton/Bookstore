using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Bookstores> Books { get; }

    }

}
