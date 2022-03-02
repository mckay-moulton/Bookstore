using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bookstore.Models
{
    public class Basket
    {
        //We want the basket overall as well as the specific basket item
        //first the overall basket

        /*first part delares, second part instanciates */
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Bookstores book, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Bookstores.BookID == book.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Bookstores = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //create method to remove item
        public virtual void RemoveItem(Bookstores bookstores)
        {
            Items.RemoveAll(x => x.Bookstores.BookID == bookstores.BookID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Bookstores.Price);
            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }

        //pass in the entire object with its attributes to make it simpler to access
        public Bookstores Bookstores { get; set; }

        public int Quantity { get; set; }
    }
}