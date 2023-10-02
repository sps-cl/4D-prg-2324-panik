using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.models;
using LibraryApp.exceptions;

namespace LibraryApp
{
    internal class Library<T> where T : LibraryItem<T>
    {
        List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void ListItems()
        {
            Console.WriteLine("Knihovn� p�edm�ty: ");
            foreach (T item in items)
            {
                item.DisplayInfo();
            }
        }

        public void CheckoutItem(int id)
        {
            T itemToCheckout = items.Find(item => item.Id == id);
            if (itemToCheckout != null)
            {
                if (itemToCheckout.IsAvailable)
                {
                    itemToCheckout.IsAvailable = false;
                    Console.WriteLine($"Vyp�j�il jsem si kn�ku: {itemToCheckout.Title}");
                }
                else
                {
                    throw new NotAvilaibleException($"Polo�ka s ID {itemToCheckout.Id} nebyla nalezena");
                }
            }
            else
            {
                throw new NotFoundException($"Polo�ka s ID {itemToCheckout.Id} nebyla nalezena");
            }
        }
        public void ReturnItem(int id)
        {
            T itemToCheckout = items.Find(item => item.Id == id);
            if (itemToCheckout != null)
            {
                if (itemToCheckout.IsAvailable)
                {
                    itemToCheckout.IsAvailable = true;
                    Console.WriteLine($"Vyp�j�il jsem si kn�ku: {itemToCheckout.Title}");
                }
                else
                {
                    throw new NotAvilaibleException($"Polo�ka s ID {itemToCheckout.Id} nebyla nalezena");
                }
            }
            else
            {
                throw new NotFoundException($"Polo�ka s ID {itemToCheckout.Id} nebyla nalezena");
            }
        }
    }
}
