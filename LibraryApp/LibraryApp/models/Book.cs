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


        public Book(int NumberOfPages, string Author, int id, string Title) : base(id, Title)
        {
            this.NumberOfPages = NumberOfPages;
            this.Author = Author;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Autor {Author} a počet stran: {NumberOfPages}");
        }

    }

}
