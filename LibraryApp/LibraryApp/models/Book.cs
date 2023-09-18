using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.models
{
    internal class Book : LibraryItem<Book>
    {
        public int NumberOfPages { get; }
        public string Author { get; }

        public Book(int NumberOfPages, string Title, string Author, int Id) : base(Title, Id)
        {
            this.NumberOfPages = NumberOfPages;
            this.Author = Author;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Author {Author} number of pages {NumberOfPages}");
        }
    }
}
