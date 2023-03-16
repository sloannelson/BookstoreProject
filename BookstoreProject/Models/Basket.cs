﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Book Bk, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == Bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = Bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book Bk)
        {
            Items.RemoveAll(x => x.Book.BookId == Bk.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }

    }
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
