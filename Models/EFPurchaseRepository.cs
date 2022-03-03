using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }
        // this is going to gather the line items (see Order.cshtml)
        // public ICollection<BasketLineItem> Lines { get; set; }
        //Then we are going to gather the associated table values from our database
        public IQueryable<Purchase> Purch => context.Purch.Include(x => x.Lines).ThenInclude(x => x.Bookstores);

        public void SavePurchase(Purchase purchase)
        {
            // from the lines, select the book associated with particualr line
            // if there isn't one (a purchase), we will add it
            context.AttachRange(purchase.Lines.Select(x => x.Bookstores));

            if(purchase.PurchaseID == 0)
            {
                context.Purch.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
