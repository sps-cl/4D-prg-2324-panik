using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.models
{
    internal class DVD : LibraryItem<DVD>
    {
        public string Director { get; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Director {Director}");
        }

        public DVD(string Director, string Title, string Author, int Id) : base(Title, Id)
        {
            this.Director = Director;
            this.Author = Author;
        }
    }
}
