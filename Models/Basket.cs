using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        //We want the basket overall as well as the specific basket item
        //first the overall basket

            /*first part delares, second part instanciates */
            public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

            public void AddItem(Bookstores book, int qty)
            {
                BasketLineItem line = Items
                    .Where(p => p.Bookstore.BookID == book.BookID)
                    .FirstOrDefault();

                if (line == null)
                {
                    Items.Add(new BasketLineItem
                    {
                        Bookstore = book,
                        Quantity = qty
                    });
                }
                else
                {
                    line.Quantity += qty;
                }
            }
            public double CalculateTotal()
            {
                double sum = Items.Sum(x => x.Quantity * 25);
                return sum;
            }
        }
        public class BasketLineItem
        {
            public int LineID { get; set; }

            //pass in the entire object with its attributes to make it simpler to access
            public Bookstores Bookstore { get; set; } 
            public int Quantity { get; set; }
        }
    }
